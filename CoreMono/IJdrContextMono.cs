using Core.Contexts;
using CoreMono.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono
{
	public interface IJdrContextMono : IJdrContextUI
	{
		IEnumerable<AbsFicheCandidate> Fiches { get; }
	}
}
