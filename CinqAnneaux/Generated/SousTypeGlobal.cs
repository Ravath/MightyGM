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
	[Table(Schema = "cinqanneaux",Name = "soustypeglobal")]
	[CoreData]
	public partial class SousTypeGlobal : DataObject {

		private string _tag = "";
		[Column(Storage = "Tag",Name = "tag")]
		public string Tag{
			get{ return _tag;}
			set{_tag = value;}
		}

		private string _nom = "";
		[Column(Storage = "Nom",Name = "nom")]
		public string Nom{
			get{ return _nom;}
			set{_nom = value;}
		}

		private TraitCompetence _traitAssocie;
		[Column(Storage = "TraitAssocie",Name = "traitassocie")]
		public TraitCompetence TraitAssocie{
			get{ return _traitAssocie;}
			set{_traitAssocie = value;}
		}

		private bool _degradante;
		[Column(Storage = "Degradante",Name = "degradante")]
		public bool Degradante{
			get{ return _degradante;}
			set{_degradante = value;}
		}

		private bool _noble;
		[Column(Storage = "Noble",Name = "noble")]
		public bool Noble{
			get{ return _noble;}
			set{_noble = value;}
		}

		private int _competenceId;
		[Column(Storage = "CompetenceId",Name = "fk_competenceglobalemodel_competence")]
		[HiddenProperty]
		public int CompetenceId{
			get{ return _competenceId;}
			set{_competenceId = value;}
		}

		private CompetenceGlobaleModel _competence;
		public CompetenceGlobaleModel Competence{
			get {
				if(_competence == null) {
					_competence = LoadById<CompetenceGlobaleModel>(CompetenceId);
			       }
				return _competence;
			} set {
				if(value == _competence) { return; }
				_competence = value;
				if(_competence != null) {
					_competenceId = _competence.Id;
				} else {
					_competenceId = 0;
				}
			}
		}
	}
}
