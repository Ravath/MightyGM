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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "listesortmodel")]
	[CoreData]
	public partial class ListeSortModel : DataModel {

		private ListeSortDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ListeSortDescription> id = GetModelReferencer<ListeSortDescription>();
					if(id.Count() == 0) {
						_obj = new ListeSortDescription();
						_obj.Model = this;
						_obj.SaveObject();
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
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

		private int _niveau;
		[Column(Storage = "Niveau",Name = "niveau")]
		public int Niveau{
			get{ return _niveau;}
			set{_niveau = value;}
		}

		private int _sortId;
		[Column(Storage = "SortId",Name = "fk_sortmodel_sort")]
		[HiddenProperty]
		public int SortId{
			get{ return _sortId;}
			set{_sortId = value;}
		}

		private SortModel _sort;
		public SortModel Sort{
			get{
				if( _sort == null)
					_sort = LoadById<SortModel>(SortId);
				return _sort;
			} set {
				if(_sort == value){return;}
				_sort = value;
				if( value != null)
					SortId = value.Id;
			}
		}
	}
	[Table(Schema = "dd35",Name = "listesortdescription")]
	public partial class ListeSortDescription : DataDescription<ListeSortModel> {
	}
	[Table(Schema = "dd35",Name = "listesortexemplar")]
	public partial class ListeSortExemplar : DataExemplaire<ListeSortModel> {
	}
}
