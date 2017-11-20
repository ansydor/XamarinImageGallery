using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinImageGallery.AppView.Views;

namespace XamarinImageGallery.AppView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class App : Xamarin.Forms.Application
	{
		public App ()
		{
			InitializeComponent ();
            SetMainPage();
               
        }

        public static void SetMainPage()
        {
            var bootstrapper = new Bootstrapper();
            var page = bootstrapper.Start();
            Current.MainPage = page;
        }
    }
}