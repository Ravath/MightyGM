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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "casearborescenceforce")]
	[CoreData]
	public partial class CaseArborescenceForce : CaseArborescence {

		private TypeCapaciteForce _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeCapaciteForce Type{
			get{ return _type;}
			set{_type = value;}
		}

		private int _cout;
		[Column(Storage = "cout",Name = "cout")]
		public int cout{
			get{ return _cout;}
			set{_cout = value;}
		}

		private int _controleId;
		[Column(Storage = "ControleId",Name = "fk_ameliorationdecontrole")]
		[HiddenProperty]
		public int ControleId{
			get{ return _controleId;}
			set{_controleId = value;}
		}

		private AmeliorationDeControle _controle;
		public AmeliorationDeControle Controle{
			get{
				if( _controle == null)
					_controle = LoadById<AmeliorationDeControle>(ControleId);
				return _controle;
			} set {
				if(_controle == value){return;}
				_controle = value;
				if( value != null)
					ControleId = value.Id;
			}
		}
	}
}
