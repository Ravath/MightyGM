using Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MightyGmCtrl.Controleurs
{
	public class EventsReport
	{
		/// <summary>
		/// Fichier de ressources contenant tous les messages de l'application destinés à l'utilisateur.
		/// </summary>
		protected ResourceManager Messages { get; private set; }

		//TODO new DLLDataLoaded
		//TODO new DllGuiLoaded
		//TODO new ContextLoaded(jdr, campagne, chapter, session)
		public delegate void ReportMessageHandler(MessageType type, string message);
		public delegate void ReportExeptionHandler(Exception percentage);
		public delegate void ReportProgressHandler(double percentage);
		public delegate void ReportEndHandler(string processName, bool success);
		public event ReportMessageHandler MessageEvent;
		public event ReportExeptionHandler ProcessExceptionEvent;
		public event ReportProgressHandler ProgressEvent;
		public event ReportEndHandler EndOfProcessEvent;

		public EventsReport()
		{
			//Les messages sont en français par défaut
			Messages = Langues.Fr.ResourceManager;
		}

		public void ReportMessage(MessageType type, string message)
		{
			MessageEvent?.Invoke(type, message);
		}

		public void ReportProgress(double percentage)
		{
			ProgressEvent?.Invoke(percentage);
		}

		public void ReportEndOfProcess(string processName, bool success)
		{
			EndOfProcessEvent?.Invoke(GetMessageRessource(processName), success);
		}

		public void ReportException(Exception ex)
		{
			ProcessExceptionEvent?.Invoke(ex);
		}

		public string GetMessageRessource(string reference, params object[] arguments)
		{
			return String.Format( Messages.GetString(reference), arguments);
		}
	}
}