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
	public class MgSplitEntity : Entity
	{

		private Entity _leftPanelContainer;
		private Entity _rightPanelContainer;
		private Entity _separator;
		private bool _horizontal;
		private float _separationWidth;
		private float _minLeftWidth;
		private float _maxLeftWidth;
		private float _leftWidth;

		#region Properties
		public float SeparationWidth
		{
			get
			{
				return _separationWidth;
			}
			set
			{
				_separationWidth = value;
				SetSeparatorWidth(value);
			}
		}
		public float MinLeftWidth
		{
			get { return _minLeftWidth; }
			set
			{
				_minLeftWidth = value;
				MarkAsDirty();
			}
		}
		public float MaxLeftWidth
		{
			get { return _maxLeftWidth; }
			set
			{
				_maxLeftWidth = value;
				MarkAsDirty();
			}
		}
		public float LeftWidth
		{
			get { return _leftWidth; }
			set
			{
				_leftWidth = value;
				MarkAsDirty();
			}
		}
		/// <summary>
		/// If Not: Vertical.
		/// </summary>
		public bool Horizontal
		{
			get
			{
				return _horizontal;
			}
			set
			{
				_horizontal = value;
				SetAnchor(horizontal: value);
			}
		}
		public Entity LeftPanel
		{
			get
			{
				if (_leftPanelContainer.Children.Count < 1) { return null; }
				return _leftPanelContainer.Children[0];
			}
			set
			{
				if (_leftPanelContainer.Children.Count >= 1)
				{
					_leftPanelContainer.RemoveChild(_leftPanelContainer.Children[0]);
				}
				_leftPanelContainer.AddChild(value, false, 0);
			}
		}
		public Entity RightPanel
		{
			get
			{
				if (_rightPanelContainer.Children.Count < 1) { return null; }
				return _rightPanelContainer.Children[0];
			}
			set
			{
				if (_rightPanelContainer.Children.Count >= 1)
				{
					_rightPanelContainer.RemoveChild(_leftPanelContainer.Children[0]);
				}
				_rightPanelContainer.AddChild(value, false, 0);
			}
		}
		#endregion


		public MgSplitEntity(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			_leftPanelContainer  = new PanelBase(new Vector2(1.0f, 1.0f), PanelSkin.None, Anchor.AutoInline) { Padding = new Vector2(0f) };
			_rightPanelContainer = new PanelBase(new Vector2(1.0f, 1.0f), PanelSkin.None, Anchor.AutoInline) { Padding = new Vector2(0f) };
			_separator = new PanelBase(new Vector2(0f), PanelSkin.None, Anchor.AutoInline) { Padding = new Vector2(0f) };
			AddChild(_leftPanelContainer);
			AddChild(_rightPanelContainer);
			Horizontal = true;
			SeparationWidth = 0f;
		}

		#region Mechanics

		private void SetSeparatorWidth(float width)
		{
			_separator.Size = new Vector2(width);
		}

		private void SetAnchor(bool horizontal)
		{
			Anchor set = horizontal ? Anchor.AutoInline : Anchor.AutoCenter;
			_leftPanelContainer.SetAnchor(set);
			_rightPanelContainer.SetAnchor(set);
			_separator.SetAnchor(set);
		}

		public override Rectangle CalcDestRect()
		{
			Rectangle ret = base.CalcDestRect();

			//Calculate destination space
			float parentWidth = Horizontal ? ret.Width : ret.Height;
			parentWidth -= 2* (Horizontal ? Padding.X : Padding.Y);
			parentWidth /= UserInterface.Active.GlobalScale;

			//Calculate leftWidth from Destination width
			float width = 0f;
			if (LeftWidth < 0) { throw new Exception("Illegal value for this parameter 'RightWidth'"); }
			if (LeftWidth > 1f)
			{
				width = Math.Min(LeftWidth, parentWidth);
			}
			else
			{
				width = LeftWidth * parentWidth;
			}

			//Enforce Min-Max values
			float max = MaxLeftWidth>1? MaxLeftWidth : parentWidth * MaxLeftWidth;
			float min = MinLeftWidth>1? MinLeftWidth : parentWidth * MinLeftWidth;
			width = Math.Min(max, Math.Max(min, width));

			//Set left and right sizes
			_leftPanelContainer.Size = new Vector2(
				 Horizontal ? width : 0.0f,
				!Horizontal ? width : 0.0f);
			_rightPanelContainer.Size = new Vector2(
				 Horizontal ? parentWidth - width - SeparationWidth : 0.0f,
				!Horizontal ? parentWidth - width - SeparationWidth : 0.0f);


			return ret;
		}
		#endregion
	}
}
