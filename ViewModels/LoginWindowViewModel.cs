using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CloneLiteApp.ComandoCrud;

namespace CloneLiteApp.ViewModels;

public partial class LoginWindowViewModel : ViewModelBase
{
    private readonly UserCrud _useCrud;

    [ObservableProperty] private string _usuario = string.Empty;
    [ObservableProperty] private string _senha = string.Empty;
    [ObservableProperty] private string _mensagemErro = string.Empty;

    public LoginWindowViewModel(UserCrud userCrud)
    {
        _useCrud = userCrud;
    }

    [RelayCommand]
    private void Logar()
    {
        MensagemErro = string.Empty;

        if(string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Senha))
        {
            MensagemErro = "Preencher usuario e senha";
            return;
        }

        var user = _useCrud.Autenticar(Usuario,Senha);

        if(user is null)
        {
            MensagemErro = "Usuario ou Senha invalido";
            return;
        }
        MensagemErro = "Login Bem Sucedido !!";
    }
}