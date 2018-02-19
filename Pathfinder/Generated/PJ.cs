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
using Core.Gestion;
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "pjmodel")]
	[CoreData]
	public partial class PJModel : PersonnageModel {

		private PJDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PJDescription> id = GetModelReferencer<PJDescription>();
					if(id.Count() == 0) {
						_obj = new PJDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
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
	[Table(Schema = "pathfinder",Name = "pjdescription")]
	public partial class PJDescription : PersonnageDescription {
	}
	[Table(Schema = "pathfinder",Name = "pjexemplar")]
	public partial class PJExemplar : PersonnageExemplar {
	}
}
