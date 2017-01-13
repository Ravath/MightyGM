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
	[Table(Schema = "starwars",Name = "armemodel")]
	[CoreData]
	public partial class ArmeModel : ObjectModel {

		private ArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeDescription> id = GetModelReferencer<ArmeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeDescription();
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

		private int _degats;
		[Column(Storage = "Degats",Name = "degats")]
		public int Degats{
			get{ return _degats;}
			set{_degats = value;}
		}

		private int _critique;
		[Column(Storage = "Critique",Name = "critique")]
		public int Critique{
			get{ return _critique;}
			set{_critique = value;}
		}

		private TypeArme _typeArme;
		[Column(Storage = "TypeArme",Name = "typearme")]
		public TypeArme TypeArme{
			get{ return _typeArme;}
			set{_typeArme = value;}
		}

		private Portee _portee;
		[Column(Storage = "Portee",Name = "portee")]
		public Portee Portee{
			get{ return _portee;}
			set{_portee = value;}
		}

		private int _emplacements;
		[Column(Storage = "Emplacements",Name = "emplacements")]
		public int Emplacements{
			get{ return _emplacements;}
			set{_emplacements = value;}
		}

		private CompetenceDeCombat _competence;
		[Column(Storage = "Competence",Name = "competence")]
		public CompetenceDeCombat Competence{
			get{ return _competence;}
			set{_competence = value;}
		}

		private IEnumerable<AttributArmeExemplar> _attributs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Attributs",OtherKey = "ArmeModelId")]
		public IEnumerable <AttributArmeExemplar> Attributs{
			get{
				if( _attributs == null ){
					_attributs = LoadFromJointure<AttributArmeExemplar,ArmeModelToAttributArmeExemplar>(false);
				}
				return _attributs;
			}
			set{
				SaveToJointure<AttributArmeExemplar, ArmeModelToAttributArmeExemplar> (_attributs, value,false);
				_attributs = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArmeModel,ArmeModelToAttributArmeExemplar>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "starwars",Name = "armedescription")]
	public partial class ArmeDescription : ObjectDescription {
	}
	[Table(Schema = "starwars",Name = "armeexemplar")]
	public partial class ArmeExemplar : ObjectExemplar {

		private IEnumerable<KitExemplar> _kits;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Kits",OtherKey = "ArmeExemplarId")]
		public IEnumerable <KitExemplar> Kits{
			get{
				if( _kits == null ){
					_kits = LoadFromJointure<KitExemplar,ArmeExemplarToKitExemplar>(false);
				}
				return _kits;
			}
			set{
				SaveToJointure<KitExemplar, ArmeExemplarToKitExemplar> (_kits, value,false);
				_kits = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArmeExemplar,ArmeExemplarToKitExemplar>(true);
			base.DeleteObject();
		}
	}
}
