using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NotesXamarin
{
    public class App : Application
    {
        public App()
        {
			var db = new SQLiteConnection(DependencyService.Get<IDadosEspecificos>().CaminhoDB("NOTAS.DB"));
			db.CreateTable<Nota>();
			//db.Insert(new Nota() { Titulo = "xxx1", Descricao = "YYY1" });
			//db.Insert(new Nota() { Titulo = "xxx2", Descricao = "YYY2" });
			//db.Insert(new Nota() { Titulo = "xxx3", Descricao = "YYY3" });


			// The root page of your application
			MainPage = new NavigationPage(new Lista());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public interface IDadosEspecificos
    {
        String CaminhoDB(String NomeDB);
    }

    public class Nota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }
    }
}
