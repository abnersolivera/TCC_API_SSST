using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Entities.Empresas;
using Entities.Entities.Pessoas;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq.Expressions;
using System.Text;
using WebAPIs.Models;
using WebAPIs.Token;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _UserManger;

        private readonly SignInManager<ApplicationUser> _SignInManager;

        private readonly IMapper _Imapper;

        private readonly IUser _IUser;

        public UsersController(UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager, IMapper iMapper, IUser iUser)
        {
            _UserManger = userManger;
            _SignInManager = signInManager;
            _Imapper = iMapper;
            _IUser = iUser;
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
                await _SignInManager.PasswordSignInAsync(login.Email, login.Senha, false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                //Recuperar Usuario Logado
                var userCurrent = await _UserManger.FindByEmailAsync(login.Email);
                var idUsuario = userCurrent.Id;

                var token = new TokenJWTBuilder().AddSecurityKey(JwtSecurityKey.Create("G4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ"))
                    .AddSubject("SSST")
                    .AddIssuer("SSST.Securiry.Bearer")
                    .AddAudience("SSST.Securiry.Bearer")
                    .AddClaim("idUsuario", idUsuario)
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
            {
                Response.StatusCode = 400;
                return BadRequest("Falta alguns dados");
            }

            var user = new ApplicationUser
            {
                Nome = login.Nome,
                UserName = login.Email,
                Email = login.Email,
                Tipo = TipoUsuario.Comum,
                StatusUsuario = true,
            };

            var resultado = await _UserManger.CreateAsync(user, login.Senha);

            if (resultado.Errors.Any())
            {
                Response.StatusCode = 400;
                return BadRequest(resultado.Errors);
            }

            //Geração de Confirmação caso precise
            var userId = await _UserManger.GetUserIdAsync(user);
            var code = await _UserManger.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // retorno email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultado2 = await _UserManger.ConfirmEmailAsync(user, code);

            if (resultado2.Succeeded)
                return Ok("Usuário Adicionado com Sucesso");
            else
            {
                Response.StatusCode = 400;
                return BadRequest("Erro ao confirmar usuários");
            }

        }

        private async Task<string> RetornaIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }

            return string.Empty;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/User/GetIdLogado")]
        public async Task<UserViewModel> GetIdLogado()
        {
            var IdLogado = RetornaIdUsuarioLogado().Result;
            var user = await _IUser.ListarUserById(IdLogado.ToString());
            var userMap = _Imapper.Map<UserViewModel>(user);
            return userMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/User/List")]
        public async Task<List<UserViewModel>> List()
        {
            var user = await _IUser.List();
            var userMap = _Imapper.Map<List<UserViewModel>>(user);
            return userMap;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPatch("/api/User/Update")]
        public async Task<IActionResult> Update([FromBody] UserImageViewModel user)
        {
            try
            {
                var IdLogado = RetornaIdUsuarioLogado().Result;

                var queryUser = await _IUser.ListarUserById(IdLogado.ToString());

                var users = new ApplicationUser
                {
                    Nome = user.Nome is not "" ? user.Nome : queryUser.Nome,
                    UserName = queryUser.Email,
                    Email = queryUser.Email,
                    Tipo = queryUser.Tipo,
                    StatusUsuario = queryUser.StatusUsuario,
                    CaminhoImagem = user.CaminhoImagem,
                    AccessFailedCount = queryUser.AccessFailedCount,
                    ConcurrencyStamp = queryUser.ConcurrencyStamp,
                    EmailConfirmed = queryUser.EmailConfirmed,
                    LockoutEnabled = queryUser.LockoutEnabled,
                    LockoutEnd = queryUser.LockoutEnd,
                    NormalizedEmail = queryUser.NormalizedEmail,
                    NormalizedUserName = queryUser.NormalizedUserName,
                    PasswordHash = queryUser.PasswordHash,
                    PhoneNumber = queryUser.PhoneNumber,                    
                    PhoneNumberConfirmed = queryUser.PhoneNumberConfirmed,
                    SecurityStamp = queryUser.SecurityStamp,
                    TwoFactorEnabled = queryUser.TwoFactorEnabled,
                    UltimoAcesso = queryUser.UltimoAcesso,
                    Id = queryUser.Id,
                };

                var pessoaMap = _Imapper.Map<ApplicationUser>(users);
                await _IUser.Update(pessoaMap);
                return Ok(pessoaMap);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return BadRequest(ex.Message);
            }

        }
    }
}
