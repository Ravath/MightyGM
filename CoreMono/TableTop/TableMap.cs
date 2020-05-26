using CoreMono.Map.Commands;
using CoreMono.TableTop.Command;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CoreMono.TableTop
{
	public class TableMap : Entity
	{
		private List<TableLayer> _layers = new List<TableLayer>();
		private int _activeLayer = 0;
		
		public int LayerCount { get { return _layers.Count; } }
		public CommandManager CurrentEventManager { get; private set; }

		public TableMap(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			UpdateStyle(DefaultStyle);

			CurrentEventManager = new CommandManager();
			OnMouseDown += (e)=> { CurrentEventManager.MouseCommand(this); };
			OnMouseReleased += (e) => { CurrentEventManager.MouseCommand(this); };
			OnMouseLeave += (e) => { CurrentEventManager.MouseCommand(this); };
			WhileMouseDown += (e) => { CurrentEventManager.MouseCommand(this); };
		}

		public void AddLayer(TableLayer newLayer)
		{
			_layers.Add(newLayer);
			AddChild(newLayer);
		}

		public E GetLayer<E>(int v) where E : TableLayer
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

		public E GetActiveLayer<E>() where E : TableLayer
		{
			if (_layers.Count == 0) return null;
			int v = _activeLayer;
			if (_activeLayer >= _layers.Count) { v = _layers.Count - 1; }
			if (_activeLayer < 0) { v = 0; }
			return GetLayer<E>(v);
		}
	}
}
