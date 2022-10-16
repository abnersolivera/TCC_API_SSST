using Entities.Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebAPIs.Models;
using WebAPIs.Token;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManger;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager)
        {
            _userManger = userManger;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CriarTokenIdentity")]
        public async Task<IActionResult> CriarTokenIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
            {
                return Unauthorized();
            }

            var resultado =
                await _signInManager.PasswordSignInAsync(login.Email, login.Senha, false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                //Recuperar Usuario Logado
                var userCurrent = await _userManger.FindByEmailAsync(login.Email);
                var IdUser = userCurrent.Id;

                var token = new TokenJWTBuilder().AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                    .AddSubject("Empresa")
                    .AddIssuer("Teste.Securiry.Bearer")
                    .AddAudience("Teste.Securiry.Bearer")
                    .AddClaim("idUsuario", IdUser)
                    .AddExpiry(5)
                    .Builder();

                return Ok(token.Value);
            }
            else
            {
                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionaUsuarioIdentity")]
        public async Task<IActionResult> AdicionaUsuarioIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
                return Ok("Falta alguns dados");

            var user = new ApplicationUser
            {
                UserName = login.Email,
                Email = login.Email,
                Tipo = TipoUsuario.Comum,
            };

            var resultado = await _userManger.CreateAsync(user, login.Senha);

            if (resultado.Errors.Any())
            {
                return Ok(resultado.Errors);
            }

            //Geração de Confirmação caso precise
            var userId = await _userManger.GetUserIdAsync(user);
            var code = await _userManger.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // retorno email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultado2 = await _userManger.ConfirmEmailAsync(user, code);

            if (resultado2.Succeeded)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return Ok("Erro ao confirmar usuários");

        }
    }
}
