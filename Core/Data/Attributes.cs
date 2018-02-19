﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Schema {
	[AttributeUsage(AttributeTargets.Property)]
	public class LargeTextAttribute : System.Attribute {
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class HiddenPropertyAttribute : System.Attribute {
	}
}
