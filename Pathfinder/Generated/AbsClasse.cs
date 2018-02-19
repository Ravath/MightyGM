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
	[Table(Schema = "pathfinder",Name = "absclassemodel")]
	public abstract partial class AbsClasseModel : AbsDVModel {

		private IEnumerable<PouvoirClasseModel> _pouvoirs;
		public IEnumerable <PouvoirClasseModel> Pouvoirs{
			get{
				if( _pouvoirs == null ){
					_pouvoirs = LoadByForeignKey<PouvoirClasseModel>(p => p.ClasseId, Id);
				}
				return _pouvoirs;
			}
			set{
				foreach( PouvoirClasseModel item in _pouvoirs ){
					item.Classe = null;

				}
				_pouvoirs = value;
				foreach( PouvoirClasseModel item in value ){
					item.Classe = this;
					item.SaveObject();
				}
			}
		}

		private bool _armesCourantes;
		[Column(Storage = "ArmesCourantes",Name = "armescourantes")]
		public bool ArmesCourantes{
			get{ return _armesCourantes;}
			set{_armesCourantes = value;}
		}

		private bool _armesGuerre;
		[Column(Storage = "ArmesGuerre",Name = "armesguerre")]
		public bool ArmesGuerre{
			get{ return _armesGuerre;}
			set{_armesGuerre = value;}
		}

		private bool _armuresLegeres;
		[Column(Storage = "ArmuresLegeres",Name = "armureslegeres")]
		public bool ArmuresLegeres{
			get{ return _armuresLegeres;}
			set{_armuresLegeres = value;}
		}

		private bool _armuresIntermediaires;
		[Column(Storage = "ArmuresIntermediaires",Name = "armuresintermediaires")]
		public bool ArmuresIntermediaires{
			get{ return _armuresIntermediaires;}
			set{_armuresIntermediaires = value;}
		}

		private bool _armuresLourdes;
		[Column(Storage = "ArmuresLourdes",Name = "armureslourdes")]
		public bool ArmuresLourdes{
			get{ return _armuresLourdes;}
			set{_armuresLourdes = value;}
		}

		private IEnumerable<SortsConnus> _sortsConnus;
		public IEnumerable <SortsConnus> SortsConnus{
			get{
				if( _sortsConnus == null ){
					_sortsConnus = LoadByForeignKey<SortsConnus>(p => p.ClasseId, Id);
				}
				return _sortsConnus;
			}
			set{
				foreach( SortsConnus item in _sortsConnus ){
					item.Classe = null;

				}
				_sortsConnus = value;
				foreach( SortsConnus item in value ){
					item.Classe = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<SortsQuotidiens> _sortsQuotidiens;
		public IEnumerable <SortsQuotidiens> SortsQuotidiens{
			get{
				if( _sortsQuotidiens == null ){
					_sortsQuotidiens = LoadByForeignKey<SortsQuotidiens>(p => p.ClasseId, Id);
				}
				return _sortsQuotidiens;
			}
			set{
				foreach( SortsQuotidiens item in _sortsQuotidiens ){
					item.Classe = null;

				}
				_sortsQuotidiens = value;
				foreach( SortsQuotidiens item in value ){
					item.Classe = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<ListeSortClasseModel> _listeDesSorts;
		public IEnumerable <ListeSortClasseModel> ListeDesSorts{
			get{
				if( _listeDesSorts == null ){
					_listeDesSorts = LoadByForeignKey<ListeSortClasseModel>(p => p.ClasseId, Id);
				}
				return _listeDesSorts;
			}
			set{
				foreach( ListeSortClasseModel item in _listeDesSorts ){
					item.Classe = null;

				}
				_listeDesSorts = value;
				foreach( ListeSortClasseModel item in value ){
					item.Classe = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "absclassedescription")]
	public abstract partial class AbsClasseDescription : AbsDVDescription {

		private string _role = "";
		[LargeText]
		[Column(Storage = "Role",Name = "role")]
		public string Role{
			get{ return _role;}
			set{_role = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "absclasseexemplar")]
	public abstract partial class AbsClasseExemplar : AbsDVExemplar {
	}
}
