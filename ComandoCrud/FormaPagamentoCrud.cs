using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloneLiteApp.Data;
using CloneLiteApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CloneLiteApp.ComandoCrud
{
    public class FormaPagamentoCrud
    {
        private readonly IDbContextFactory<AppDBConnect> _contextFactory;

        public FormaPagamentoCrud(IDbContextFactory<AppDBConnect> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void CadastroPagamento(FormaPagamento pagamento)
        {
            using var db = _contextFactory.CreateDbContext();

            db.FormaPagamentos.Add(pagamento);
            db.SaveChanges();
        }

        public int PegarIdPagamento(string formaPagamento)
        {
            using var db = _contextFactory.CreateDbContext();

            return db.FormaPagamentos.AsNoTracking()
            .Where(f => EF.Functions.ILike(f.nome, $"{formaPagamento}"))
            .Select(f=>f.id)
            .FirstOrDefault();
        }

    }
}