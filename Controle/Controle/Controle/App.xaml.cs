using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Controle.Views;

namespace Controle
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new InserirPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
