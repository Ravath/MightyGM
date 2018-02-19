using Core;
using CinqAnneaux.Data;
using CinqAnneaux.JdrCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contexts;
using CinqAnneaux.Langues;

namespace CinqAnneaux
{
	public class LocalContext : DefaultJdrContext, IJdrContext
	{

		#region Members
		public override string Name { get { return "CinqAnneaux"; } }
		#endregion

		#region Init
		public LocalContext(IGlobalContext global) : base(global, Fr.ResourceManager) { }
		#endregion
	}
}
