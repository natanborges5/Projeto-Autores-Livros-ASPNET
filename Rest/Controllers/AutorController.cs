using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Context;
using Rest.Controllers.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class AutorController : ControllerBase
    {
        private AutoresServices Services { get; set; }
        private readonly InfnetContext _context;
        private readonly IMapper _mapper;

        public AutorController(AutoresServices services, InfnetContext context, IMapper mapper)
        {
            _context = context;
            this.Services = services;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Autores> Get()
        {
            return Services.GetAll();
        }
        [HttpGet("Livros")]
        public IEnumerable<Livros> GetLivros()
        {
            return Services.GetAllLivros();
        }

        [HttpGet("{id}")]
        public Autores Get(Guid id)
        {
            return Services.GetAlunoById(id);
        }

        [HttpPost]
        public void Post([FromBody] Autores model)
        {
            try
            {
                this.Services.Save(model);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.Services.Delete(id);
        }
   
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Autores model)
        {
            this.Services.Update(id, model);
        }
        [HttpGet("{id}/livros")]
        public ActionResult GetLivrosDoAutor([FromRoute] Guid id)
        {

            var pais = _context.Autores.Find(id);
            if (pais == null)
                return NotFound();

            var estados = _context.Livros.Where(x => x.autorId == id).ToList();
            var response = _mapper.Map<List<LivrosResponse>>(estados);

            return Ok(response);


        }
        [HttpPost("{id}/livros")]
        public ActionResult PostLivrosDoAutor([FromRoute] Guid id, [FromBody] LivrosRequest request)
        {
            var pais = _context.Autores.Find(id);

            if (pais == null)
                return NotFound(); //404

            var response = CriarLivro(id, request);

            return CreatedAtAction(nameof(PostLivrosDoAutor), new { response.Id }, response); //201
        }



        private LivrosResponse CriarLivro(Guid id, LivrosRequest request)
        {
            var estado = _mapper.Map<Livros>(request);
            estado.autorId = id;


            _context.Livros.Add(estado);
            _context.SaveChanges();

            var response = _mapper.Map<LivrosResponse>(estado);

            return response;
        }
    }
}
