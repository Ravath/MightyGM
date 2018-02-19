using Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contexts {
	
	public interface IContext
	{
		void ReportMessageRef(MessageType type, string reference, params object[] arguments);
		void ReportMessage(MessageType type, string Message);
	}

	public interface IMiddleContext<T,U> : IContext
		where T : IContext 
		where U : IContext
	{
		T UpperContext { get; }
		U CurrentSubContext { get; set; }
		IEnumerable<U> GetLowerContexts();
	}

	public interface IGlobalContext : IContext
	{
		Database Data { get; }
		IJdrContext JdrContext { get; }

		IEnumerable<ICampaignContext> GetCampaigns(IJdrContext defaultJdrContext);
	}


	public interface IJdrContext : IMiddleContext<IGlobalContext, ICampaignContext>
	{
		string Name { get; }
	}

	public interface IJdrContextUI : IContext
	{
		IEnumerable<object> FicheCandidates { get; }
	}

	public interface ICampaignContext : IMiddleContext<IJdrContext, ISessionContext>
	{

	}

	public interface ISessionContext : IContext
	{

	}
}
