using Xamarin.Forms;

namespace Compound
{
	public partial class App : Application
	{
		bool soundIsPlaying = true;
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainMenuPage(soundIsPlaying));
		}

		protected override void OnStart()
		{
			DependencyService.Get<IAudio>().PlayAudioFile("yayayaya.mp3");

			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			DependencyService.Get<IAudio>().Stop();

			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

