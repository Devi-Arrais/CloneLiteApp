using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CloneLiteApp.Data;
using CloneLiteApp.ComandoCrud;
using CloneLiteApp.ViewModels;
using CloneLiteApp.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.NameTranslation;
using CloneLiteApp.Models;

namespace CloneLiteApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        
        var services = new ServiceCollection();

        services.AddDbContextFactory<AppDBConnect>(options =>
        {
            options.UseNpgsql(
                "Host=localhost;Port=5432;Database=cloneLite;Username=admin;Password=admin",
                o => o.MapEnum<UnidadeMedida>("unidade_medida",
                nameTranslator: new NpgsqlNullNameTranslator())
            );
        });
        

        services.AddTransient<UserCrud>();
        services.AddTransient<ProdutosCrud>();

        services.AddTransient<LoginWindowViewModel>();
        services.AddTransient<ListarProdutosViewModel>();
        services.AddTransient<CadastraProdutoViewModel>();
        services.AddTransient<MainWindowViewModel>();

        services.AddTransient<LoginWindow>();
        services.AddTransient<MainWindow>();

        var provider = services.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var loginWindow = provider.GetRequiredService<LoginWindow>();
            desktop.MainWindow = loginWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}