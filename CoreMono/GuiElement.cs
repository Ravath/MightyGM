using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoreMono.GUI
{
	public class GuiElement
	{
		private Rectangle _position = new Rectangle(0, 0, 0, 0);
		public Rectangle Position { get { return _position; } }

		public IGuiApparence Apparence { get; set; }

		private GuiElement _parent;
		public GuiElement Parent {
			get { return _parent; }
			protected internal set {
				if (_parent == value) { return; }
				_parent = value;
			}
		}

		public virtual void Draw(SpriteBatch batch)
		{
			if (Apparence != null)
			{
				Apparence.Draw(batch, this);
			}
		}

		#region Resize Event
		public delegate void GuiResizeEventHandler(GuiElement sender, GuiResizeEventArg arg);

		public event GuiResizeEventHandler ResizeUpdate;

		public virtual void Resize(int x, int y, int w, int h)
		{
			_position.X = x;
			_position.Y = y;
			_position.Width = w;
			_position.Height = h;
			ResizeUpdate?.Invoke(this, new GuiResizeEventArg());
		} 
		#endregion

		#region Mouse Event
		private bool _prevMouseIn = false;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="mouseState"></param>
		/// <returns>false if the mouse didn't interact with the element.</returns>
		public virtual bool MouseClick(MouseState mouseState)
		{
			bool mouseIn = Position.Contains(mouseState.Position.X, mouseState.Position.Y);
			if (mouseIn)
			{
				/* the mouse is in the element */
				if (_prevMouseIn != mouseIn)
				{
					MouseEvent?.Invoke(this, new MouseEventArg(MouseBehaviour.MOUSE_GET_IN, mouseState));
				}
				else
				{
					MouseEvent?.Invoke(this, new MouseEventArg(MouseBehaviour.MOUSE_IN, mouseState));
				}
			}
			else
			{
				/* the mouse is out the element */
				if (_prevMouseIn != mouseIn)
				{
					MouseEvent?.Invoke(this, new MouseEventArg(MouseBehaviour.MOUSE_GET_OUT, mouseState));
				}
			}
			bool ret = mouseIn || _prevMouseIn;
			_prevMouseIn = mouseIn;
			return ret;
		}

		public delegate void MouseEventHandler(GuiElement sender, MouseEventArg arg);
		public event MouseEventHandler MouseEvent; 
		#endregion
	}

	public abstract class GuiSingleChildElement : GuiElement
	{
		protected GuiElement _child;
		public GuiElement Child {
			get { return _child; }
			set {
				if(_child == value) { return; }
				_child = value;
				value.Parent = this;
			}
		}

		public abstract void ManageChild();

		public sealed override void Resize(int x, int y, int w, int h)
		{
			base.Resize(x, y, w, h);
			ManageChild();
		}

		public sealed override bool MouseClick(MouseState state)
		{
			if (base.MouseClick(state))
			{
				Child?.MouseClick(state);
				return true;
			}
			return false;
		}

		public override void Draw(SpriteBatch batch)
		{
			base.Draw(batch);
			Child?.Draw(batch);
		}
	}

	public abstract class GuiMultipleChildrenElement : GuiElement
	{
		private List<GuiElement> _children = new List<GuiElement>();

		public IEnumerable<GuiElement> Children { get { return _children; } }

		public void Add(GuiElement e)
		{
			_children.Add(e);
			e.Parent = this;
		}

		public abstract void ManageChildren();

		public sealed override void Resize(int x, int y, int w, int h)
		{
			base.Resize(x, y, w, h);
			ManageChildren();
		}

		public sealed override bool MouseClick(MouseState state)
		{
			if (base.MouseClick(state))
			{
				foreach (var child in Children)
				{
					child.MouseClick(state);
				}
				return true;
			}
			return false;
		}

		public override void Draw(SpriteBatch batch)
		{
			base.Draw(batch);
			foreach (var child in Children)
			{
				child.Draw(batch);
			}
		}
	}
}