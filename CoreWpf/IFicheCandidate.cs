using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Core;
using Core.Contexts;

namespace CoreWpf
{
	public interface IFicheCandidate
	{
		string FicheName { get; }
		UserControl Control { get; }
		void Afficher(IGlobalContext c);
	}
}
