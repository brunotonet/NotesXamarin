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

            var db = new SQLiteConnection(DependencyService.Get<IDadosEspecificos>().CaminhoDB("NOTAS.DB"));
            ListaNotas.ItemsSource = db.Table<Nota>().ToList();

            ListaNotas.ItemTapped += ListaNotas_ItemTapped;
        }

        private void ListaNotas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int ID = ((Nota)e.Item).Id;
        }
    }
}
