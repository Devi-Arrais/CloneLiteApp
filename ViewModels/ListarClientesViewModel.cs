using System;
using System.Collections.ObjectModel;
using CloneLiteApp.Models;
using CloneLiteApp.ComandoCrud;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;

namespace CloneLiteApp.ViewModels;

public partial class ListarClientesViewModel : ViewModelBase
{
    private readonly ClienteCrud _clienteCrud;

    public ObservableCollection<Cliente> ListarCliente{get;} = new();

    public ListarClientesViewModel(ClienteCrud clienteCrud)
    {
        _clienteCrud = clienteCrud;
        Carregar();
    }

    [RelayCommand]
    public void Carregar()
    {
        ListarCliente.Clear();
        foreach(var c in _clienteCrud.ListarClientes())
            ListarCliente.Add(c);
    }
}
