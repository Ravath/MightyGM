using Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyGmCtrl.Controleurs
{
	public class Controleur
	{
		#region members
		private Context _context;
		/// <summary>
		/// le niveau de progression du processus en cours.
		/// </summary>
		private int iProg;
		/// <summary>
		/// Le nombre d'étapes du processus en cours.
		/// </summary>
		private int nbrEtapes;
		#endregion
		#region Properties
		protected Context GlobalContext{ get { return _context; } }
		#endregion
		#region Init
		public Controleur(Context context)
		{
			_context = context;
		}
		#endregion
		
		public string GetMessageRessource(string reference, params object[] args)
		{
			return GlobalContext.GetMessageRessource(reference, args);
		}

		protected void ReportMessageRef(MessageType type, string reference, params object[] args)
		{
			ReportMessage(type, GetMessageRessource(reference, args));
		}
		/// <summary>
		/// Report a message.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="message"></param>
		protected void ReportMessage(MessageType type, string message)
		{
			GlobalContext.ReportMessage(type, message);
		}
		/// <summary>
		/// Report an occured axception.
		/// </summary>
		/// <param name="ex"></param>
		protected void ReportException(Exception ex)
		{
			GlobalContext.ReportManager.ReportException(ex);
		}
		/// <summary>
		/// Report the current process avancement.
		/// </summary>
		/// <param name="percentageAvancement"></param>
		private void ReportProgress(double percentageAvancement)
		{
			GlobalContext.ReportManager.ReportProgress(percentageAvancement);
		}
		/// <summary>
		/// Report the end of the current process.
		/// </summary>
		/// <param name="processName"></param>
		/// <param name="success"></param>
		protected void ReportSuccess(string processName, bool success)
		{
			GlobalContext.ReportManager.ReportEndOfProcess(processName, success);
		}

		public void SetNbrEtapes(int nbrEtapes)
		{
			this.nbrEtapes = nbrEtapes;
		}

		public void SetFinEtape()
		{
			ReportProgress( ((double)++iProg / (double)nbrEtapes) );
		}
	}
}
