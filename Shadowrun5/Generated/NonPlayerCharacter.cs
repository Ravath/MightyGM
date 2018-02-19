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
	[Table(Schema = "shadowrun5",Name = "nonplayercharactermodel")]
	public abstract partial class NonPlayerCharacterModel : CharacterModel {
	}
	[Table(Schema = "shadowrun5",Name = "nonplayercharacterdescription")]
	public abstract partial class NonPlayerCharacterDescription : CharacterDescription {
	}
	[Table(Schema = "shadowrun5",Name = "nonplayercharacterexemplar")]
	public abstract partial class NonPlayerCharacterExemplar : CharacterExemplar {
	}
}
