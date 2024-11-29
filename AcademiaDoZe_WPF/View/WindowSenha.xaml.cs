using AcademiaDoZe_WPF.Extensions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Interaction logic for WindowSenha.xaml
    /// </summary>
    public partial class WindowSenha : Window
    {
        public WindowSenha()
        {
            InitializeComponent();
            TextBoxCPF.PreviewTextInput += Validacoes.TxtCPF_PreviewTextInput;
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

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
