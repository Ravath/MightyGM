using Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Data;
using System.Reflection;

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
	}
}
