using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;
using AcademiaDoZe_WPF.Extensions;

namespace AcademiaDoZe_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // aplicando polimorfismo
        // reescrita do método OnStartup
        protected override void OnStartup(StartupEventArgs e)
        {
            // registra os provedores de banco de dados
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

            // mantem o que já acontecia no método original
            base.OnStartup(e);

            // Define a cultura padrão
            ClassFuncoes.AjustaIdiomaRegiao();
        }

    }

}
