using System;

namespace CloneLiteApp.Models
{
    public class FormaPagamento
    {
        public int id {get; set;}
        public string nome {get; set;} = string.Empty;
        public decimal taxa_percentual {get; set;}
        public DateTime criado_em {get; set;} = DateTime.UtcNow; 
    }
}