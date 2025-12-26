using TestePraticoDevCSharp.Repository;
using TestePraticoDevCSharp.Service;
using Microsoft.Extensions.DependencyInjection;
using TestePraticoDevCSharp.Interfaces.Repository;
using TestePraticoDevCSharp.Interfaces.Service;

namespace TestePraticoDevCSharp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ServiceCollection services = new();
            
            // Repositórios
            services.AddSingleton<IClienteRepository>(sp => new ClienteRepository()); 
            services.AddSingleton<IProdutoRepository>(sp => new ProdutoRepository()); 
            services.AddSingleton<IVendaRepository>(sp => new VendaRepository()); 
            
            // Serviços
            services.AddSingleton<IClienteService, ClienteService>(); 
            services.AddSingleton<IProdutoService, ProdutoService>(); 
            services.AddSingleton<IVendaService, VendaService>(); 
            
            // Forms (registrados também no container)
            services.AddTransient<FrmPrincipal>(); 
            services.AddTransient<FrmClienteConsulta>();
            services.AddTransient<FrmClienteCadastro>();
            services.AddTransient<FrmProdutoConsulta>();
            services.AddTransient<FrmProdutoCadastro>();
            services.AddTransient<FrmVendaConsulta>();
            services.AddTransient<FrmVendaCadastro>();
            services.AddTransient<FrmVendaRelatorio>();

            // Constrói o provider
            ServiceProvider provider = services.BuildServiceProvider();

            // Resolve o MainForm já com dependências injetadas

            FrmPrincipal frmPrincipal = provider.GetRequiredService<FrmPrincipal>(); 
            
            Application.Run(frmPrincipal);
        }
    }
}