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
	public class FicheKiho : FicheModel<KihoModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _element = new MgProperty();
		private Paragraph _type = new MgProperty();
		private MgDescription _description = new MgDescription();

		public FicheKiho(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_element);
			AddChild(_type);
			AddChild(_description);
		}

		protected override void SetModel(KihoModel model)
		{
			_name.Text = model.Name;
			_element.Text = String.Format("{0} - {1}", model.Anneau, model.Maitrise);
			_type.Text = model.Type.ToString();
			if(model.UseAtemi) { _type.Text += String.Format(" ({0})", "Atemi"); }
			_description.Text = model.Description.Description;
		}

		protected override void SetNoObject()
		{
			_name.Text = "Kiho";
			_element.Text = "";
			_type.Text = "";
			_description.Text = "";
		}
	}
}
