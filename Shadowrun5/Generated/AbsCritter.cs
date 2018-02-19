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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "abscrittermodel")]
	public abstract partial class AbsCritterModel : CharacterModel {

		private CritterType _type;
		[Column(Storage = "Type",Name = "type")]
		public CritterType Type{
			get{ return _type;}
			set{_type = value;}
		}

		private int _walk;
		[Column(Storage = "Walk",Name = "walk")]
		public int Walk{
			get{ return _walk;}
			set{_walk = value;}
		}

		private int _run;
		[Column(Storage = "Run",Name = "run")]
		public int Run{
			get{ return _run;}
			set{_run = value;}
		}

		private int _sprint;
		[Column(Storage = "Sprint",Name = "sprint")]
		public int Sprint{
			get{ return _sprint;}
			set{_sprint = value;}
		}

		private int _armor;
		[Column(Storage = "Armor",Name = "armor")]
		public int Armor{
			get{ return _armor;}
			set{_armor = value;}
		}

		private IEnumerable<CritterPowerExemplar> _powers;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Powers",OtherKey = "AbsCritterModelId")]
		public IEnumerable <CritterPowerExemplar> Powers{
			get{
				if( _powers == null ){
					_powers = LoadFromJointure<CritterPowerExemplar,AbsCritterModelToCritterPowerExemplar_Powers>(false);
				}
				return _powers;
			}
			set{
				SaveToJointure<CritterPowerExemplar, AbsCritterModelToCritterPowerExemplar_Powers> (_powers, value,false);
				_powers = value;
			}
		}

		private IEnumerable<CritterPowerExemplar> _optionalPowers;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "OptionalPowers",OtherKey = "AbsCritterModelId")]
		public IEnumerable <CritterPowerExemplar> OptionalPowers{
			get{
				if( _optionalPowers == null ){
					_optionalPowers = LoadFromJointure<CritterPowerExemplar,AbsCritterModelToCritterPowerExemplar_OptionalPowers>(false);
				}
				return _optionalPowers;
			}
			set{
				SaveToJointure<CritterPowerExemplar, AbsCritterModelToCritterPowerExemplar_OptionalPowers> (_optionalPowers, value,false);
				_optionalPowers = value;
			}
		}

		private IEnumerable<NaturalWeaponExemplar> _naturalWeapons;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "NaturalWeapons",OtherKey = "AbsCritterModelId")]
		public IEnumerable <NaturalWeaponExemplar> NaturalWeapons{
			get{
				if( _naturalWeapons == null ){
					_naturalWeapons = LoadFromJointure<NaturalWeaponExemplar,AbsCritterModelToNaturalWeaponExemplar_NaturalWeapons>(false);
				}
				return _naturalWeapons;
			}
			set{
				SaveToJointure<NaturalWeaponExemplar, AbsCritterModelToNaturalWeaponExemplar_NaturalWeapons> (_naturalWeapons, value,false);
				_naturalWeapons = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AbsCritterModel,AbsCritterModelToCritterPowerExemplar_Powers>(true);
			DeleteJoins<AbsCritterModel,AbsCritterModelToCritterPowerExemplar_OptionalPowers>(true);
			DeleteJoins<AbsCritterModel,AbsCritterModelToNaturalWeaponExemplar_NaturalWeapons>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "shadowrun5",Name = "abscritterdescription")]
	public abstract partial class AbsCritterDescription : CharacterDescription {

		private string _naturalHabitat = "";
		[LargeText]
		[Column(Storage = "NaturalHabitat",Name = "naturalhabitat")]
		public string NaturalHabitat{
			get{ return _naturalHabitat;}
			set{_naturalHabitat = value;}
		}

		private string _notes = "";
		[LargeText]
		[Column(Storage = "Notes",Name = "notes")]
		public string Notes{
			get{ return _notes;}
			set{_notes = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "abscritterexemplar")]
	public abstract partial class AbsCritterExemplar : CharacterExemplar {

		private IEnumerable<CritterPowerExemplar> _supplementaryPowers;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SupplementaryPowers",OtherKey = "AbsCritterExemplarId")]
		public IEnumerable <CritterPowerExemplar> SupplementaryPowers{
			get{
				if( _supplementaryPowers == null ){
					_supplementaryPowers = LoadFromJointure<CritterPowerExemplar,AbsCritterExemplarToCritterPowerExemplar_SupplementaryPowers>(false);
				}
				return _supplementaryPowers;
			}
			set{
				SaveToJointure<CritterPowerExemplar, AbsCritterExemplarToCritterPowerExemplar_SupplementaryPowers> (_supplementaryPowers, value,false);
				_supplementaryPowers = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AbsCritterExemplar,AbsCritterExemplarToCritterPowerExemplar_SupplementaryPowers>(true);
			base.DeleteObject();
		}
	}
}
