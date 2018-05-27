using CoreMono.Map.Commands;
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
		FIX, FIT, STRETCH_VERT, STRETCH_HORI
	}
	public class MapDrawer : Entity
	{
		private List<MapLayer> _layers = new List<MapLayer>();
		private int _activeLayer = 0;
		
		public MouseDrawCmd ActiveCommand { get; set; }

		public int SquareSize { get; set; }
		public SquareSizeMode SquareSizeMode { get; set; }


		public MapDrawer(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			SquareSize = 30;
			SquareSizeMode = SquareSizeMode.FIT;
			this.OnMouseDown += LayerMap_MouseDown;
			this.OnMouseReleased += LayerMap_MouseUp;
			this.OnMouseLeave += LayerMap_MouseOut;
			this.WhileMouseDown += Layermap_MouseDragging;
			UpdateStyle(DefaultStyle);
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

		public void AddLayer(MapLayer newLayer)
		{
			_layers.Add(newLayer);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			/* resize squares */
			Stretch(SquareSizeMode, GetMaxCol(), GetMaxRow());

			/* draw layers */
			for (int i = 0; i < _layers.Count; i++)
			{
				_layers[i].Draw(spriteBatch, this);
			}
		}

		public int GetMaxCol()
		{
			int i = 0;
			foreach (MapLayerGrid l in _layers)
			{
				i = Math.Max(i, l.Column);
			}
			return i;
		}

		public int GetMaxRow()
		{
			int i = 0;
			foreach (MapLayerGrid l in _layers)
			{
				i = Math.Max(i, l.Row);
			}
			return i;
		}

		private void Stretch(SquareSizeMode mode, int col, int row)
		{
			switch (mode)
			{
				case SquareSizeMode.FIT:
					SquareSize = Math.Min(Parent.InternalDestRect.Width/ col, Parent.InternalDestRect.Height / row);
					break;
				case SquareSizeMode.STRETCH_HORI:
					SquareSize = Parent.InternalDestRect.Width / col;
					break;
				case SquareSizeMode.STRETCH_VERT:
					SquareSize = Parent.InternalDestRect.Height / row;
					break;
			}
		}

		public E GetLayer<E>(int v) where E : MapLayer
		{
			return (E)_layers[v];
		}

		public void SetActiveLayer(int i)
		{
			_activeLayer = i;
		}

		public E GetActiveLayer<E>() where E : MapLayer
		{
			int v = _activeLayer;
			if (_activeLayer >= _layers.Count) { v = _layers.Count - 1; }
			if (_activeLayer < 0) { v = 0; }
			return GetLayer<E>(v);
		}

		public bool GetSquareCoordinate(Point windowCoordinate, out int x, out int y)
		{
			x = (windowCoordinate.X - Parent.InternalDestRect.X) / SquareSize;
			y = (windowCoordinate.Y - Parent.InternalDestRect.Y) / SquareSize;
			MapLayerGrid l = GetActiveLayer<MapLayerGrid>();
			if (l != null)
			{
				return x < l.Column && y < l.Row && x >= 0 && y >= 0;
			}
			return false;
		}
	}
}
