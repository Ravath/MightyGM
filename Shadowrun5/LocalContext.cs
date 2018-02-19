using Core;
using Core.Contexts;
using Shadowrun5.Langues;

namespace Shadowrun5 {
	public class LocalContext : DefaultJdrContext, IJdrContext {

		#region Members
		public override string Name { get { return "Shadowrun5"; } }
		#endregion

		#region Init

		public LocalContext( IGlobalContext ctxt ) : base(ctxt ,Fr.ResourceManager) { }
		#endregion
	}
}
