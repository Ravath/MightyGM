using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Parser;
using DataGenerator.DataModel2.Model;

namespace DataGenerator.DataModel2.AttributeConverter
{
	public abstract class AbsAttributeSectionConverter
	{
		public static EnumSectionConverter EnumSection = new EnumSectionConverter();
		public static DiceSectionConverter DiceSection = new DiceSectionConverter();
		public static StructSectionConverter StructSection = new StructSectionConverter();
		public static DataObjectSectionConverter ObjectSection = new DataObjectSectionConverter();

		public abstract void AddAttribute(DataEntity entity, DataAttribute att, RawAttribute raw);

		protected void NoSection(DataEntity entity, DataAttribute att, RawAttribute raw)
		{
			AttributeCheck.CheckAttributePresence(entity.Name, att.Name, raw.Section, false, "Section");
		}
	}

	public class EnumSectionConverter : AbsAttributeSectionConverter
	{
		public override void AddAttribute(DataEntity entity, DataAttribute att, RawAttribute raw)
		{
			NoSection(entity, att, raw);
			DataEnum e = (DataEnum)entity;
			e.AddAttribute((DataEnumAttribute)att);
		}
	}

	public class DiceSectionConverter : AbsAttributeSectionConverter
	{
		public override void AddAttribute(DataEntity entity, DataAttribute att, RawAttribute raw)
		{
			NoSection(entity, att, raw);
			DataDice e = (DataDice)entity;
			e.AddAttribute((DataDiceAttribute)att);
		}
	}

	public class StructSectionConverter : AbsAttributeSectionConverter
	{
		public override void AddAttribute(DataEntity entity, DataAttribute att, RawAttribute raw)
		{
			NoSection(entity, att, raw);
			DataStruct e = (DataStruct)entity;
			e.AddAttribute((DataObjectAttribute)att);
		}
	}

	public class DataObjectSectionConverter : AbsAttributeSectionConverter
	{
		public override void AddAttribute(DataEntity entity, DataAttribute att, RawAttribute raw)
		{
			NoSection(entity, att, raw);
			DataObject e = (DataObject)entity;
			if (AttributeCheck.CheckAttributePresence(entity.Name, att.Name, raw.Section, true, "Section"))
			{
				switch (raw.Section.ToLower())
				{
					case "model":
						e.AddModelAttribute((DataObjectAttribute)att);
						break;
					case "exemplar":
						e.AddExemplarAttribute((DataObjectAttribute)att);
						break;
					case "description":
						e.AddDescriptionAttribute((DataObjectAttribute)att);
						break;
					default:
						ErrorManager.ErrorRef("UNKNOWN_SECTION", entity.Name, raw.Section);
						break;
				}
			}
		}
	}
}
