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
	[Table(Schema = "polaris",Name = "villemajeuremodel")]
	[CoreData]
	public partial class VilleMajeureModel : DataModel {

		private VilleMajeureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<VilleMajeureDescription> id = GetModelReferencer<VilleMajeureDescription>();
					if(id.Count() == 0) {
						_obj = new VilleMajeureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _villeId;
		[Column(Storage = "VilleId",Name = "fk_villemodel_ville")]
		[HiddenProperty]
		public int VilleId{
			get{ return _villeId;}
			set{_villeId = value;}
		}

		private VilleModel _ville;
		public VilleModel Ville{
			get{
				if( _ville == null)
					_ville = LoadById<VilleModel>(VilleId);
				return _ville;
			} set {
				if(_ville == value){return;}
				_ville = value;
				if( value != null)
					VilleId = value.Id;
			}
		}

		private string _gouvernement = "";
		[Column(Storage = "Gouvernement",Name = "gouvernement")]
		public string Gouvernement{
			get{ return _gouvernement;}
			set{_gouvernement = value;}
		}

		private string _dirigeant = "";
		[Column(Storage = "Dirigeant",Name = "dirigeant")]
		public string Dirigeant{
			get{ return _dirigeant;}
			set{_dirigeant = value;}
		}
	}
	[Table(Schema = "polaris",Name = "villemajeuredescription")]
	public partial class VilleMajeureDescription : DataDescription<VilleMajeureModel> {
	}
	[Table(Schema = "polaris",Name = "villemajeureexemplar")]
	public partial class VilleMajeureExemplar : DataExemplaire<VilleMajeureModel> {
	}
}
