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
	[Table(Schema = "shadowrun5",Name = "absgrenademodel")]
	public abstract partial class AbsGrenadeModel : WeaponModel {

		private int _blastFactor;
		[Column(Storage = "BlastFactor",Name = "blastfactor")]
		public int BlastFactor{
			get{ return _blastFactor;}
			set{_blastFactor = value;}
		}

		private BlastType _blastType;
		[Column(Storage = "BlastType",Name = "blasttype")]
		public BlastType BlastType{
			get{ return _blastType;}
			set{_blastType = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "absgrenadedescription")]
	public abstract partial class AbsGrenadeDescription : WeaponDescription {
	}
	[Table(Schema = "shadowrun5",Name = "absgrenadeexemplar")]
	public abstract partial class AbsGrenadeExemplar : WeaponExemplar {
	}
}
