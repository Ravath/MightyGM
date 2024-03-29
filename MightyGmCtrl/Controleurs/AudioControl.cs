﻿using Core.Data;
using CSCore.CoreAudioAPI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System;
using System.IO;

namespace MightyGmCtrl.Controleurs
{
	public class AudioControl : Controleur
	{
		private int _deviceIndex;
		private readonly ObservableCollection<MMDevice> _devices = new ObservableCollection<MMDevice>();
		private List<TrackControl> _tracks = new List<TrackControl>();

		public IEnumerable<MMDevice> MMDevices
		{
			get { return _devices; }
		}

		public int SelectedDeviceIndex
		{
			get{ return _deviceIndex; }
			set
			{
				if(value == _deviceIndex) { return; }
				_deviceIndex = value;
				foreach (TrackControl tr in _tracks)
				{
					tr.InitializeSoundOut(MMDevices.ElementAt(SelectedDeviceIndex));
				}
			}
		}

		public AudioControl(Context context) : base(context)
		{
			ActualizeMMDevicesList();
		}

		private TrackControl Open(FileInfo track, MMDevice device)
		{
			TrackControl newTrack = new TrackControl(this);
			newTrack.Open(track, device);
			_tracks.Add(newTrack);

			return newTrack;
		}

		/// <summary>
		/// Add the given Soundtrack to the player.
		/// </summary>
		/// <param name="track">Track to play.</param>
		public TrackControl Open(RawRessource track)
		{
			Contract.Assert(track.RessourceType == RawRessourceType.Soundtrack);
			return Open(track.Info, MMDevices.ElementAt(SelectedDeviceIndex));
		}

		/// <summary>
		/// Should be called only by 'TrackControl::Dispose()'.
		/// </summary>
		/// <param name="track"></param>
		internal void Remove(TrackControl track)
		{
			_tracks.Remove(track);
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

		internal void Exit()
		{
			for (int i = _tracks.Count-1; i >=0; i--)
			{
				_tracks.ElementAt(i).Dispose();
			}
		}
	}
}
