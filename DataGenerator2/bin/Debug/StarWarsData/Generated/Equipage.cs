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
	[Table(Schema = "starwars",Name = "equipagemodel")]
	[CoreData]
	public partial class EquipageModel : DataModel {

		private EquipageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EquipageDescription> id = GetModelReferencer<EquipageDescription>();
					if(id.Count() == 0) {
						_obj = new EquipageDescription();
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
	[Table(Schema = "starwars",Name = "equipagedescription")]
	public partial class EquipageDescription : DataDescription<EquipageModel> {
	}
	[Table(Schema = "starwars",Name = "equipageexemplar")]
	public partial class EquipageExemplar : DataExemplaire<EquipageModel> {

		[Column(Name="nombre_min", Storage="NombreMin")]
		[HiddenProperty]
		public int NombreMin{
			get{
				return Nombre.Min;
			}
			set{
				Nombre.Min = value;
			}
		}

		[Column(Name="nombre_max", Storage="NombreMax")]
		[HiddenProperty]
		public int NombreMax{
			get{
				return Nombre.Max;
			}
			set{
				Nombre.Max = value;
			}
		}

		private Range _nombre = new Range();
		public Range Nombre{
			get{
				return _nombre;
			}
			set{
				_nombre = value;
			}
		}


	}
}
