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
	[Table(Schema = "polaris",Name = "objectmodel")]
	public abstract partial class ObjectModel : DataModel {

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}

		private int _dispo;
		[Column(Storage = "Dispo",Name = "dispo")]
		public int Dispo{
			get{ return _dispo;}
			set{_dispo = value;}
		}

		private int _dispoNoir;
		[Column(Storage = "DispoNoir",Name = "disponoir")]
		public int DispoNoir{
			get{ return _dispoNoir;}
			set{_dispoNoir = value;}
		}

		private decimal _poids;
		[Column(Storage = "Poids",Name = "poids")]
		public decimal Poids{
			get{ return _poids;}
			set{_poids = value;}
		}

		private int _nT;
		[Column(Storage = "NT",Name = "nt")]
		public int NT{
			get{ return _nT;}
			set{_nT = value;}
		}

		private IEnumerable<Fabriquant> _fabriquant;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Fabriquant",OtherKey = "ObjectModelId")]
		public IEnumerable <Fabriquant> Fabriquant{
			get{
				if( _fabriquant == null ){
					_fabriquant = LoadFromJointure<Fabriquant,ObjectModelToFabriquant_Fabriquant>(false);
				}
				return _fabriquant;
			}
			set{
				SaveToJointure<Fabriquant, ObjectModelToFabriquant_Fabriquant> (_fabriquant, value,false);
				_fabriquant = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ObjectModel,ObjectModelToFabriquant_Fabriquant>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "objectdescription")]
	public abstract partial class ObjectDescription : DataDescription<ObjectModel> {
	}
	[Table(Schema = "polaris",Name = "objectexemplar")]
	public abstract partial class ObjectExemplar : DataExemplaire<ObjectModel> {

		private int _integriteMax;
		[Column(Storage = "IntegriteMax",Name = "integritemax")]
		public int IntegriteMax{
			get{ return _integriteMax;}
			set{_integriteMax = value;}
		}

		private int _integrte;
		[Column(Storage = "Integrte",Name = "integrte")]
		public int Integrte{
			get{ return _integrte;}
			set{_integrte = value;}
		}
	}
}
