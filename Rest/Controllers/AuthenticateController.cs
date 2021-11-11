using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.ViewModel;

namespace Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private AuthenticateService AuthenticateService { get; set; }
        private AutoresServices Services { get; set; }

        public AuthenticateController(AuthenticateService service, AutoresServices Autorservices)
        {
            this.AuthenticateService = service;
            this.Services = Autorservices;
        }
        [HttpPost]
        public void Post([FromBody] Usuario user)
        {
            try
            {
                this.Services.SaveUser(user);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        
        [Route("Token")]
        [HttpPost]
        [RequireHttps]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return await Task.FromResult(BadRequest(ModelState));

            var token = this.AuthenticateService.AuthenticateUser(loginRequest.Login, loginRequest.Password);

            if (String.IsNullOrWhiteSpace(token))
            {
                return await Task.FromResult(BadRequest("Login ou senha Inválidos"));
            }

            return Ok(new
            {
                Token = token
            });

        }
        [Route("GetId")]
        [HttpPost]
        [RequireHttps]
        public async Task<IActionResult> GetId([FromBody] IdRequest idRequest)
        {

            var token = this.AuthenticateService.GetID(idRequest.Id);

            if (String.IsNullOrWhiteSpace(token))
            {
                return await Task.FromResult(BadRequest("Login ou senha Inválidos"));
            }

            return Ok(new
            {
                autorId = token
            });

        }



    }
}
