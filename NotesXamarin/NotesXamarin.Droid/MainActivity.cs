using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotesXamarin.Droid.DadosEspecificos))]

namespace NotesXamarin.Droid
{
    [Activity(Label = "NotesXamarin", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }

	public class DadosEspecificos : IDadosEspecificos
	{
		public String CaminhoDB(String NomeDB)
		{
			return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), NomeDB);
		}
	}
}

