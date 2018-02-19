using DataGenerator.DataModel2.AttributeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Parser;
using DataGenerator.DataModel2.Model;

namespace DataGenerator.DataModel2.EntityConverter
{
	public abstract class AbsEntityConverter
	{
		public AbsEntityNameConverter	NameConverter		{ get; protected set; }
		public AbsMajorTagConverter		MajorTagConverter	{ get; protected set; }
		public AbsMinorTagConverter		MinorTagConverter	{ get; protected set; }
		public AbsAttributeConverter	AttributeConverter	{ get; protected set; }

		public abstract string EntityTag { get; }


		#region Init
		public AbsEntityConverter()
		{
			NameConverter = AbsEntityNameConverter.DefaultEntityNameConverter;
		}
		#endregion

		public abstract DataEntity AddEntity(DataModel dm, string tabName);

		public string GetName(RawTable tab)
		{
			return NameConverter.GetName(tab);
		}

		public void GetTags(DataEntity entity, RawTable tab)
		{
			MinorTagConverter.ConvertTags(entity, tab.MinorTags);
		}

		public void LinkInheritance(DataModel dm, DataEntity entity, RawTable tab)
		{
			MajorTagConverter.ConvertTag(dm, entity, tab);
		}

		public void LinkAttributes(DataModel dm, DataEntity entity, RawTable tab)
		{
			AttributeConverter.ReflexReferenceConverter.Convert(dm, entity, tab);
		}
	}
}
