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
	public class WeaponFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<ArmeModel> _weapons;

		private DropDown _dropDown;
		private DataList<ArmeModel> _listWeapon;
		private DataList<ArmureModel> _listArmor;

		private FicheWeapon _ficheWeapon;
		private FicheArmor _ficheArmor;

		public WeaponFc() : base("Arme")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_dropDown = new DropDown() {
				Anchor = Anchor.TopLeft,
				Size = new Vector2(0.5f / UserInterface.Active.GlobalScale, Size.Y) };
			_dropDown.SelectList.Size = new Vector2(_dropDown.SelectList.Size.X, 600);
			foreach (var item in typeof(TypeArme).GetEnumValues())
			{
				_dropDown.AddItem(item.ToString());
			}

			_listWeapon = new DataList<ArmeModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_listArmor = new DataList<ArmureModel>(new Vector2(listWidth, 0.8f), Anchor.AutoInline) { Padding = new Vector2(0) };

			_ficheWeapon = new FicheWeapon(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);
			_ficheArmor = new FicheArmor(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listWeapon);
			AddChild(_ficheWeapon);
			AddChild(_listArmor);
			AddChild(_ficheArmor);
			AddChild(_dropDown);

			_listWeapon.OnItemChanged += (DataList<ArmeModel> sender) => { _ficheWeapon.SetDisplayedModel(sender.SelectedItem); };
			_listArmor.OnItemChanged += (DataList<ArmureModel> sender) => { _ficheArmor.SetDisplayedModel(sender.SelectedItem); };
			_dropDown.OnValueChange = (Entity entity) =>
			{
				TypeArme type = (TypeArme)typeof(TypeArme).GetEnumValues().GetValue(_dropDown.SelectedIndex);
				_listWeapon.Data = _weapons.Where(w => w.Type == type);
			};
		}

		public override void LoadData(IJdrContext context)
		{
			_weapons = context.UpperContext.Data.GetTable<ArmeModel>().OrderBy(t => t.Tag);
			_listArmor.Data = context.UpperContext.Data.GetTable<ArmureModel>().OrderBy(t => t.Tag);
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheWeapon.Size = new Vector2(ficheWidth, 0.8f);
			_ficheArmor.Size = new Vector2(ficheWidth, 0.8f);
			return ret;
		}

		private float ComputeFicheWidth(float destinationWidth)
		{
			//The actual percentage of width size available
			float actualScale = 1f / UserInterface.Active.GlobalScale;
			return ((destinationWidth * actualScale) - 2 * (listWidth + leftpadding)) / 2;
		}
	}
}
