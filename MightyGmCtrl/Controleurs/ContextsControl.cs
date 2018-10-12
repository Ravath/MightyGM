using Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using System.Reflection;
using System.IO;

namespace MightyGmCtrl.Controleurs
{
	public class Contexts : Controleur
	{
		public delegate void ContextChanged<T>(T newContext) where T : IContext;
		public delegate void JdrContextChanged(IJdrContext newJdrContext, IJdrContextUI newJdrUiContext);
		public event ContextChanged<ICampaignContext> CampaignChanged;
		public event ContextChanged<ISessionContext> SessionChanged;
		public event JdrContextChanged JdrChanged;
		#region members
		private IJdrContext _jdrContext;
		private IJdrContextUI _jdrContextUi;
		private List<JdrAssembly> _jdrAssemblies;
		public IEnumerable<JdrAssembly> JdrAssemblies {
			get
			{
				if(_jdrAssemblies == null)
				{
					_jdrAssemblies = GetJdrAssemblies();
				}
				return _jdrAssemblies;
			}
		}
		public Rpg Rpg { get; private set; }
		#endregion

		public Contexts(Context context) : base(context)
		{
		}

		public IJdrContext JdrContext{
			get { return _jdrContext; }
			private set
			{
				if(value != _jdrContext)
				{
					_jdrContext = value;
					if(value == null)
					{
						_jdrContextUi = null;
					}
					else
					{
						_jdrContextUi = GlobalContext.Files.GetUIDll(value.Name);
					}
					JdrChanged?.Invoke(_jdrContext, _jdrContextUi);
				}
			}
		}

		internal void OnAssemblyChanged_Event(DllData sender, Assembly newAssembly)
		{
			JdrContext = sender.GetJdrContext(GlobalContext);
		}

		internal List<JdrAssembly> GetJdrAssemblies()
		{
			// Init
			List<JdrAssembly> ret = new List<JdrAssembly>();

			// Find the dll modules
			foreach (FileInfo fi in GlobalContext.Files.FindJdrModules())
			{
				if (fi.Extension.ToLower() == ".dll")
				{
					// Create new Assembly
					JdrAssembly newAss = new JdrAssembly()
					{
						Name = fi.Name.Remove(fi.Name.Length - 4, 4),
						DllPath = fi
					};
					ret.Add(newAss);
				}
			}

			// End
			return ret;
		}

		public void SetJdrAssembly(JdrAssembly assembly)
		{
			// Load Dll
			GlobalContext.Dll.SetAssembly(assembly.DllPath.FullName);

			// Get RPG in DB
			var qj = from c in GlobalContext.Data.GetTable<Rpg>()
					 where c.Name == assembly.Name
					 select c;
			Rpg j = qj.SingleOrDefault();

			// Create if doesn't exist
			if (j == null)
			{
				j = new Rpg { Name = assembly.Name };
				j.SaveObject();
			}

			// Keep
			Rpg = j;
		}
	}
}
