using System.Collections.ObjectModel;
using System.Collections.Generic;
using CloneLiteApp.Models;
using CloneLiteApp.ComandoCrud;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;

namespace CloneLiteApp.ViewModels;

    public partial class ListarProdutosViewModel : ViewModelBase
    {
        private readonly ProdutosCrud _produtoscrud;

        public ListarProdutosViewModel(ProdutosCrud produtosCrud)
        {
           _produtoscrud = produtosCrud;
            Carregar();
        }
        public ObservableCollection<Produtos> Produtos { get; } = new();
        [RelayCommand]
        private void Carregar()
        {
            Produtos.Clear();
            var listar = _produtoscrud.Listar_Produtos();
            foreach(var p in listar)
                Produtos.Add(p);
        
        }
    }
