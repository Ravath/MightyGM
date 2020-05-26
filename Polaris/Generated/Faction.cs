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
	[Table(Schema = "polaris",Name = "factionmodel")]
	[CoreData]
	public partial class FactionModel : DataModel {

		private FactionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FactionDescription> id = GetModelReferencer<FactionDescription>();
					if(id.Count() == 0) {
						_obj = new FactionDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}
	}
	[Table(Schema = "polaris",Name = "factiondescription")]
	public partial class FactionDescription : DataDescription<FactionModel> {


		private IEnumerable < string > _sousDivision;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "SousDivision",OtherKey = "FactionDescription")]
		public IEnumerable < string > SousDivision{
			get{
				if( _sousDivision == null ){
					_sousDivision = LoadFromDataValue<SousDivisionFromFactionDescription, string>();
				}
				return _sousDivision;
			}
			set{
				SaveDataValue<SousDivisionFromFactionDescription, string>(_sousDivision, value);
			}
		}
		public override void DeleteObject() {
			DeleteDataValue<SousDivisionFromFactionDescription>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "factionexemplar")]
	public partial class FactionExemplar : DataExemplaire<FactionModel> {
	}
}
