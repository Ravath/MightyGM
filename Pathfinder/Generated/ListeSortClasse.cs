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
	[Table(Schema = "pathfinder",Name = "listesortclassemodel")]
	[CoreData]
	public partial class ListeSortClasseModel : DataModel {

		private ListeSortClasseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ListeSortClasseDescription> id = GetModelReferencer<ListeSortClasseDescription>();
					if(id.Count() == 0) {
						_obj = new ListeSortClasseDescription();
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
			get {
				if(_sort == null) {
					_sort = LoadById<SortModel>(SortId);
			       }
				return _sort;
			} set {
				if(value == _sort) { return; }
				_sort = value;
				if(_sort != null) {
					_sortId = _sort.Id;
				} else {
					_sortId = 0;
				}
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "listesortclassedescription")]
	public partial class ListeSortClasseDescription : DataDescription<ListeSortClasseModel> {
	}
	[Table(Schema = "pathfinder",Name = "listesortclasseexemplar")]
	public partial class ListeSortClasseExemplar : DataExemplaire<ListeSortClasseModel> {

		private bool _maitriseDesSorts;
		[Column(Storage = "MaitriseDesSorts",Name = "maitrisedessorts")]
		public bool MaitriseDesSorts{
			get{ return _maitriseDesSorts;}
			set{_maitriseDesSorts = value;}
		}
	}
}
