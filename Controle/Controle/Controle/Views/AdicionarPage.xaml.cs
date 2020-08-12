using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Controle.Dados;
using System.Runtime.CompilerServices;

namespace Controle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarPage : ContentPage
    {
        public AdicionarPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Controle.db");
            var elementosDatabase = new ElementosDatabase(dbPath);
            ControleLista.ItemsSource = await elementosDatabase.ConsultarTodosAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InserirPage());
        }
    }
}