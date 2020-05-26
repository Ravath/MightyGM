using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data {
	public partial class Tag {

		public override bool Equals(object obj)
		{
			Tag tested = obj as Tag;
			if (obj == null) return false;
			return tested == this || Label == tested.Label;
		}

		public override int GetHashCode()
		{
			return 981597221 + EqualityComparer<string>.Default.GetHashCode(Label);
		}

		public override string ToString()
		{
			return Label;
		}
	}
}
