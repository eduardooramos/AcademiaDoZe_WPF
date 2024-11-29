using AcademiaDoZe_WPF.Extensions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AcademiaDoZe_WPF.View
{
    /// <summary>
    /// Interação lógica para LogradouroPag.xam
    /// </summary>
    public partial class LogradouroPag : Page
    {
        public LogradouroPag()
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
            MessageBox.Show("Logradouro salvo com successo!");
        }

        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.Box_GotFocus(sender, e);
        }

        private void Box_LostFocus(object sender, RoutedEventArgs e)
        {
            ClassFuncoes.Box_LostFocus(sender, e);
        }

        private async void textPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textPais.SelectedValue != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string reposta = await client.GetStringAsync("https://servicodados.ibge.gov.br/api/v1/localidades/estados");
                        var estados = JsonConvert.DeserializeObject<List<EstadoECidade>>(reposta);

                        textUf.ItemsSource = estados;
                        textUf.DisplayMemberPath = "nome";
                        textUf.SelectedValuePath = "id";
                    }
                    catch (HttpRequestException ex)
                    {
                        Console.WriteLine($"Erro na requisição: {ex.Message}");
                    }
                }
            }
        }

        private async void textUf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textUf.SelectedValue != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    string resposta = await client.GetStringAsync($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{(long)textUf.SelectedValue}/municipios");
                    var cidades = JsonConvert.DeserializeObject<List<EstadoECidade>>(resposta);
                    textCidade.ItemsSource = cidades;
                    textCidade.DisplayMemberPath = "nome";
                    textCidade.SelectedValuePath = "id";
                }
            }
        }
    }

    public class Regiao
    {
        public long id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }

    public class EstadoECidade
    {
        public long id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao regiao { get; set; }

    }
}
