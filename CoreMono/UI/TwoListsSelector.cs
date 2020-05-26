using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	public class TwoListsSelector<O> : PanelBase
	{
		public delegate void SelectionUpdated(TwoListsSelector<O> entity, O updatedItem);
		public delegate string ConvertString(O entity);

		/// <summary>Used to get the displayed string in the list.</summary>
		[System.Xml.Serialization.XmlIgnore]
		public ConvertString ConvertItemToString = null;
		/// <summary>CallBack called when an item have been added to the selection.</summary>
		[System.Xml.Serialization.XmlIgnore]
		public SelectionUpdated OnAddedItem= null;
		/// <summary>CallBack called when an item have been removed from the selection.</summary>
		[System.Xml.Serialization.XmlIgnore]
		public SelectionUpdated OnRemovedItem = null;

		private SelectList _leftList = new SelectList(new Vector2(0.5f, 0f), Anchor.CenterLeft);
		private SelectList _rightList = new SelectList(new Vector2(0.5f, 0f), Anchor.CenterRight);

		private IEnumerable<O> _set;
		private List<O> _rigthSet;
		private List<O> _leftSet;

		public TwoListsSelector(Vector2 size, Anchor anchor = Anchor.Center, Vector2? offset = null) : base(size, PanelSkin.None, anchor, offset)
		{
			Padding = Vector2.Zero;
			AddChild(_leftList);
			AddChild(_rightList);
			_leftList.OnValueChange = LeftList_selection;
			_rightList.OnValueChange = RightList_selection;
		}

		private void LeftList_selection(Entity entity)
		{
			int selIndex = _leftList.SelectedIndex;
			if(selIndex < 0) { return; }
			O sel = _leftSet[selIndex];

			//remove from list
			_leftList.RemoveItem(selIndex);
			_leftSet.RemoveAt(selIndex);

			// add to other list
			_rigthSet.Add(sel);
			_rightList.AddItem(GetDisplayedString(sel));

			// removed event
			OnRemovedItem?.Invoke(this, sel);

			//unselect item in list
			_leftList.SelectedIndex = -1;
		}

		private void RightList_selection(Entity entity)
		{
			int selIndex = _rightList.SelectedIndex;
			if (selIndex < 0) { return; }
			O sel = _rigthSet[selIndex];

			//remove from list
			_rigthSet.RemoveAt(selIndex);
			_rightList.RemoveItem(selIndex);

			// add to other list
			_leftSet.Add(sel);
			_leftList.AddItem(GetDisplayedString(sel));

			// added event
			OnAddedItem?.Invoke(this, sel);

			//unselect item in list
			_rightList.SelectedIndex = -1;
		}

		public void LoadSet(IEnumerable<O> set)
		{
			Contract.Assert(set != null);
			_set = set;
		}

		public void LoadSelection(IEnumerable<O> selection)
		{
			Contract.Assert(selection != null);
			Contract.Assume(selection.Except(_set).Count() == 0);

			// update left list (selected)
			_leftSet = selection.ToList();
			_leftList.ClearItems();
			_leftList.AddItem(_leftSet.Select(o => GetDisplayedString(o)));

			// update right list (unselected)
			_rigthSet = _set.Except(_leftSet).ToList();
			_rightList.ClearItems();
			_rightList.AddItem(_rigthSet.Select(o => GetDisplayedString(o)));
		}

		public IEnumerable<O> GetCurrentSelection()
		{
			return _leftSet;
		}

		private string GetDisplayedString(O displayed)
		{
			if (ConvertItemToString != null)
			{
				return ConvertItemToString(displayed);
			}
			return displayed.ToString();
		}
	}
}
