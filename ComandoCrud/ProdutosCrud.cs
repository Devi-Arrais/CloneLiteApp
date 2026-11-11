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

        public bool Atualizar(Produtos produto)
        {
            using var db = _contextFactory.CreateDbContext();
            var existente = db.Produtos.FirstOrDefault(p => p.id == produto.id);
            if (existente is null) return false;

            existente.descricao = produto.descricao;
            existente.unidade_medida = produto.unidade_medida;
            existente.codigo_barras = produto.codigo_barras;
            existente.referencia = produto.referencia;
            existente.quantidade = produto.quantidade;
            existente.preco_venda = produto.preco_venda;
            existente.custo_compra = produto.custo_compra;

            db.SaveChanges();
            return true;
        }
    }
}