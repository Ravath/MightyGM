using Core;
using Core.UI;
using System;
using System.Collections.Generic;

namespace Pathfinder {
	public class LocalContext : IJdrContext {

		#region Members
		private List<IFicheCandidate> _listeFiches = new List<IFicheCandidate>();
		private IGlobalContext _context;
		#endregion

		#region Init
		public LocalContext() {
			/* instanciate fiches */

		}

		public LocalContext( IGlobalContext ctxt ) : this() {
			UpperContext = ctxt;
		}
		#endregion

		public IGlobalContext UpperContext {
			get { return _context; }
			set {
				_context = value;
			}
		}

		public IEnumerable<IFicheCandidate> FicheCandidates {
			get {
				return _listeFiches;
            }
		}
	}
}
