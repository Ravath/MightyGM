using Core.Engine;
using Shadowrun5.JdrCore.Agents;
using Shadowrun5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shadowrun5.JdrCore.Attributs;
using Shadowrun5.JdrCore.Traits;

namespace Shadowrun5.JdrCore {
	public class Metatype {

		private List<TraitShadowrun> _traits = new List<TraitShadowrun>();

		public string Nom { get; private set; }
		public ModifierShadowrun Constitution { get; }
		public ModifierShadowrun Agilite { get; }
		public ModifierShadowrun Reaction { get; }
		public ModifierShadowrun Force { get; }
		public ModifierShadowrun Volonte { get; }
		public ModifierShadowrun Logique { get; }
		public ModifierShadowrun Intuition { get; }
		public ModifierShadowrun Charisme { get; }
		public ModifierShadowrun Chance { get; }
		public Value Reach { get; }
		public Value Armor { get; }
		public Value LifeStyleMod { get; }

		private Metatype() {
			Constitution = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Agilite = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Reaction = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Force = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Volonte = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Logique = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Intuition = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Charisme = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Chance = new ModifierShadowrun() { Type = TypeModifier.Racial };
			Reach = new Value();
			Armor = new Value();
			LifeStyleMod = new Value();
		}

		public Metatype( MetatypeModel model ) : this() {
			SetMetatype( model );
		}

		public void SetMetatype( MetatypeModel model ) {
			Nom = model.Name;
            Constitution.BaseValue = model.Body;
			Agilite.BaseValue = model.Agility;
			Reaction.BaseValue = model.Reaction;
			Force.BaseValue = model.Strength;
			Volonte.BaseValue = model.Willpower;
			Logique.BaseValue = model.Logic;
			Intuition.BaseValue = model.Intuition;
			Charisme.BaseValue = model.Charisma;
			Chance.BaseValue = model.Edge;
			Reach.BaseValue = model.Reach;
			Armor.BaseValue = model.Armor;
			LifeStyleMod.BaseValue = model.LifeStyleMod;
			ClearTraits();
			switch(model.Vision) {
				case VisionType.Nocturne:
				AddTrait(new VisionNocturne());
				break;
				case VisionType.Thermographique:
				AddTrait(new VisionThermique());
				break;
			}
        }

		public void AffectPersonnage( Agents.ShadowrunAgent p ) {
			p.Caracteristiques.Constitution.AddModifier(Constitution);
			p.Caracteristiques.Agilite.AddModifier(Agilite);
			p.Caracteristiques.Reaction.AddModifier(Reaction);
			p.Caracteristiques.Force.AddModifier(Force);
			p.Caracteristiques.Volonte.AddModifier(Volonte);
			p.Caracteristiques.Logique.AddModifier(Logique);
			p.Caracteristiques.Intuition.AddModifier(Intuition);
			p.Caracteristiques.Charisme.AddModifier(Charisme);
			p.Caracteristiques.MaxChance.AddModifier(Chance);
			p.ModificateurCoutVie.BaseValue = LifeStyleMod.BaseValue;
			p.Allonge.BaseValue = Reach.BaseValue;
			p.Armure.BaseValue = Armor.BaseValue;
			foreach(var t in _traits) {
				p.DefaultTraits.AddTrait(t);
            }
		}

		public void UnaffectPersonnage( Agents.ShadowrunAgent p ) {
			p.Caracteristiques.Constitution.RemoveModifier(Constitution);
			p.Caracteristiques.Agilite.RemoveModifier(Agilite);
			p.Caracteristiques.Reaction.RemoveModifier(Reaction);
			p.Caracteristiques.Force.RemoveModifier(Force);
			p.Caracteristiques.Volonte.RemoveModifier(Volonte);
			p.Caracteristiques.Logique.RemoveModifier(Logique);
			p.Caracteristiques.Intuition.RemoveModifier(Intuition);
			p.Caracteristiques.Charisme.RemoveModifier(Charisme);
			p.Caracteristiques.MaxChance.RemoveModifier(Chance);
			p.ModificateurCoutVie.BaseValue = 0;
			p.Allonge.BaseValue = 0;
			p.Armure.BaseValue = 0;
			foreach(var t in _traits) {
				p.DefaultTraits.RemoveTrait(t);
			}
		}

		public override string ToString() {
			return Nom;
		}

		#region Traits
		public void ClearTraits() {
			_traits.Clear();
		}
		public void AddTrait( TraitShadowrun ts ) {
			_traits.Add(ts);
		}
		public IEnumerable<TraitShadowrun> Traits { get { return _traits; } } 
		#endregion
	}
}
