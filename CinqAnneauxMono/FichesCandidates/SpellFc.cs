using CoreMono.UI;
using System.Linq;
using Core.Contexts;
using CinqAnneaux.Data;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using CinqAnneauxMono.Fiches;
using System.Collections.Generic;

namespace CinqAnneauxMono.FichesCandidates
{
	public class SpellFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<SortModel> _spells;
		private IEnumerable<MahouModel> _mahou;

		private DropDown _dropDown;
		private DataList<AbsSortModel> _listSpell;
		private FicheSpell _ficheSpell;

		public SpellFc() : base("Sort")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_dropDown = new DropDown() { Anchor = Anchor.TopCenter };
			_dropDown.AddItem("Universel");
			_dropDown.AddItem("Feu");
			_dropDown.AddItem("Air");
			_dropDown.AddItem("Terre");
			_dropDown.AddItem("Eau");
			_dropDown.AddItem("Mahou");
			_dropDown.SelectList.Size = new Vector2(_dropDown.SelectList.Size.X, 300);

			_listSpell = new DataList<AbsSortModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_listSpell.TextSize = 0.8f;

			_ficheSpell = new FicheSpell(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listSpell);
			AddChild(_ficheSpell);
			AddChild(_dropDown);

			_listSpell.OnItemChanged += (DataList<AbsSortModel> sender) => { _ficheSpell.SetDisplayedModel(sender.SelectedItem); };
			_dropDown.OnValueChange = (Entity entity) =>
			{
				switch (_dropDown.SelectedIndex)
				{
					case 0:
						_listSpell.Data = _spells.Where(s => s.Element == ElementSort.Universel);
						break;
					case 1:
						_listSpell.Data = _spells.Where(s => s.Element == ElementSort.Feu);
						break;
					case 2:
						_listSpell.Data = _spells.Where(s => s.Element == ElementSort.Air);
						break;
					case 3:
						_listSpell.Data = _spells.Where(s => s.Element == ElementSort.Terre);
						break;
					case 4:
						_listSpell.Data = _spells.Where(s => s.Element == ElementSort.Eau);
						break;
					case 5:
						_listSpell.Data = _mahou;
						break; 
					default:
						break;
				}
			};
		}

		public override void LoadData(IJdrContext context)
		{
			_spells = context.UpperContext.Data.GetTable<SortModel>().OrderBy(t => t.Tag);
			_mahou = context.UpperContext.Data.GetTable<MahouModel>().OrderBy(t => t.Tag);
			_dropDown.SelectedIndex = 0;
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheSpell.Size = new Vector2(ficheWidth, 0.8f);
			return ret;
		}

		private float ComputeFicheWidth(float destinationWidth)
		{
			//The actual percentage of width size available
			float actualScale = 1f / UserInterface.Active.GlobalScale;
			return (destinationWidth * actualScale) - 2 * leftpadding - listWidth;
		}
	}
}
