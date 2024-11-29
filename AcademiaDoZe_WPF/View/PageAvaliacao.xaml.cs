using AcademiaDoZe_WPF.Extensions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AcademiaDoZe_WPF.View;

/// <summary>
/// Interaction logic for PageAvaliacao.xaml
/// </summary>
public partial class PageAvaliacao : Page
{
    public PageAvaliacao()
    {
        InitializeComponent();
        DatePickerData.PreviewTextInput += Validacoes.TxtData_PreviewTextInput;
        this.KeyDown += new KeyEventHandler(ClassFuncoes.Window_KeyDown);
        this.PreviewKeyDown += new KeyEventHandler(ClassFuncoes.Window_KeyDown);
        this.Loaded += Page_Loaded;
    }

    private void Box_GotFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            textBox.Background = Brushes.LightCyan;
        }
        else if (sender is PasswordBox passwordBox)
        {
            passwordBox.Background = Brushes.LightCyan;
        }
    }
    private void Box_LostFocus(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            textBox.Background = Brushes.White;
        }
        else if (sender is PasswordBox passwordBox)
        {
            passwordBox.Background = Brushes.White;
        }
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ClassFuncoes.AjustaResources(this);
    }
}
