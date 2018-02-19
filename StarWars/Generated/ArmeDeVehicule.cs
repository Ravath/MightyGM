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
	[Table(Schema = "starwars",Name = "armedevehiculemodel")]
	[CoreData]
	public partial class ArmeDeVehiculeModel : ArmeModel {

		private ArmeDeVehiculeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeDeVehiculeDescription> id = GetModelReferencer<ArmeDeVehiculeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeDeVehiculeDescription();
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
	}
	[Table(Schema = "starwars",Name = "armedevehiculedescription")]
	public partial class ArmeDeVehiculeDescription : ArmeDescription {
	}
	[Table(Schema = "starwars",Name = "armedevehiculeexemplar")]
	public partial class ArmeDeVehiculeExemplar : ArmeExemplar {

		private int _nombre;
		[Column(Storage = "Nombre",Name = "nombre")]
		public int Nombre{
			get{ return _nombre;}
			set{_nombre = value;}
		}

		private ArcTir _arcDeTir;
		[Column(Storage = "ArcDeTir",Name = "arcdetir")]
		public ArcTir ArcDeTir{
			get{ return _arcDeTir;}
			set{_arcDeTir = value;}
		}
	}
}
