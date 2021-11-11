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
    public class AutoresRepository
    {
        private InfnetContext Context { get; set; }

        public AutoresRepository(InfnetContext context)
        {
            this.Context = context;
        }

        public IEnumerable<Autores> GetAll()
        {
            return Context.Autores.AsEnumerable();

        }
        public IEnumerable<Livros> GetAllLivros()
        {
            return Context.Livros.AsEnumerable();

        }

        public Autores GetAlunoById(Guid id)
        {
            return Context.Autores.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Autores autores)
        {
            this.Context.Autores.Add(autores);
            this.Context.SaveChanges();
        }
        public void SaveUser(Usuario users)
        {
            this.Context.Usuario.Add(users);
            this.Context.SaveChanges();
        }
        public Autores GetAlunoByEmail(string email)
        {
            return Context.Autores.FirstOrDefault(x => x.Email == email);
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
            var aluno = Context.Autores.FirstOrDefault(x => x.Id == id);
            this.Context.Autores.Remove(aluno);
            this.Context.SaveChanges();
        }

        public void Update(Guid id, Autores autores)
        {
            var amigoOld = Context.Autores.FirstOrDefault(x => x.Id == id);

            amigoOld.nome = autores.nome;
            amigoOld.sobrenome = autores.sobrenome;
            amigoOld.Email = autores.Email;          
            amigoOld.dataAniversario = autores.dataAniversario;

            Context.Autores.Update(amigoOld);
            this.Context.SaveChanges();
        }
    }
}
