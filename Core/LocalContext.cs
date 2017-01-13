using Core.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Core {
	public interface ILocalContext {

		IGlobalContext Context { get; set; }

		IEnumerable<IFicheCandidate> FicheCandidates { get; }

	}

	public interface IFicheCandidate {
		string Name { get; }
		UserControl Control { get; }
		void Afficher( IGlobalContext c );
    }
}
