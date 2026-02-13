using System.IdentityModel.Tokens.Jwt;

namespace WebAPIs.Token
{
    public class TokenJwt
    {
        private readonly JwtSecurityToken _token;

        public DateTime ValidTo => _token.ValidTo;

        public string Value => new JwtSecurityTokenHandler().WriteToken(_token);

        internal TokenJwt(JwtSecurityToken token)
        {
            _token = token;
        }
    }
}
