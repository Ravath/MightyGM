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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "typecreaturemodel")]
	[CoreData]
	public partial class TypeCreatureModel : AbsDVModel {

		private TypeCreatureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TypeCreatureDescription> id = GetModelReferencer<TypeCreatureDescription>();
					if(id.Count() == 0) {
						_obj = new TypeCreatureDescription();
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

		private AlignementLoi _alignementLoi;
		[Column(Storage = "AlignementLoi",Name = "alignementloi")]
		public AlignementLoi AlignementLoi{
			get{ return _alignementLoi;}
			set{_alignementLoi = value;}
		}

		private AlignementBien _alignementBien;
		[Column(Storage = "AlignementBien",Name = "alignementbien")]
		public AlignementBien AlignementBien{
			get{ return _alignementBien;}
			set{_alignementBien = value;}
		}

		private FrequenceAlignement _frequenceAlignement;
		[Column(Storage = "FrequenceAlignement",Name = "frequencealignement")]
		public FrequenceAlignement FrequenceAlignement{
			get{ return _frequenceAlignement;}
			set{_frequenceAlignement = value;}
		}

		private IEnumerable<PouvoirMonstrueuxModel> _pouvoirs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Pouvoirs",OtherKey = "TypeCreatureModelId")]
		public IEnumerable <PouvoirMonstrueuxModel> Pouvoirs{
			get{
				if( _pouvoirs == null ){
					_pouvoirs = LoadFromJointure<PouvoirMonstrueuxModel,TypeCreatureModelToPouvoirMonstrueuxModel_Pouvoirs>(false);
				}
				return _pouvoirs;
			}
			set{
				SaveToJointure<PouvoirMonstrueuxModel, TypeCreatureModelToPouvoirMonstrueuxModel_Pouvoirs> (_pouvoirs, value,false);
				_pouvoirs = value;
			}
		}

		private bool _formationArmeCourante;
		[Column(Storage = "FormationArmeCourante",Name = "formationarmecourante")]
		public bool FormationArmeCourante{
			get{ return _formationArmeCourante;}
			set{_formationArmeCourante = value;}
		}

		private bool _formationArmeGuerre;
		[Column(Storage = "FormationArmeGuerre",Name = "formationarmeguerre")]
		public bool FormationArmeGuerre{
			get{ return _formationArmeGuerre;}
			set{_formationArmeGuerre = value;}
		}

		private bool _formationArmure;
		[Column(Storage = "FormationArmure",Name = "formationarmure")]
		public bool FormationArmure{
			get{ return _formationArmure;}
			set{_formationArmure = value;}
		}

		private bool _mange;
		[Column(Storage = "Mange",Name = "mange")]
		public bool Mange{
			get{ return _mange;}
			set{_mange = value;}
		}

		private bool _dors;
		[Column(Storage = "Dors",Name = "dors")]
		public bool Dors{
			get{ return _dors;}
			set{_dors = value;}
		}

		private bool _respire;
		[Column(Storage = "Respire",Name = "respire")]
		public bool Respire{
			get{ return _respire;}
			set{_respire = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<TypeCreatureModel,TypeCreatureModelToPouvoirMonstrueuxModel_Pouvoirs>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "typecreaturedescription")]
	public partial class TypeCreatureDescription : AbsDVDescription {
	}
	[Table(Schema = "dd35",Name = "typecreatureexemplar")]
	public partial class TypeCreatureExemplar : AbsDVExemplar {
	}
}
