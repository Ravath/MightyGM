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
	public partial class SpecialObjetModel
	{
	}
	public partial class SpecialObjetExemplar
	{
		public override string ToString()
		{
			return String.Format(Model.Description.Description,Complement.Split(';'));
		}
	}
	public partial class SpecialObjetDescription
	{
	}
}
