using System.Configuration;
using System.Windows;
using System.Windows.Input;
using AcademiaDoZe_WPF.Extensions;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Lógica interna para WindowConfig.xaml
    /// </summary>
    public partial class WindowConfig : Window
    {
        private string ConnectionString { get; set; }
        private string ProviderName { get; set; }

        public WindowConfig()
        {
            InitializeComponent();
            comboBoxIdioma.SelectedItem = ConfigurationManager.AppSettings.Get("IdiomaRegiao");

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            comboBoxProvider.SelectedItem = config.ConnectionStrings.ConnectionStrings["DB"].ProviderName;
            textBoxStringDeConexao.Text = config.ConnectionStrings.ConnectionStrings["DB"].ConnectionString;

            this.KeyDown += new KeyEventHandler(ClassFuncoes.Window_KeyDown);
        }

        public WindowConfig(string providerName, string connectionString)
        {
            InitializeComponent();

            ConnectionString = connectionString;
            ProviderName = providerName;

            comboBoxIdioma.SelectedItem = ConfigurationManager.AppSettings.Get("IdiomaRegiao");
            comboBoxProvider.SelectedItem = ProviderName;
            textBoxStringDeConexao.Text = ConnectionString;
            this.KeyDown += new KeyEventHandler(ClassFuncoes.Window_KeyDown);
        }

        private void EncerrarAplicacao_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SalvaIdioma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("IdiomaRegiao");
                config.AppSettings.Settings.Add("IdiomaRegiao", comboBoxIdioma.Text);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                ClassFuncoes.AjustaIdiomaRegiao();
                _ = MessageBox.Show("Idioma/região alterada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        private void SalvaDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["DB"].ProviderName = comboBoxProvider.Text;
                config.ConnectionStrings.ConnectionStrings["DB"].ConnectionString = textBoxStringDeConexao.Text;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
                _ = MessageBox.Show("Dados alterados com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }
    }
}
