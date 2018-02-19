using CinqAnneaux.JdrCore.Agent;
using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Ecoles {
	public class ListeEcoles : AgentPart<Personnage> {

		private List<Ecole> _ecoles = new List<Ecole>();

		public ListeEcoles(Personnage perso): base(perso) {

		}

		public void AddEcole(Ecole e, int rank ) {
			e.Rank.BaseValue = rank;
            _ecoles.Add(e);
			for(int i=1; i<= rank; i++) {
				Agent.Techniques.AddTrait(e.Techniques[i]);
            }
			e.Rank.ValueChanged += V_ValueChanged;
		}

		private void V_ValueChanged( IValue ival, int newValue, int oldValue ) {
			foreach(Ecole item in _ecoles) {
				if(item.Rank == ival) {//find the sender
					if(newValue > oldValue) {
						// add new techniques
						for(int i = oldValue+1; i <=newValue; i++) {
							Agent.Techniques.AddTrait(item.Techniques[i]);
						}
					} else if(newValue < oldValue) {//should not be equal, but for security
						//remove old techniques
						for(int i = oldValue; i < newValue; i--) {
							Agent.Techniques.RemoveTrait(item.Techniques[i]);
						}
					}
				}
			}
		}

		internal void ClearSchools() {
			Agent.Techniques.Clear();
            _ecoles.Clear();
        }
	}
}
