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
	public class FicheIntrigue : FicheModel<IntrigueModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _actors = new MgTextInsert();
		private MgDescription _description = new MgDescription();

		public FicheIntrigue(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_actors);
			AddChild(_description);
		}

		protected override void SetModel(IntrigueModel model)
		{
			_name.Text = model.Name;
			_description.Text = model.Description.Description;

			// SCHOOLS
			_actors.Visible = model.Acteurs.Count() > 0;
			if (_actors.Visible)
			{
				StringBuilder sb = new StringBuilder("Acteurs");
				foreach (string item in model.Acteurs)
				{
					sb.AddItem(item);
				}
				_actors.Text = sb.ToString();
			}
		}

		protected override void SetNoObject()
		{
			_name.Text = "Intrigue";
			_actors.Text = "";
			_description.Text = "";
		}
	}
}
