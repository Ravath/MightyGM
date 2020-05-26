using Core.Contexts;
using CoreMono.UI;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections.Generic;
using Core.Data;
using System;

namespace CoreMono.UI
{
	public class DefaultFicheCandidate<D> : AbsFicheCandidate
		where D : DataModel
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<D> _data;

		private DataList<D> _list;
		private FicheModel<D> _fiche;
		private Panel _scroll;

		private List<FicheFilter<D>> _filters = new List<FicheFilter<D>>();
		private Entity _filterPanel = new PanelBase(new Vector2(0f, 0.1f), PanelSkin.None, Anchor.TopCenter, Vector2.Zero) { Padding = new Vector2(leftpadding) };

		public FicheModel<D> Fiche { get { return _fiche; } }

		public DefaultFicheCandidate(string name, FicheModel<D> fiche) : base(name)
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_list = new DataList<D>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = Vector2.Zero };
			_list.TextSize = 0.8f;

			_scroll = new Panel(new Vector2(ficheWidth, 0.0f), PanelSkin.None, Anchor.CenterRight);

			_fiche = fiche;
			_fiche.Size = new Vector2(0f, 0.8f);
			_fiche.Anchor = Anchor.Center;
			_fiche.Offset = Vector2.Zero;

			AddChild(_list);
			AddChild(_scroll);
			AddChild(_filterPanel);
			_scroll.AddChild(_fiche);

			_list.OnItemChanged += (DataList<D> sender) => { _fiche.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_data = context.UpperContext.Data.GetTable<D>().OrderBy(t => t.Tag);
			foreach (var item in _filters)
			{
				item.LoadData(context);
			}
			UpdateListData();
		}

		public void UpdateListData()
		{
			IEnumerable<D> _filteredData = _data.ToArray();
			foreach (var item in _filters)
			{
				_filteredData = _filteredData.Where(item.Filter);
			}
			_list.Data = _filteredData;
		}

		protected override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_scroll.Size = new Vector2(ficheWidth, 0f);
			return ret;
		}

		private float ComputeFicheWidth(float destinationWidth)
		{
			//The actual percentage of width size available
			float actualScale = 1f / UserInterface.Active.GlobalScale;
			return (destinationWidth * actualScale) - 2 * leftpadding - listWidth;
		}

		public void SetFullHeight()
		{
			_fiche.Size = Vector2.Zero;
			_fiche.Anchor = Anchor.Auto;
			_scroll.PanelOverflowBehavior = PanelOverflowBehavior.VerticalScroll;
			// For the time being, let's forbid filters when in fullHeight
			_filterPanel.Visible = false;
		}

		public void AddFilter(FicheFilter<D> newFilter)
		{
			_filters.Add(newFilter);
			_filterPanel.AddChild(newFilter);
			newFilter.OnFilterUpdate += () =>
			{
				UpdateListData();
			};
		}
	}

	public class SplitFicheCandidate : AbsFicheCandidate
	{
		private AbsFicheCandidate _left;
		private AbsFicheCandidate _right;
		public SplitFicheCandidate(string name, AbsFicheCandidate left, AbsFicheCandidate right) : base(name)
		{
			_left = left;
			_right = right;
			AddChild(_left);
			AddChild(_right);
		}

		public override void LoadData(IJdrContext context)
		{
			_left.LoadData(context);
			_right.LoadData(context);
		}
	}
}
