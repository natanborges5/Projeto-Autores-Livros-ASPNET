using Domain;
using Repository;
using System;
using System.Collections.Generic;

namespace ApplicationService
{
    public class LivrosServices
    {
        private LivrosRepository Repository { get; set; }

        public LivrosServices(LivrosRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Livros> GetAll()
        {
            return Repository.GetAll();
        }

        public Livros GetAlunoById(Guid id)
        {
            return Repository.GetAlunoById(id);
        }

        public void Save(Livros autores)
        {
            if (this.GetAlunoByEmail(autores.titulo) != null)
            {
                throw new Exception("Já existe um autor com este email, por favor cadastre outro email");
            }

            this.Repository.Save(autores);
        }
        public void SaveUser(Usuario users)
        {
            if (this.GetAlunoByEmail(users.Login) != null)
            {
                throw new Exception("Já existe um Usuario com este login, por favor cadastre outro login");
            }

            this.Repository.SaveUser(users);
        }

        public Livros GetAlunoByEmail(string titulo)
        {
            return Repository.GetLivroByName(titulo);
        }
        public Usuario GetUserByLogin(string Login)
        {
            return Repository.GetUserByLogin(Login);
        }


        public void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public void Update(Guid id, Livros autores)
        {
            Repository.Update(id, autores);
        }

    }
}
