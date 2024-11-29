using AcademiaDoZe_WPF.Extensions;
using AcademiaDoZe_WPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AcademiaDoZe_WPF.View;

/// <summary>
/// Interaction logic for PageListaAluno.xaml
/// </summary>
public partial class PageListaAluno : Page
{
    private AlunoViewModel ViewModelAluno;

    public PageListaAluno()
    {
        InitializeComponent();

        this.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(ClassFuncoes.Window_KeyDown);
        this.Loaded += Page_Loaded;

        try
        {
            ViewModelAluno = new AlunoViewModel();
            ViewModelAluno.GetAll();
            DataContext = ViewModelAluno;
        }
        catch
        {
            MessageBox.Show("Erro ao carregar a lista de alunos!");
        }
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ClassFuncoes.AjustaResources(this);
    }
}
