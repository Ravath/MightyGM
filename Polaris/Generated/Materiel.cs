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
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "materielmodel")]
	[CoreData]
	public partial class MaterielModel : ObjectModel {

		private MaterielDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MaterielDescription> id = GetModelReferencer<MaterielDescription>();
					if(id.Count() == 0) {
						_obj = new MaterielDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int? _niveau;
		[Column(Storage = "Niveau",Name = "niveau")]
		public int? Niveau{
			get{ return _niveau;}
			set{_niveau = value;}
		}

		private bool _isBonus;
		[Column(Storage = "IsBonus",Name = "isbonus")]
		public bool IsBonus{
			get{ return _isBonus;}
			set{_isBonus = value;}
		}

		private bool _niveauVariable;
		[Column(Storage = "NiveauVariable",Name = "niveauvariable")]
		public bool NiveauVariable{
			get{ return _niveauVariable;}
			set{_niveauVariable = value;}
		}

		private IEnumerable<ObjectEffectExemplar> _effects;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Effects",OtherKey = "MaterielModelId")]
		public IEnumerable <ObjectEffectExemplar> Effects{
			get{
				if( _effects == null ){
					_effects = LoadFromJointure<ObjectEffectExemplar,MaterielModelToObjectEffectExemplar_Effects>(false);
				}
				return _effects;
			}
			set{
				SaveToJointure<ObjectEffectExemplar, MaterielModelToObjectEffectExemplar_Effects> (_effects, value,false);
				_effects = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<MaterielModel,MaterielModelToObjectEffectExemplar_Effects>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "materieldescription")]
	public partial class MaterielDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "materielexemplar")]
	public partial class MaterielExemplar : ObjectExemplar {
	}
}
