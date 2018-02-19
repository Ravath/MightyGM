using Core;
using Core.UI;
using StarWars.Data;
using StarWars.CaracterConstructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsData.CaracterConstructor;

namespace StarWars {
	public class LocalContext : IJdrContext {

		#region Members
		private IGlobalContext _context;
		private static Fiche defaultFiche = new Fiche();
		private List<IFicheCandidate> _listeFiches = new List<IFicheCandidate>();
		private IFicheCandidate FichePersonnage;
		#endregion

		#region Properties
		public IEnumerable<IFicheCandidate> FicheCandidates {
			get {
				return _listeFiches;
			}
		}

		public IGlobalContext UpperContext {
			get { return _context; }
			set {
				_context = value;
			}
		}
		#endregion

		#region Init
		public LocalContext() {
			FichePersonnage = new FicheGestionPersonnage();
			_listeFiches.Add(FichePersonnage);
		}
		public LocalContext( IGlobalContext ctxt )  : this() {
			UpperContext = ctxt;
		}
		#endregion
    }
}
