using System.IdentityModel.Tokens.Jwt;

namespace WebAPIs.Token
{
    public class TokenJWT
    {
        private JwtSecurityToken Token;

        public DateTime ValidTo => Token.ValidTo;

        public string Value => new JwtSecurityTokenHandler().WriteToken(Token);

        internal TokenJWT(JwtSecurityToken token)
        {
            Token = token;
        }
    }
}
