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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "personnalitemodel")]
	[CoreData]
	public partial class PersonnaliteModel : DataModel {

		private PersonnaliteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PersonnaliteDescription> id = GetModelReferencer<PersonnaliteDescription>();
					if(id.Count() == 0) {
						_obj = new PersonnaliteDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _nationId;
		[Column(Storage = "NationId",Name = "fk_nationmodel_nation")]
		[HiddenProperty]
		public int NationId{
			get{ return _nationId;}
			set{_nationId = value;}
		}

		private NationModel _nation;
		public NationModel Nation{
			get {
				if(_nation == null) {
					_nation = LoadById<NationModel>(NationId);
			       }
				return _nation;
			} set {
				if(value == _nation) { return; }
				_nation = value;
				if(_nation != null) {
					_nationId = _nation.Id;
				} else {
					_nationId = 0;
				}
			}
		}
	}
	[Table(Schema = "polaris",Name = "personnalitedescription")]
	public partial class PersonnaliteDescription : DataDescription<PersonnaliteModel> {
	}
	[Table(Schema = "polaris",Name = "personnaliteexemplar")]
	public partial class PersonnaliteExemplar : DataExemplaire<PersonnaliteModel> {
	}
}
