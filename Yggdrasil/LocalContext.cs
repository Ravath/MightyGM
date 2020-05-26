using Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yggdrasil.Langues;

namespace Yggdrasil
{
	public class LocalContext : DefaultJdrContext, IJdrContext
	{

		#region Members
		public override string Name { get { return "Yggdrasil"; } }
		#endregion

		#region Init
		public LocalContext(IGlobalContext global) : base(global, Fr.ResourceManager) { }
		#endregion
	}
}
