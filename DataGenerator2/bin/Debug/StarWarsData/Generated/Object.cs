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
	[Table(Schema = "starwars",Name = "objectmodel")]
	[CoreData]
	public partial class ObjectModel : DataModel {

		private ObjectDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ObjectDescription> id = GetModelReferencer<ObjectDescription>();
					if(id.Count() == 0) {
						_obj = new ObjectDescription();
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

		private int _prix;
		[Column(Storage = "prix",Name = "prix")]
		public int prix{
			get{ return _prix;}
			set{_prix = value;}
		}

		private int _rarete;
		[Column(Storage = "Rarete",Name = "rarete")]
		public int Rarete{
			get{ return _rarete;}
			set{_rarete = value;}
		}

		private TypeObject _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeObject Type{
			get{ return _type;}
			set{_type = value;}
		}

		private bool _interdit;
		[Column(Storage = "Interdit",Name = "interdit")]
		public bool Interdit{
			get{ return _interdit;}
			set{_interdit = value;}
		}

		private int _encombrement;
		[Column(Storage = "Encombrement",Name = "encombrement")]
		public int Encombrement{
			get{ return _encombrement;}
			set{_encombrement = value;}
		}


		private IEnumerable < ModelesFromObjectModel > _modeles;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Modeles",OtherKey = "ObjectModel")]
		public IEnumerable < ModelesFromObjectModel > Modeles{
			get{
				if( _modeles == null ){
					_modeles = LoadByForeignKey<ModelesFromObjectModel>(p => p.ObjectModelId, Id);
				}
				return _modeles;
			}
			set{
				foreach( var item in _modeles ){
					item.From = null;
				}
				_modeles = value;
				foreach( var item in value ){
					item.From = this;
				}
			}
		}
	}
	[Table(Schema = "starwars",Name = "objectdescription")]
	public partial class ObjectDescription : DataDescription<ObjectModel> {

		private string _reglementation;
		[LargeText]
		[Column(Storage = "Reglementation",Name = "reglementation")]
		public string Reglementation{
			get{ return _reglementation;}
			set{_reglementation = value;}
		}
	}
	[Table(Schema = "starwars",Name = "objectexemplar")]
	public partial class ObjectExemplar : DataExemplaire<ObjectModel> {

		private Endomagement _dommages;
		[Column(Storage = "Dommages",Name = "dommages")]
		public Endomagement Dommages{
			get{ return _dommages;}
			set{_dommages = value;}
		}

		private string _modele;
		[Column(Storage = "Modele",Name = "modele")]
		public string Modele{
			get{ return _modele;}
			set{_modele = value;}
		}
	}
}
