using System;
using Avalonia.Controls;
using CloneLiteApp.ViewModels;
using CloneLiteApp.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CloneLiteApp.Views;

public partial class LoginWindow : Window
{
    private readonly IServiceProvider _serviceProvider;

    public LoginWindow(LoginWindowViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = viewModel;
        _serviceProvider = serviceProvider;

        viewModel.LoginSucesso += AbrirMainWindow;
    }

    private void AbrirMainWindow()
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>();
        mainWindow.Show();
        Close();
    }
}