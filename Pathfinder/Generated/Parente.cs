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
	[Table(Schema = "pathfinder",Name = "parentemodel")]
	[CoreData]
	public partial class ParenteModel : DataModel {

		private ParenteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ParenteDescription> id = GetModelReferencer<ParenteDescription>();
					if(id.Count() == 0) {
						_obj = new ParenteDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _raceId;
		[Column(Storage = "RaceId",Name = "fk_racemodel_race")]
		[HiddenProperty]
		public int RaceId{
			get{ return _raceId;}
			set{_raceId = value;}
		}

		private RaceModel _race;
		public RaceModel Race{
			get{
				if( _race == null)
					_race = LoadById<RaceModel>(RaceId);
				return _race;
			} set {
				if(_race == value){return;}
				_race = value;
				if( value != null)
					RaceId = value.Id;
			}
		}

		private IEnumerable<PaysNatal> _paysNatal;
		public IEnumerable <PaysNatal> PaysNatal{
			get{
				if( _paysNatal == null ){
					_paysNatal = LoadByForeignKey<PaysNatal>(p => p.ParenteId, Id);
				}
				return _paysNatal;
			}
			set{
				foreach( PaysNatal item in _paysNatal ){
					item.Parente = null;

				}
				_paysNatal = value;
				foreach( PaysNatal item in value ){
					item.Parente = this;
					item.SaveObject();
				}
			}
		}

		private int _chancesParentsEnVie;
		[Column(Storage = "ChancesParentsEnVie",Name = "chancesparentsenvie")]
		public int ChancesParentsEnVie{
			get{ return _chancesParentsEnVie;}
			set{_chancesParentsEnVie = value;}
		}

		private int _chancesPereEnVie;
		[Column(Storage = "ChancesPereEnVie",Name = "chancespereenvie")]
		public int ChancesPereEnVie{
			get{ return _chancesPereEnVie;}
			set{_chancesPereEnVie = value;}
		}

		private int _chancesMereEnVie;
		[Column(Storage = "ChancesMereEnVie",Name = "chancesmereenvie")]
		public int ChancesMereEnVie{
			get{ return _chancesMereEnVie;}
			set{_chancesMereEnVie = value;}
		}

		private int _chancesOrphelin;
		[Column(Storage = "ChancesOrphelin",Name = "chancesorphelin")]
		public int ChancesOrphelin{
			get{ return _chancesOrphelin;}
			set{_chancesOrphelin = value;}
		}

		private IEnumerable<Fratrie> _fratrie;
		public IEnumerable <Fratrie> Fratrie{
			get{
				if( _fratrie == null ){
					_fratrie = LoadByForeignKey<Fratrie>(p => p.ParenteId, Id);
				}
				return _fratrie;
			}
			set{
				foreach( Fratrie item in _fratrie ){
					item.Parente = null;

				}
				_fratrie = value;
				foreach( Fratrie item in value ){
					item.Parente = this;
					item.SaveObject();
				}
			}
		}

		private int _chancesEnfantUnique;
		[Column(Storage = "ChancesEnfantUnique",Name = "chancesenfantunique")]
		public int ChancesEnfantUnique{
			get{ return _chancesEnfantUnique;}
			set{_chancesEnfantUnique = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "parentedescription")]
	public partial class ParenteDescription : DataDescription<ParenteModel> {
	}
	[Table(Schema = "pathfinder",Name = "parenteexemplar")]
	public partial class ParenteExemplar : DataExemplaire<ParenteModel> {
	}
}
