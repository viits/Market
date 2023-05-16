using Domain.DTOS.Request;
using Domain.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService
    {
        public Token CreateTokenMercado(LogaTokenRequestDTO dto)
        {
            Claim[] mercadoClaim = new Claim[]
            {
                new Claim("username",dto.Nome),
                new Claim("id",dto.Id.ToString())
            };
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn"));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(claims: mercadoClaim, signingCredentials:credenciais, expires: DateTime.UtcNow.AddHours(1));
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }

        public Token GeraToken(int id)
        {
            var securityToken = new JwtSecurityTokenHandler();
            var token = securityToken.CreateToken(new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn" + id)), SecurityAlgorithms.HmacSha256)
            });
            return new Token(securityToken.WriteToken(token));
        }

        public bool verificaToken(AtivarContaDTO dto)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(dto.Token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn" + dto.Id)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out _);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
