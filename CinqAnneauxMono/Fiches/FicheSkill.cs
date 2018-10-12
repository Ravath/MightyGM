using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Competences;
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
	public class FicheSkill : FicheModel<CompetenceModel>
	{
		private Header _name = new MgHeader();
		private Paragraph _group = new MgProperty();
		private Paragraph _attribute = new MgProperty();
		private Paragraph _keyword = new MgSubProperty();
		private MgTextInsert _speciality = new MgTextInsert();
		private MgTextInsert _mastery = new MgTextInsert();
		private MgDescription _description = new MgDescription();

		public FicheSkill(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_name);
			AddChild(_group);
			AddChild(_attribute);
			AddChild(_keyword);
			AddChild(_speciality);
			AddChild(_mastery);
			AddChild(_description);
		}

		protected override void SetModel(CompetenceModel model)
		{
			if (model.Global != null)
			{
				_name.Text = String.Format("{0} : {1}", model.Global.Name, model.Name);
			}
			else
			{
				_name.Text = model.Name;
			}
			_group.Text = model.Groupe.ToString();
			_attribute.Text = model.TraitAssocie.ToString();
			if(model.TraitAlternatif != null)
			{
				_attribute.Text += String.Format(" / {0}", model.TraitAlternatif);
			}
			_description.Text = model.Description.Description;

			// ADD KEYWORDS
			_keyword.Visible = model.Noble || model.Degradante || model.Martiale || model.Sociale;
			if(_keyword.Visible)
			{
				bool former = false;
				StringBuilder sb = new StringBuilder("Mots-Clefs:");
				void Addkw(string text) {
					sb.Append((former?" / ":"") + text);
					former = true;
				};

				if (model.Noble) { Addkw(" Noble"); }
				if (model.Degradante) { Addkw(" Degradante"); }
				if (model.Martiale) { Addkw(" Martiale"); }
				if (model.Sociale) { Addkw(" Sociale"); }
				_keyword.Text = sb.ToString();
			}

			// ADD SPECIALITIES
			_speciality.Visible = model.Specialisations.Count() > 0;
			if (_speciality.Visible)
			{
				StringBuilder sb = new StringBuilder("Specialites");
				foreach (var item in model.Specialisations)
				{
					sb.AddItem(item.Name);
				}
				_speciality.Text = sb.ToString();
			}

			// ADD MASTERIES
			_mastery.Visible = model.Maitrises.Count() > 0;
			if (_mastery.Visible)
			{
				StringBuilder sb = new StringBuilder("Maitrises");
				foreach (var item in model.Maitrises)
				{
					Maitrise m = MaitriseInstanciator.Instanciate(item);
					sb.AddItem(m.Rang + " - " + m.Description);
				}
				_mastery.Text = sb.ToString();
			}
		}

		protected override void SetNoObject()
		{
			_name.Text = "Comptecence";
			_group.Text = "";
			_attribute.Text = "";
			_keyword.Text = "";
			_speciality.Text = "";
			_mastery.Text = "";
			_description.Text = "";
		}
	}
}
