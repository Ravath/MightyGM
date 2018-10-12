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
	public class ValueReader : Entity
	{
		protected Paragraph _display = new MgParagraph("", Anchor.Center);

		private IValue _value;
		public IValue Value
		{
			get{ return _value; }
			set
			{
				if(_value == value) { return;  }

				if(_value!= null)
					_value.ValueChanged -= Value_ValueChanged;

				_value = value;

				if(_value == null)
				{
					_display.Text = "";
					_display.ToolTipText = "";
				}
				else
				{
					SetText(_value);
					_value.ValueChanged += Value_ValueChanged;
				}
			}
		}

		public Paragraph Display { get { return _display; } }

		public float TextSize
		{
			get { return _display.Scale; }
			set { _display.Scale = value; }
		}

		public ValueReader(IValue value, Anchor anchor = Anchor.Auto, Vector2? offset = null, Vector2? size = null) : base(size, anchor, offset)
		{
			AddChild(_display);
			_display.Padding = Vector2.Zero;
			Value = value;
			Padding = Vector2.Zero;
		}

		private void Value_ValueChanged(IValue ival, int newValue, int oldValue)
		{
			SetText(ival);
		}

		private void SetText(IValue value)
		{
			// Text
			_display.Text = _value.TotalValue.ToString();

			// Tooltip
			StringBuilder sb = new StringBuilder(_value.Label + " : " + _value.BaseValue);
			foreach (var item in _value.Modifiers)
			{
				sb.AddItem(item.Label + " : " + item.TotalValue);
			}
			_display.ToolTipText = sb.ToString();
		}
	}
}
