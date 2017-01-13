using LinqToDB.Mapping;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data {
	public class DllData {
		#region Members
		private Assembly _assembly;
		private List<Type> _RawData = new List<Type>();
		#endregion
		#region Properties
		/// <summary>
		/// L'assembly, et donc le Jdr correspondant, chargé pour l'instant.
		/// </summary>
		public Assembly Assembly {
			get { return _assembly; }
			set {
				_assembly = value;
				ParseAssembly();
                if(OnAssemblyChanged != null)
					OnAssemblyChanged(this, value);
			}
		}
		public IEnumerable<Type> RawDataTables { get { return _RawData; } }
		#endregion

		public delegate void AssemblyChanged( DllData sender, Assembly newAssembly );
		public event AssemblyChanged OnAssemblyChanged;

		#region Init
		public DllData(Assembly assembly) {
			_assembly = assembly;
			ParseAssembly();
        }
		private void ParseAssembly() {
			initCoreDataList();
		}
		private void initCoreDataList() {
			_RawData.Clear();
			if(_assembly == null)
				return;
			foreach(var tca in _assembly.GetTypes().Where(t => typeof(DataObject).IsAssignableFrom(t))) {
				foreach(var att in tca.GetCustomAttributes(true))//récupérer les dataObject qui ont un attribut CoreData
					if(att is CoreDataAttribute) {
						_RawData.Add(tca);
						break;
					}
			}
		}
		#endregion

		/// <summary>
		/// le premier context local trouvé dans l'assembly.
		/// </summary>
		public ILocalContext LocalContext( IGlobalContext gc ) {
			ILocalContext _local;
            if(_assembly == null)
				_local = null;
			else {//instancier un contexte local
				//prendre le premier implémentant ILocalContext
				Type t = _assembly.GetTypes().Where(ty => typeof(ILocalContext).IsAssignableFrom(ty)).FirstOrDefault();
				if(t == null) { _local = null; return _local; }
				ConstructorInfo ci = t.GetConstructor(new Type[] { typeof(IGlobalContext) });
				if(ci != null) {//essayer avec constructeur prenant le Contexte Global.
					_local = (ILocalContext)ci.Invoke(new object[] { gc });
				} else {//Sinon, constructeur par défaut.
					ci = t.GetConstructor(Type.EmptyTypes);
					_local = (ILocalContext)ci.Invoke(new object[] { });
					_local.Context = gc;
				}
			}
			return _local;
		}

		public bool ExportModeleDataToExcel( Database db, string outputFilePath ) {
			try {
				using(FileStream file = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write)) {
					IWorkbook workbook = new XSSFWorkbook();

					foreach(Type ty in RawDataTables) {
						ImportExcel.CreateSheet(workbook, db, ty);
					}

					workbook.Write(file);
                }
			} catch(IOException) {
				return false;
			}

			return true;
		}


		public bool ExportModeleDataToWord( Type t, Database db, string outputFilePath ) {
			try {
				XWPFDocument doc =  ImportExcel.WriteDocument(t, db);
				using(FileStream out1 = new FileStream(outputFilePath, FileMode.Create)) {
					doc.Write(out1);
				}
			} catch(IOException) {
				return false;
			}

			return true;
		}
	}
}
