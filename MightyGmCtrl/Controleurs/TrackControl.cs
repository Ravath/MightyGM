using Core.Data;
using CSCore;
using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyGmCtrl.Controleurs
{
	public class TrackControl : IDisposable
	{
		private ISoundOut _soundOut;
		private IWaveSource _waveSource;
		private MMDevice _device;
		private Soundtrack _track;
		public event EventHandler<PlaybackStoppedEventArgs> PlaybackStopped;

		public PlaybackState PlaybackState
		{
			get
			{
				if (_soundOut != null)
					return _soundOut.PlaybackState;
				return PlaybackState.Stopped;
			}
		}

		public bool Plays
		{
			get { return PlaybackState == PlaybackState.Playing; }
		}

		public TimeSpan Position
		{
			get
			{
				if (_waveSource != null)
					return _waveSource.GetPosition();
				return TimeSpan.Zero;
			}
			set
			{
				if (_waveSource != null)
					_waveSource.SetPosition(value);
			}
		}

		public TimeSpan Length
		{
			get
			{
				if (_waveSource != null)
					return _waveSource.GetLength();
				return TimeSpan.Zero;
			}
		}

		public int Volume
		{
			get
			{
				if (_soundOut != null)
					return Math.Min(100, Math.Max((int)(_soundOut.Volume * 100), 0));
				return 100;
			}
			set
			{
				if (_soundOut != null)
				{
					_soundOut.Volume = Math.Min(1.0f, Math.Max(value / 100f, 0f));
				}
			}
		}

		public void Play()
		{
			if (_soundOut != null)
				_soundOut.Play();
		}

		public void Pause()
		{
			if (_soundOut != null)
				_soundOut.Pause();
		}

		public void Stop()
		{
			if (_soundOut != null)
				_soundOut.Stop();
			Position = TimeSpan.Zero;
		}

		private void CleanupPlayback()
		{
			if (_soundOut != null)
			{
				_soundOut.Dispose();
				_soundOut = null;
			}
			if (_waveSource != null)
			{
				_waveSource.Dispose();
				_waveSource = null;
			}
		}

		public void Open(Soundtrack track, MMDevice device)
		{
			CleanupPlayback();

			_track = track;

			_waveSource =
				CodecFactory.Instance.GetCodec(_track.FilePath)
					.ToSampleSource()
					.ToMono()
					.ToWaveSource();

			InitializeSoundOut(device);
		}

		public void InitializeSoundOut(MMDevice device)
		{
			_device = device;

			_soundOut?.Dispose();

			_soundOut = new WasapiOut() { Latency = 100, Device = _device };
			_soundOut.Initialize(_waveSource);
			if (PlaybackStopped != null) _soundOut.Stopped += PlaybackStopped;
		}

		public void Dispose()
		{
			CleanupPlayback();
		}
	}
}