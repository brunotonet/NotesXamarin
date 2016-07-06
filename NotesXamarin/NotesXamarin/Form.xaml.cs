using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace NotesXamarin
{
    public partial class Form : ContentPage
    {
		//Altera
		public Form(Nota NotaAlterar)
		{
			InitializeComponent();
   
			Title = "Alterar Nota";
			BindingContext = NotaAlterar;
			botaoAcao.Text = "Atualizar Nota";
		}

		//Nova
        public Form()
        {
            InitializeComponent();

			Title = "Nova Nota";
			BindingContext = new Nota();
			botaoAcao.Text = "Cadastrar Nota";
        }


		void Salvar_Clicked(object sender, System.EventArgs e)
		{
			var db = new SQLiteConnection(DependencyService.Get<IDadosEspecificos>().CaminhoDB("NOTAS.DB"));

			Nota NotaAlterada = (Nota)BindingContext;

			if (NotaAlterada.Id != 0) 
			{
				db.Update(NotaAlterada);
			}
			else 
			{
				db.Insert(NotaAlterada);
			}

			Navigation.PopAsync();
		}
	}
}
