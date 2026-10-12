using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CloneLiteApp.ViewModels;

    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly ListarProdutosViewModel _listarProdutosVm;
        private readonly CadastraProdutoViewModel _cadastraProdutoVm;

        [ObservableProperty]
        private ViewModelBase _currentView;

        public MainWindowViewModel(ListarProdutosViewModel listarProdutosVm, CadastraProdutoViewModel cadastraProdutoVm)
        {
            _listarProdutosVm = listarProdutosVm;
            _cadastraProdutoVm = cadastraProdutoVm;

            _currentView = listarProdutosVm;
        }

        [RelayCommand]
        public void MostrarLista() => CurrentView = _listarProdutosVm;

        [RelayCommand]
        public void MostrarCadastro() => CurrentView = _cadastraProdutoVm;
    }
