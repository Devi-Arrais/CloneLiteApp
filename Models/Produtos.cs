namespace CloneLiteApp.Models
{
    public class Produtos
    {
        public int id {get; set;}
        public string descricao {get; set;} = string.Empty;
        public UnidadeMedida unidade_medida{get; set;}
        public string? codigo_barras{get; set;}
        public string? referencia{get;set;}
        public decimal quantidade{get; set;}
        public decimal preco_venda{get; set;}
        public decimal custo_compra{get; set;}

        public override string ToString()
        => $"Id: {id,-4} | Descrição: {descricao,-30} | Unidade: {unidade_medida, -4} |" +
           $"Codigo de Barra {codigo_barras, -7}" + $"Ref: {referencia,-15} | Qtd: {quantidade,-8} | " +
           $"Venda: {preco_venda,10:C} | Custo: {custo_compra,10:C}";
    }
}