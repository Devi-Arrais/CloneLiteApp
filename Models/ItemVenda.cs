
namespace CloneLiteApp.Models
{
    public class ItemVenda
    {
        public int id {get; set;}
        public int id_venda {get; set;}
        public int id_produto {get; set;}
        public decimal quantidade {get; set;}
        public decimal valor_unitario {get; set;}
        public decimal total_item {get; set;}

    }
}