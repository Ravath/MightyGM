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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "tableheritageconsequencesmodel")]
	[CoreData]
	public partial class TableHeritageConsequencesModel : DataModel {

		private TableHeritageConsequencesDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TableHeritageConsequencesDescription> id = GetModelReferencer<TableHeritageConsequencesDescription>();
					if(id.Count() == 0) {
						_obj = new TableHeritageConsequencesDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _tableHeritageId;
		[Column(Storage = "TableHeritageId",Name = "fk_tableheritagemodel_tableheritage")]
		[HiddenProperty]
		public int TableHeritageId{
			get{ return _tableHeritageId;}
			set{_tableHeritageId = value;}
		}

		private TableHeritageModel _tableHeritage;
		public TableHeritageModel TableHeritage{
			get {
				if(_tableHeritage == null) {
					_tableHeritage = LoadById<TableHeritageModel>(TableHeritageId);
			       }
				return _tableHeritage;
			} set {
				if(value == _tableHeritage) { return; }
				_tableHeritage = value;
				if(_tableHeritage != null) {
					_tableHeritageId = _tableHeritage.Id;
				} else {
					_tableHeritageId = 0;
				}
			}
		}

		private int _chances;
		[Column(Storage = "Chances",Name = "chances")]
		public int Chances{
			get{ return _chances;}
			set{_chances = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "tableheritageconsequencesdescription")]
	public partial class TableHeritageConsequencesDescription : DataDescription<TableHeritageConsequencesModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "tableheritageconsequencesexemplar")]
	public partial class TableHeritageConsequencesExemplar : DataExemplaire<TableHeritageConsequencesModel> {
	}
}
