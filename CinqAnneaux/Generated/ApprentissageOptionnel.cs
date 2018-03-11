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
	[Table(Schema = "cinqanneaux",Name = "apprentissageoptionnelmodel")]
	[CoreData]
	public partial class ApprentissageOptionnelModel : DataModel {

		private ApprentissageOptionnelDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ApprentissageOptionnelDescription> id = GetModelReferencer<ApprentissageOptionnelDescription>();
					if(id.Count() == 0) {
						_obj = new ApprentissageOptionnelDescription();
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
	[Table(Schema = "cinqanneaux",Name = "apprentissageoptionneldescription")]
	public partial class ApprentissageOptionnelDescription : DataDescription<ApprentissageOptionnelModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "apprentissageoptionnelexemplar")]
	public partial class ApprentissageOptionnelExemplar : DataExemplaire<ApprentissageOptionnelModel> {

		private int _nombre;
		[Column(Storage = "nombre",Name = "nombre")]
		public int nombre{
			get{ return _nombre;}
			set{_nombre = value;}
		}
	}
}
