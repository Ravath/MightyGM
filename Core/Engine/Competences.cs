using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Core.Engine {
	/// <summary>
	/// Un test de compétence, avec une barre de dificulté.
	/// </summary>
	public interface ITest {
		/// <summary>
		/// Le seuil de difficulté, tel qu'utilisé dans la plupart des jdrs.
		/// </summary>
		int Difficulty { get; set; }
	}
	public interface ITestResult {
		/// <summary>
		/// Le test est-il réussit?
		/// </summary>
		bool IsSucces { get; }
	}

	public interface ICompetence {
		/// <summary>
		/// Effectue le test. Doit Assigner un objet à TestResult
		/// </summary>
		/// <param name="conditions">Les conditions, la difficulté du test.</param>
		/// <returns>true if test succeded.</returns>
		ITestResult DoTest( ITest conditions );
	}
	/// <summary>
	/// Une collection de compétences
	/// </summary>
	public class CompetenceCollection : IEnumerable<ICompetence>{

		#region Properties
		public IPersonnage Personnage { get; private set; }
		#endregion

		#region Init
		public CompetenceCollection( IPersonnage perso) {
			Personnage = perso;
        }
		#endregion

		#region Competences Collection
		private List<ICompetence> _competences = new List<ICompetence>();

		public virtual void Add( ICompetence cpt ) {
			_competences.Add(cpt);
		}
		public virtual void Remove( ICompetence cpt ) {
			_competences.Remove(cpt);
		}

		public IEnumerator<ICompetence> GetEnumerator() {
			return _competences.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _competences.GetEnumerator();
		}

		public IEnumerable<ICompetence> GetAll {
			get {
				return _competences;
			}
		} 
		#endregion
	}
}
