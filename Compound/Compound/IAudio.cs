using System;

namespace Compound
{
	public interface IAudio
	{
		void PlayAudioFile(string fileName);
		void Stop();
	}

}