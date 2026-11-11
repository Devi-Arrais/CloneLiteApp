using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CloneLiteApp.Data;
using CloneLiteApp.Models;
using System.Linq;

namespace CloneLiteApp.ComandoCrud
{
    public class ItemVendaCrud
    {
        private readonly IDbContextFactory<AppDBConnect> _contextFactory;

        public ItemVendaCrud(IDbContextFactory<AppDBConnect> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void InserirItem(ItemVenda itens)
        {
            using var db = _contextFactory.CreateDbContext();

            db.ItemVendas.Add(itens);
            db.SaveChanges();
        }
    
    
    }
}