using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebAPIs.Token
{
    public class TokenJwtBuilder
    {
        private SecurityKey? _securityKey;
        private string _subject = "";
        private string _issuer = "";
        private string _audience = "";
        private readonly Dictionary<string, string> _claims = new();
        private int _expiryInDays = 5;

        public TokenJwtBuilder AddSecurityKey(SecurityKey securityKey)
        {
            _securityKey = securityKey;
            return this;
        }

        public TokenJwtBuilder AddSubject(string subject)
        {
            _subject = subject;
            return this;
        }

        public TokenJwtBuilder AddIssuer(string issuer)
        {
            _issuer = issuer;
            return this;
        }

        public TokenJwtBuilder AddAudience(string audience)
        {
            _audience = audience;
            return this;
        }

        public TokenJwtBuilder AddClaim(string type, string value)
        {
            _claims.Add(type, value);
            return this;
        }

        public TokenJwtBuilder AddExpiry(int expiryInDays)
        {
            _expiryInDays = expiryInDays;
            return this;
        }

        private void EnsureArguments()
        {
            if (_securityKey == null)
                throw new ArgumentNullException("Security Key");

            if (string.IsNullOrEmpty(_subject))
                throw new ArgumentNullException("Subject");

            if (string.IsNullOrEmpty(_issuer))
                throw new ArgumentNullException("Issuer");

            if (string.IsNullOrEmpty(_audience))
                throw new ArgumentNullException("Audience");
        }

        public TokenJwt Builder()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, _subject),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(this._claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_expiryInDays),
                signingCredentials: new SigningCredentials(
                    _securityKey,
                    SecurityAlgorithms.HmacSha256)
                );

            return new TokenJwt(token);
        }
    }
}
