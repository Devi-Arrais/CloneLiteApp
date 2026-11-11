using CloneLiteApp.Models;
using CloneLiteApp.ComandoCrud;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.CodeDom;
using System;

namespace CloneLiteApp.ViewModels;

public partial class CadastroClienteViewModel : ViewModelBase
{
    public event Action? CancelarSolicitado;
    private readonly ClienteCrud _clienteCrud;


    [ObservableProperty] private string _nome = string.Empty;
    [ObservableProperty] private string _cpf =string.Empty;
    [ObservableProperty] private DateTimeOffset? _dataNascimento;
    [ObservableProperty] private string _email = string.Empty;
    [ObservableProperty] private string _celular =string.Empty;
    [ObservableProperty] private string _cep =string.Empty;
    [ObservableProperty] private string _rua =string.Empty;
    [ObservableProperty] private string _numeroCasa =string.Empty;
    [ObservableProperty] private string _complemento =string.Empty;
    [ObservableProperty] private string _bairro =string.Empty;
    [ObservableProperty] private string _cidade =string.Empty;
    [ObservableProperty] private string _uf =string.Empty;
    [ObservableProperty] private string _observacao =string.Empty;
    [ObservableProperty] private string _mensagem =string.Empty;

    public CadastroClienteViewModel(ClienteCrud clienteCrud)
    {
        _clienteCrud = clienteCrud;
    }

    [RelayCommand]
    public void Salvar()
    {
        Mensagem = string.Empty;

        if(string.IsNullOrWhiteSpace(Nome))
        {
            Mensagem = "Nome e Obrigatorio";
            return;
        }

        var cliente = new Cliente
        {
            nome = Nome.Trim(),
            cpf = string.IsNullOrWhiteSpace(Cpf)? null : Cpf.Trim(),
            data_nascimento = DataNascimento.HasValue
    ? DateTime.SpecifyKind(DataNascimento.Value.Date, DateTimeKind.Utc)
    : null,
            email = string.IsNullOrWhiteSpace(Email)? null : Email.Trim(),
            celular         = string.IsNullOrWhiteSpace(Celular) ? null : Celular.Trim(),
            cep             = string.IsNullOrWhiteSpace(Cep) ? null : Cep.Trim(),
            rua             = string.IsNullOrWhiteSpace(Rua) ? null : Rua.Trim(),
            numero_casa     = string.IsNullOrWhiteSpace(NumeroCasa) ? null : NumeroCasa.Trim(),
            complemento     = string.IsNullOrWhiteSpace(Complemento) ? null : Complemento.Trim(),
            bairro          = string.IsNullOrWhiteSpace(Bairro) ? null : Bairro.Trim(),
            cidade          = string.IsNullOrWhiteSpace(Cidade) ? null : Cidade.Trim(),
            uf              = string.IsNullOrWhiteSpace(Uf) ? null : Uf.Trim().ToUpper(),
            observacoes     = string.IsNullOrWhiteSpace(Observacao) ? null : Observacao.Trim(),


        };

        try
        {
            _clienteCrud.NovoCliente(cliente);
            Mensagem = "Cliente cadastrado";
            Limpa();

        }
        catch(Exception e)
        {
            Console.WriteLine($"Erro ao cadastrar{e}");
        }
    }
    
    [RelayCommand]
    public void Cancelar()
    {
        CancelarSolicitado?.Invoke();
    }


    public void Limpa()
    {
        Nome = string.Empty;
        Cpf = string.Empty;
        DataNascimento = null;
        Email = string.Empty;
        Celular = string.Empty;
        Cep = string.Empty;
        Rua = string.Empty;
        NumeroCasa = string.Empty;
        Complemento = string.Empty;
        Bairro = string.Empty;
        Cidade = string.Empty;
        Uf = string.Empty;
        Observacao = string.Empty;
    }
}
    
