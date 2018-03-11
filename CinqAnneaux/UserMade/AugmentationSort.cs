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
using CinqAnneaux.JdrCore.Capacites;

namespace CinqAnneaux.Data {
	public partial class AugmentationSortModel
	{
	}
	public partial class AugmentationSortExemplar
	{
		public override string ToString()
		{
			return Augmentation.GetImplementation(this).Description;
		}
	}
	public partial class AugmentationSortDescription
	{
	}
}
