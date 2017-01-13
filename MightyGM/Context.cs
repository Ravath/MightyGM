using Core;
using Core.Data;
using MightyGM.Tabs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MightyGM {
	/// <summary>
	/// Le controleur global et le contexte de l'application, avec tous les paramètres.
	/// </summary>
	public class Context : IGlobalContext {
		#region Members
		private List<Assembly> _assemblies = new List<Assembly>();
		private ILocalContext _localContext;
		#endregion

		#region Properties
		/// <summary>
		/// La connexion à la base de donnée.
		/// </summary>
		public Database Data { get; internal set; }
		/// <summary>
		/// Le modèle de données du JdR courant.
		/// </summary>
		public DllData Dll { get; internal set; }
		/// <summary>
		/// Le contexte local de la base de données.
		/// </summary>
		public ILocalContext LocalContext {
			get { return _localContext; }
			internal set {
				_localContext = value;
				if(LocalContextChanged != null)
					LocalContextChanged(value);
			}
		}

		public TabCreateurs TabCreateurs { get; }
		public TabFiches TabFiches { get; }
		public TabMusique TabMusique { get; }
		public TabNetwork TabNetwork { get; }
		public TabParameters TabParameters { get; }
		public TabRawData TabRawData { get; }
		public TabScenarii TabScenarii { get; }
		public TabTabletop TabTabletop { get; }
		#endregion

		#region Static
		private static Context _globalContext;
		public static Context GlobalContext { get { return _globalContext; } }
		#endregion

		#region Events
		public delegate void LocalContextChangedHandler( ILocalContext local );
		public event LocalContextChangedHandler LocalContextChanged;
		#endregion

		public Context() {
			_globalContext = this;
			Data = new Database();
			Dll = new DllData(null);
			//création dynamique des onglets
			TabCreateurs	= new TabCreateurs(this);
			TabFiches		= new TabFiches(this);
			TabMusique		= new TabMusique(this);
			TabNetwork		= new TabNetwork(this);
			TabParameters	= new TabParameters(this);
			TabRawData		= new TabRawData(this);
			TabScenarii		= new TabScenarii(this);
			TabTabletop		= new TabTabletop(this);
			//Trouver les dlls de modèle
			List<FileInfo> assems = new List<FileInfo>();
			foreach(string dir in Directory.EnumerateDirectories("Modules")){
				foreach(string file	in Directory.EnumerateFiles(dir)) {
					FileInfo fi = new FileInfo(file);
					if(fi.Extension == ".dll") {
						assems.Add(fi);
                    }
				}
			}
			TabParameters.SetAssemblyList(assems);

			//events
			Dll.OnAssemblyChanged += RefreshDllData;
		}

		internal void SetAssembly( string assemblyPath ) {
			Assembly ass = Assembly.LoadFrom(assemblyPath);
			Dll.Assembly = ass;
        }

		public void Message( string text ) {
			TabParameters.Console(text);
		}
		public void ExceptionMessage(Exception ex ) {
			Message(ex.Message);
			Message(ex.StackTrace);
		}

		private void RefreshDllData( DllData sender, Assembly newAssembly ) {
			LocalContext = sender.LocalContext(this);
			TabRawData.InitTypeList(sender.RawDataTables);
        }

	}
}
