using CinqAnneaux.Data;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;

namespace CinqAnneauxMono.Fiches
{
	public class FicheAction : FicheModel<ActionCombatModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _type = new MgProperty();
		private Paragraph _cost = new MgProperty();
		private MgDescription _description = new MgDescription();

		public FicheAction(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_type);
			AddChild(_cost);
			AddChild(_description);
		}

		protected override void SetModel(ActionCombatModel model)
		{
			_name.Text = model.Name;
			_type.Text = model.Type.ToString();
			_cost.Visible = model.Type == TypeActionCombat.Augmentation;
			if( model.CoutMax>model.CoutMin)
			{
				_cost.Text = String.Format("Cout : {0}-{1}", model.CoutMin, model.CoutMax);
			}
			else
			{
				_cost.Text = String.Format("Cout : {0}", model.CoutMin);
			}
			_description.Text = model.Description.Description;
		}

		protected override void SetNoObject()
		{
			_name.Text = "Action";
			_type.Text = "";
			_cost.Text = "";
			_description.Text = "";
		}
	}
}
