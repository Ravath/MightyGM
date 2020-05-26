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
	[Table(Schema = "yggdrasil",Name = "figurantmodel")]
	[CoreData]
	public partial class FigurantModel : DataModel {

		private FigurantDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FigurantDescription> id = GetModelReferencer<FigurantDescription>();
					if(id.Count() == 0) {
						_obj = new FigurantDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _conflitOffensif;
		[Column(Storage = "ConflitOffensif",Name = "conflitoffensif")]
		public int ConflitOffensif{
			get{ return _conflitOffensif;}
			set{_conflitOffensif = value;}
		}

		private int _conflitDefensif;
		[Column(Storage = "ConflitDefensif",Name = "conflitdefensif")]
		public int ConflitDefensif{
			get{ return _conflitDefensif;}
			set{_conflitDefensif = value;}
		}

		private int _relationnel;
		[Column(Storage = "Relationnel",Name = "relationnel")]
		public int Relationnel{
			get{ return _relationnel;}
			set{_relationnel = value;}
		}

		private int _physique;
		[Column(Storage = "Physique",Name = "physique")]
		public int Physique{
			get{ return _physique;}
			set{_physique = value;}
		}

		private int _mental;
		[Column(Storage = "Mental",Name = "mental")]
		public int Mental{
			get{ return _mental;}
			set{_mental = value;}
		}

		private int _mystiqueActif;
		[Column(Storage = "MystiqueActif",Name = "mystiqueactif")]
		public int MystiqueActif{
			get{ return _mystiqueActif;}
			set{_mystiqueActif = value;}
		}

		private int _mystiquePassif;
		[Column(Storage = "MystiquePassif",Name = "mystiquepassif")]
		public int MystiquePassif{
			get{ return _mystiquePassif;}
			set{_mystiquePassif = value;}
		}

		private int _vitalite;
		[Column(Storage = "Vitalite",Name = "vitalite")]
		public int Vitalite{
			get{ return _vitalite;}
			set{_vitalite = value;}
		}

		private CategorieFigurant _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieFigurant Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}

		private int _degats;
		[Column(Storage = "Degats",Name = "degats")]
		public int Degats{
			get{ return _degats;}
			set{_degats = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "figurantdescription")]
	public partial class FigurantDescription : DataDescription<FigurantModel> {
	}
	[Table(Schema = "yggdrasil",Name = "figurantexemplar")]
	public partial class FigurantExemplar : DataExemplaire<FigurantModel> {

		private string _nom = "";
		[Column(Storage = "Nom",Name = "nom")]
		public string Nom{
			get{ return _nom;}
			set{_nom = value;}
		}

		private IEnumerable<CaractereExemplar> _caracteres;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Caracteres",OtherKey = "FigurantExemplarId")]
		public IEnumerable <CaractereExemplar> Caracteres{
			get{
				if( _caracteres == null ){
					_caracteres = LoadFromJointure<CaractereExemplar,FigurantExemplarToCaractereExemplar_Caracteres>(false);
				}
				return _caracteres;
			}
			set{
				SaveToJointure<CaractereExemplar, FigurantExemplarToCaractereExemplar_Caracteres> (_caracteres, value,false);
				_caracteres = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<FigurantExemplar,FigurantExemplarToCaractereExemplar_Caracteres>(true);
			base.DeleteObject();
		}
	}
}
