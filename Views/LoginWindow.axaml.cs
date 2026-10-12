using Avalonia.Controls;
using CloneLiteApp.ViewModels;

namespace CloneLiteApp.Views;

public partial class LoginWindow : Window
{
    // O ViewModel é injetado pelo contêiner
    public LoginWindow(LoginWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}