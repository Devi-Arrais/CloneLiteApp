using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CloneLiteApp.Data;
using CloneLiteApp.Models;
using System.Linq;

namespace CloneLiteApp.ComandoCrud
{
    public class UserCrud
    {
        private readonly IDbContextFactory<AppDBConnect> _contextFactory;

        public UserCrud(IDbContextFactory<AppDBConnect> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public User Inserir(User usuario)
        {
            using var db = _contextFactory.CreateDbContext();

            db.User.Add(usuario);
            db.SaveChanges();

            return usuario;
        }

        public List<User> Buscar(string nome)
        {
            using var db = _contextFactory.CreateDbContext();
            
            return db.User
            .AsNoTracking()
            .Where(u => EF.Functions.ILike(u.Nome, $"%{nome}%"))
            .ToList();
        }

        public User? Autenticar(string nome, string senha)
        {
            using var db = _contextFactory.CreateDbContext();
            return db.User
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
        }
    }
}