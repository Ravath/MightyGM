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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "adversairemodel")]
	[CoreData]
	public partial class AdversaireModel : PersonnageModel {

		private AdversaireDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AdversaireDescription> id = GetModelReferencer<AdversaireDescription>();
					if(id.Count() == 0) {
						_obj = new AdversaireDescription();
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

		private RangAdversaire _rangAdversite;
		[Column(Storage = "RangAdversite",Name = "rangadversite")]
		public RangAdversaire RangAdversite{
			get{ return _rangAdversite;}
			set{_rangAdversite = value;}
		}
	}
	[Table(Schema = "starwars",Name = "adversairedescription")]
	public partial class AdversaireDescription : PersonnageDescription {
	}
	[Table(Schema = "starwars",Name = "adversaireexemplar")]
	public partial class AdversaireExemplar : PersonnageExemplar {
	}
}
