using Dapper;
using Domain;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class LivrosRepository
    {
        private InfnetContext Context { get; set; }

        public LivrosRepository(InfnetContext context)
        {
            this.Context = context;
        }

        public IEnumerable<Livros> GetAll()
        {
            return Context.Livros.AsEnumerable();

        }

        public Livros GetAlunoById(Guid id)
        {
            return Context.Livros.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Livros autores)
        {
            this.Context.Livros.Add(autores);
            this.Context.SaveChanges();
        }
        public void SaveUser(Usuario users)
        {
            this.Context.Usuario.Add(users);
            this.Context.SaveChanges();
        }
        public Livros GetLivroByName(string titulo)
        {
            return Context.Livros.FirstOrDefault(x => x.titulo == titulo);
        }
        public Usuario GetUserByLogin(string login)
        {
            return Context.Usuario.FirstOrDefault(x => x.Login == login);
        }
        public Usuario GetUserByLogineSenha(string login, string senha)
        {
            return Context.Usuario.FirstOrDefault(x => x.Login == login && x.Password == senha);
        }

        public void Delete(Guid id)
        {
            var aluno = Context.Livros.FirstOrDefault(x => x.Id == id);
            this.Context.Livros.Remove(aluno);
            this.Context.SaveChanges();
        }

        public void Update(Guid id, Livros autores)
        {
            var amigoOld = Context.Livros.FirstOrDefault(x => x.Id == id);

            amigoOld.titulo = autores.titulo;
            amigoOld.isbn = autores.isbn;
            amigoOld.ano = autores.ano;          

            Context.Livros.Update(amigoOld);
            this.Context.SaveChanges();
        }
    }
}
