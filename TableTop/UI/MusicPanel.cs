using Core.Data;
using CoreMono;
using GeonBit.UI.Entities;
using GeonBit.UI.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MightyGmCtrl.Controleurs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableTop.UI
{
	public class MusicPanel : Entity
	{
		private int currentPlay = -1;

		private IEnumerable<Soundtrack> tracks;

		private TrackPlayer _player = new TrackPlayer(null);
		private Button btn_add = new Button("+", ButtonSkin.Default, Anchor.AutoInline, new Vector2(100f, 100f));
		private SelectList audioList = new SelectList(new Vector2(0f, 0.9f), Anchor.AutoCenter, null);

		private AudioControl audio;

		public MusicPanel()
		{
			AddChild(btn_add);
			AddChild(audioList);
			AddChild(_player);

			audio = MainApplication.Controler.Audio;
			
			//'Add Files' button event
			btn_add.OnClick = (Entity btn) => {
				FileInfo[] files = MainApplication.Controler.Files.GetAudioFiles(out string message, out bool success);
				if (!success)
				{
					MessageBox.ShowMsgBox("Error", message);
				}
				else
				{
					Soundtrack[] getTracks = Soundtrack.Cast(files);
					foreach (Soundtrack tr in getTracks)
					{
						//TODO save soundtracks
						//tr.SaveObject(); (better than next one?)
						//MainApplication.Controler.Data.Insert(tr);
					}
					UpdateList(getTracks);
				}
			};
			//Tracks selection list
			audioList.OnValueChange = (Entity ent) =>
			{
				SetPlay(audioList.SelectedIndex);
			};
		}

		private void SetPlay(int index)
		{
			if(index == currentPlay) { return; }
			if (index < 0)
			{
				_player.Track?.Dispose();
				_player.Track = null;
			}
			else
			{
				_player.Track = audio.Open(tracks.ElementAt(index));
				_player.Track.Play();
			}
			currentPlay = index;
		}

		public void UpdateList(IEnumerable<Soundtrack> newTracks)
		{
			tracks = newTracks;
			audioList.ClearItems();
			foreach (Soundtrack t in tracks)
			{
				audioList.AddItem(t.Name);
			}
		}
	}
}
