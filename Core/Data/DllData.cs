using Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core.Data {
	public class DllData {
		#region Members
		private Assembly _assembly;
		private List<Type> _rawData = new List<Type>();
		private List<Type> _jointData = new List<Type>();
		private List<Type> _jointVal = new List<Type>();
		#endregion
		#region Properties
		/// <summary>
		/// L'assembly, et donc le Jdr correspondant, chargé pour l'instant.
		/// </summary>
		public Assembly Assembly {
			get { return _assembly; }
			private set {
				_assembly = value;
				ParseAssembly();
				OnAssemblyChanged?.Invoke(this, value);
			}
		}
		public IEnumerable<Type> RawDataTables { get { return _rawData; } }
		public IEnumerable<Type> JointDataTables { get { return _jointData; } }
		public IEnumerable<Type> JointValueTables { get { return _jointVal; } }
		#endregion

		public delegate void AssemblyChanged( DllData sender, Assembly newAssembly );
		public event AssemblyChanged OnAssemblyChanged;

		#region Init
		public DllData(Assembly assembly) {
			_assembly = assembly;
			ParseAssembly();
        }
		private void ParseAssembly() {
			InitCoreDataList();
		}
		private void InitCoreDataList() {

			// vider les listes de types
			_rawData.Clear();
			_jointData.Clear();
			_jointVal.Clear();

			// vérifier validité
			if (_assembly == null)
				return;

			// Précalculer listes de types
			//CoreData
			foreach(var tca in GetDllTypes<DataObject>()) {
				foreach(var att in tca.GetCustomAttributes(true))//récupérer les dataObject qui ont un attribut CoreData
					if(att is CoreDataAttribute) {
						_rawData.Add(tca);
						break;
					}
			}
			//Jointures
			_jointData.AddRange(GetDllTypes<IDataRelation>());
			_jointVal.AddRange(GetDllTypes<IDataValue>());
		}

		public void SetAssembly(string assemblyPath)
		{
			Assembly ass = Assembly.LoadFrom(assemblyPath);
			Assembly = ass;
		}
		#endregion

		/// <summary>
		/// Récupère parmis les types définis dans la DLL, ceux qui héritent du type donné.
		/// Types à privilégier (et/ou leurs interfaces):
		///  - DataObject
		///   - DataModel
		///   - DataDescription<T:DataModel>
		///   - DataExemplaire<T:DataModel>
		///   - DataRelation<T:DataObject U:DataObject>
		///   - DataValue<F:DataObject val>
		/// </summary>
		/// <typeparam name="T">Type parent à rechercher.</typeparam>
		/// <returns></returns>
		public IEnumerable<Type> GetDllTypes<T>()
		{
			return _assembly.GetTypes().Where(t => typeof(T).IsAssignableFrom(t));
		}

		/// <summary>
		/// le premier context local trouvé dans l'assembly.
		/// </summary>
		/// <param name="gc">Le GlobalContext à associer.</param>
		/// <returns>Le local context de cette Dll.</returns>
		public IJdrContext GetJdrContext( IGlobalContext gc ) {
			IJdrContext _local;
            if(_assembly == null)
				_local = null;
			else {
				//instancier un contexte local
				//prendre le premier implémentant ILocalContext
				Type t = _assembly.GetTypes().Where(ty => typeof(IJdrContext).IsAssignableFrom(ty)).FirstOrDefault();
				if(t == null) { _local = null; return _local; }
				ConstructorInfo ci = t.GetConstructor(new Type[] { typeof(IGlobalContext) });
				if(ci != null) {//essayer avec constructeur prenant le Contexte Global.
					_local = (IJdrContext)ci.Invoke(new object[] { gc });
				} else {//Sinon, rien.
					_local = null;
				}
			}
			return _local;
		}

		public IJdrContextUI GetUiContext(string assemblyPath, IGlobalContext gc)
		{
			Assembly ass = Assembly.LoadFrom(assemblyPath);
			if(ass != null)
			{
				var types = _assembly.GetTypes();
				Type t = ass.GetTypes().FirstOrDefault(ty => typeof(IJdrContextUI).IsAssignableFrom(ty));
				if (t!= null)
				{
					ConstructorInfo ci = t.GetConstructor(new Type[] { typeof(IGlobalContext) });
					if (ci != null)
					{
						//essayer avec constructeur prenant le Contexte Global.
						return (IJdrContextUI)ci.Invoke(new object[] { gc });
					}
				}
			}
			gc.ReportMessageRef(MessageType.ERROR, "UI_DLL_NOT_LOADED", assemblyPath);
			return null;
		}
	}
}
