using Controle.Dados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Controle.Modelos;

namespace Controle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InserirPage : ContentPage
    {
        private ElementoDatabase elementoDatabase;
        public InserirPage()
        {
            InitializeComponent();
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Controle.db");
                elementoDatabase = new ElementoDatabase(dbPath);
        }

        private  async void Button_Clicked(object sender, EventArgs e)
        {
            Elemento produtos = new Elemento();

            produtos.Data = DataEntry.Date;
            produtos.Descricao = DescricaoEntry.Text;
            produtos.Valor = ValorEntry.Text;

            await elementoDatabase.SalvarElementosAsync(produtos);
            await Navigation.PopModalAsync();
        }
    }
}