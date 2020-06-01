using CoreMono.TableTop.Command;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CoreMono.TableTop
{
	public class Map : Entity
	{
		private List<Layer> _layers = new List<Layer>();
		private int _activeLayer = 0;

		public int LayerCount { get { return _layers.Count; } }
		public CommandManager CurrentEventManager { get; private set; }
		public RelativeMapScale MapScale { get; }

		public Map(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			UpdateStyle(DefaultStyle);

			MapScale = new RelativeMapScale(new EntityMapScale(this));
			CurrentEventManager = new CommandManager();
			WhileMouseHoverOrDown += (e) => {
				CurrentEventManager.WheelCommand(this, MouseInput.MouseWheelChange);
				CurrentEventManager.MouseCommand(this);
			};
		}

		public void AddLayer(Layer newLayer)
		{
			newLayer.SetMap(this);
			_layers.Add(newLayer);
			AddChild(newLayer);
		}

		public E GetLayer<E>(int v) where E : Layer
		{
			return _layers.Count > v ? _layers[v] as E : null;
		}

		public void SetActiveLayer(int i)
		{
			_activeLayer = i;
			if (_activeLayer < 0)
				_activeLayer = 0;
			if (_activeLayer >= LayerCount)
				_activeLayer = LayerCount - 1;
		}

		public E GetActiveLayer<E>() where E : Layer
		{
			if (_layers.Count == 0) return null;
			int v = _activeLayer;
			if (_activeLayer >= _layers.Count) { v = _layers.Count - 1; }
			if (_activeLayer < 0) { v = 0; }
			return GetLayer<E>(v);
		}

		public void SetGridDimensions(int col, int row)
		{
			foreach (Layer layer in _layers)
			{
				layer.Resize(col, row);
			}
		}
	}
}
