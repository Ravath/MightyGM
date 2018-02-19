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
	[Table(Schema = "pathfinder",Name = "particularitemodel")]
	[CoreData]
	public partial class ParticulariteModel : DataModel {

		private ParticulariteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ParticulariteDescription> id = GetModelReferencer<ParticulariteDescription>();
					if(id.Count() == 0) {
						_obj = new ParticulariteDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeParticularite _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeParticularite Type{
			get{ return _type;}
			set{_type = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "particularitedescription")]
	public partial class ParticulariteDescription : DataDescription<ParticulariteModel> {
	}
	[Table(Schema = "pathfinder",Name = "particulariteexemplar")]
	public partial class ParticulariteExemplar : DataExemplaire<ParticulariteModel> {

		private string _valeur = "";
		[Column(Storage = "Valeur",Name = "valeur")]
		public string Valeur{
			get{ return _valeur;}
			set{_valeur = value;}
		}
	}
}
