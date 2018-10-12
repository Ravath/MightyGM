using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;

namespace CinqAnneauxMono.Fiches
{
	public abstract class FicheAgent<T, A> : FicheModel<T> where T : PersonnageModel where A : Agent, new()
	{
		private const String title = "Personnage";
		private Header _name = new MgHeader(title);
		private DisplayAttributes _attributes = new DisplayAttributes();
		private DisplayLife _life = new DisplayLife(size: new Vector2(0f, 280)) { Padding = new Vector2(10f) };
		private DisplaySecondaries _secondaries = new DisplaySecondaries(new Vector2(0f, 280f), Anchor.Auto) { Padding = new Vector2(0f) };
		private DisplayAttacks _attacks = new DisplayAttacks(new Vector2(0f, 100f), Anchor.Auto);
		private DisplaySkills _skills = new DisplaySkills(new Vector2(0f, 100f), Anchor.Auto);
		private DisplayNaturalPowers _powers = new DisplayNaturalPowers();
		private MgDescription _description = new MgDescription();

		protected Agent _character = new A();

		protected FicheAgent(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			Padding = Vector2.Zero;
			const float columnHeight = 800;

			Entity topPanel = new Panel(new Vector2(0f, 210), PanelSkin.Default, Anchor.AutoInline) { Padding = new Vector2(0f, 10f) };
			Entity leftColumn = new Panel(new Vector2(0.5f, columnHeight), PanelSkin.Default, Anchor.AutoInline) { Padding = new Vector2(0f, 10f) };
			Entity rightColumn = new Panel(new Vector2(0.5f, columnHeight), PanelSkin.Default, Anchor.AutoInline) { Padding = new Vector2(0f, 10f) };

			leftColumn.AddChild(new MgHeader("Stats") { FillColor = Color.Gold });
			leftColumn.AddChild(_secondaries);
			leftColumn.AddChild(new HorizontalLine());
			leftColumn.AddChild(_life);
			leftColumn.AddChild(new HorizontalLine());
			leftColumn.AddChild(_attacks);
			rightColumn.AddChild(new MgHeader("Competences") { FillColor = Color.Gold });
			rightColumn.AddChild(_skills);

			topPanel.AddChild(_name);
			topPanel.AddChild(_attributes);

			AddChild(topPanel);
			AddChild(leftColumn);
			AddChild(rightColumn);
			AddChild(_powers);
			AddChild(_description);

			_attributes.Attributs = _character.Attributs;
			_life.Life = _character.Vie;
			_secondaries.Character = _character;
			_attacks.Character = _character;
			_skills.Character = _character;
			_powers.Character = _character;

			MinSize = new Vector2(800f, columnHeight + _description.Size.Y + _attributes.Size.Y + 500f);
		}

		protected override void SetModel(T model)
		{
			_name.Text = _character.EtatCivil.Name;
			_description.Text = _character.EtatCivil.Description;
			_life.Life = _character.Vie;
		}

		protected override void SetNoObject()
		{
			_name.Text = title;
			_description.Text = "";
		}
	}
}
