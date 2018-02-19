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
	[Table(Schema = "cinqanneaux",Name = "techniqueavanceemodel")]
	[CoreData]
	public partial class TechniqueAvanceeModel : DataModel {

		private TechniqueAvanceeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TechniqueAvanceeDescription> id = GetModelReferencer<TechniqueAvanceeDescription>();
					if(id.Count() == 0) {
						_obj = new TechniqueAvanceeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _ecoleId;
		[Column(Storage = "EcoleId",Name = "fk_ecoleavanceemodel_ecole")]
		[HiddenProperty]
		public int EcoleId{
			get{ return _ecoleId;}
			set{_ecoleId = value;}
		}

		private EcoleAvanceeModel _ecole;
		public EcoleAvanceeModel Ecole{
			get {
				if(_ecole == null) {
					_ecole = LoadById<EcoleAvanceeModel>(EcoleId);
			       }
				return _ecole;
			} set {
				if(value == _ecole) { return; }
				_ecole = value;
				if(_ecole != null) {
					_ecoleId = _ecole.Id;
				} else {
					_ecoleId = 0;
				}
			}
		}

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "techniqueavanceedescription")]
	public partial class TechniqueAvanceeDescription : DataDescription<TechniqueAvanceeModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "techniqueavanceeexemplar")]
	public partial class TechniqueAvanceeExemplar : DataExemplaire<TechniqueAvanceeModel> {
	}
}
