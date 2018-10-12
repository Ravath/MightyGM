using CinqAnneaux.Data;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;

namespace CinqAnneauxMono.Fiches
{
	public class FicheObject : FicheModel<ObjetModel>
	{
		private Header _objectName = new MgHeader();
		private Paragraph _objectCost = new MgProperty();
		private MgDescription _objectDescription = new MgDescription();

		public FicheObject(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_objectName);
			AddChild(_objectCost);
			AddChild(_objectDescription);
		}

		protected override void SetNoObject()
		{
			_objectName.Text = "Objet";
			_objectCost.Text = "";
			_objectDescription.Text = "";
		}

		protected override void SetModel(ObjetModel model)
		{
			_objectName.Text = model.Name;
			_objectCost.Text = String.Format("Cout : {0} {2} {1}",
				model.Cout.Value,
				model.Cout.Unity,
				(model.CoutMax == null) ? "" : (model.CoutMax == -1) ? "ou plus" : " - "+model.CoutMax);
			_objectDescription.Text = model.Description.Description;
		}
	}
}
