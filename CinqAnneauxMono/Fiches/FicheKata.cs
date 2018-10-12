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
	public class FicheKata : FicheModel<KataModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _element = new MgProperty();
		private Paragraph _schools = new MgTextInsert();
		private MgDescription _description = new MgDescription();

		public FicheKata(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_element);
			AddChild(_schools);
			AddChild(_description);
		}

		protected override void SetModel(KataModel model)
		{
			_name.Text = model.Name;
			_element.Text = String.Format("{0} - {1}", model.Anneau, model.Maitrise);
			_description.Text = model.Description.Description;

			// SCHOOLS
			_schools.Visible = model.Ecoles.Count() > 0;
			if (_schools.Visible)
			{
				StringBuilder sb = new StringBuilder("Ecoles Accessibles");
				foreach (var item in model.Ecoles)
				{
					sb.AddItem(item.Name);
				}
				_schools.Text = sb.ToString();
			}
		}

		protected override void SetNoObject()
		{
			_name.Text = "Kata";
			_element.Text = "";
			_schools.Text = "";
			_description.Text = "";
		}
	}
}
