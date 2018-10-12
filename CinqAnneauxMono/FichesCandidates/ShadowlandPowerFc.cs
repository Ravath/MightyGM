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
	public class ShadowlandPowerFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<PouvoirOutremondeModel> _powers;

		private DropDown _dropDown;
		private DataList<PouvoirOutremondeModel> _listPowers;
		private FicheShadowlandPower _fichePower;

		public ShadowlandPowerFc() : base("Outremonde")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_dropDown = new DropDown() { Anchor = Anchor.TopCenter };
			foreach (var item in typeof(TypePouvoirOutremonde).GetEnumValues())
			{
				_dropDown.AddItem(item.ToString());
			}
			_dropDown.SelectList.Size = new Vector2(_dropDown.SelectList.Size.X, 300);

			_listPowers = new DataList<PouvoirOutremondeModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_listPowers.TextSize = 0.8f;

			_fichePower = new FicheShadowlandPower(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listPowers);
			AddChild(_fichePower);
			AddChild(_dropDown);

			_listPowers.OnItemChanged += (DataList<PouvoirOutremondeModel> sender) => { _fichePower.SetDisplayedModel(sender.SelectedItem); };
			_dropDown.OnValueChange = (Entity entity) =>
			{
				TypePouvoirOutremonde ring = (TypePouvoirOutremonde)typeof(TypePouvoirOutremonde).GetEnumValues().GetValue(_dropDown.SelectedIndex);
				_listPowers.Data = _powers.Where(k => k.TypePouvoir == ring);
			};
		}

		public override void LoadData(IJdrContext context)
		{
			_powers = context.UpperContext.Data.GetTable<PouvoirOutremondeModel>().OrderBy(t => t.Tag);
			_dropDown.SelectedIndex = 0;
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_fichePower.Size = new Vector2(ficheWidth, 0.8f);
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
