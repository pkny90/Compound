using System;
using Xamarin.Forms;
using Android.Media;
using Android.Content.Res;
using Compound;

[assembly: Dependency(typeof(AudioService))]
namespace Compound
{
	public class AudioService : IAudio
	{
		public AudioService()
		{
			
		}
		public MediaPlayer player;
		public void PlayAudioFile(string fileName)
		{
			player = new MediaPlayer();
			var fd = global::Android.App.Application.Context.Assets.OpenFd(fileName);
			player.Prepared += (s, e) =>
			{
				player.Start();
			};
			player.SetDataSource(fd.FileDescriptor, fd.StartOffset, fd.Length);
			for (int i = 10; i <= 10; i++)
			{
				player.Prepare();
			}
		}
		public void Stop()
		{
				player.Stop();
		}
	}
}