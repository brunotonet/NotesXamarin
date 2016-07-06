using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NotesXamarin
{
    public partial class Lista : ContentPage
    {
        public Lista()
        {
            InitializeComponent();

			Title = "Notas";

			ToolbarItems.Add(new ToolbarItem("Nova", null, async () =>
			{
				await Navigation.PushAsync(new Form());
			}));

            ListaNotas.ItemTapped += ListaNotas_ItemTapped;
        }

        private void ListaNotas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
			Nota NotaAlterar = ((Nota)e.Item);
			Navigation.PushAsync(new Form(NotaAlterar));
        }

		void Atualiza()
		{ 
			var db = new SQLiteConnection(DependencyService.Get<IDadosEspecificos>().CaminhoDB("NOTAS.DB"));
			ListaNotas.ItemsSource = db.Table<Nota>().ToList();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			//Atualiza Dados
			Atualiza();
		}

		async void Apagar_Clicked(object sender, System.EventArgs e)
		{
			var NotaApagar = ((MenuItem)sender).CommandParameter;

			if (await DisplayAlert("Apagar", "Gostaria de apagar a nota selecionada", "Sim", "Não"))
			{
				var db = new SQLiteConnection(DependencyService.Get<IDadosEspecificos>().CaminhoDB("NOTAS.DB"));
				db.Delete(NotaApagar);
				Atualiza();
			}
		}
	}
}
