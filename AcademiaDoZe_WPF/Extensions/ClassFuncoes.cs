using AcademiaDoZe_WPF.View;
using System.ComponentModel;
using System.Configuration;
using System.Data.Common;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AcademiaDoZe_WPF.Extensions;

class ClassFuncoes
{
    /// <summary>
    /// De forma recursiva, varre todos os componentes da tela informada, executando o método ApplyResources em cada um dos componentes localizados.
    /// O ApplyResources realiza a leitura do satellite assembly, ou seja, do arquivo de resource que foi ativo conforme o idioma escolhido pelo usuário,
    /// e com base no nome do campo ajusta todos os parâmetros contidos no resource para aquele campo, por exemplo Text, Content, Font, Size, etc.
    /// Deve possuir, em Properties, um arquivo de resources para cada idioma desejado, devendo ser alimentado na coluna nome o nome do campo e a propriedade que deseja ajustar.
    /// Por exemplo, em cadeias de caracteres labelLogin.Content, em outros textBoxSenha.PasswordChar, ou seja, todas as propriedades podem ser ajustadas conforme o idioma e região em uso.
    /// </summary>
    /// <param name="parent">Informar o container inicial, geralmente this para pegar todos os campos da tela, ou então, por exemplo, o nome de um panel ou usercontrol.</param>
    public static void AjustaResources(DependencyObject parent)
    {
        if (parent == null) return;
        // Percorre cada filho direto do objeto pai
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            // Obtém o filho no índice atual
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is FrameworkElement element)
            {
                // Aplicar recursos ao componente
                ComponentResourceManager resources = new(typeof(Properties.Idioma));
                resources.ApplyResources(element, element.Name);
            }
            // Chama recursivamente para percorrer os filhos do filho atual
            AjustaResources(child);
        }
    }

    /// <summary>
    /// Ajusta o idioma e a região com base nas configurações.
    /// </summary>
    public static void AjustaIdiomaRegiao()
    {
        // pt-BR, en-US, es-ES
        // ? indica que o valor pode ser nulo
        string? auxIdiomaRegiao = ConfigurationManager.AppSettings.Get("IdiomaRegiao");
        // no ternário estamos tratando para isso não acontecer
        string idiomaRegiao = auxIdiomaRegiao is not null ? auxIdiomaRegiao : "";
        // Definir a cultura e ajusta o idioma/região
        // o operador ! (null-forgiving) afirma que o valor já foi tratado e não será nulo aqui
        CultureInfo culture = new(idiomaRegiao!);
        Thread.CurrentThread.CurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
    }

    /// <summary>
    /// Tratar eventos de teclado, no caso tecla ENTER funcionando com TAB e tecla ESC para fechar
    /// </summary>
    /// <param name="sender">Objeto que gerou o evento</param>
    /// <param name="e">Evento que foi capturado</param>
    /// <example>No construtor do formulário:
    /// this.KeyDown += new System.Windows.Input.KeyEventHandler(ClassFuncoes.Window_KeyDown);
    ///</example>
    public static void Window_KeyDown(object sender, KeyEventArgs e)
    {
        // Se a tecla ENTER for pressionada
        if (e.Key == Key.Enter)
        {
            // Move o foco para o próximo controle, como o TAB faria
            var focusedElement = Keyboard.FocusedElement as UIElement;
            // Move o foco para o próximo controle na ordem de tabulação
            focusedElement?.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            e.Handled = true; // Previne comportamento padrão do ENTER (como som)
        }
        // Se a tecla ESC for pressionada
        else if (e.Key == Key.Escape)
        {
            // verifica se é window e fecha
            if (sender is Window window)
            {
                MessageBoxResult result = MessageBox.Show("Você realmente deseja fechar a aplicação?", "Confirmação", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    window.Close();
            }
            // carrega uma página inicial
            else
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    // precisa passar o método para public
                    mainWindow.Button_Click(sender, e);
                }
            }
        }
    }

    public static void Box_GotFocus(object sender, RoutedEventArgs e)
    {
        var cor = Brushes.LightCyan;
        if (sender is TextBox)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Background = cor;
        }
        else if (sender is PasswordBox)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            passwordBox.Background = cor;
        }
    }

    public static void Box_LostFocus(object sender, RoutedEventArgs e)
    {
        var cor = Brushes.White;
        if (sender is TextBox)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Background = cor;
        }
        else if (sender is PasswordBox)
        {
            PasswordBox passwordBox = (PasswordBox)sender;
            passwordBox.Background = cor;
        }
    }

    public static void ValidaConexaoDB()
    {
        DbProviderFactory factory;
        string provider = ConfigurationManager.ConnectionStrings["DB"].ProviderName;
        string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        try
        {
            factory = DbProviderFactories.GetFactory(provider);
            using var conexao = factory.CreateConnection();
            conexao!.ConnectionString = connectionString;
            using var comando = factory.CreateCommand();
            comando!.Connection = conexao;
            conexao.Open();
        }
        catch (DbException ex)
        {
            MessageBox.Show($"{ex.Source}\n\n{ex.Message}\n\n{ex.ErrorCode}\n\n{ex.SqlState}\n\n{ex.StackTrace}");
            var auxConfig = new WindowConfig(provider, connectionString);
            auxConfig.ShowDialog();
            ValidaConexaoDB();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Source}\n\n{ex.Message}\n\n{ex.StackTrace}");
            var auxConfig = new WindowConfig(provider, connectionString);
            auxConfig.ShowDialog();
            ValidaConexaoDB();
        }
    }

    public static string Sha256Hash(string senha)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        byte[] bytes =
        sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        return Convert.ToBase64String(bytes);
    }
}