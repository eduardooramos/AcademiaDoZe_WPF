using AcademiaDoZe_WPF.Extensions;
using AcademiaDoZe_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AcademiaDoZe_WPF.View;

/// <summary>
/// Interaction logic for PageListaLogradouro.xaml
/// </summary>
public partial class PageListaLogradouro : Page
{
    private LogradouroViewModel ViewModelLogradouro;

    public PageListaLogradouro()
    {
        InitializeComponent();

        this.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(ClassFuncoes.Window_KeyDown);
        this.Loaded += Page_Loaded;

        try
        {
            ViewModelLogradouro = new LogradouroViewModel();
            ViewModelLogradouro.GetAll();
            DataContext = ViewModelLogradouro;
        }
        catch
        {
            MessageBox.Show("Erro ao carregar a lista de logradouros!");
        }
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ClassFuncoes.AjustaResources(this);
    }

    private void ButtonNovo_Click(object sender, RoutedEventArgs e)
    {

    }
}
