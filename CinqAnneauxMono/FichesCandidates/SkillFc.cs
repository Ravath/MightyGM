using CoreMono.UI;
using System.Linq;
using Core.Contexts;
using CinqAnneaux.Data;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using CinqAnneauxMono.Fiches;
using System.Collections.Generic;

namespace CinqAnneauxMono.FichesCandidates
{
	public class SkillFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<CompetenceModel> _skills;

		private DropDown _dropDown;
		private DataList<CompetenceModel> _listSkill;
		private FicheSkill _ficheSkill;

		public SkillFc() : base("Competence")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_dropDown = new DropDown() { Anchor = Anchor.TopCenter };
			_dropDown.AddItem("Noble");
			_dropDown.AddItem("Martiale");
			_dropDown.AddItem("Marchand");
			_dropDown.AddItem("Degradante");
			_dropDown.SelectList.Size = new Vector2(_dropDown.SelectList.Size.X, 300);

			_listSkill = new DataList<CompetenceModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_listSkill.TextSize = 0.8f;

			_ficheSkill = new FicheSkill(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listSkill);
			AddChild(_ficheSkill);
			AddChild(_dropDown);

			_listSkill.OnItemChanged += (DataList<CompetenceModel> sender) => { _ficheSkill.SetDisplayedModel(sender.SelectedItem); };
			_dropDown.OnValueChange = (Entity entity) =>
			{
				switch (_dropDown.SelectedIndex)
				{
					case 0:
						_listSkill.Data = _skills.Where(s => s.Groupe == GroupeCompetence.Noble);
						break;
					case 1:
						_listSkill.Data = _skills.Where(s => s.Groupe == GroupeCompetence.Bugei);
						break;
					case 2:
						_listSkill.Data = _skills.Where(s => s.Groupe == GroupeCompetence.Marchand);
						break;
					case 3:
						_listSkill.Data = _skills.Where(s => s.Groupe == GroupeCompetence.Degradante);
						break;
				}
			};
		}

		public override void LoadData(IJdrContext context)
		{
			_skills = context.UpperContext.Data.GetTable<CompetenceModel>().OrderBy(t => t.Tag);
			_dropDown.SelectedIndex = 0;
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheSkill.Size = new Vector2(ficheWidth, 0.8f);
			return ret;
		}

		private float ComputeFicheWidth(float destinationWidth)
		{
			//The actual percentage of width size available
			float actualScale = 1f / UserInterface.Active.GlobalScale;
			return (destinationWidth * actualScale) - 2 * leftpadding - listWidth;
		}
	}
}
