using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data
{
	[Table(Schema = "core",Name = "rawressource")]
	[CoreData]
	public partial class RawRessource : Ressource {

		private int _dBId;
		[Column(Storage = "DBId",Name = "fk_ressourcebase_db")]
		[HiddenProperty]
		public int DBId{
			get{ return _dBId;}
			set{_dBId = value;}
		}

		private RessourceBase _dB;
		public RessourceBase DB{
			get{
				if( _dB == null)
					_dB = LoadById<RessourceBase>(DBId);
				return _dB;
			} set {
				if(_dB == value){return;}
				_dB = value;
				if( value != null)
					DBId = value.Id;
			}
		}

		private RawRessourceType _ressourceType;
		[Column(Storage = "RessourceType",Name = "ressourcetype")]
		public RawRessourceType RessourceType{
			get{ return _ressourceType;}
			set{_ressourceType = value;}
		}

		private string _path = "";
		[Column(Storage = "Path",Name = "path")]
		public string Path{
			get{ return _path;}
			set{_path = value;}
		}
	}
}
