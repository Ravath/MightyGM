using DataGenerator.DataModel.Model;
using DataGenerator.Parser;

namespace DataGenerator.DataModel.AttributeConvert
{
	/// <summary>
	/// Base class of attribute Section Converters.
	/// </summary>
	public abstract class AbsSectionConverter : AbsAttributeConverter
	{
		public static EnumSectionConverter EnumSection = new EnumSectionConverter();
		public static DiceSectionConverter DiceSection = new DiceSectionConverter();
		public static StructSectionConverter StructSection = new StructSectionConverter();
		public static DataObjectSectionConverter ObjectSection = new DataObjectSectionConverter();

		public abstract void AddAttribute(DataEntity entity, DataEntityAttribute att, RawAttribute raw);

		protected void NoSection(DataEntity entity, DataEntityAttribute att, RawAttribute raw)
		{
			CheckAttributePresence(entity.Name, att.Name, raw.Section, false, "Section");
		}
	}

	/// <summary>
	/// Check there isn't a Section value in the RawAttribute, which is therefore not used.
	/// </summary>
	public class EnumSectionConverter : AbsSectionConverter
	{
		public override void AddAttribute(DataEntity entity, DataEntityAttribute att, RawAttribute raw)
		{
			NoSection(entity, att, raw);
			DataEnum e = (DataEnum)entity;
			e.Attributes.Add((DataEnumAttribute)att);
		}
	}

	public class DiceSectionConverter : AbsSectionConverter
	{
		public override void AddAttribute(DataEntity entity, DataEntityAttribute att, RawAttribute raw)
		{
			NoSection(entity, att, raw);
			DataDice e = (DataDice)entity;
			e.Attributes.Add((DataDiceAttribute)att);
		}
	}

	public class StructSectionConverter : AbsSectionConverter
	{
		public override void AddAttribute(DataEntity entity, DataEntityAttribute att, RawAttribute raw)
		{
			//no section, but exception for model keyword
			if(raw.Section.ToLower() != "model")
			{
				NoSection(entity, att, raw);
			}
			//add attribute
			DataStruct e = (DataStruct)entity;
			e.Attributes.Add((AbsDataStructAttribute)att);
		}
	}

	public class DataObjectSectionConverter : AbsSectionConverter
	{
		public override void AddAttribute(DataEntity entity, DataEntityAttribute att, RawAttribute raw)
		{
			DataObject e = (DataObject)entity;
			if (raw.Section == null)
				raw.Section = "";
			switch (raw.Section.ToLower())
			{
				case "":
				case "model":
					e.ModelAttributes.Add((AbsDataStructAttribute)att);
					break;
				case "exemplar":
					e.ExemplarAttributes.Add((AbsDataStructAttribute)att);
					break;
				case "description":
					e.DescriptionAttributes.Add((AbsDataStructAttribute)att);
					break;
				default:
					ErrorManager.ErrorRef("UNKNOWN_SECTION", entity.Name, raw.Section);
					break;
			}
		}
	}
}
