using CloneLiteApp.Models;
using CloneLiteApp.ComandoCrud;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmds.DBus.Protocol;

namespace CloneLiteApp.ViewModels;

public partial class CadastraProdutoViewModel : ViewModelBase
{
    public event Action? CancelarSolicitado;
    private readonly ProdutosCrud _produtosCrud;
    private Produtos? _produtoEditando;   // null = novo; não-null = edição

    [ObservableProperty] private string _descricao = string.Empty;
    [ObservableProperty] private UnidadeMedida _unidadeSelecionada = UnidadeMedida.UN;
    [ObservableProperty] private string _codigoBarras = string.Empty;
    [ObservableProperty] private string _referencia = string.Empty;
    [ObservableProperty] private decimal _quantidade;
    [ObservableProperty] private decimal _precoVenda;
    [ObservableProperty] private decimal _custoCompra;
    [ObservableProperty] private string _mensagem = string.Empty;
    [ObservableProperty] private bool _modoEdicao;   // para a View mostrar "Salvar alterações"
    public UnidadeMedida[] Unidades => UnidadeMedida.GetValues<UnidadeMedida>();

    public CadastraProdutoViewModel(ProdutosCrud produtosCrud)
    {
        _produtosCrud = produtosCrud;
    }
    public void CarregarProduto(Produtos produto)
    {
        _produtoEditando = produto;
        ModoEdicao = true;

        Descricao = produto.descricao;
        UnidadeSelecionada = produto.unidade_medida;
        CodigoBarras = produto.codigo_barras ?? string.Empty;
        Referencia = produto.referencia ?? string.Empty;
        Quantidade = produto.quantidade;
        PrecoVenda = produto.preco_venda;
        CustoCompra = produto.custo_compra;
        Mensagem = string.Empty;
    }

    [RelayCommand]
    private void Salvar()
    {
        Mensagem = string.Empty;

        if (string.IsNullOrWhiteSpace(Descricao))
        {
            Mensagem = "Descrição é obrigatória.";
            return;
        }

        try
        {
            if (_produtoEditando is null)
            {
                var novo = new Produtos
                {
                    descricao = Descricao,
                    unidade_medida = UnidadeSelecionada,
                    codigo_barras = string.IsNullOrWhiteSpace(CodigoBarras) ? null : CodigoBarras,
                    referencia = string.IsNullOrWhiteSpace(Referencia) ? null : Referencia,
                    quantidade = Quantidade,
                    preco_venda = PrecoVenda,
                    custo_compra = CustoCompra
                };

                _produtosCrud.NovoProduto(novo);
                Mensagem = $"Produto cadastrado! Id = {novo.id}";
                Cancelar();
            }
            else
            {
                _produtoEditando.descricao = Descricao;
                _produtoEditando.unidade_medida = UnidadeSelecionada;
                _produtoEditando.codigo_barras = string.IsNullOrWhiteSpace(CodigoBarras) ? null : CodigoBarras;
                _produtoEditando.referencia = string.IsNullOrWhiteSpace(Referencia) ? null : Referencia;
                _produtoEditando.quantidade = Quantidade;
                _produtoEditando.preco_venda = PrecoVenda;
                _produtoEditando.custo_compra = CustoCompra;

                _produtosCrud.Atualizar(_produtoEditando);
                Mensagem = "Produto atualizado com sucesso!";
            }
        }
        catch (Exception ex)
        {
            Mensagem = $"Erro: {ex.Message}";
        }
    }

    [RelayCommand]
    public void Cancelar()
    {
        CancelarSolicitado?.Invoke();
    }

    public void Limpar()
    {
        Descricao = string.Empty;
        UnidadeSelecionada = UnidadeMedida.UN;
        CodigoBarras = string.Empty;
        Referencia = string.Empty;
        Quantidade = 0;
        PrecoVenda = 0;
        CustoCompra = 0;
        Mensagem = string.Empty;

    }
}