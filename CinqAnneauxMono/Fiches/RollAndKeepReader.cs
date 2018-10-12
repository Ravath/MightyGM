using CoreMono.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Engine;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using CinqAnneaux.JdrCore;

namespace CinqAnneauxMono.Fiches
{
	public class RollAndKeepReader : Entity
	{
		private ValueReader _roll = new ValueReader(null, Anchor.AutoInline, size:new Vector2(0.33f,0.0f));
		private ValueReader _keep = new ValueReader(null, Anchor.AutoInline, size:new Vector2(0.33f,0.0f));
		private Paragraph _slash = new MgParagraph("g", Anchor.Center) { Padding = Vector2.Zero };

		private RollAndKeep _dices;
		public RollAndKeep Roll
		{
			get { return _dices; }
			set
			{
				if(_dices == value) { return; }
				_dices = value;

				_roll.Value = _dices?.RollValue;
				_keep.Value = _dices?.KeepValue;
			}
		}

		public RollAndKeepReader(RollAndKeep roll, Anchor anchor = Anchor.Auto, Vector2? offset = null, Vector2? size = null) : base(size, anchor, offset)
		{
			AddChild(_roll);
			PanelBase pb = new PanelBase(new Vector2(0.33f, 0.0f), PanelSkin.None, Anchor.AutoInline) { Padding = Vector2.Zero };
			pb.AddChild(_slash);
			AddChild(pb);
			AddChild(_keep);
			Padding = Vector2.Zero;
			Roll = roll;
		}

		public float TextSize
		{
			get { return _slash.Scale; }
			set
			{
				_slash.Scale = value;
				_roll.TextSize = value;
				_keep.TextSize = value;
			}
		}
	}
}
