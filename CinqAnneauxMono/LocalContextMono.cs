using CoreMono;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contexts;
using CoreMono.UI;
using CinqAnneauxMono.FichesCandidates;
using CinqAnneaux.Data;
using CinqAnneauxMono.Fiches;
using Microsoft.Xna.Framework;
using GeonBit.UI.Entities;

namespace CinqAnneauxMono
{
	public class LocalContextMono : IJdrContextMono
	{
		private List<AbsFicheCandidate> _fiches = new List<AbsFicheCandidate>();

		private IGlobalContext _context;
		public LocalContextMono(IGlobalContext context)
		{
			_context = context;

			var clan = new ClanFc();
			var advantage = new DefaultFicheCandidate<AvantageModel>("Avantage", new FicheAdvantage<AvantageModel>()) { Size = new Vector2(0.5f, 0f), Anchor = Anchor.AutoInline };
			var disadvantage = new DefaultFicheCandidate<DesavantageModel>("Desavantage", new FicheAdvantage<DesavantageModel>()) { Size = new Vector2(0.5f, 0f), Anchor = Anchor.AutoInline };
			var weapon = new DefaultFicheCandidate<ArmeModel>("Arme", new FicheWeapon()) { Size = new Vector2(0.5f, 0f), Anchor = Anchor.AutoInline };
			var armor = new DefaultFicheCandidate<ArmureModel>("Armure", new FicheArmor()) { Size = new Vector2(0.5f, 0f), Anchor = Anchor.AutoInline };
			var obj = new DefaultFicheCandidate<ObjetModel>("Objet", new FicheObject());
			var skill = new DefaultFicheCandidate<CompetenceModel>("Competence", new FicheSkill());
			var kata = new DefaultFicheCandidate<KataModel>("Kata", new FicheKata());
			var kiho = new DefaultFicheCandidate<KihoModel>("Kiho", new FicheKiho());
			var tattoo = new DefaultFicheCandidate<TatouageTogashiModel>("Tatouage", new FicheTatoo());
			var spell = new DefaultFicheCandidate<SortModel>("Sort", new FicheSpell<SortModel>());
			var mahou = new DefaultFicheCandidate<MahouModel>("Mahou", new FicheSpell<MahouModel>());
			var ancestor = new DefaultFicheCandidate<AncetreModel>("Ancetre", new FicheAncestor());
			var altPath = new DefaultFicheCandidate<VoieAlternativeModel>("Voie Alternative", new FicheAlternativeSchool());
			var advancedSchool = new DefaultFicheCandidate<EcoleAvanceeModel>("Ecole Avancee", new FicheAdvancedSchool());
			var shadowPower = new DefaultFicheCandidate<PouvoirOutremondeModel>("Outremonde", new FicheShadowlandPower());
			var opportunity = new DefaultFicheCandidate<OpportuniteHeroiqueModel>("Opportunites Heroiques", new FicheHeroicOpportunity());
			var condition = new DefaultFicheCandidate<CombatConditionModel>("Condition", new FicheCondition());
			var action = new DefaultFicheCandidate<ActionCombatModel>("Action", new FicheAction());
			var status = new StatusFc();
			var plot = new DefaultFicheCandidate<IntrigueModel>("Intrigue", new FicheIntrigue());
			var creature = new DefaultFicheCandidate<FigurantModel>("Creature", new FicheFigurant());
			creature.SetFullHeight();

			// Add Filters
			weapon.AddFilter(new DefaultFilterByEnumDropDown<ArmeModel, TypeArme>(
				(e, f) => { return e.Type == f; }, new Vector2(0.5f, 60f), Anchor.AutoInline)
			{ DefaultFiltering = false, Preset = 0 });
			skill.AddFilter(new DefaultFilterByEnumDropDown<CompetenceModel, GroupeCompetence>(
				(e, f) => { return e.Groupe == f; }, new Vector2(0.5f, 60f), Anchor.AutoInline)
			{ DefaultFiltering = false, Preset = 0 });
			kiho.AddFilter(new DefaultFilterByEnumDropDown<KihoModel, Anneau>(
				(e, f) => { return e.Anneau == f; }, new Vector2(0.5f, 60f), Anchor.AutoInline)
			{ DefaultFiltering = false, Preset = 0 });
			spell.AddFilter(new DefaultFilterByEnumDropDown<SortModel, ElementSort>(
				(e, f) => { return e.Element == f; }, new Vector2(0.5f, 60f), Anchor.AutoInline)
			{ DefaultFiltering = false, Preset = (int)ElementSort.Universel });
			mahou.AddFilter(new DefaultFilterByEnumDropDown<MahouModel, ElementSort>(
				(e, f) => { return e.Element == f; }, new Vector2(0.5f, 60f), Anchor.AutoInline)
			{ DefaultFiltering = false, Preset = (int)ElementSort.Feu });
			shadowPower.AddFilter(new DefaultFilterByEnumDropDown<PouvoirOutremondeModel, TypePouvoirOutremonde>(
				(e, f) => { return e.TypePouvoir == f; }, new Vector2(0.5f, 60f), Anchor.AutoInline)
			{ DefaultFiltering = false, Preset = 0 });

			_fiches.Add(clan);
			_fiches.Add(new SplitFicheCandidate("Avantage", advantage, disadvantage));
			_fiches.Add(obj);
			_fiches.Add(new SplitFicheCandidate("Arme", weapon, armor));
			_fiches.Add(skill);
			_fiches.Add(kata);
			_fiches.Add(kiho);
			_fiches.Add(tattoo);
			_fiches.Add(spell);
			_fiches.Add(mahou);
			_fiches.Add(ancestor);
			_fiches.Add(altPath);
			_fiches.Add(advancedSchool);
			_fiches.Add(shadowPower);
			_fiches.Add(opportunity);
			_fiches.Add(condition);
			_fiches.Add(action);
			_fiches.Add(status);
			_fiches.Add(plot);
			_fiches.Add(creature);
		}

		public IEnumerable<object> FicheCandidates { get { return Fiches; } }

		public IEnumerable<AbsFicheCandidate> Fiches { get { return _fiches; } }

		public void ReportMessage(MessageType type, string Message)
		{
			throw new NotImplementedException();
		}

		public void ReportMessageRef(MessageType type, string reference, params object[] arguments)
		{
			throw new NotImplementedException();
		}
	}
}
