using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApplicationService;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using RestSharp;
using Web.ViewModel;

namespace Web.Controllers
{
    public class AutorController : Controller
    {

        private AutoresServices Services { get; set; }
        private AuthenticateService AutheServices { get; set; }
        private AutoresRepository Repository { get; set; }

        public AutorController(AutoresServices services, AutoresRepository repository, AuthenticateService autheServices)
        {
            this.Services = services;
            this.Repository = repository;
            this.AutheServices = autheServices;
        }
        public ActionResult Login(LoginViewModel model)
        {

            if (model == null)
                return RedirectToAction("Login", "Home");

            var client = new RestClient();


            var requestToken = new RestRequest("https://localhost:5001/api/Authenticate/Token");

            requestToken.AddJsonBody(JsonConvert.SerializeObject(new
            {
                login = model.Login,
                password = model.Password
            })); ;

            var tokengerado = client.Post<TokenResult>(requestToken).Data;
            if (tokengerado == null)
                return RedirectToAction("Login", "Home");


            this.HttpContext.Session.SetString("Token", tokengerado.Token);

            return RedirectToAction("Index", "Autor");

        }

        // GET: AlunoController
        public ActionResult Index()
        {
            var client = new RestClient();

            var request = new RestRequest("https://localhost:5001/api/Autor", DataFormat.Json);
            request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));


            var response = client.Get<List<Autores>>(request);

            return View(response.Data);



        }


        // GET: AlunoController/Details/5
        public ActionResult Details(Guid id)
        {
            var aluno = this.Services.GetAlunoById(id);

            return View(aluno);
        }

        // GET: AlunoController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autores aluno)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View(aluno);


                var client = new RestClient();
                var request = new RestRequest("https://localhost:5001/api/Autor", DataFormat.Json);
                request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));
                request.AddJsonBody(aluno);

                var response = client.Post<Autores>(request);

                 return RedirectToAction("Index", "Autor");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("APP_ERROR", ex.Message);
                return View(aluno);
            }
        }
        public ActionResult Edit(Guid id)
        {
            var aluno = this.Services.GetAlunoById(id);
            return View(aluno);
        }

        // POST: AlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Autores amigo)
        {
            try
            {

                this.Services.Update(id, amigo);
                return RedirectToAction("Index", "Autor");
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("APP_ERROR", ex.Message);
                return View(amigo);
            }
        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var aluno = this.Services.GetAlunoById(id);

            return View(aluno);
        }

        // POST: AlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Autores aluno)
        {
            try
            {
                this.Services.Delete(id);
                return RedirectToAction("Index", "Autor");
            }
            catch
            {
                return View();
            }
        }
        public class TokenResult
        {
            public String Token { get; set; }
        }
    }
}
