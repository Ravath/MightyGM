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
	[Table(Schema = "pathfinder",Name = "armemodel")]
	[CoreData]
	public partial class ArmeModel : ObjetModel {

		private ArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeDescription> id = GetModelReferencer<ArmeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeArme _typeArme;
		[Column(Storage = "TypeArme",Name = "typearme")]
		public TypeArme TypeArme{
			get{ return _typeArme;}
			set{_typeArme = value;}
		}

		private ManiementArme _maniement;
		[Column(Storage = "Maniement",Name = "maniement")]
		public ManiementArme Maniement{
			get{ return _maniement;}
			set{_maniement = value;}
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

		private TypeDegatArme? _typeDegatComplementaire;
		[Column(Storage = "TypeDegatComplementaire",Name = "typedegatcomplementaire")]
		public TypeDegatArme? TypeDegatComplementaire{
			get{ return _typeDegatComplementaire;}
			set{_typeDegatComplementaire = value;}
		}

		private bool _typeDegatCplIsAlternative;
		[Column(Storage = "TypeDegatCplIsAlternative",Name = "typedegatcplisalternative")]
		public bool TypeDegatCplIsAlternative{
			get{ return _typeDegatCplIsAlternative;}
			set{_typeDegatCplIsAlternative = value;}
		}

		private int _secondeTeteId;
		[Column(Storage = "SecondeTeteId",Name = "fk_armemodel_secondetete")]
		[HiddenProperty]
		public int SecondeTeteId{
			get{ return _secondeTeteId;}
			set{_secondeTeteId = value;}
		}

		private ArmeModel _secondeTete;
		public ArmeModel SecondeTete{
			get{
				if( _secondeTete == null)
					_secondeTete = LoadById<ArmeModel>(SecondeTeteId);
				return _secondeTete;
			} set {
				if(_secondeTete == value){return;}
				_secondeTete = value;
				if( value != null)
					SecondeTeteId = value.Id;
			}
		}

		private int? _facteurPortee;
		[Column(Storage = "FacteurPortee",Name = "facteurportee")]
		public int? FacteurPortee{
			get{ return _facteurPortee;}
			set{_facteurPortee = value;}
		}

		private int _munitionId;
		[Column(Storage = "MunitionId",Name = "fk_munitionmodel_munition")]
		[HiddenProperty]
		public int MunitionId{
			get{ return _munitionId;}
			set{_munitionId = value;}
		}

		private MunitionModel _munition;
		public MunitionModel Munition{
			get {
				if(_munition == null) {
					_munition = LoadById<MunitionModel>(MunitionId);
			       }
				return _munition;
			} set {
				if(value == _munition) { return; }
				_munition = value;
				if(_munition != null) {
					_munitionId = _munition.Id;
				} else {
					_munitionId = 0;
				}
			}
		}

		private IEnumerable<SpecialArmeExemplar> _specialArme;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SpecialArme",OtherKey = "ArmeModelId")]
		public IEnumerable <SpecialArmeExemplar> SpecialArme{
			get{
				if( _specialArme == null ){
					_specialArme = LoadFromJointure<SpecialArmeExemplar,ArmeModelToSpecialArmeExemplar_SpecialArme>(false);
				}
				return _specialArme;
			}
			set{
				SaveToJointure<SpecialArmeExemplar, ArmeModelToSpecialArmeExemplar_SpecialArme> (_specialArme, value,false);
				_specialArme = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArmeModel,ArmeModelToSpecialArmeExemplar_SpecialArme>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "armedescription")]
	public partial class ArmeDescription : ObjetDescription {
	}
	[Table(Schema = "pathfinder",Name = "armeexemplar")]
	public partial class ArmeExemplar : ObjetExemplar {

		private bool _armeDeMaitre;
		[Column(Storage = "ArmeDeMaitre",Name = "armedemaitre")]
		public bool ArmeDeMaitre{
			get{ return _armeDeMaitre;}
			set{_armeDeMaitre = value;}
		}

		private int _alteration;
		[Column(Storage = "Alteration",Name = "alteration")]
		public int Alteration{
			get{ return _alteration;}
			set{_alteration = value;}
		}

		private IEnumerable<EnchantementArmeExemplar> _enchantements;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Enchantements",OtherKey = "ArmeExemplarId")]
		public IEnumerable <EnchantementArmeExemplar> Enchantements{
			get{
				if( _enchantements == null ){
					_enchantements = LoadFromJointure<EnchantementArmeExemplar,ArmeExemplarToEnchantementArmeExemplar_Enchantements>(false);
				}
				return _enchantements;
			}
			set{
				SaveToJointure<EnchantementArmeExemplar, ArmeExemplarToEnchantementArmeExemplar_Enchantements> (_enchantements, value,false);
				_enchantements = value;
			}
		}

		private IEnumerable<MunitionExemplar> _munitions;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Munitions",OtherKey = "ArmeExemplarId")]
		public IEnumerable <MunitionExemplar> Munitions{
			get{
				if( _munitions == null ){
					_munitions = LoadFromJointure<MunitionExemplar,ArmeExemplarToMunitionExemplar_Munitions>(false);
				}
				return _munitions;
			}
			set{
				SaveToJointure<MunitionExemplar, ArmeExemplarToMunitionExemplar_Munitions> (_munitions, value,false);
				_munitions = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArmeExemplar,ArmeExemplarToEnchantementArmeExemplar_Enchantements>(true);
			DeleteJoins<ArmeExemplar,ArmeExemplarToMunitionExemplar_Munitions>(true);
			base.DeleteObject();
		}
	}
}
