using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Competences;
using CinqAnneaux.JdrCore.Ecoles;
using CinqAnneaux.JdrCore.Objets;
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
	public class FicheAdvancedSchool : FicheModel<EcoleAvanceeModel>
	{
		private const float techDescHeigth = 350;

		private Header _schoolName = new MgHeader();
		private Paragraph _schoolClan = new MgSubProperty();
		private Paragraph _schoolRequirements = new MgTextInsert();
		private MgDescription _schoolDescription = new MgDescription();
		private MgCompressedList _schoolTechniques = new MgCompressedList(new Vector2(0f, techDescHeigth + 160)) { Padding = new Vector2(0f) };

		public FicheAdvancedSchool(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_schoolName);
			AddChild(_schoolClan);
			AddChild(_schoolRequirements);
			AddChild(_schoolDescription);
			AddChild(_schoolTechniques);
		}

		protected override void SetModel(EcoleAvanceeModel school)
		{
			_schoolName.Text = String.Format("{0} [{1}]", school.Name, school.Balise);
			_schoolDescription.Text = school.Description.Description;

			// Clan
			_schoolClan.Visible = school.Clan != null;
			if (_schoolClan.Visible)
			{
				_schoolClan.Text = String.Format("Clan : {0}", school.Clan.Name);
			}

			// Requirements
			_schoolRequirements.Visible = (school.CompetencesRequises.Count() + school.Conditions.Count()) > 0;
			if (_schoolRequirements.Visible)
			{
				StringBuilder sb = new StringBuilder("Conditions requises");
				foreach (CompetenceStatus cpt in school.CompetencesRequises)
				{
					sb.AppendFormat("\n - {0,-15} {1}", cpt.Competence.Name, cpt.Rang);
					if (cpt.Specialite != null)
					{
						sb.AppendFormat(" ({0})", cpt.Specialite.Name);
					}
				}
				foreach (ConditionAdmissionExemplar cpt in school.Conditions)
				{
					ConditionAdmission opa = ConditionAdmissionImplementation.Instanciate(cpt);
					sb.AppendFormat("\n - {0}", opa.Description);
				}
				_schoolRequirements.Text = sb.ToString();
			}

			// Technics
			_schoolTechniques.RemoveAll();
			foreach (TechniqueAvanceeModel tech in school.Techniques.OrderBy(t => t.Rang))
			{
				_schoolTechniques.AddItem(
					new MgParagraph(String.Format(" {0} - {1}", tech.Rang, tech.Name)) { FillColor = Color.LightGray },
					new MgDescription() { Text = tech.Description.Description, Size = new Vector2(0.0f, techDescHeigth), Padding = new Vector2(10f) }
					);
			}
		}

		protected override void SetNoObject()
		{
			_schoolName.Text = "Ecole Avancee";
			_schoolClan.Text = "";
			_schoolRequirements.Text = "";
			_schoolDescription.Text = "";
			_schoolTechniques.RemoveAll();
		}
	}
}
