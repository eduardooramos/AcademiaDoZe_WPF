using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AcademiaDoZe_WPF.Extensions;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Interação lógica para ColaboradoresPag.xam
    /// </summary>
    public partial class ColaboradoresPag : Page
    {
        public ColaboradoresPag()
        {
            InitializeComponent(); 

            this.Loaded += Page_Loaded;
            this.PreviewKeyDown += new KeyEventHandler(ClassFuncoes.Window_KeyDown);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.AjustaResources(this);
        }

        private void salvarLog_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Colaborador salvo com successo!");
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
