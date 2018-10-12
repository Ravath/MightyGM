using Core.Data;
using CoreMono;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MightyGmCtrl.Controleurs;
using System;

namespace TableTop.UI
{
	public class TrackPlayer : Entity
	{
		private Button btn_play = new Button(">", ButtonSkin.Default, Anchor.AutoInline, new Vector2(100f, 100f));
		private Button btn_stop = new Button("||", ButtonSkin.Default, Anchor.AutoInline, new Vector2(100f, 100f));
		Slider slide = new Slider(0, 100);

		private TrackControl _track;
		public TrackControl Track
		{
			get { return _track; }
			set
			{
				if(_track == value) { return; }
				Pause();
				_track?.Dispose();
				_track = value;
				slide.Value = 0;
			}
		}

		public TrackPlayer(TrackControl track)
		{
			SetAnchor(Anchor.AutoInline);
			Size = new Vector2(0f, 0f);

			AddChild(btn_play);
			AddChild(btn_stop);
			AddChild(slide);
			Track = track;

			//Play and Stop buttons events
			btn_play.OnClick = (Entity btn) => {
				if(Track == null) { return; }
				if (Track.Plays) { Pause(); }
				else { Play(); }
			};
			btn_stop.OnClick = (Entity btn) => {
				Stop();
				slide.Value = 0;
			};

			//Slider events
			slide.OnValueChange = (Entity ent) =>
			{
				if (Track != null)
				{
					Track.Position = TimeSpan.FromMilliseconds(Track.Length.TotalMilliseconds * slide.GetValueAsPercent());
				}
			};

			//private void trackBar1_musicProgession(object sender, EventArgs e)
			//{
			//	TimeSpan position = Track.Position;
			//	TimeSpan length = Track.Length;
			//	if (position > length)
			//		length = position;

			//	string chrono = String.Format(@"{0:mm\:ss} / {1:mm\:ss}", position, length);

			//	if (!_stopSliderUpdate &&
			//		length != TimeSpan.Zero && position != TimeSpan.Zero)
			//	{
			//		double perc = position.TotalMilliseconds / length.TotalMilliseconds * trackBar1.Maximum;
			//		trackBar1.Value = (int)perc;
			//	}
			//}
		}

		private void Play()
		{
			Track?.Play();
			btn_play.ButtonParagraph.Text = "=";
		}

		private void Pause()
		{
			Track?.Pause();
			btn_play.ButtonParagraph.Text = ">";
		}

		private void Stop()
		{
			Track?.Stop();
			btn_play.ButtonParagraph.Text = ">";
		}
	}
}
