using CinqAnneaux.Data;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Competences {
	public class ListeCompetences : AgentPart<Agent.Agent> {

		#region Members
		private List<Competence> _competences = new List<Competence>();
		private Attributs.Attributs _attr;
		#endregion

		#region Properties
		public IEnumerable<Competence> Competences {
			get { return _competences; }
		}
		#endregion

		#region Init
		public ListeCompetences( Attributs.Attributs attr, Agent.Agent agent ) : base(agent) {
			_attr = attr;
        }
		#endregion

		#region Evénements
		//todo : check the 2 events can use the same delaguate (I don't know if type or variable)
		public delegate void SetCompetences( ListeCompetences emiter,  params Competence[] competences );
		/// <summary>
		/// Fired after competences are added.
		/// </summary>
		public event SetCompetences NewCompetences;
		/// <summary>
		/// Fired after removal of competences.
		/// </summary>
		public event SetCompetences RemovedCompetences;
		#endregion

		public void AddCompetence( Competence cpt ) {
			_competences.Add(cpt);
			cpt.SetAttribut(_attr);
		}

		public void SetPersonnage( PJModel perso ) {
			ClearList();
            foreach(CompetenceExemplar cpt in perso.Competences) {
				Competence icpt = new Competence();
				icpt.SetCompetence(cpt);
				AddCompetence(icpt);
			}
			// todo compétences globables
			/* évènement nouvelles compétences */
			NewCompetences?.Invoke(this, this.Competences.ToArray());
		}

		public void SetPersonnage(CreatureModel perso)
		{
			ClearList();
			foreach (CompetenceStatus cpt in perso.Competences)
			{
				Competence icpt = new Competence();
				icpt.SetCompetence(cpt);
				AddCompetence(icpt);
			}
			// todo compétences globables
			/* évènement nouvelles compétences */
			NewCompetences?.Invoke(this, this.Competences.ToArray());
		}

		public Competence GetCompetenceArme( TypeArme type ) {
			switch(type) {
				case TypeArme.Fleche: // error
				throw new ArgumentException("There is no competence for fleche weapons.");
				case TypeArme.Arc:
				return GetCompetenceByTag("CPT0019");
                case TypeArme.Chaine:
				return GetCompetenceByTag("CPT0012");
				case TypeArme.Hast:
				return GetCompetenceByTag("CPT0013");
				case TypeArme.Ninjutsu:
				return GetCompetenceByTag("CPT0021");
				case TypeArme.Lourde:
				return GetCompetenceByTag("CPT0014");
				case TypeArme.Baton:
				return GetCompetenceByTag("CPT0015");
				case TypeArme.Couteau:
				return GetCompetenceByTag("CPT0016");
				case TypeArme.Eventail:
				return GetCompetenceByTag("CPT0017");
				case TypeArme.Lance:
				return GetCompetenceByTag("CPT0020");
				case TypeArme.Sabre:
				return GetCompetenceByTag("CPT0018");
				default:
				throw new NotImplementedException(type+" weapon type has not been implemented.");
			}
		}
		public Competence GetCompetenceByTag(string tag ) {
			return _competences.SingleOrDefault(c => c.Tag == tag);
		}

		public RollAndKeep GetPool(TraitCompetence attribute, string cptTag, string speTag)
		{
			Competence cpt = GetCompetenceByTag(cptTag);

			if(cpt == null)
			{
				var pool = Agent.Attributs.GetAttribut(attribute).Pool;
				return pool;
			}
			else
			{
				cpt.SetAttribut(Agent.Attributs.GetAttribut(attribute));
				cpt.Pool.Reroll1 = cpt.HasSpeciality(speTag);
				return cpt.Pool;
			}
		}

		public void ClearList() {
			Competence[] cs = _competences.ToArray();
			foreach(var cpt in _competences) {
				cpt.SetAttribut((Attributs.Attribut)null);
			}
			_competences.Clear();
			/* évènement des compétences retirées */
			RemovedCompetences?.Invoke(this, cs);
		}
	}
}
