using CinqAnneaux.Data;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;

namespace CinqAnneauxMono.Fiches
{
	public class FicheAncestor : FicheModel<AncetreModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _clan = new MgProperty();
		private Paragraph _cost = new MgProperty();
		private MgDescription _description = new MgDescription();
		private MgDescription _exigences = new MgDescription();

		public FicheAncestor(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_clan);
			AddChild(_cost);
			AddChild(_description);
			AddChild(_exigences);
		}

		protected override void SetModel(AncetreModel model)
		{
			_name.Text = model.Name;
			_clan.Text = model.Clan.Name;
			_cost.Text = String.Format("Cout : {0}", model.Cout);
			_description.Text = model.Description.Description;
			_exigences.Text = String.Format("Exigences :\n{0}", ((AncetreDescription)model.Description).Exigences);
		}

		protected override void SetNoObject()
		{
			_name.Text = "Ancetre";
			_clan.Text = "";
			_cost.Text = "";
			_description.Text = "";
			_exigences.Text = "";
		}
	}
}
