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
	[Table(Schema = "cinqanneaux",Name = "competencemodel")]
	[CoreData]
	public partial class CompetenceModel : DataModel {

		private CompetenceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CompetenceDescription> id = GetModelReferencer<CompetenceDescription>();
					if(id.Count() == 0) {
						_obj = new CompetenceDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private GroupeCompetence _groupe;
		[Column(Storage = "Groupe",Name = "groupe")]
		public GroupeCompetence Groupe{
			get{ return _groupe;}
			set{_groupe = value;}
		}

		private TraitCompetence _traitAssocie;
		[Column(Storage = "TraitAssocie",Name = "traitassocie")]
		public TraitCompetence TraitAssocie{
			get{ return _traitAssocie;}
			set{_traitAssocie = value;}
		}

		private TraitCompetence? _traitAlternatif;
		[Column(Storage = "TraitAlternatif",Name = "traitalternatif")]
		public TraitCompetence? TraitAlternatif{
			get{ return _traitAlternatif;}
			set{_traitAlternatif = value;}
		}

		private bool _degradante;
		[Column(Storage = "Degradante",Name = "degradante")]
		public bool Degradante{
			get{ return _degradante;}
			set{_degradante = value;}
		}

		private bool _sociale;
		[Column(Storage = "Sociale",Name = "sociale")]
		public bool Sociale{
			get{ return _sociale;}
			set{_sociale = value;}
		}

		private bool _martiale;
		[Column(Storage = "Martiale",Name = "martiale")]
		public bool Martiale{
			get{ return _martiale;}
			set{_martiale = value;}
		}

		private IEnumerable<MaitriseModel> _maitrises;
		public IEnumerable <MaitriseModel> Maitrises{
			get{
				if( _maitrises == null ){
					_maitrises = LoadByForeignKey<MaitriseModel>(p => p.CompetenceId, Id);
				}
				return _maitrises;
			}
			set{
				foreach( MaitriseModel item in _maitrises ){
					item.Competence = null;

				}
				_maitrises = value;
				foreach( MaitriseModel item in value ){
					item.Competence = this;
					item.SaveObject();
				}
			}
		}

		private int _globalId;
		[Column(Storage = "GlobalId",Name = "fk_competenceglobalemodel_global")]
		[HiddenProperty]
		public int GlobalId{
			get{ return _globalId;}
			set{_globalId = value;}
		}

		private CompetenceGlobaleModel _global;
		public CompetenceGlobaleModel Global{
			get {
				if(_global == null) {
					_global = LoadById<CompetenceGlobaleModel>(GlobalId);
			       }
				return _global;
			} set {
				if(value == _global) { return; }
				_global = value;
				if(_global != null) {
					_globalId = _global.Id;
				} else {
					_globalId = 0;
				}
			}
		}

		private IEnumerable<Specialisation> _specialisations;
		public IEnumerable <Specialisation> Specialisations{
			get{
				if( _specialisations == null ){
					_specialisations = LoadByForeignKey<Specialisation>(p => p.CompetenceId, Id);
				}
				return _specialisations;
			}
			set{
				foreach( Specialisation item in _specialisations ){
					item.Competence = null;

				}
				_specialisations = value;
				foreach( Specialisation item in value ){
					item.Competence = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "competencedescription")]
	public partial class CompetenceDescription : DataDescription<CompetenceModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "competenceexemplar")]
	public partial class CompetenceExemplar : DataExemplaire<CompetenceModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}

		private IEnumerable<Specialisation> _specialisationsChoisies;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SpecialisationsChoisies",OtherKey = "CompetenceExemplarId")]
		public IEnumerable <Specialisation> SpecialisationsChoisies{
			get{
				if( _specialisationsChoisies == null ){
					_specialisationsChoisies = LoadFromJointure<Specialisation,CompetenceExemplarToSpecialisation_SpecialisationsChoisies>(false);
				}
				return _specialisationsChoisies;
			}
			set{
				SaveToJointure<Specialisation, CompetenceExemplarToSpecialisation_SpecialisationsChoisies> (_specialisationsChoisies, value,false);
				_specialisationsChoisies = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<CompetenceExemplar,CompetenceExemplarToSpecialisation_SpecialisationsChoisies>(true);
			base.DeleteObject();
		}
	}
}
