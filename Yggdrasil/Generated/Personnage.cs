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
namespace Yggdrasil.Data {
	[Table(Schema = "yggdrasil",Name = "personnagemodel")]
	[CoreData]
	public partial class PersonnageModel : DataModel {

		private PersonnageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PersonnageDescription> id = GetModelReferencer<PersonnageDescription>();
					if(id.Count() == 0) {
						_obj = new PersonnageDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _puissance;
		[Column(Storage = "Puissance",Name = "puissance")]
		public int Puissance{
			get{ return _puissance;}
			set{_puissance = value;}
		}

		private int _vigueur;
		[Column(Storage = "Vigueur",Name = "vigueur")]
		public int Vigueur{
			get{ return _vigueur;}
			set{_vigueur = value;}
		}

		private int _intellect;
		[Column(Storage = "Intellect",Name = "intellect")]
		public int Intellect{
			get{ return _intellect;}
			set{_intellect = value;}
		}

		private int _perception;
		[Column(Storage = "Perception",Name = "perception")]
		public int Perception{
			get{ return _perception;}
			set{_perception = value;}
		}

		private int _tenacite;
		[Column(Storage = "Tenacite",Name = "tenacite")]
		public int Tenacite{
			get{ return _tenacite;}
			set{_tenacite = value;}
		}

		private int _charisme;
		[Column(Storage = "Charisme",Name = "charisme")]
		public int Charisme{
			get{ return _charisme;}
			set{_charisme = value;}
		}

		private int _instinct;
		[Column(Storage = "Instinct",Name = "instinct")]
		public int Instinct{
			get{ return _instinct;}
			set{_instinct = value;}
		}

		private int _communication;
		[Column(Storage = "Communication",Name = "communication")]
		public int Communication{
			get{ return _communication;}
			set{_communication = value;}
		}

		private IEnumerable<RuneExemplar> _tirage;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Tirage",OtherKey = "PersonnageModelId")]
		public IEnumerable <RuneExemplar> Tirage{
			get{
				if( _tirage == null ){
					_tirage = LoadFromJointure<RuneExemplar,PersonnageModelToRuneExemplar_Tirage>(false);
				}
				return _tirage;
			}
			set{
				SaveToJointure<RuneExemplar, PersonnageModelToRuneExemplar_Tirage> (_tirage, value,false);
				_tirage = value;
			}
		}

		private TypeFuror _typeFuror;
		[Column(Storage = "TypeFuror",Name = "typefuror")]
		public TypeFuror TypeFuror{
			get{ return _typeFuror;}
			set{_typeFuror = value;}
		}

		private IEnumerable<DonModel> _dons;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Dons",OtherKey = "PersonnageModelId")]
		public IEnumerable <DonModel> Dons{
			get{
				if( _dons == null ){
					_dons = LoadFromJointure<DonModel,PersonnageModelToDonModel_Dons>(false);
				}
				return _dons;
			}
			set{
				SaveToJointure<DonModel, PersonnageModelToDonModel_Dons> (_dons, value,false);
				_dons = value;
			}
		}

		private IEnumerable<BlessureExemplar> _sequelles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Sequelles",OtherKey = "PersonnageModelId")]
		public IEnumerable <BlessureExemplar> Sequelles{
			get{
				if( _sequelles == null ){
					_sequelles = LoadFromJointure<BlessureExemplar,PersonnageModelToBlessureExemplar_Sequelles>(false);
				}
				return _sequelles;
			}
			set{
				SaveToJointure<BlessureExemplar, PersonnageModelToBlessureExemplar_Sequelles> (_sequelles, value,false);
				_sequelles = value;
			}
		}

		private IEnumerable<MaladieExemplar> _maladies;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Maladies",OtherKey = "PersonnageModelId")]
		public IEnumerable <MaladieExemplar> Maladies{
			get{
				if( _maladies == null ){
					_maladies = LoadFromJointure<MaladieExemplar,PersonnageModelToMaladieExemplar_Maladies>(false);
				}
				return _maladies;
			}
			set{
				SaveToJointure<MaladieExemplar, PersonnageModelToMaladieExemplar_Maladies> (_maladies, value,false);
				_maladies = value;
			}
		}

		private IEnumerable<ProuesseExemplar> _prouesses;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Prouesses",OtherKey = "PersonnageModelId")]
		public IEnumerable <ProuesseExemplar> Prouesses{
			get{
				if( _prouesses == null ){
					_prouesses = LoadFromJointure<ProuesseExemplar,PersonnageModelToProuesseExemplar_Prouesses>(false);
				}
				return _prouesses;
			}
			set{
				SaveToJointure<ProuesseExemplar, PersonnageModelToProuesseExemplar_Prouesses> (_prouesses, value,false);
				_prouesses = value;
			}
		}

		private IEnumerable<SortSejdrModel> _sortsSejdr;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SortsSejdr",OtherKey = "PersonnageModelId")]
		public IEnumerable <SortSejdrModel> SortsSejdr{
			get{
				if( _sortsSejdr == null ){
					_sortsSejdr = LoadFromJointure<SortSejdrModel,PersonnageModelToSortSejdrModel_SortsSejdr>(false);
				}
				return _sortsSejdr;
			}
			set{
				SaveToJointure<SortSejdrModel, PersonnageModelToSortSejdrModel_SortsSejdr> (_sortsSejdr, value,false);
				_sortsSejdr = value;
			}
		}

		private IEnumerable<SortGaldrModel> _sortsGaldr;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SortsGaldr",OtherKey = "PersonnageModelId")]
		public IEnumerable <SortGaldrModel> SortsGaldr{
			get{
				if( _sortsGaldr == null ){
					_sortsGaldr = LoadFromJointure<SortGaldrModel,PersonnageModelToSortGaldrModel_SortsGaldr>(false);
				}
				return _sortsGaldr;
			}
			set{
				SaveToJointure<SortGaldrModel, PersonnageModelToSortGaldrModel_SortsGaldr> (_sortsGaldr, value,false);
				_sortsGaldr = value;
			}
		}

		private IEnumerable<SortRuneModel> _sortsRune;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SortsRune",OtherKey = "PersonnageModelId")]
		public IEnumerable <SortRuneModel> SortsRune{
			get{
				if( _sortsRune == null ){
					_sortsRune = LoadFromJointure<SortRuneModel,PersonnageModelToSortRuneModel_SortsRune>(false);
				}
				return _sortsRune;
			}
			set{
				SaveToJointure<SortRuneModel, PersonnageModelToSortRuneModel_SortsRune> (_sortsRune, value,false);
				_sortsRune = value;
			}
		}

		private IEnumerable<ArmeModel> _armes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Armes",OtherKey = "PersonnageModelId")]
		public IEnumerable <ArmeModel> Armes{
			get{
				if( _armes == null ){
					_armes = LoadFromJointure<ArmeModel,PersonnageModelToArmeModel_Armes>(false);
				}
				return _armes;
			}
			set{
				SaveToJointure<ArmeModel, PersonnageModelToArmeModel_Armes> (_armes, value,false);
				_armes = value;
			}
		}

		private IEnumerable<ArmureModel> _armures;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Armures",OtherKey = "PersonnageModelId")]
		public IEnumerable <ArmureModel> Armures{
			get{
				if( _armures == null ){
					_armures = LoadFromJointure<ArmureModel,PersonnageModelToArmureModel_Armures>(false);
				}
				return _armures;
			}
			set{
				SaveToJointure<ArmureModel, PersonnageModelToArmureModel_Armures> (_armures, value,false);
				_armures = value;
			}
		}

		private IEnumerable<ObjetQuotidienModel> _objets;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Objets",OtherKey = "PersonnageModelId")]
		public IEnumerable <ObjetQuotidienModel> Objets{
			get{
				if( _objets == null ){
					_objets = LoadFromJointure<ObjetQuotidienModel,PersonnageModelToObjetQuotidienModel_Objets>(false);
				}
				return _objets;
			}
			set{
				SaveToJointure<ObjetQuotidienModel, PersonnageModelToObjetQuotidienModel_Objets> (_objets, value,false);
				_objets = value;
			}
		}

		private string _historique = "";
		[LargeText]
		[Column(Storage = "Historique",Name = "historique")]
		public string Historique{
			get{ return _historique;}
			set{_historique = value;}
		}

		private int _experience;
		[Column(Storage = "Experience",Name = "experience")]
		public int Experience{
			get{ return _experience;}
			set{_experience = value;}
		}

		private int _renommee;
		[Column(Storage = "Renommee",Name = "renommee")]
		public int Renommee{
			get{ return _renommee;}
			set{_renommee = value;}
		}

		private int _argent;
		[Column(Storage = "Argent",Name = "argent")]
		public int Argent{
			get{ return _argent;}
			set{_argent = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<PersonnageModel,PersonnageModelToRuneExemplar_Tirage>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToDonModel_Dons>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToBlessureExemplar_Sequelles>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToMaladieExemplar_Maladies>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToProuesseExemplar_Prouesses>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToSortSejdrModel_SortsSejdr>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToSortGaldrModel_SortsGaldr>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToSortRuneModel_SortsRune>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToArmeModel_Armes>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToArmureModel_Armures>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToObjetQuotidienModel_Objets>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "yggdrasil",Name = "personnagedescription")]
	public partial class PersonnageDescription : DataDescription<PersonnageModel> {
	}
	[Table(Schema = "yggdrasil",Name = "personnageexemplar")]
	public partial class PersonnageExemplar : DataExemplaire<PersonnageModel> {

		private int _furorDepensee;
		[Column(Storage = "FurorDepensee",Name = "furordepensee")]
		public int FurorDepensee{
			get{ return _furorDepensee;}
			set{_furorDepensee = value;}
		}

		private int _pointsDeDegat;
		[Column(Storage = "PointsDeDegat",Name = "pointsdedegat")]
		public int PointsDeDegat{
			get{ return _pointsDeDegat;}
			set{_pointsDeDegat = value;}
		}
	}
}
