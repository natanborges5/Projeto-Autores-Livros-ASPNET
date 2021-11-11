using Domain;
using Repository;
using System;
using System.Collections.Generic;

namespace ApplicationService
{
    public class AutoresServices
    {
        private AutoresRepository Repository { get; set; }

        public AutoresServices(AutoresRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Autores> GetAll()
        {
            return Repository.GetAll();
        }
        public IEnumerable<Livros> GetAllLivros()
        {
            return Repository.GetAllLivros();
        }

        public Autores GetAlunoById(Guid id)
        {
            return Repository.GetAlunoById(id);
        }

        public void Save(Autores autores)
        {
            if (this.GetAlunoByEmail(autores.Email) != null)
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

        public Autores GetAlunoByEmail(string email)
        {
            return Repository.GetAlunoByEmail(email);
        }
        public Usuario GetUserByLogin(string Login)
        {
            return Repository.GetUserByLogin(Login);
        }


        public void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public void Update(Guid id, Autores autores)
        {
            Repository.Update(id, autores);
        }

    }
}
