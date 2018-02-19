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
	[Table(Schema = "pathfinder",Name = "donhistoiremodel")]
	[CoreData]
	public partial class DonHistoireModel : DataModel {

		private DonHistoireDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DonHistoireDescription> id = GetModelReferencer<DonHistoireDescription>();
					if(id.Count() == 0) {
						_obj = new DonHistoireDescription();
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
	[Table(Schema = "pathfinder",Name = "donhistoiredescription")]
	public partial class DonHistoireDescription : DataDescription<DonHistoireModel> {

		private string _conditionRequise = "";
		[LargeText]
		[Column(Storage = "ConditionRequise",Name = "conditionrequise")]
		public string ConditionRequise{
			get{ return _conditionRequise;}
			set{_conditionRequise = value;}
		}

		private string _avantage = "";
		[LargeText]
		[Column(Storage = "Avantage",Name = "avantage")]
		public string Avantage{
			get{ return _avantage;}
			set{_avantage = value;}
		}

		private string _objectif = "";
		[LargeText]
		[Column(Storage = "Objectif",Name = "objectif")]
		public string Objectif{
			get{ return _objectif;}
			set{_objectif = value;}
		}

		private string _avantageReussite = "";
		[LargeText]
		[Column(Storage = "AvantageReussite",Name = "avantagereussite")]
		public string AvantageReussite{
			get{ return _avantageReussite;}
			set{_avantageReussite = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "donhistoireexemplar")]
	public partial class DonHistoireExemplar : DataExemplaire<DonHistoireModel> {
	}
}
