using CoreMono.Map.Commands;
using CoreMono.Map.Layers;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CoreMono.Map
{
	public enum SquareSizeMode
	{
		// Don't bother
		FIX,
		// Make it fit entirely in the display space
		FIT,
		// Make it fit at maximum in the width display space
		STRETCH_VERT,
		// Make it fit at maximum in the height display space
		STRETCH_HORI
	}

	public class MapDrawer : Entity
	{
		private List<IMapLayer> _layers = new List<IMapLayer>();
		private int _activeLayer = 0;
		
		public MouseDrawCmd ActiveCommand { get; set; }

		public int LayerCount { get { return _layers.Count; } }
		public int RelativeSquareSize { get; set; }
		public int RelativeOffsetX { get; set; }
		public int RelativeOffsetY { get; set; }
		public int Column { get; private set; }
		public int Row { get; private set; }
		public double ZoomFactor { get; set; }
		public SquareSizeMode SquareSizeMode { get; set; }

		public double ScreenSquareSize { get { return RelativeSquareSize * ZoomFactor; } }
		public double ScreenOffsetX { get { return Parent.InternalDestRect.X + RelativeOffsetX; } }
		public double ScreenOffsetY { get { return Parent.InternalDestRect.Y + RelativeOffsetY; } }

		public MapDrawer(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			RelativeOffsetY = 0;
			RelativeOffsetX = 0;
			ZoomFactor = MapDefaultValues.ZoomFactor;
			SquareSizeMode = MapDefaultValues.SquareSizeMode;
			RelativeSquareSize = MapDefaultValues.RelativeSquareSize;
			OnMouseDown += LayerMap_MouseDown;
			OnMouseReleased += LayerMap_MouseUp;
			OnMouseLeave += LayerMap_MouseOut;
			WhileMouseDown += Layermap_MouseDragging;
			UpdateStyle(DefaultStyle);
		}

		public void SetGridDimensions(int col, int row)
		{
			Column = col;
			Row = row;
			foreach (IMapLayer layer in _layers)
			{
				layer.Resize(col, row, RelativeSquareSize);
			}
		}

		private void Layermap_MouseDragging(Entity entity)
		{
			if (ActiveCommand != null)
			{
				ActiveCommand.MouseCommand(this, new MouseEventArg(MouseBehaviour.MOUSE_IN, Mouse.GetState()));
			}
		}

		private void LayerMap_MouseOut(Entity entity)
		{
			if (ActiveCommand != null)
			{
				ActiveCommand.MouseCommand(this, new MouseEventArg(MouseBehaviour.MOUSE_GET_OUT, Mouse.GetState()));
			}
		}

		private void LayerMap_MouseDown(Entity entity)
		{
			if (ActiveCommand != null)
			{
				ActiveCommand.MouseCommand(this, new MouseEventArg(MouseBehaviour.MOUSE_IN, Mouse.GetState()));
			}
		}
		private void LayerMap_MouseUp(Entity entity)
		{
			if (ActiveCommand != null)
			{
				ActiveCommand.MouseCommand(this, new MouseEventArg(MouseBehaviour.MOUSE_IN, Mouse.GetState()));
			}
		}

		public void AddLayer(IMapLayer newLayer)
		{
			_layers.Add(newLayer);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			if(Column <=0 || Row <= 0) { return; }

			/* resize squares */
			Stretch();

			/* draw layers */
			spriteBatch.Begin();
			for (int i = 0; i < _layers.Count; i++)
			{
				_layers[i].Draw(spriteBatch, this);
			}
			spriteBatch.End();
		}
		
		public void Stretch()
		{
			//TODO : Use 'isDirty' flag to autoupdate when values change?
			int sizeToMatch = RelativeSquareSize;
			switch (SquareSizeMode)
			{
				case SquareSizeMode.FIX:
					// Don't bother
					break;
				case SquareSizeMode.FIT:
					sizeToMatch = Math.Min(Parent.InternalDestRect.Width/ Column, Parent.InternalDestRect.Height / Row);
					break;
				case SquareSizeMode.STRETCH_HORI:
					sizeToMatch = Parent.InternalDestRect.Width / Column;
					break;
				case SquareSizeMode.STRETCH_VERT:
					sizeToMatch = Parent.InternalDestRect.Height / Row;
					break;
			}
			ZoomFactor = sizeToMatch / RelativeSquareSize;
		}

		public E GetLayer<E>(int v) where E : IMapLayer
		{
			return (E)_layers[v];
		}

		public void SetActiveLayer(int i)
		{
			_activeLayer = i;
		}

		public E GetActiveLayer<E>() where E : IMapLayer
		{
			int v = _activeLayer;
			if (_activeLayer >= _layers.Count) { v = _layers.Count - 1; }
			if (_activeLayer < 0) { v = 0; }
			return GetLayer<E>(v);
		}

		public bool GetSquareCoordinate(Point windowCoordinate, out int x, out int y)
		{
			x = (int)((windowCoordinate.X - RelativeOffsetX) / ScreenSquareSize);
			y = (int)((windowCoordinate.Y - RelativeOffsetY) / ScreenSquareSize);
			IMapLayer l = GetActiveLayer<IMapLayer>();
			if (l != null)
			{
				return x < Column && y < Row && x >= 0 && y >= 0;
			}
			return false;
		}
	}
}
