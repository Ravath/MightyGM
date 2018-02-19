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
	[Table(Schema = "dd35",Name = "donmodel")]
	[CoreData]
	public partial class DonModel : DataModel {

		private DonDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DonDescription> id = GetModelReferencer<DonDescription>();
					if(id.Count() == 0) {
						_obj = new DonDescription();
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

		private TypeDon _typeDon;
		[Column(Storage = "TypeDon",Name = "typedon")]
		public TypeDon TypeDon{
			get{ return _typeDon;}
			set{_typeDon = value;}
		}

		private bool _donMartial;
		[Column(Storage = "DonMartial",Name = "donmartial")]
		public bool DonMartial{
			get{ return _donMartial;}
			set{_donMartial = value;}
		}
	}
	[Table(Schema = "dd35",Name = "dondescription")]
	public partial class DonDescription : DataDescription<DonModel> {

		private string _conditions = "";
		[LargeText]
		[Column(Storage = "Conditions",Name = "conditions")]
		public string Conditions{
			get{ return _conditions;}
			set{_conditions = value;}
		}

		private string _avantage = "";
		[LargeText]
		[Column(Storage = "Avantage",Name = "avantage")]
		public string Avantage{
			get{ return _avantage;}
			set{_avantage = value;}
		}

		private string _special = "";
		[LargeText]
		[Column(Storage = "Special",Name = "special")]
		public string Special{
			get{ return _special;}
			set{_special = value;}
		}
	}
	[Table(Schema = "dd35",Name = "donexemplar")]
	public partial class DonExemplar : DataExemplaire<DonModel> {
	}
}
