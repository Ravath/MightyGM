using Core.Contexts;
using Core.Data;
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
	/// <summary>
	/// A Panel providing means to filter a list of DataModel objects.
	/// Generaly implemented with DropDown lists.
	/// </summary>
	/// <typeparam name="D">The type of Data to filter;</typeparam>
	public abstract class FicheFilter<D> : PanelBase
		where D : DataModel
	{
		#region Init
		public FicheFilter() { Padding = Vector2.Zero; }
		public FicheFilter(Vector2 size, Anchor anchor = Anchor.Center, Vector2? offset = null) :
			base(size, PanelSkin.None, anchor, offset)
		{ Padding = Vector2.Zero; }
		#endregion

		#region Properties
		public bool DefaultFiltering { get; set; }
		public int Preset { get; set; } = 0; 
		#endregion

		#region Update
		public delegate void FilterUpdate();
		public event FilterUpdate OnFilterUpdate;

		/// <summary>
		/// Called when the data has to be filtered.
		/// </summary>
		protected void Update()
		{
			OnFilterUpdate?.Invoke();
		}
		#endregion

		#region Abstract
		public abstract bool Filter(D data);
		public abstract void LoadData(IJdrContext context);
		#endregion
	}

	/// <summary>
	/// Default implementation of FicheFilter.
	/// Provides a DropDown of the filtering data to choose from.
	/// </summary>
	/// <typeparam name="D">Type of the Data to filter.</typeparam>
	/// <typeparam name="F">Type of the filtering data.</typeparam>
	public class DefaultFilterByDataObjectDropDown<D,F> : FicheFilter<D>
		where D : DataModel
		where F : DataModel
	{
		private DropDown _filteringList = new DropDown(new Vector2(0f, 300f));
		private IEnumerable<F> _filteringData;

		public DefaultFilterByDataObjectDropDown(FilterPredicate filterPredicate)
		{
			AddChild(_filteringList);
			Compare = filterPredicate;
		}
		public DefaultFilterByDataObjectDropDown(FilterPredicate filterPredicate, Vector2 size, Anchor anchor = Anchor.Center, Vector2? offset = null) :
			base(size, anchor, offset)
		{
			AddChild(_filteringList);
			Compare = filterPredicate;
		}

		public override bool Filter(D data)
		{
			if (_filteringList.SelectedIndex < 0) { return DefaultFiltering; }

			return Compare(data, _filteringData.ElementAt(_filteringList.SelectedIndex));
		}

		public delegate bool FilterPredicate(D data, F criteria);
		private FilterPredicate Compare;

		public override void LoadData(IJdrContext context)
		{
			_filteringList.OnValueChange = null;
			_filteringData = context.UpperContext.Data.GetTable<F>().OrderBy(t => t.Tag).ToArray();
			_filteringList.ClearItems();
			foreach (var item in _filteringData)
			{
				_filteringList.AddItem(item.Name);
			}
			if (_filteringData.Count() > Preset)
				_filteringList.SelectedIndex = Preset >= 0 ? Preset : -1;

			_filteringList.OnValueChange = (e) => { Update(); };
			Update();
		}
	}

	/// <summary>
	/// Default implementation of FicheFilter.
	/// Provides a DropDown of the filtering Enumeration Value to choose from.
	/// </summary>
	/// <typeparam name="D">Type of the Data to filter.</typeparam>
	/// <typeparam name="F">Type of the filtering data.</typeparam>
	public class DefaultFilterByEnumDropDown<D, F> : FicheFilter<D>
		where D : DataModel
		where F : struct, IConvertible
	{
		private DropDown _filteringList = new DropDown(new Vector2(0f, 300f));
		private IEnumerable<F> _filteringData;

		public DefaultFilterByEnumDropDown(FilterPredicate filterPredicate)
		{
			Contract.Assert(typeof(F).IsEnum);
			AddChild(_filteringList);
			Compare = filterPredicate;
			UpdateDropDown();
		}
		public DefaultFilterByEnumDropDown(FilterPredicate filterPredicate, Vector2 size, Anchor anchor = Anchor.Center, Vector2? offset = null) :
			base(size, anchor, offset)
		{
			Contract.Assert(typeof(F).IsEnum);
			AddChild(_filteringList);
			Compare = filterPredicate;
			UpdateDropDown();
		}

		public override bool Filter(D data)
		{
			if (_filteringList.SelectedIndex < 0) { return DefaultFiltering; }

			return Compare(data, _filteringData.ElementAt(_filteringList.SelectedIndex));
		}

		public delegate bool FilterPredicate(D data, F criteria);
		private FilterPredicate Compare;

		private void UpdateDropDown()
		{
			_filteringList.OnValueChange = null;
			_filteringData = (IEnumerable<F>)Enum.GetValues(typeof(F));
			_filteringList.ClearItems();
			
			foreach (var item in _filteringData)
			{
				_filteringList.AddItem(item.ToString());
			}
			_filteringList.OnValueChange = (e) => { Update(); };
		}

		public override void LoadData(IJdrContext context)
		{

			if (_filteringData.Count() > Preset)
				_filteringList.SelectedIndex = Preset >= 0 ? Preset : -1;

		}
	}
}
