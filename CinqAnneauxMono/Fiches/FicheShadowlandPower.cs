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
	public class FicheShadowlandPower : FicheModel<PouvoirOutremondeModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _type = new MgProperty();
		private MgDescription _description = new MgDescription();

		public FicheShadowlandPower(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_type);
			AddChild(_description);
		}

		protected override void SetModel(PouvoirOutremondeModel model)
		{
			_name.Text = model.Name;
			_type.Text = model.TypePouvoir.ToString();
			_description.Text = model.Description.Description;
		}

		protected override void SetNoObject()
		{
			_name.Text = "Pouvoir";
			_type.Text = "";
			_description.Text = "";
		}
	}
}
