using CloneLiteApp.Models;
using CloneLiteApp.ComandoCrud;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.CodeDom;

namespace CloneLiteApp.ViewModels;

public partial class CadastraProdutoViewModel : ViewModelBase
{
    private readonly ProdutosCrud _produtosCrud;

    [ObservableProperty] private string _descricao = string.Empty;
    [ObservableProperty] private UnidadeMedida _unidadeSelecionada = UnidadeMedida.UN;
    [ObservableProperty] private string _codigoBarras = string.Empty;
    [ObservableProperty] private string _referencia = string.Empty;
    [ObservableProperty] private decimal _quantidade;
    [ObservableProperty] private decimal _precoVenda;
    [ObservableProperty] private decimal _precoCompra;
    [ObservableProperty] private string _mensagem = string.Empty;

    public UnidadeMedida[] unidade => System.Enum.GetValues<UnidadeMedida>();

    public CadastraProdutoViewModel(ProdutosCrud produtosCrud)
    {
        _produtosCrud = produtosCrud;
    }

    [RelayCommand]
    public void Salvar()
    {
        Mensagem = string.Empty;

        if(string.IsNullOrWhiteSpace(Descricao))
        {
            Mensagem = "Descrição e obrigatoria!";
            return;
        }

        var Produto = new Produtos
        {
          descricao = Descricao,
          unidade_medida = UnidadeSelecionada,
          codigo_barras = string.IsNullOrWhiteSpace(CodigoBarras) ? null : CodigoBarras,
          referencia = string.IsNullOrWhiteSpace(Referencia) ? null : Referencia,
          quantidade = Quantidade,
          preco_venda = PrecoVenda,
          custo_compra = PrecoCompra  
        };

        try
        {
            _produtosCrud.NovoProduto(Produto);
            Mensagem = $"Produto salvo com sucesso Id = {Produto.id}";
            Limpa();
        }
        catch(System.Exception e)
        {
            Mensagem = $"Erro = {e}";
        }

    }

    [RelayCommand]
    public void Limpa()
    {
        Descricao = string.Empty;
        UnidadeSelecionada = UnidadeMedida.UN;
        CodigoBarras = string.Empty;
        Referencia = string.Empty;
        Quantidade = 0;
        PrecoVenda = 0;
        PrecoCompra = 0;
    }
}