using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CloneLiteApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ProdutosViewModel _produtosVm;
    private readonly ClientesViewModel _clienteVm;


    [ObservableProperty] private ViewModelBase _currentCategoria;

    public MainWindowViewModel(
        ProdutosViewModel produtosVm,
        ClientesViewModel clienteVm)
    {

        _produtosVm = produtosVm;
        _currentCategoria = _produtosVm;   // começa em Produtos
        _clienteVm = clienteVm;
    }

    [RelayCommand] private void AbrirProdutos()
    {    
     
     _produtosVm.VoltarParaLista();
     CurrentCategoria = _produtosVm;
    
    }
    [RelayCommand] private void Cliente() 
    {
        _clienteVm.VoltarLista();
        CurrentCategoria = _clienteVm;
    }
}
