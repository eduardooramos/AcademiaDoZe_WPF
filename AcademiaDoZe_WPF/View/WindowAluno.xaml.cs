using AcademiaDoZe_WPF.Extensions;
using AcademiaDoZe_WPF.ViewModel;
using System.Windows;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Interaction logic for WindowAluno.xaml
    /// </summary>
    public partial class WindowAluno : Window
    {
        public WindowAluno()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Input.KeyEventHandler(ClassFuncoes.Window_KeyDown);
            this.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(ClassFuncoes.Window_KeyDown);
            this.Loaded += Page_Loaded;

            DataContext = new AlunoCadastroViewModel();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.AjustaResources(this);
        }
    }
}
