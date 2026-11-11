using CloneLiteApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CloneLiteApp.ViewModels;

public partial class ProdutosViewModel : ViewModelBase
{
    private readonly ListarProdutosViewModel _listaVm;
    private readonly CadastraProdutoViewModel _cadastroVm;

    [ObservableProperty]
    private ViewModelBase _currentSubView;

    public ProdutosViewModel(
        ListarProdutosViewModel listaVm,
        CadastraProdutoViewModel cadastroVm)
    {
        _listaVm = listaVm;
        _cadastroVm = cadastroVm;

        _currentSubView = _listaVm;

        // 👇 escuta o pedido de edição vindo da lista
        _listaVm.EditarSolicitado += AbrirEdicao;
        _cadastroVm.CancelarSolicitado += VoltarParaLista;
    }

    [RelayCommand]
    private void MostrarLista() => CurrentSubView = _listaVm;

    [RelayCommand]
    private void MostrarCadastro()
    {
        _cadastroVm.Limpar();
        CurrentSubView = _cadastroVm;
    }

    private void AbrirEdicao(Produtos produto)
    {
        _cadastroVm.CarregarProduto(produto);
        CurrentSubView = _cadastroVm;
    }

    public void VoltarParaLista()
    {
        _listaVm.Carregar();
        CurrentSubView = _listaVm;
    }
}