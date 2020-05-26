using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Capacites;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using System.Text;

namespace CinqAnneauxMono.Fiches
{
	public class FicheSpell<S> : FicheModel<S> where S : AbsSortModel
	{
		private Header _name = new MgHeader();
		private Paragraph _element = new MgProperty();
		private Paragraph _range = new MgSubProperty();
		private Paragraph _zone = new MgSubProperty();
		private Paragraph _duration = new MgSubProperty();
		private MgDescription _description = new MgDescription();
		private MgTextInsert _augmentations = new MgTextInsert();
		private MgTextInsert _keyWords = new MgTextInsert();

		public FicheSpell(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_element);
			AddChild(_range);
			AddChild(_zone);
			AddChild(_duration);
			AddChild(_description);
			AddChild(_augmentations);
			AddChild(_keyWords);
		}

		protected override void SetModel(S model)
		{
			_name.Text = model.Name;
			_element.Text = String.Format("{0} - {1}", model.Element, model.Maitrise);
			const string sRank = " x Rang";
			_range.Text = String.Format("Portee : {0,3} {1}{2}",
				model.FacteurPortee > 0 ? model.FacteurPortee.ToString() : "",
				model.Portee,
				model.PorteeXRang ? sRank : "");
			_zone.Text = String.Format("Zone   : {0,3} {1}{2}",
				model.FacteurZone > 0 ? model.FacteurZone.ToString() : "",
				model.ZoneEffet,
				model.ZoneXRang ? sRank : "");
			_duration.Text = String.Format("Duree  : {0,3} {1}{2}{3}",
				model.FacteurDuree > 0 ? model.FacteurDuree.ToString() : "",
				model.Duree,
				model.DureeXRang ? sRank : "", model.Concentration ? " + Concentration" : "");
			_description.Text = model.Description.Description;

			// AUGMENTATIONS
			if(model.Augmentations.Count() > 0)
			{
				StringBuilder sb = new StringBuilder("\n");
				foreach (AugmentationSortExemplar item in model.Augmentations)
				{
					Augmentation aug = Augmentation.GetImplementation(item);
					sb.AddItem(aug.Description);
				}
				_augmentations.Text = sb.ToString();
			}
			_augmentations.Visible = model.Augmentations.Count() > 0;

			// KEY WORDS
			if (model.MotClefs.Count() > 0)
			{
				StringBuilder sb = new StringBuilder("\nMots-clefs");
				foreach (MotClefSort item in model.MotClefs)
				{
					sb.AddItem(item.ToString());
				}
				_keyWords.Text = sb.ToString();
			}
			_keyWords.Visible = model.MotClefs.Count() > 0;
		}

		protected override void SetNoObject()
		{
			_name.Text = "Sort";
			_element.Text = "";
			_range.Text = "";
			_zone.Text = "";
			_duration.Text = "";
			_description.Text = "";
			_augmentations.Visible = false;
			_keyWords.Visible = false;
		}
	}
}
