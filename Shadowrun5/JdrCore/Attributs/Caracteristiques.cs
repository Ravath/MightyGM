using Core.Engine;
using Shadowrun5.Data;
using Shadowrun5.JdrCore.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Attributs {
	public class Caracteristiques : AgentPart<Agents.ShadowrunAgent> {

		#region Properties
		public BaseAttributShadowrun Constitution { get; }
		public BaseAttributShadowrun Agilite { get; }
		public BaseAttributShadowrun Reaction { get; }
		public BaseAttributShadowrun Force { get; }
		public BaseAttributShadowrun Volonte { get; }
		public BaseAttributShadowrun Logique { get; }
		public BaseAttributShadowrun Intuition { get; }
		public BaseAttributShadowrun Charisme { get; }
		public AttributShadowrun Essence { get; }
		public ModifierShadowrun MalusEssence { get; }
		public Value MaxChance { get; }
		public CompositeJauge Chance { get; }
		/// <summary>
		/// La résonance si technomancien, sinon Magie.
		/// </summary>
		public AttributShadowrun Puissance { get; }
		#region Dérivés
		public Initiative Initiative { get; }
		public Initiative InitiativeAstrale { get; }
		public Initiative InitiativeMatricielle { get; }
		public Limite LimitePhysique { get; }
		public Limite LimiteMentale { get; }
		public Limite LimiteSociale { get; }
		public Moniteur MoniteurPhysique { get; }
		public Moniteur MoniteurEtourdissant { get; }
		#endregion
		#endregion

		#region Init
		public Caracteristiques( Agents.ShadowrunAgent s ) : base(s) {
			Constitution = new BaseAttributShadowrun() { Label = "Constitution" };
			Agilite = new BaseAttributShadowrun() { Label = "Agilite" };
			Reaction = new BaseAttributShadowrun() { Label = "Reaction" };
			Force = new BaseAttributShadowrun() { Label = "Force" };
			Volonte = new BaseAttributShadowrun() { Label = "Volonte" };
			Logique = new BaseAttributShadowrun() { Label = "Logique" };
			Intuition = new BaseAttributShadowrun() { Label = "Intuition" };
			Charisme = new BaseAttributShadowrun() { Label = "Charisme" };
			Essence = new AttributShadowrun() { Label = "Essence" };
			MalusEssence = new ModifierShadowrun() { Label = "Initiative" };
			Essence.AddModifier(MalusEssence);
			MaxChance = new Value(6);
			Chance = new CompositeJauge(0, MaxChance, MaxChance.BaseValue);
			Puissance = new AttributShadowrun() { Label = "Magie/Res" };
			Essence.BaseValue = 6;
			Initiative = new Initiative(Reaction, Intuition) { Label = "Initiative" };
			InitiativeAstrale = new Initiative(Intuition, Intuition) { Label = "Initiative Astrale" };
			InitiativeMatricielle = new Initiative(Reaction, Intuition) { Label = "Initiative Matricielle" };
			LimitePhysique = new Limite(Constitution, Reaction, Force) { Label = "Limite Physique" };
			LimiteMentale = new Limite(Volonte, Intuition, Logique) { Label = "Limite Mentale" };
			LimiteSociale = new Limite(Essence, Volonte, Charisme) { Label = "Limite Sociale" };
			MaxMoniteurValue maxPhys = new MaxMoniteurValue(Constitution) { Label = "Moniteur Physique" };
			MaxMoniteurValue maxEtou = new MaxMoniteurValue(Volonte) { Label = "Moniteur Etourdissant" };
			MoniteurPhysique = new Moniteur(maxPhys);
			MoniteurEtourdissant = new Moniteur(maxEtou);
		}
		public void SetModel( CharacterModel c ) {
			Constitution.BaseValue = c.Body;
			Agilite.BaseValue = c.Agility;
			Reaction.BaseValue = c.Reaction;
			Force.BaseValue = c.Strength;
			Volonte.BaseValue = c.Willpower;
			Logique.BaseValue = c.Logic;
			Intuition.BaseValue = c.Intuition;
			Charisme.BaseValue = c.Charisma;
			Essence.BaseValue = c.Essence;
			MaxChance.BaseValue = c.Edge;
			if(c?.Magic > 0) {
				Puissance.BaseValue = (int)c.Magic;
			}
		}
		public void SetExemplaire( CharacterExemplar ce ) {
			Chance.CurrentValue = ce.CurrentEdge;
			MalusEssence.BaseValue = -ce.EssenceMalus;
			MoniteurPhysique.CurrentValue = ce.CurrentPhysicalDamage;
			MoniteurEtourdissant.CurrentValue = ce.CurrentStressDamage;
		}
		public void ResetModel() {
			Constitution.BaseValue = 0;
			Agilite.BaseValue = 0;
			Reaction.BaseValue = 0;
			Force.BaseValue = 0;
			Volonte.BaseValue = 0;
			Logique.BaseValue =0;
			Intuition.BaseValue = 0;
			Charisme.BaseValue =0;
			Essence.BaseValue =0;
			MaxChance.BaseValue = 0;
			Puissance.BaseValue = 0;
        }
		public void ResetExemplaire() {
			Chance.CurrentValue = 0;
			MalusEssence.BaseValue = 0;
			MoniteurPhysique.CurrentValue = 0;
			MoniteurEtourdissant.CurrentValue = 0;
		}
		#endregion
		/// <summary>
		/// Get the attribut from the enumeration type.
		/// </summary>
		/// <param name="a"></param>
		/// <returns>null si Chance.</returns>
		public AttributShadowrun GetAttribut( Attribut a ) {
			switch(a) {
				case Attribut.Body:
				return Constitution;
				case Attribut.Agility:
				return Agilite;
				case Attribut.Reaction:
				return Reaction;
				case Attribut.Strength:
				return Force;
				case Attribut.Willpower:
				return Volonte;
				case Attribut.Logic:
				return Logique;
				case Attribut.Intuition:
				return Intuition;
				case Attribut.Charisma:
				return Charisme;
				case Attribut.Magic:
				case Attribut.Resonance:
				return Puissance;
				case Attribut.Essence:
				return Essence;
				default:
				return null;
			}
		}
	}
}
