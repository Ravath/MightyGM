using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contexts
{
	public abstract class DefaultJdrContext : IJdrContext
	{
		protected ResourceManager MessagesRessources { get; }
		public IGlobalContext UpperContext { get; }
		public ICampaignContext CurrentSubContext { get; set; }
		public abstract string Name { get; }

		public DefaultJdrContext(IGlobalContext global, ResourceManager messages)
		{
			UpperContext = global;
			MessagesRessources = messages;
		}

		public string GetMessageRessource(string reference, params object[] arguments)
		{
			return String.Format(MessagesRessources.GetString(reference), arguments);
		}

		public void ReportMessageRef(MessageType type, string reference, params object[] arguments)
		{
			ReportMessage(type, GetMessageRessource(reference, arguments));
		}

		public void ReportMessage(MessageType type, string message)
		{
			UpperContext.ReportMessage(type, message);
		}

		public IEnumerable<ICampaignContext> GetLowerContexts()
		{
			return UpperContext.GetCampaigns(this);
		}
	}
}
