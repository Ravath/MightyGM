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
	[Table(Schema = "cinqanneaux",Name = "personnagejoueurmodel")]
	[CoreData]
	public partial class PersonnageJoueurModel : PersonnageModel {

		private PersonnageJoueurDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PersonnageJoueurDescription> id = GetModelReferencer<PersonnageJoueurDescription>();
					if(id.Count() == 0) {
						_obj = new PersonnageJoueurDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _playerId;
		[Column(Storage = "PlayerId",Name = "fk_player_id")]
		[HiddenProperty]
		public int PlayerId{
			get{ return _playerId;}
			set{_playerId = value;}
		}

		private Player _player;
		public Player Player{
			get {
				if(_player == null) {
					_player = LoadById<Player>(PlayerId);
			       }
				return _player;
			} set {
				if(value == _player) { return; }
				_player = value;
				if(_player != null) {
					_playerId = _player.Id;
				} else {
					_playerId = 0;
				}
			}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "PersonnageJoueurModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,PersonnageJoueurModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, PersonnageJoueurModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}

		private int _xpTotal;
		[Column(Storage = "XpTotal",Name = "xptotal")]
		public int XpTotal{
			get{ return _xpTotal;}
			set{_xpTotal = value;}
		}

		private int _xpDepense;
		[Column(Storage = "XpDepense",Name = "xpdepense")]
		public int XpDepense{
			get{ return _xpDepense;}
			set{_xpDepense = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<PersonnageJoueurModel,PersonnageJoueurModelToCompetenceExemplar_Competences>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "personnagejoueurdescription")]
	public partial class PersonnageJoueurDescription : PersonnageDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "personnagejoueurexemplar")]
	public partial class PersonnageJoueurExemplar : PersonnageExemplar {
	}
}
