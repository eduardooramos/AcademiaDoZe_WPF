using AcademiaDoZe_WPF.Extensions;
using AcademiaDoZe_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Interaction logic for PageListaMatricula.xaml
    /// </summary>
    public partial class PageListaMatricula : Page
    {
        private MatriculaViewModel ViewModelMatricula;
        public PageListaMatricula()
        {
            InitializeComponent();
            this.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(ClassFuncoes.Window_KeyDown);
            this.Loaded += Page_Loaded;

            try
            {
                ViewModelMatricula = new MatriculaViewModel();
                ViewModelMatricula.GetAll();
                DataContext = ViewModelMatricula;
            }
            catch
            {
                MessageBox.Show("Erro ao carregar a lista de matrículas!");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.AjustaResources(this);
        }
    }
}
