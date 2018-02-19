using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.DataModel2.Model;
using DataGenerator.Parser;

namespace DataGenerator.DataModel2.AttributeConverter
{
	public abstract class AbsAttributeTargetConverter
	{
		public static NoTargetConverter NoTarget = new NoTargetConverter();

		public abstract void Convert(DataModel dm, DataEntity entity, RawTable tab);

		protected void NoTargetProp(DataEntity entity, RawAttribute raw)
		{
			AttributeCheck.CheckAttributePresence(entity.Name, raw.Name, raw.Target, false, "Target");
		}
	}

	public class NoTargetConverter : AbsAttributeTargetConverter
	{
		public override void Convert(DataModel dm, DataEntity entity, RawTable tab)
		{
			foreach (RawAttribute raw in tab.Attributes)
			{
				NoTargetProp(entity, raw);
			}
		}
	}

	public class DataObjectTargetConverter : AbsAttributeTargetConverter
	{
		public override void Convert(DataModel dm, DataEntity entity, RawTable tab)
		{
			throw new NotImplementedException();
			foreach (RawAttribute raw in tab.Attributes)
			{
				//TODO DataObjectTargetConverter implementation
				NoTargetProp(entity, raw);
				//Find referenced table

				//Find property in table

				//If the other property if a reference, check if points backward
			}
		}
	}
}
