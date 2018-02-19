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
	[Table(Schema = "pathfinder",Name = "armenaturellemodel")]
	[CoreData]
	public partial class ArmeNaturelleModel : DataModel {

		private ArmeNaturelleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeNaturelleDescription> id = GetModelReferencer<ArmeNaturelleDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeNaturelleDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _nombre;
		[Column(Storage = "Nombre",Name = "nombre")]
		public int Nombre{
			get{ return _nombre;}
			set{_nombre = value;}
		}

		private int _nbrDDegats;
		[Column(Storage = "nbrDDegats",Name = "nbrddegats")]
		public int nbrDDegats{
			get{ return _nbrDDegats;}
			set{_nbrDDegats = value;}
		}

		private int _tailleDDegats;
		[Column(Storage = "TailleDDegats",Name = "tailleddegats")]
		public int TailleDDegats{
			get{ return _tailleDDegats;}
			set{_tailleDDegats = value;}
		}

		private int _facteurCritique;
		[Column(Storage = "FacteurCritique",Name = "facteurcritique")]
		public int FacteurCritique{
			get{ return _facteurCritique;}
			set{_facteurCritique = value;}
		}

		private int _zoneCritique;
		[Column(Storage = "ZoneCritique",Name = "zonecritique")]
		public int ZoneCritique{
			get{ return _zoneCritique;}
			set{_zoneCritique = value;}
		}

		private TypeDegatArme _typeDegat;
		[Column(Storage = "TypeDegat",Name = "typedegat")]
		public TypeDegatArme TypeDegat{
			get{ return _typeDegat;}
			set{_typeDegat = value;}
		}

		private bool _secondaire;
		[Column(Storage = "Secondaire",Name = "secondaire")]
		public bool Secondaire{
			get{ return _secondaire;}
			set{_secondaire = value;}
		}

		private IEnumerable<ParticulariteAttaqueExemplar> _special;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Special",OtherKey = "ArmeNaturelleModelId")]
		public IEnumerable <ParticulariteAttaqueExemplar> Special{
			get{
				if( _special == null ){
					_special = LoadFromJointure<ParticulariteAttaqueExemplar,ArmeNaturelleModelToParticulariteAttaqueExemplar_Special>(false);
				}
				return _special;
			}
			set{
				SaveToJointure<ParticulariteAttaqueExemplar, ArmeNaturelleModelToParticulariteAttaqueExemplar_Special> (_special, value,false);
				_special = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArmeNaturelleModel,ArmeNaturelleModelToParticulariteAttaqueExemplar_Special>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "armenaturelledescription")]
	public partial class ArmeNaturelleDescription : DataDescription<ArmeNaturelleModel> {
	}
	[Table(Schema = "pathfinder",Name = "armenaturelleexemplar")]
	public partial class ArmeNaturelleExemplar : DataExemplaire<ArmeNaturelleModel> {
	}
}
