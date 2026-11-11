using System;

namespace CloneLiteApp.Models
{
    public class Venda
    {
        public int id{get; set;}
        public string numero_venda {get; set;} = string.Empty;
        public DateTime data_hora_venda {get; set;} = DateTime.UtcNow;
        public int id_cliente {get; set;}
        public int id_funcionario {get; set;}
        public int id_forma_pagamento {get; set;}
        public string dado_forma_pagamento {get; set;} = string.Empty;
        public decimal desconto {get; set;}
        public decimal valor_pago {get; set;}
        public decimal troco {get; set;}
        public decimal valor_taxa {get; set;}
        
    }
}