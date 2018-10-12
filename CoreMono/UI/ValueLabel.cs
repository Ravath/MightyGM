using Core.Engine;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	public class ValueLabel : Entity
	{
		private ValueReader _value;
		private Paragraph _label = new MgParagraph();

		public ValueReader Value { get { return _value; } }
		public Paragraph Label { get { return _label; } }

		public ValueLabel(String label, ValueReader value, Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			_value = value;
			_label.Text = label;
			_value.Size = new Vector2(30,1.0f);
			_label.Offset = Vector2.Zero;
			_value.Offset = Vector2.Zero;
			_value.Padding = Vector2.Zero;
			SetHorizontal();
			AddChild(_label);
			AddChild(_value);
		}

		public void SetHorizontal()
		{
			_label.Anchor = Anchor.CenterLeft;
			_value.Anchor = Anchor.CenterRight;
		}
		public void SetVertical()
		{
			_label.Anchor = Anchor.TopCenter;
			_value.Anchor = Anchor.BottomCenter;
		}

		public float TextSize
		{
			get { return _label.Scale; }
			set
			{
				_label.Scale = value;
				_value.TextSize = value;
			}
		}
	}
}
