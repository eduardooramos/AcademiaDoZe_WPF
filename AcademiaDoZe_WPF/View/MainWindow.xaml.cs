using System.Configuration;
using System.Windows;
using System.Windows.Input;
using AcademiaDoZe_WPF.Extensions;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ConnectionString { get; set; }
        private string ProviderName { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ClassFuncoes.ValidaConexaoDB();

            ProviderName = ConfigurationManager.ConnectionStrings["DB"].ProviderName;
            ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.Loaded += Page_Loaded;
            this.PreviewKeyDown += new KeyEventHandler(ClassFuncoes.Window_KeyDown);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.AjustaResources(this);
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Home h = new Home(ProviderName, ConnectionString);
            h.Show();
            this.Close();
        }

        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.Box_GotFocus(sender, e);
        }

        private void Box_LostFocus(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.Box_LostFocus(sender, e);
        }
    }
}