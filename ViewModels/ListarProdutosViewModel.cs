using System;
using System.Collections.ObjectModel;
using CloneLiteApp.Models;
using CloneLiteApp.ComandoCrud;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CloneLiteApp.ViewModels;

public partial class ListarProdutosViewModel : ViewModelBase
{
    private readonly ProdutosCrud _produtosCrud;

    // 👇 evento que a categoria escuta para abrir a edição
    public event Action<Produtos>? EditarSolicitado;

    [ObservableProperty] private Produtos? _produtoSelecionado;

    public ObservableCollection<Produtos> ListaProdutos { get; } = new();

    public ListarProdutosViewModel(ProdutosCrud produtosCrud)
    {
        _produtosCrud = produtosCrud;
        Carregar();
    }

    [RelayCommand]
    public void Carregar()
    {
        ListaProdutos.Clear();
        foreach (var p in _produtosCrud.Listar_Produtos())
            ListaProdutos.Add(p);
    }

    // 👇 chamado pelo duplo clique (via code-behind da View)
    [RelayCommand]
    public void Editar(Produtos? produto)
    {
        if (produto is null) return;
        EditarSolicitado?.Invoke(produto);
    }
}