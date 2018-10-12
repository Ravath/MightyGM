using CinqAnneaux.Data;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;

namespace CinqAnneauxMono.Fiches
{
	public class FicheCondition : FicheModel<CombatConditionModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _type = new MgProperty();
		private MgDescription _description = new MgDescription();

		public FicheCondition(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_type);
			AddChild(_description);
		}

		protected override void SetModel(CombatConditionModel model)
		{
			_name.Text = model.Name;
			_type.Visible = model.Type != TypeCombatCondition.Autre;
			_type.Text = model.Type.ToString();
			_description.Text = model.Description.Description;
		}

		protected override void SetNoObject()
		{
			_name.Text = "Condition";
			_type.Text = "";
			_description.Text = "";
		}
	}
}
