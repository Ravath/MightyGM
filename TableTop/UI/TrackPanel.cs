using Core.Data;
using CoreMono;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MightyGmCtrl.Controleurs;
using System;

namespace TableTop.UI
{
	public class TrackPanel : Entity
	{
		private const float buttonSize = 50f;
		private Button btn_play ;
		private Button btn_stop;
		private Label lbl_trackName;
		private Slider slider_trackPosition;

		private TrackControl _track;
		/// <summary>
		/// Flag used to communicate between the manual and auto update of the slider.
		/// </summary>
		private bool isAutoSlideUpdate = false;

		public TrackControl Track
		{
			get { return _track; }
			set
			{
				if(_track == value) { return; }
				Pause();
				_track?.Dispose();
				_track = value;
				slider_trackPosition.Value = 0;
			}
		}

		public TrackPanel(TrackControl track, Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			const int buttonSizeWidth = 16;
			const int buttonSizeHeigth = 2;
			const int numberOfButtons = 2;
			MinSize = new Vector2(buttonSize * buttonSizeWidth + Padding.X*2, buttonSize * buttonSizeHeigth + Padding.Y * 2);

			btn_play = new Button(">", ButtonSkin.Default, Anchor.AutoInline, new Vector2(buttonSize, buttonSize)) { Padding = Vector2.Zero, ToggleMode = true };
			btn_stop = new Button("||", ButtonSkin.Default, Anchor.AutoInline, new Vector2(buttonSize, buttonSize)) { Padding = Vector2.Zero };
			lbl_trackName = new Label("", Anchor.AutoInline) { Padding = Vector2.Zero };
			slider_trackPosition = new Slider(0, 1000, SliderSkin.Default, Anchor.Auto);

			AddChild(btn_play);
			AddChild(btn_stop);
			PanelBase frame = new PanelBase(new Vector2(buttonSize*(buttonSizeWidth-numberOfButtons), buttonSize), PanelSkin.None, Anchor.AutoInline, Vector2.Zero) { Padding = new Vector2(5, 5) };
			frame.AddChild(lbl_trackName);
			AddChild(frame);

			AddChild(new LineSpace(0));
			AddChild(slider_trackPosition);
			Track = track;

			//Play and Stop buttons events
			btn_play.OnClick = (Entity btn) => {
				if(Track == null) { return; }
				if (Track.Plays) { Pause(); }
				else { Play(); }
			};
			btn_stop.OnClick = (Entity btn) => {
				Stop();
				slider_trackPosition.Value = 0;
			};

			//Slider events
			slider_trackPosition.OnValueChange = (Entity ent) =>
			{
				if (Track != null && !isAutoSlideUpdate)
				{
					Track.Position = TimeSpan.FromMilliseconds(Track.Length.TotalMilliseconds * slider_trackPosition.GetValueAsPercent());
				}
			};
		}

		/// <summary>
		/// Called before drawing child entities of this entity.
		/// </summary>
		/// <param name="spriteBatch">SpriteBatch used to draw entities.</param>
		protected override void BeforeDrawChildren(SpriteBatch spriteBatch)
		{
			//Update TrackBar position
			TimeSpan position = Track.Position;
			TimeSpan length = Track.Length;
			if (position > length)
				length = position;

			//Update Chrono
			lbl_trackName.Text = string.Format(@"{0:mm\:ss} / {1:mm\:ss} - {2}", position, length, Track?.File?.Name ?? "");

			if (//!_stopSliderUpdate &&
				length != TimeSpan.Zero && position != TimeSpan.Zero)
			{
				isAutoSlideUpdate = true;
				double perc = position.TotalMilliseconds / length.TotalMilliseconds * slider_trackPosition.Max;
				slider_trackPosition.Value = (int)perc;
				isAutoSlideUpdate = false;
			}
		}

		public void Play()
		{
			Track?.Play();
			btn_play.Checked = true;
		}

		public void Pause()
		{
			Track?.Pause();
			btn_play.Checked = false;
		}

		public void Stop()
		{
			Track?.Stop();
			btn_play.Checked = false;
		}
	}
}
