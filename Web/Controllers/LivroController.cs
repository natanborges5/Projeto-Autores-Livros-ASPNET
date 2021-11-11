using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository;
using RestSharp;

namespace Web.Controllers
{
    public class LivroController : Controller
    {

            private LivrosServices Services { get; set; }
            private AuthenticateService AutheServices { get; set; }
            private LivrosRepository Repository { get; set; }

            public LivroController(LivrosServices services, LivrosRepository repository, AuthenticateService autheServices)
            {
                this.Services = services;
                this.Repository = repository;
                this.AutheServices = autheServices;
            }

            // GET: AlunoController
            public ActionResult Index(string id)
            {
                var client = new RestClient();

                var requestId = new RestRequest("https://localhost:5001/api/Authenticate/GetId");

                requestId.AddJsonBody(JsonConvert.SerializeObject(new
                {
                    Id = id,
  
                })); ;

                var idgerado = client.Post<AutorId>(requestId).Data;
                this.HttpContext.Session.SetString("autorId", idgerado.autorId);

                ////////////////////////////////////////////////////////////////

                var request = new RestRequest($"https://localhost:5001/api/autor/{id}/livros", DataFormat.Json);
                request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));


                var response = client.Get<List<Livros>>(request);

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
            public ActionResult Create(Livros aluno)
            {
                try
                {
                    if (ModelState.IsValid == false)
                        return View(aluno);
                    var id = this.HttpContext.Session.GetString("autorId");


                    var client = new RestClient();
                    var request = new RestRequest($"https://localhost:5001/api/autor/{id}/livros", DataFormat.Json);
                    request.AddHeader("Authorization", "Bearer " + this.HttpContext.Session.GetString("Token"));
                    request.AddJsonBody(aluno);

                    var response = client.Post<Livros>(request);

                    return RedirectToAction("Index","Autor");
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
            public ActionResult Edit(Guid id, Livros amigo)
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
            public ActionResult Delete(Guid id, Livros aluno)
            {
                try
                {
                    this.Services.Delete(id);
                    return RedirectToAction("Index","Autor");
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
            public class AutorId
            {
                public String autorId { get; set; }
            }

    }
}
