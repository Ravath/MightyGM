using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	/// <summary>
	/// A List of Items with a sub-component visible when clicking on an item.
	/// </summary>
	public class MgCompressedList : Entity
	{
		private Entity _list;
		private List<Entity> _headers = new List<Entity>();
		private List<Entity> _bodies = new List<Entity>();

		public MgCompressedList(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			_list = new PanelBase(new Vector2(0f), PanelSkin.None, Anchor.Center) { Padding = new Vector2(0f) };
			AddChild(_list);
		}

		public void AddItem(Entity header, Entity body)
		{
			_list.AddChild(header);
			_list.AddChild(body);
			_headers.Add(header);
			_bodies.Add(body);
			body.Visible = false;
			header.OnClick = (Entity e) =>
			{
				if (body.Visible)
				{
					body.Visible = false;
				}
				else
				{
					CompressAll();
					body.Visible = true;
				}
			};
		}

		public void CompressAll()
		{
			foreach (Entity item in _bodies)
			{
				item.Visible = false;
			}
		}

		public void RemoveFromHeader(Entity header)
		{
			int index = _headers.FindIndex(e => e == header);
			RemoveFromIndex(index);
		}

		public void RemoveFromBody(Entity body)
		{
			int index = _bodies.FindIndex(e => e == body);
			RemoveFromIndex(index);
		}

		public void RemoveFromIndex(int index)
		{
			_list.RemoveChild(_headers[index]);
			_list.RemoveChild(_bodies[index]);
			_headers.RemoveAt(index);
			_bodies.RemoveAt(index);
		}

		public void RemoveAll()
		{
			_list.ClearChildren();
			_headers.Clear();
			_bodies.Clear();
		}
	}
}
