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
	[Table(Schema = "cinqanneaux",Name = "figurantmodel")]
	[CoreData]
	public partial class FigurantModel : PersonnageModel {

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

		private int _nDArmure;
		[Column(Storage = "NDArmure",Name = "ndarmure")]
		public int NDArmure{
			get{ return _nDArmure;}
			set{_nDArmure = value;}
		}

		private int _reduction;
		[Column(Storage = "Reduction",Name = "reduction")]
		public int Reduction{
			get{ return _reduction;}
			set{_reduction = value;}
		}

		private int _initiative_r;
		[Column(Storage = "Initiative_r",Name = "initiative_r")]
		public int Initiative_r{
			get{ return _initiative_r;}
			set{_initiative_r = value;}
		}

		private int _initiative_k;
		[Column(Storage = "Initiative_k",Name = "initiative_k")]
		public int Initiative_k{
			get{ return _initiative_k;}
			set{_initiative_k = value;}
		}

		private bool _vieHumaine;
		[Column(Storage = "VieHumaine",Name = "viehumaine")]
		public bool VieHumaine{
			get{ return _vieHumaine;}
			set{_vieHumaine = value;}
		}

		private int _vieMax;
		[Column(Storage = "VieMax",Name = "viemax")]
		public int VieMax{
			get{ return _vieMax;}
			set{_vieMax = value;}
		}

		private IEnumerable<SeuilBlessure> _seuils;
		public IEnumerable <SeuilBlessure> Seuils{
			get{
				if( _seuils == null ){
					_seuils = LoadByForeignKey<SeuilBlessure>(p => p.FigurantId, Id);
				}
				return _seuils;
			}
			set{
				foreach( SeuilBlessure item in _seuils ){
					item.Figurant = null;

				}
				_seuils = value;
				foreach( SeuilBlessure item in value ){
					item.Figurant = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<AttaqueFigurant> _attaques;
		public IEnumerable <AttaqueFigurant> Attaques{
			get{
				if( _attaques == null ){
					_attaques = LoadByForeignKey<AttaqueFigurant>(p => p.FigurantId, Id);
				}
				return _attaques;
			}
			set{
				foreach( AttaqueFigurant item in _attaques ){
					item.Figurant = null;

				}
				_attaques = value;
				foreach( AttaqueFigurant item in value ){
					item.Figurant = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<CompetenceStatus> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "FigurantModelId")]
		public IEnumerable <CompetenceStatus> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceStatus,FigurantModelToCompetenceStatus_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceStatus, FigurantModelToCompetenceStatus_Competences> (_competences, value,false);
				_competences = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<FigurantModel,FigurantModelToCompetenceStatus_Competences>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "figurantdescription")]
	public partial class FigurantDescription : PersonnageDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "figurantexemplar")]
	public partial class FigurantExemplar : PersonnageExemplar {
	}
}
