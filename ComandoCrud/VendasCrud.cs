using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CloneLiteApp.Data;
using CloneLiteApp.Models;
using System.Linq;

namespace CloneLiteApp.ComandoCrud
{
    public class VendasCrud
    {
        private readonly IDbContextFactory<AppDBConnect> _contextFactory;

        public VendasCrud(IDbContextFactory<AppDBConnect> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public int Vender(Venda venda)
        {
            using var db = _contextFactory.CreateDbContext();
            
            db.Vendas.Add(venda);
            db.SaveChanges();

            return venda.id;
        }

       
    }
}