using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core;
using Core.Contexts;
using Unbound.Data;
using Unbound.Langues;

namespace Unbound
{
	public class LocalContext : DefaultJdrContext, IJdrContext
	{

		#region Members
		public override string Name { get { return "Unbound"; } }
		#endregion

		#region Init
		public LocalContext(IGlobalContext global) : base(global, Fr.ResourceManager) { }
		#endregion
	}
}
