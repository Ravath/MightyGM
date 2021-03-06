using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using Core.Gestion;
using LinqToDB.Mapping;
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "playercharactermodel")]
	[CoreData]
	public partial class PlayerCharacterModel : CharacterModel {

		private PlayerCharacterDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PlayerCharacterDescription> id = GetModelReferencer<PlayerCharacterDescription>();
					if(id.Count() == 0) {
						_obj = new PlayerCharacterDescription();
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

		private int _joueurId;
		[Column(Storage = "JoueurId",Name = "fk_joueur_id")]
		[HiddenProperty]
		public int JoueurId{
			get{ return _joueurId;}
			set{_joueurId = value;}
		}

		private Joueur _joueur;
		public Joueur Joueur{
			get {
				if(_joueur == null) {
					_joueur = LoadById<Joueur>(JoueurId);
			       }
				return _joueur;
			} set {
				if(value == _joueur) { return; }
				_joueur = value;
				if(_joueur != null) {
					_joueurId = _joueur.Id;
				} else {
					_joueurId = 0;
				}
			}
		}
	}
	[Table(Schema = "shadowrun5",Name = "playercharacterdescription")]
	public partial class PlayerCharacterDescription : CharacterDescription {
	}
	[Table(Schema = "shadowrun5",Name = "playercharacterexemplar")]
	public partial class PlayerCharacterExemplar : CharacterExemplar {
	}
}
