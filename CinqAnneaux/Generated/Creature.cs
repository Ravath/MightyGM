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
	[Table(Schema = "cinqanneaux",Name = "creaturemodel")]
	[CoreData]
	public partial class CreatureModel : PersonnageModel {

		private CreatureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CreatureDescription> id = GetModelReferencer<CreatureDescription>();
					if(id.Count() == 0) {
						_obj = new CreatureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int? _vide;
		[Column(Storage = "Vide",Name = "vide")]
		public int? Vide{
			get{ return _vide;}
			set{_vide = value;}
		}

		private int? _souillure;
		[Column(Storage = "Souillure",Name = "souillure")]
		public int? Souillure{
			get{ return _souillure;}
			set{_souillure = value;}
		}

		private int _nDArmure;
		[Column(Storage = "NDArmure",Name = "ndarmure")]
		public int NDArmure{
			get{ return _nDArmure;}
			set{_nDArmure = value;}
		}

		private int _reduction;
		[Column(Storage = "Reduction",Name = "reduction")]
		public int Reduction{
			get{ return _reduction;}
			set{_reduction = value;}
		}

		private int _xgInitiative;
		[Column(Storage = "xgInitiative",Name = "xginitiative")]
		public int xgInitiative{
			get{ return _xgInitiative;}
			set{_xgInitiative = value;}
		}

		private int _gxInitiative;
		[Column(Storage = "gxInitiative",Name = "gxinitiative")]
		public int gxInitiative{
			get{ return _gxInitiative;}
			set{_gxInitiative = value;}
		}

		private int _bless5;
		[Column(Storage = "Bless5",Name = "bless5")]
		public int Bless5{
			get{ return _bless5;}
			set{_bless5 = value;}
		}

		private int _bless10;
		[Column(Storage = "Bless10",Name = "bless10")]
		public int Bless10{
			get{ return _bless10;}
			set{_bless10 = value;}
		}

		private int _bless15;
		[Column(Storage = "Bless15",Name = "bless15")]
		public int Bless15{
			get{ return _bless15;}
			set{_bless15 = value;}
		}

		private int _vieMax;
		[Column(Storage = "VieMax",Name = "viemax")]
		public int VieMax{
			get{ return _vieMax;}
			set{_vieMax = value;}
		}

		private bool _vieHumaine;
		[Column(Storage = "VieHumaine",Name = "viehumaine")]
		public bool VieHumaine{
			get{ return _vieHumaine;}
			set{_vieHumaine = value;}
		}

		private IEnumerable<AttaqueCreature> _attaques;
		public IEnumerable <AttaqueCreature> Attaques{
			get{
				if( _attaques == null ){
					_attaques = LoadByForeignKey<AttaqueCreature>(p => p.CreatureId, Id);
				}
				return _attaques;
			}
			set{
				foreach( AttaqueCreature item in _attaques ){
					item.Creature = null;

				}
				_attaques = value;
				foreach( AttaqueCreature item in value ){
					item.Creature = this;
					item.SaveObject();
				}
			}
		}

		private TypeCreature _typeCreature;
		[Column(Storage = "TypeCreature",Name = "typecreature")]
		public TypeCreature TypeCreature{
			get{ return _typeCreature;}
			set{_typeCreature = value;}
		}

		private IEnumerable<PouvoirCreatureExemplar> _pouvoirs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Pouvoirs",OtherKey = "CreatureModelId")]
		public IEnumerable <PouvoirCreatureExemplar> Pouvoirs{
			get{
				if( _pouvoirs == null ){
					_pouvoirs = LoadFromJointure<PouvoirCreatureExemplar,CreatureModelToPouvoirCreatureExemplar_Pouvoirs>(false);
				}
				return _pouvoirs;
			}
			set{
				SaveToJointure<PouvoirCreatureExemplar, CreatureModelToPouvoirCreatureExemplar_Pouvoirs> (_pouvoirs, value,false);
				_pouvoirs = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<CreatureModel,CreatureModelToPouvoirCreatureExemplar_Pouvoirs>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "creaturedescription")]
	public partial class CreatureDescription : PersonnageDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "creatureexemplar")]
	public partial class CreatureExemplar : PersonnageExemplar {
	}
}
