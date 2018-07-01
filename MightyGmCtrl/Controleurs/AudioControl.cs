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
	public class AudioControl : Controleur
	{
		private ISoundOut _soundOut;
		private IWaveSource _waveSource;
		private readonly ObservableCollection<MMDevice> _devices = new ObservableCollection<MMDevice>();
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

		public IEnumerable<MMDevice> MMDevices
		{
			get { return _devices; }
		}

		public AudioControl(Context context) : base(context)
		{
			ActualizeMMDevicesList();
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

		private void Open(string filename, MMDevice device)
		{
			CleanupPlayback();

			_waveSource =
				CodecFactory.Instance.GetCodec(filename)
					.ToSampleSource()
					.ToMono()
					.ToWaveSource();
			_soundOut = new WasapiOut() { Latency = 100, Device = device };
			_soundOut.Initialize(_waveSource);
			if (PlaybackStopped != null) _soundOut.Stopped += PlaybackStopped;
		}

		/// <summary>
		/// done to prevent using MMdevice class from user.
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="deviceIndex"></param>
		public void Open(string filename, int deviceIndex)
		{
			Open(filename, MMDevices.ElementAt(deviceIndex));
		}

		public void ActualizeMMDevicesList()
		{
			_devices.Clear();

			// get a list of devices
			using (var mmdeviceEnumerator = new MMDeviceEnumerator())
			{
				using (var mmdeviceCollection = mmdeviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
				{
					// add each of them to the collection
					foreach (var device in mmdeviceCollection)
					{
						_devices.Add(device);
					}
				}
			}
		}
	}
}
