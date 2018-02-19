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
	[Table(Schema = "pathfinder",Name = "historiqueclassemodel")]
	[CoreData]
	public partial class HistoriqueClasseModel : AbsOddTableModel {

		private HistoriqueClasseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<HistoriqueClasseDescription> id = GetModelReferencer<HistoriqueClasseDescription>();
					if(id.Count() == 0) {
						_obj = new HistoriqueClasseDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _classeId;
		[Column(Storage = "ClasseId",Name = "fk_classemodel_classe")]
		[HiddenProperty]
		public int ClasseId{
			get{ return _classeId;}
			set{_classeId = value;}
		}

		private ClasseModel _classe;
		public ClasseModel Classe{
			get{
				if( _classe == null)
					_classe = LoadById<ClasseModel>(ClasseId);
				return _classe;
			} set {
				if(_classe == value){return;}
				_classe = value;
				if( value != null)
					ClasseId = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "historiqueclassedescription")]
	public partial class HistoriqueClasseDescription : AbsOddTableDescription {
	}
	[Table(Schema = "pathfinder",Name = "historiqueclasseexemplar")]
	public partial class HistoriqueClasseExemplar : AbsOddTableExemplar {
	}
}
