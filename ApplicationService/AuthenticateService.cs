using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class AuthenticateService
    {
        private AutoresRepository Repository { get; set; }

        private IConfiguration Configuration { get; set; }

        public AuthenticateService(AutoresRepository repository, IConfiguration configuration)
        {
            this.Repository = repository;
            this.Configuration = configuration;
        }

        public string AuthenticateUser(string login, string senha)
        {
            var user = this.Repository.GetUserByLogineSenha(login, senha);

            if (user == null)
                return null;



            return CreateToken(user);
        }
        public string GetID(string id)
        {
            var AutorId = id;

            if (AutorId == null)
                return null;



            return (AutorId);
        }


        public string CreateToken(Usuario usuario)
        {
            var key = Encoding.UTF8.GetBytes(this.Configuration["Token:Secret"]);

            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, usuario.Login));


            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Audience = "Autor-API",
                Issuer = "Autor-API"
            };

            var securityToken = tokenHandler.CreateToken(tokenDescription);

            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
