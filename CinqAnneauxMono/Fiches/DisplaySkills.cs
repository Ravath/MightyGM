using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
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
	public class DisplaySkills : Entity
	{
		private Agent _character;
		public Agent Character
		{
			get { return _character; }
			set
			{
				if (_character == value) { return; }

				if (_character != null)
					_character.OnModelChanged -= Skills_OnModelChanged;
				_character = value;
				if (_character != null)
					_character.OnModelChanged += Skills_OnModelChanged;

				Skills_OnModelChanged(value);
			}
		}

		private List<SkillCategory> _categories = new List<SkillCategory>();

		public DisplaySkills(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			_categories.Add(new SkillCategory("Noble", GroupeCompetence.Noble));
			_categories.Add(new SkillCategory("Bugei", GroupeCompetence.Bugei));
			_categories.Add(new SkillCategory("Marchand", GroupeCompetence.Marchand));
			_categories.Add(new SkillCategory("Degradante", GroupeCompetence.Degradante));
		}

		private void Skills_OnModelChanged(Agent agent)
		{
			ClearChildren();
			foreach (var item in _categories) { item.Clear(); }
			foreach (var item in agent.Competences.Competences)
			{
				_categories.Single(c => c.Groupe == item.Groupe).AddSkill(item);
			}
			foreach (var iCategory in _categories)
			{
				if(iCategory.SkillDisplays.Count() > 0)
				{
					AddChild(iCategory.Display);
					foreach (var item2 in iCategory.SkillDisplays)
					{
						AddChild(item2);
					}
				}
			}
		}


		private class SkillCategory
		{
			private bool _visible = true;
			private string _name;
			private List<Entity> _skills = new List<Entity>();
			public GroupeCompetence Groupe { get; private set; }
			public Entity Display { get; private set; }
			public IEnumerable<Entity> SkillDisplays { get { return _skills; } }

			public SkillCategory(string name, GroupeCompetence groupe)
			{
				_name = name;
				Groupe = groupe;

				// create display
				Entity display = new MgHeader(_name, Anchor.AutoCenter)
				{
					Scale = 0.8f
				};
				Display = display;
				display.OnClick = (Entity e) =>
				{
					SwapVisibility();
				};
			}

			public void AddSkill(Competence skill)
			{
				MgParagraph sk = new MgParagraph(
					String.Format(" - {0,-28} {1,-4}", skill.Nom, skill.Trait.ToString().Substring(0,3)),
					Anchor.AutoInline, new Vector2(0.8f, 0.0f))
				{
					Scale = 0.8f,
					Padding = Vector2.Zero
				};

				// Add Tags
				StringBuilder sb = new StringBuilder("");
				if (skill.Degradante)
					sb.AppendLine("Degradante");
				if (skill.Noble)
					sb.AppendLine("Noble");
				if (skill.Martiale)
					sb.AppendLine("Martiale");
				if (skill.Sociale)
					sb.AppendLine("Sociale");
				if (skill.TraitAlternatif != null)
					sb.AppendLine("Trait Alternatif : " + skill.TraitAlternatif);

				// Add Specialities
				if (skill.Specialisations.Count() > 0)
				{
					sb.Append("\n Specialites : ");
					foreach (var item in skill.Specialisations) { sb.AddItem(item.Nom); }
					sb.AppendLine();
				}

				// Add Masteries
				if (skill.CurrentMaitrises.Count() > 0)
				{
					sb.Append("\n Maitrises : ");
					foreach (var item in skill.CurrentMaitrises) { sb.AddItem(item.Description); }
				}
				sk.ToolTipText = MgFont.Clean( sb.ToString() );

				RollAndKeepReader rkr = new RollAndKeepReader(skill.Pool, Anchor.AutoInline, size:new Vector2(0.2f, 0f)) {
					Padding = Vector2.Zero,
					TextSize = 0.8f,
					MaxSize = new Vector2(90, 0f)
				};

				Panel line = new Panel(Vector2.Zero, PanelSkin.None, Anchor.AutoInline) { Padding = Vector2.Zero };
				line.AddChild(sk);
				line.AddChild(rkr);
				_skills.Add(line);

				sk.CalcTextActualRectWithWrap();
				line.Size = new Vector2(0f, sk.GetActualDestRect().Height);
			}
			public void Clear() { _skills.Clear(); _visible = true; }
			public void SwapVisibility()
			{
				_visible = !_visible;
				foreach (var item in _skills)
				{
					item.Visible = _visible;
				}
			}
		}
	}
}
