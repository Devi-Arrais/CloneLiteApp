using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CloneLiteApp.Data;
using CloneLiteApp.Models;
using System.Linq;

namespace CloneLiteApp.ComandoCrud
{
    public class ClienteCrud
    {
        private readonly IDbContextFactory<AppDBConnect> _contextFactory;

        public ClienteCrud(IDbContextFactory<AppDBConnect> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void NovoCliente(Cliente cliente)
        {
            using var db = _contextFactory.CreateDbContext();

            db.Cliente.Add(cliente);
            db.SaveChanges();
        }

        public int BuscaNome(string nome)
        {
            using var db = _contextFactory.CreateDbContext();

            return db.Cliente
                    .AsNoTracking()
                    .Where(n => EF.Functions.ILike(n.nome, $"%{nome}%"))
                    .Select(n=>n.id)
                    .FirstOrDefault();
        }

        public List<Cliente> BuscarCliente(string nome)
        {
            using var db = _contextFactory.CreateDbContext();

            return db.Cliente
                .AsNoTracking()
                .Where(n => EF.Functions.ILike(n.nome, $"{nome}"))
                .ToList();
        }
        
        public List<Cliente> ListarClientes()
        {
            using var db = _contextFactory.CreateDbContext();

            return db.Cliente
                    .AsNoTracking()
                    .OrderBy(c => c.id)
                    .ToList();
        }
    }
}