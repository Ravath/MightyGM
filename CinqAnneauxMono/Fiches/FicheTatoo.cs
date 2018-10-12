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
	public class FicheTatoo : FicheModel<TatouageTogashiModel>
	{
		private Header _name = new MgHeader();
		private MgDescription _description = new MgDescription();

		public FicheTatoo(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_description);
		}

		protected override void SetModel(TatouageTogashiModel model)
		{
			_name.Text = model.Name;
			_description.Text = model.Description.Description;
		}

		protected override void SetNoObject()
		{
			_name.Text = "Tatouage";
			_description.Text = "";
		}
	}
}
