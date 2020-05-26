using Core.Data;
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
	/// Displays a list of DataModels in a List.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class DataList<T> : Entity where T : IDataModel
	{
		public delegate void ItemChanged(DataList<T> sender);
		public event ItemChanged OnItemChanged;

		private SelectList list = new SelectList(Anchor.Center) { Size = new Vector2(0, 0) };
		private IEnumerable<T> _data;

		public IEnumerable<T> Data
		{
			get
			{
				return _data;
			}
			set
			{
				if(_data == value) { return; }
				_data = value;
				UpdateList();
			}
		}

		public T SelectedItem
		{
			get {
				if (list.SelectedIndex < 0) { return default(T); }
				else return _data.ElementAt(list.SelectedIndex);
			}
		}

		public float TextSize
		{
			get { return list.ItemsScale; }
			set { list.ItemsScale = value; }
		}

		public DataList(Vector2? size, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(list);
			list.OnValueChange = (Entity e) =>
			{
				OnItemChanged?.Invoke(this);
			};
		}

		private void UpdateList()
		{
			list.ClearItems();
			if(_data == null) { return; }

			list.AddItem(_data.Select(s=> MgFont.Clean(s.Name)));
		}

	}
}
