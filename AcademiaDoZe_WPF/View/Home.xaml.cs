using System.Globalization;
using System.Windows;
using System.Windows.Input;
using AcademiaDoZe_WPF.Extensions;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Lógica interna para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private string ConnectionString { get; set; }
        private string ProviderName { get; set; }

        public Home(string providerName, string connectionString)
        {
            ConnectionString = connectionString;
            ProviderName = providerName;

            InitializeComponent();

            this.Loaded += Page_Loaded;
            this.PreviewKeyDown += new KeyEventHandler(ClassFuncoes.Window_KeyDown);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.AjustaResources(this);
        }

        private void LOGOUT_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Logradourobtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.Content is not PageListaLogradouro)
                mainFrame.Content = new PageListaLogradouro();
        }

        private void AlunoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.Content is not PageListaAluno)
                mainFrame.Content = new PageListaAluno();
        }

        private void ColaboradorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.Content is not PageListaColaborador)
                mainFrame.Content = new PageListaColaborador();
        }

        private void SenhaBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowSenha windowSenha = new();
            windowSenha.ShowDialog();
        }

        private void Matriculabtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.Content is not PageListaMatricula)
                mainFrame.Navigate(new PageListaMatricula());
        }

        private void AvaliacaoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.Content is not PageAvaliacao)
                mainFrame.Content = new PageAvaliacao();
        }

        private void FrequenciaBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new FrequenciaPag());
        }

        /// <summary>
        /// Altera o idioma da interface do usuário.
        /// </summary>
        /// <param name="cultureCode">Código da cultura (ex: en-US, es-ES, pt-BR)</param>
        private void ChangeLanguage(string cultureCode)
        {
            // en-US, es-ES, pt-BR
            // Definir a cultura
            CultureInfo culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            // Recargar a interface do usuário para refletir as mudanças
            var oldWindow = this;
            var newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            oldWindow.Close();
        }

        private void txtConfig_Click(object sender, RoutedEventArgs e)
        {
            WindowConfig windowConfig = new();
            windowConfig.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            windowConfig.ShowDialog();
            // Recarregar a interface do usuário para refletir as mudanças
            var newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            Close();
        }
    }
}
