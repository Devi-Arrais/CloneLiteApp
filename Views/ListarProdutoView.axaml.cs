using Avalonia.Controls;
using Avalonia.Input;
using CloneLiteApp.ViewModels;

namespace CloneLiteApp.Views;

public partial class ListarProdutosView : UserControl
{
    public ListarProdutosView()
    {
        InitializeComponent();
    }

    private void OnItemDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (DataContext is ListarProdutosViewModel vm)
        {
            // chama o comando Editar passando o item selecionado
            vm.EditarCommand.Execute(vm.ProdutoSelecionado);
        }
    }
}