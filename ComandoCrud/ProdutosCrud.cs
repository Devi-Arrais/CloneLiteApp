using Microsoft.EntityFrameworkCore;
using CloneLiteApp.Data;
using CloneLiteApp.Models;
using System.Linq;
using System.Collections.Generic;
//using System.Data.Entity;

namespace CloneLiteApp.ComandoCrud
{
    public class ProdutosCrud
    {
        private readonly IDbContextFactory<AppDBConnect> _contextFactory;

        public ProdutosCrud(IDbContextFactory<AppDBConnect> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public Produtos NovoProduto(Produtos Produto)
        {
            using var db = _contextFactory.CreateDbContext();

            db.Produtos.Add(Produto);
            db.SaveChanges();
            
            return Produto;
        }

        public List<Produtos> BuscarItem(string nome)
        {
            using var db = _contextFactory.CreateDbContext();

            return db.Produtos
            .AsNoTracking()
            .Where(p => EF.Functions.ILike(p.descricao, $"%{nome}%"))
            .ToList();
        }

        public List<Produtos> Listar_Produtos()
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Produtos
                    .AsNoTracking()
                    .OrderBy(p => p.id)
                    .ToList();
        }
    }
}