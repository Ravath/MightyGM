using CinqAnneaux.Data;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneauxMono.Fiches
{
	public class FicheHeroicOpportunity : FicheModel<OpportuniteHeroiqueModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _citation = new MgCitation();
		private MgDescription _description = new MgDescription();

		public FicheHeroicOpportunity(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_citation);
			AddChild(_description);
		}

		protected override void SetModel(OpportuniteHeroiqueModel model)
		{
			_name.Text = model.Name;
			_citation.Text = model.Action;
			_description.Text = model.Description.Description;
		}

		protected override void SetNoObject()
		{
			_name.Text = "Opportunite";
			_citation.Text = "";
			_description.Text = "";
		}
	}
}
