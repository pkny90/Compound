using System;
using Xamarin.Forms;
using System.IO;
using Foundation;
using AVFoundation;
using Compound;

[assembly: Dependency(typeof(AudioService))]
namespace Compound
{
	public class AudioService : NSObject, IAudio, IAVAudioPlayerDelegate
	{
		public AudioService()
		{
		}
		AVAudioPlayer _player;
		public void PlayAudioFile(string fileName)
		{

			NSError error = null;
			AVAudioSession.SharedInstance().SetCategory(AVAudioSession.CategoryPlayback, out error);

			string sFilePath = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(fileName), Path.GetExtension(fileName));
			var url = NSUrl.FromString(sFilePath);
			_player = AVAudioPlayer.FromUrl(url);
			_player.Delegate = this;
			_player.Volume = 5f;
			_player.PrepareToPlay();
			_player.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
			{
				_player = null;
			};
			for (int i = 10; i <= 10;i++)
			{
				_player.Play();
			}
		}

		public void Stop()
		{
			_player.Stop();
		}
	}
}