using CloneLiteApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CloneLiteApp.ViewModels;

    public partial class ClientesViewModel : ViewModelBase
    {
        private readonly ListarClientesViewModel _listaVm;
        private readonly CadastroClienteViewModel _cadastroVm;

        [ObservableProperty]
        private ViewModelBase _currentSubView;

        public ClientesViewModel(
            ListarClientesViewModel listarVm,
            CadastroClienteViewModel cadastroVm)
        {
            _listaVm = listarVm;
            _cadastroVm = cadastroVm;

            _currentSubView = _listaVm;

            _cadastroVm.CancelarSolicitado += VoltarLista;
        
        }

        [RelayCommand]
        private void MostrarLista() => CurrentSubView = _listaVm;

        [RelayCommand]
        private void CadastroNovo()
        {
            _cadastroVm.Limpa();
            CurrentSubView = _cadastroVm;
        }

        public void VoltarLista()
        {
            _listaVm.Carregar();
            CurrentSubView = _listaVm;
        }
        

        
        
    }
