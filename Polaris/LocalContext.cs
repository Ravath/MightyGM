using Core.Contexts;
using Polaris.Langues;

namespace CinqAnneaux
{
	public class LocalContext : DefaultJdrContext, IJdrContext
	{

		#region Members
		public override string Name { get { return "Polaris"; } }
		#endregion

		#region Init
		public LocalContext(IGlobalContext global) : base(global, Fr.ResourceManager) { }
		#endregion
	}
}
