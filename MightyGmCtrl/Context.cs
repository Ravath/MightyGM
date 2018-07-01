using Core;
using Core.Contexts;
using Core.Data;
using MightyGmCtrl.Controleurs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MightyGmCtrl
{
	/// <summary>
	/// Global container and general context of the application, with every parameters.
	/// </summary>
	public class Context : IGlobalContext {
		#region Members
		private static Context _ctx;
		#endregion

		#region Properties
		/// <summary>
		/// Singleton access to the application Context.
		/// </summary>
		public static Context MightyGmContext(string uitypeName) {
			if (_ctx == null)
			{
				LinqToDB.Common.Configuration.Linq.GenerateExpressionTest = true;
				_ctx = new Context(uitypeName);
			}
			return _ctx;
		}
		/// <summary>
		/// Files manager of the application.
		/// </summary>
		public FilesControl Files { get; }
		/// <summary>
		/// Jdr/Campaign/session Manager.
		/// </summary>
		public Contexts Contexts { get; }
		/// <summary>
		/// Connexion to the DataBase.
		/// </summary>
		public Database Data { get; internal set; }
		/// <summary>
		/// Current JDR's DataModel.
		/// </summary>
		public DllData Dll { get; internal set; }
		/// <summary>
		/// Textures Manager.
		/// </summary>
		public Textures Textures { get; }
		/// <summary>
		/// Data Import Manager (excel, word,...)
		/// </summary>
		public DataImport DataImport { get; }
		/// <summary>
		/// Data Export Manager (excel, word,...)
		/// </summary>
		public DataExport DataExport { get; }
		/// <summary>
		/// The Audio Manager of the application.
		/// </summary>
		public AudioControl Audio { get; }
		/// <summary>
		/// Manages the events and messages from process.
		/// </summary>
		public EventsReport ReportManager { get; }
		/// <summary>
		/// The current JDR context (Needed for Implementation of interface).
		/// </summary>
		public IJdrContext JdrContext
		{
			get { return Contexts.JdrContext; }
		}
		#endregion

		#region Static
		private static Context _globalContext;
		public static Context GlobalContext { get { return _globalContext; } }
		#endregion

		private Context(string uitypeName) {
			_globalContext = this;

			// Managers instantiation.
			Data = new Database();
			Dll = new DllData(null);
			Contexts = new Contexts(this);
			Files = new FilesControl(this, uitypeName);
			Textures = new Textures(this);
			DataImport = new DataImport(this);
			DataExport = new DataExport(this);
			Audio = new AudioControl(this);
			ReportManager = new EventsReport();

			// Events
			Dll.OnAssemblyChanged += Contexts.OnAssemblyChanged_Event;
		}

		#region Messages Management
		/// <summary>
		/// Report a message directly.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="text"></param>
		public void ReportMessage(MessageType type, string text)
		{
			ReportManager.ReportMessage(type, text);
		}

		/// <summary>
		/// Report an exception.
		/// </summary>
		/// <param name="ex"></param>
		public void ReportException(Exception ex)
		{
			ReportManager.ReportException(ex);
		}

		/// <summary>
		/// Report the given information, converting the reference into a well-sentenced in the current language.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="reference"></param>
		/// <param name="arguments"></param>
		public void ReportMessageRef(MessageType type, string reference, params object[] arguments)
		{
			ReportMessage(type, GetMessageRessource(reference, arguments));
		}

		/// <summary>
		/// Convert the given Tag to the corresponding mesage from the current Messages RessourceManager.
		/// The purpose is usualy to use the loaded language dynamicaly.
		/// </summary>
		/// <param name="reference">The Tag reference to the wanted message.</param>
		/// <returns></returns>
		public string GetMessageRessource(string reference, params object[] arguments)
		{
			return ReportManager.GetMessageRessource(reference, arguments);
		}
		#endregion

		/// <summary>
		/// Get the saved campaigns associated with the given Jdr Context.
		/// </summary>
		/// <param name="defaultJdrContext"></param>
		/// <returns></returns>
		public IEnumerable<ICampaignContext> GetCampaigns(IJdrContext defaultJdrContext)
		{
			throw new NotImplementedException();
		}
	}
}
