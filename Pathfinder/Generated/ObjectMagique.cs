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
	[Table(Schema = "pathfinder",Name = "objectmagiquemodel")]
	public abstract partial class ObjectMagiqueModel : ObjetModel {

		private UsageObjectMagique _usage;
		[Column(Storage = "Usage",Name = "usage")]
		public UsageObjectMagique Usage{
			get{ return _usage;}
			set{_usage = value;}
		}

		private EcoleMagie _ecoleAura;
		[Column(Storage = "EcoleAura",Name = "ecoleaura")]
		public EcoleMagie EcoleAura{
			get{ return _ecoleAura;}
			set{_ecoleAura = value;}
		}

		private PuissanceAura _puissanceAura;
		[Column(Storage = "PuissanceAura",Name = "puissanceaura")]
		public PuissanceAura PuissanceAura{
			get{ return _puissanceAura;}
			set{_puissanceAura = value;}
		}

		private int _nLS;
		[Column(Storage = "NLS",Name = "nls")]
		public int NLS{
			get{ return _nLS;}
			set{_nLS = value;}
		}

		private IEnumerable<SortModel> _sortsCreation;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SortsCreation",OtherKey = "ObjectMagiqueModelId")]
		public IEnumerable <SortModel> SortsCreation{
			get{
				if( _sortsCreation == null ){
					_sortsCreation = LoadFromJointure<SortModel,ObjectMagiqueModelToSortModel_SortsCreation>(false);
				}
				return _sortsCreation;
			}
			set{
				SaveToJointure<SortModel, ObjectMagiqueModelToSortModel_SortsCreation> (_sortsCreation, value,false);
				_sortsCreation = value;
			}
		}

		private IEnumerable<RequisExemplar> _requisPort;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "RequisPort",OtherKey = "ObjectMagiqueModelId")]
		public IEnumerable <RequisExemplar> RequisPort{
			get{
				if( _requisPort == null ){
					_requisPort = LoadFromJointure<RequisExemplar,ObjectMagiqueModelToRequisExemplar_RequisPort>(false);
				}
				return _requisPort;
			}
			set{
				SaveToJointure<RequisExemplar, ObjectMagiqueModelToRequisExemplar_RequisPort> (_requisPort, value,false);
				_requisPort = value;
			}
		}

		private IEnumerable<RequisExemplar> _requisCreation;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "RequisCreation",OtherKey = "ObjectMagiqueModelId")]
		public IEnumerable <RequisExemplar> RequisCreation{
			get{
				if( _requisCreation == null ){
					_requisCreation = LoadFromJointure<RequisExemplar,ObjectMagiqueModelToRequisExemplar_RequisCreation>(false);
				}
				return _requisCreation;
			}
			set{
				SaveToJointure<RequisExemplar, ObjectMagiqueModelToRequisExemplar_RequisCreation> (_requisCreation, value,false);
				_requisCreation = value;
			}
		}

		private TypeObjetMagique _typeObjetMagique;
		[Column(Storage = "TypeObjetMagique",Name = "typeobjetmagique")]
		public TypeObjetMagique TypeObjetMagique{
			get{ return _typeObjetMagique;}
			set{_typeObjetMagique = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<ObjectMagiqueModel,ObjectMagiqueModelToSortModel_SortsCreation>(true);
			DeleteJoins<ObjectMagiqueModel,ObjectMagiqueModelToRequisExemplar_RequisPort>(true);
			DeleteJoins<ObjectMagiqueModel,ObjectMagiqueModelToRequisExemplar_RequisCreation>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "objectmagiquedescription")]
	public abstract partial class ObjectMagiqueDescription : ObjetDescription {
	}
	[Table(Schema = "pathfinder",Name = "objectmagiqueexemplar")]
	public abstract partial class ObjectMagiqueExemplar : ObjetExemplar {

		private int _intelligenceId;
		[Column(Storage = "IntelligenceId",Name = "fk_objetintelligent_intelligence")]
		[HiddenProperty]
		public int IntelligenceId{
			get{ return _intelligenceId;}
			set{_intelligenceId = value;}
		}

		private ObjetIntelligent _intelligence;
		public ObjetIntelligent Intelligence{
			get{
				if( _intelligence == null)
					_intelligence = LoadById<ObjetIntelligent>(IntelligenceId);
				return _intelligence;
			} set {
				if(_intelligence == value){return;}
				_intelligence = value;
				if( value != null)
					IntelligenceId = value.Id;
			}
		}
	}
}
