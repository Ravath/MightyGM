using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTop.GUI;
using TableTop.Map.Commands;

namespace TableTop.Map
{
	public enum SquareSizeMode
	{
		FIX, FIT, STRETCH_VERT, STRETCH_HORI
	}
	public class LayerMap : GuiElement, IGuiApparence
	{
		private List<Layer> _layers = new List<Layer>();
		private int _activeLayer = 0;
		public IMapCommand ActiveCommand { get; set; }

		public int SquareSize { get; set; }
		public SquareSizeMode SquareSizeMode { get; set; }

		public LayerMap(int column, int row)
		{
			Apparence = this;
			SquareSize = 30;
			SquareSizeMode = SquareSizeMode.FIT;
			this.MouseEvent += LayerMap_MouseEvent;
		}

		private void LayerMap_MouseEvent(GuiElement sender, GuiMouseEventArg arg)
		{
			if(ActiveCommand != null)
			{
				ActiveCommand.MouseCommand(this, arg);
			}
		}

		public void AddLayer(Layer newLayer)
		{
			_layers.Add(newLayer);
		}

		public void Draw(SpriteBatch batch, GuiElement e)
		{
			/* resize squares */
			Stretch(SquareSizeMode, GetMaxCol(), GetMaxRow());

			/* draw layers */
			LayerMap lm = (LayerMap)e;
			for (int i = 0; i < _layers.Count; i++)
			{
				_layers[i].Draw(batch, lm);
			}
		}

		public int GetMaxCol()
		{
			int i = 0;
			foreach (LayerGrid l in _layers)
			{
				i = Math.Max(i, l.Column);
			}
			return i;
		}

		public int GetMaxRow()
		{
			int i = 0;
			foreach (LayerGrid l in _layers)
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
					SquareSize = Math.Min(Position.Width / col, Position.Height / row);
					break;
				case SquareSizeMode.STRETCH_HORI:
					SquareSize = Position.Width / col;
					break;
				case SquareSizeMode.STRETCH_VERT:
					SquareSize = Position.Height / row;
					break;
			}
		}

		public E getLayer<E>(int v) where E : Layer
		{
			return (E)_layers[v];
		}

		public void SetActivalayer(int i)
		{
			_activeLayer = i;
		}

		public E getActiveLayer<E>() where E : Layer
		{
			int v = _activeLayer;
			if (_activeLayer >= _layers.Count) { v = _layers.Count - 1; }
			if (_activeLayer < 0) { v = 0; }
			return getLayer<E>(v);
		}

		public bool getSquareCoordinate(Point windowCoordinate, out int x, out int y)
		{
			x = (int)((windowCoordinate.X - Position.X) / SquareSize);
			y = (int)((windowCoordinate.Y - Position.Y) / SquareSize);
			LayerGrid l = getActiveLayer<LayerGrid>();
			if (l != null)
			{
				return x < l.Column && y < l.Row && x >= 0 && y >= 0;
			}
			return false;
		}
	}
}
