using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Competences;
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
	public class FicheSchool : FicheModel<EcoleModel>
	{
		private const float techDescHeight = 350;

		private Header _schoolName = new MgHeader();
		private Paragraph _schoolAttribute = new MgProperty();
		private Paragraph _schoolHonnor = new MgProperty();
		private Paragraph _schoolMoney = new MgProperty();
		private Paragraph _shugenjaAffinity = new MgSubProperty();
		private Paragraph _shugenjaDefficience = new MgSubProperty();
		private Paragraph _shugenjaStartSpells = new MgSubProperty();
		private Paragraph _monkDevotion = new MgSubProperty();
		private Paragraph _schoolSkills = new MgTextInsert();
		private Paragraph _schoolEquipment = new MgTextInsert();
		private MgDescription _schoolDescription = new MgDescription();
		private MgCompressedList _schoolTechniques = new MgCompressedList(new Vector2(0f, techDescHeight+160)) { Padding = new Vector2(0f) };

		public FicheSchool(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			PanelTabs pt = new PanelTabs();
			TabData tab1 = pt.AddTab("Desc");
			TabData tab2 = pt.AddTab("Stat");
			TabData tab3 = pt.AddTab("Tech");
			tab1.panel.PanelOverflowBehavior = PanelOverflowBehavior.VerticalScroll;
			tab3.panel.PanelOverflowBehavior = PanelOverflowBehavior.VerticalScroll;
			tab1.panel.Scrollbar.AdjustMaxAutomatically = true;
			tab3.panel.Scrollbar.AdjustMaxAutomatically = true;
			tab1.panel.AddChild(_schoolName);
			tab1.panel.AddChild(_schoolAttribute);
			tab1.panel.AddChild(_schoolHonnor);
			tab1.panel.AddChild(_schoolMoney);
			tab1.panel.AddChild(_shugenjaAffinity);
			tab1.panel.AddChild(_shugenjaDefficience);
			tab1.panel.AddChild(_shugenjaStartSpells);
			tab1.panel.AddChild(_monkDevotion);
			tab1.panel.AddChild(_schoolDescription);
			tab2.panel.AddChild(_schoolSkills);
			tab2.panel.AddChild(_schoolEquipment);
			tab3.panel.AddChild(_schoolTechniques);

			AddChild(pt);
		}

		protected override void SetModel(EcoleModel school)
		{
			// Clear lists
			_schoolTechniques.RemoveAll();

			_schoolName.Text = String.Format("{0} [{1}]", school.Name, school.Balise);
			_schoolAttribute.Text = school.BonusInitial.ToString();
			_schoolHonnor.Text = "Honneur : " + school.Honneur;
			_schoolMoney.Text = "Argent : " + school.ArgentInitial + " Koku";
			SetShugenjaDisplay(school);
			SetMonkDisplay(school);
			_schoolDescription.Text = school.Description.Description;
			// Technics
			foreach (TechniqueModel tech in school.Techniques.OrderBy(t => t.Rang))
			{
				_schoolTechniques.AddItem(
					new MgParagraph(String.Format(" {0} - {1}", tech.Rang, tech.Name)) { FillColor = Color.LightGray },
					new MgDescription() { Text = tech.Description.Description, Size = new Vector2(0.0f, techDescHeight), Padding = new Vector2(10f) }
					);
			}

			// Skills
			StringBuilder sb = new StringBuilder("Competences");
			foreach (CompetenceStatus cpt in school.Competences)
			{
				sb.AppendFormat("\n - {0,-15} {1}", cpt.Competence.Name, cpt.Rang);
				if (cpt.Specialite != null)
				{
					sb.AppendFormat(" ({0})", cpt.Specialite.Name);
				}
			}
			foreach (ApprentissageOptionnelExemplar cpt in school.CompetencesOpt)
			{
				CompetenceOptionnelle opa = CompetenceOptionnelleInstaciator.Instanciate(cpt);
				sb.AppendFormat("\n - {0}x{1}", opa.Nombre, opa.Description);
			}
			_schoolSkills.Text = sb.ToString();

			// Equipment
			sb.Clear();
			sb.Append("\nEquipement");
			foreach (AbsObjetModel obj in school.Equipement)
			{
				sb.AddItem(obj.Name);
			}
			if (school.NecessaireDeVoyage)
				sb.AddItem("Necessaire de Voyage");
			foreach (EquipementOptionnelExemplar eqpt in school.EquipementsOpt)
			{
				OptEquipment ope = OptEquipmentImplementation.Instanciate(eqpt);
				sb.AddItem(ope.Description);
			}
			_schoolEquipment.Text = sb.ToString();
		}

		protected override void SetNoObject()
		{
			// Clear lists
			_schoolTechniques.RemoveAll();

			// Reset Texts
			_schoolName.Text = "Ecole";
			_schoolAttribute.Text = "";
			_schoolHonnor.Text = "";
			_schoolMoney.Text = "";
			_shugenjaAffinity.Text = "";
			_shugenjaDefficience.Text = "";
			_shugenjaStartSpells.Text = "";
			_monkDevotion.Text = "";
			_schoolSkills.Text = "";
			_schoolEquipment.Text = "";
			_schoolDescription.Text = "";
		}
		
		private void SetShugenjaDisplay(EcoleModel school)
		{
			if(school.Balise == BaliseEcole.Shugenja)
			{
				_shugenjaAffinity.Visible = true;
				_shugenjaDefficience.Visible = true;
				_shugenjaStartSpells.Visible = true;

				_shugenjaAffinity.Text = "Affinite : " + school.Affinite;
				_shugenjaDefficience.Text = "Deficience : " + school.Deficience;
				_shugenjaStartSpells.Text = String.Format("Sorts Air : {0} Terre : {1} Feu : {2} Eau : {3} Vide : {4}",
					school.NbrSortAir, school.NbrSortTerre, school.NbrSortFeu, school.NbrSortEau, school.NbrSortVide);
			}
			else
			{
				_shugenjaAffinity.Visible = false;
				_shugenjaDefficience.Visible = false;
				_shugenjaStartSpells.Visible = false;
			}
		}

		private void SetMonkDisplay(EcoleModel school)
		{
			if (school.Devotion == null)
			{
				_monkDevotion.Visible = false;
			}
			else
			{
				_monkDevotion.Visible = true;
				_monkDevotion.Text = "Devotion : " + school.Devotion;
			}
		}
	}
}
