using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "sortsquotidiens")]
	[CoreData]
	public partial class SortsQuotidiens : TableSorts {

		private int _classeId;
		[Column(Storage = "ClasseId",Name = "fk_absclassemodel_classe")]
		[HiddenProperty]
		public int ClasseId{
			get{ return _classeId;}
			set{_classeId = value;}
		}

		private AbsClasseModel _classe;
		public AbsClasseModel Classe{
			get {
				if(_classe == null) {
					_classe = LoadById<AbsClasseModel>(ClasseId);
			       }
				return _classe;
			} set {
				if(value == _classe) { return; }
				_classe = value;
				if(_classe != null) {
					_classeId = _classe.Id;
				} else {
					_classeId = 0;
				}
			}
		}
	}
}
