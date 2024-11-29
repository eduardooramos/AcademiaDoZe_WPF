using AcademiaDoZe_WPF.Extensions;
using AcademiaDoZe_WPF.ViewModel;
using System.Windows;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Interaction logic for WindowColaborador.xaml
    /// </summary>
    public partial class WindowColaborador : Window
    {
        public WindowColaborador()
        {
            InitializeComponent();

            this.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(ClassFuncoes.Window_KeyDown);
            this.Loaded += Page_Loaded;

            ComboBoxTipo.ItemsSource = Enum.GetValues(typeof(ColaboradorTipoEnum));
            ComboBoxVinculo.ItemsSource = Enum.GetValues(typeof(ColaboradorVinculoEnum));

            DataContext = new ColaboradorCadastroViewModel();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.AjustaResources(this);
        }
    }
}
