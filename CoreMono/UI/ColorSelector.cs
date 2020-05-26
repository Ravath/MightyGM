using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	public class ColorSelector : Entity
	{
		private Color _color;

		public Color Value
		{
			get { return _color; }
			set {
				_color = value;
				previewImageColor.FillColor = _color;
				OnValueChange?.Invoke(this);
			}
		}

		private ColoredRectangle previewImageColor;

		public ColorSelector(Color initColor, Color? outlineColor = null, int outlineWidth = 0, Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) :
			base(size, anchor, offset)
		{
			Padding = Vector2.Zero;

			// create color selection buttons
			previewImageColor = new ColoredRectangle(initColor, outlineColor, outlineWidth);

			Panel pickPanel = new Panel(new Vector2(10), PanelSkin.None)
			{
				Anchor = Anchor.TopRight,
				Padding = Vector2.Zero,
				Visible = false,
				Offset = new Vector2(-10, 0),
			};
			previewImageColor.OnClick = (Entity entity) =>
			{
				pickPanel.Visible = !pickPanel.Visible;
			};
			previewImageColor.OnMouseLeave = (Entity entity) =>
			{
				pickPanel.Visible = false;
			};
			pickPanel.OnMouseLeave = (Entity entity) =>
			{
				pickPanel.Visible = false;
			};

			Color[] colors = { Color.White, Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Purple, Color.Cyan, Color.Brown, Color.Orange };
			int colorPickSize = 24;
			foreach (Color baseColor in colors)
			{
				for (int i = 0; i < 9; ++i)
				{
					Color color = baseColor * (1.0f - (i * 2 / 16.0f)); color.A = 255;
					ColoredRectangle currColorButton = new ColoredRectangle(color, Vector2.One * colorPickSize, i == 0 ? Anchor.Auto : Anchor.AutoInlineNoBreak);
					currColorButton.Padding = currColorButton.SpaceAfter = currColorButton.SpaceBefore = Vector2.Zero;
					currColorButton.OnClick = (Entity entity) =>
					{
						Value = entity.FillColor;
					};
					pickPanel.AddChild(currColorButton);
				}
			}

			AddChild(previewImageColor);
			AddChild(pickPanel);
		}

		/// <summary>
		/// Set entity render and update priority.
		/// ColorSelector entity override this function to give some bonus priority, since when list is opened it needs to override entities
		/// under it, which usually have bigger index in container.
		/// </summary>
		override protected int Priority
		{
			get { return 100 - _indexInParent + PriorityBonus; }
		}
	}
}
