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
	[Table(Schema = "cinqanneaux",Name = "equipementoptionnelmodel")]
	[CoreData]
	public partial class EquipementOptionnelModel : DataModel {

		private EquipementOptionnelDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EquipementOptionnelDescription> id = GetModelReferencer<EquipementOptionnelDescription>();
					if(id.Count() == 0) {
						_obj = new EquipementOptionnelDescription();
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
	[Table(Schema = "cinqanneaux",Name = "equipementoptionneldescription")]
	public partial class EquipementOptionnelDescription : DataDescription<EquipementOptionnelModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "equipementoptionnelexemplar")]
	public partial class EquipementOptionnelExemplar : DataExemplaire<EquipementOptionnelModel> {

		private int _nombre;
		[Column(Storage = "nombre",Name = "nombre")]
		public int nombre{
			get{ return _nombre;}
			set{_nombre = value;}
		}
	}
}
