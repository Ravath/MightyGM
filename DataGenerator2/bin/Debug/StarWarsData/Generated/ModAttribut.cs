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
	[Table(Schema = "starwars",Name = "modattributmodel")]
	[CoreData]
	public partial class ModAttributModel : ModModel {

		private ModAttributDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ModAttributDescription> id = GetModelReferencer<ModAttributDescription>();
					if(id.Count() == 0) {
						_obj = new ModAttributDescription();
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

		private int _attributId;
		[Column(Storage = "AttributId",Name = "fk_attributarmemodel")]
		[HiddenProperty]
		public int AttributId{
			get{ return _attributId;}
			set{_attributId = value;}
		}

		private AttributArmeModel _attribut;
		public AttributArmeModel Attribut{
			get{
				if( _attribut == null)
					_attribut = LoadById<AttributArmeModel>(AttributId);
				return _attribut;
			} set {
				if(_attribut == value){return;}
				_attribut = value;
				if( value != null)
					AttributId = value.Id;
			}
		}
	}
	[Table(Schema = "starwars",Name = "modattributdescription")]
	public partial class ModAttributDescription : ModDescription {
	}
	[Table(Schema = "starwars",Name = "modattributexemplar")]
	public partial class ModAttributExemplar : ModExemplar {
	}
}
