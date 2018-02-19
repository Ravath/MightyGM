using Core.Engine;
using Shadowrun5.Data;
using Shadowrun5.JdrCore.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun5.JdrCore.Competences {
	public class Competence {

		#region Properties
		public ShadowrunAgent Agent { get; set; }
		public string Nom { get; set; }
		public string Tag { get; private set; }
		public bool Default { get; private set; }
		public Value Rang { get; }
		public Attribut Attribut { get; private set; }
		public SkillGroup? Group{ get; private set; }
		public SkillCategory Category { get; private set; }
		public string Specialite { get; set; }
		public BoolCapacity Aptitude { get; }
		#endregion

		#region Init
		public Competence() {
			Aptitude = new BoolCapacity();
			Rang = new Value();
        }
		public Competence( SkillExemplar sk ) : this() {
			SetExemplaire(sk);
		}
		public Competence( SkillModel sk ) : this() {
			SetModel(sk);
        } 
		public void SetExemplaire( SkillExemplar sk ) {
			SetModel(sk.Model);
			Rang.BaseValue = sk.Rang;
        }
		public void SetModel( SkillModel sk ) {
			Nom = sk.Name;
			Tag = sk.Tag;
			Default = sk.DefaultUse;
			Attribut = sk.Caracteristic;
			Group = sk.SkillGroup;
			Category = sk.Type;
		}
		public void AddAgent( ShadowrunAgent a ) {
			if(Agent != null)
				RemoveAgent();
			Agent = a;
			Rang.AddModifier(Agent.Caracteristiques.GetAttribut(Attribut));
		}
		public void RemoveAgent() {
			Rang.RemoveModifier(Agent.Caracteristiques.GetAttribut(Attribut));
			Agent = null;
		}
		#endregion
	}

	public class CompetencesCollection : AgentPart<ShadowrunAgent> {

		private List<Competence> _competences = new List<Competence>();

		public IEnumerable<Competence> Competences { get { return _competences; } }

		#region Init
		public CompetencesCollection( ShadowrunAgent s ) : base(s) { }
		#endregion

		public void AddCompetence( Competence cp ) {
			cp.AddAgent(Agent);
            _competences.Add(cp);
        }
		public bool RemoveCompetence( Competence cp ) {
			cp.RemoveAgent();
            return _competences.Remove(cp);
		}
		public void Clear() {
			foreach(Competence cp in _competences) {
				cp.RemoveAgent();
			}
			_competences.Clear();
		}
	}
}
