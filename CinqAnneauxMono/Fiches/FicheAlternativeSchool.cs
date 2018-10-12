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
	public class FicheAlternativeSchool : FicheModel<VoieAlternativeModel>
	{
		private const float techDescHeigth = 350;

		private Header _schoolName = new MgHeader();
		private Paragraph _schoolRank = new MgProperty();
		private Paragraph _schoolClan = new MgSubProperty();
		private Paragraph _schoolRequirements = new MgTextInsert();
		private MgDescription _schoolDescription = new MgDescription();
		private MgDescription _schoolTechnique = new MgDescription();

		public FicheAlternativeSchool(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_schoolName);
			AddChild(_schoolRank);
			AddChild(_schoolClan);
			AddChild(_schoolRequirements);
			AddChild(_schoolDescription);
			AddChild(_schoolTechnique);
		}

		protected override void SetModel(VoieAlternativeModel school)
		{
			// Name & Balise
			if(school.Balise != null)
				_schoolName.Text = String.Format("{0} [{1}]", school.Name, school.Balise);
			else
				_schoolName.Text = String.Format("{0}", school.Name);

			// Rank
			_schoolRank.Visible = school.Rang > 0;
			_schoolRank.Text = String.Format("Rang :  {0}", school.Rang);

			// Descriptions
			_schoolDescription.Text = school.Description.Description;
			_schoolTechnique.Text = ((VoieAlternativeDescription)school.Description).Technique;

			// Clan
			_schoolClan.Visible = school.ClanRequis != null;
			if (_schoolClan.Visible)
			{
				_schoolClan.Text = String.Format("Clan : {0}", school.ClanRequis.Name);
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
		}

		protected override void SetNoObject()
		{
			_schoolName.Text = "Ecole Alternative";
			_schoolRank.Text = "";
			_schoolClan.Text = "";
			_schoolRequirements.Text = "";
			_schoolDescription.Text = "";
			_schoolTechnique.Text = "";
		}
	}
}
