using Core;
using Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace CoreWpf
{
	public interface IJdrContextWPF : IJdrContextUI
	{
		IEnumerable<IFicheCandidate> FicheCandidatesWPF { get; }
	}

	public class DefaultJdrContextWPF : IJdrContextWPF
	{
		public IGlobalContext GlobalContext { get; private set; }
		public DefaultJdrContextWPF(IGlobalContext global, ResourceManager messages)
		{
			this.messages = messages;
			this.GlobalContext = global;
		}
		private ResourceManager messages;
		private List<IFicheCandidate> _fiches = new List<IFicheCandidate>();
		public IEnumerable<IFicheCandidate> FicheCandidatesWPF
		{
			get { return _fiches; }
		}

		public IEnumerable<object> FicheCandidates
		{
			get { return FicheCandidatesWPF; }
		}

		public void ReportMessage(MessageType type, string Message)
		{
			GlobalContext.ReportMessage(type, Message);
		}

		public void ReportMessageRef(MessageType type, string reference, params object[] arguments)
		{
			ReportMessage(type, GetMessageRessource(reference, arguments));
		}

		public string GetMessageRessource(string reference, params object[] arguments)
		{
			return String.Format(messages.GetString(reference), arguments);
		}

		public void AddFiche(IFicheCandidate fiche)
		{
			_fiches.Add(fiche);
		}
	}
}
