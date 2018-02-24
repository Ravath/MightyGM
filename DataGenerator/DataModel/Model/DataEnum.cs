using DataGenerator.CSharp;
using System.IO;
using System;

namespace DataGenerator.DataModel.Model
{
	/// <summary>
	/// Enum Entity.
	/// </summary>
	public class DataEnum : DataEntity
	{
		#region Attributes Collection
		private AttributeCollection<DataEnumAttribute> _attributes;
		public AttributeCollection<DataEnumAttribute> Attributes
		{
			get { return _attributes; }
		}
		private string _unitTypeName;
		public string UnitTypeName()
		{
			return _unitTypeName;
		}
		#endregion

		#region Init
		public DataEnum(string name) : base(name) {
			_attributes = new AttributeCollection<DataEnumAttribute>(this);
			_unitTypeName = "UnitValue<int," + Name + ">";
		}
		public DataEnum(string name, string unitTypeName) : base(name)
		{
			_attributes = new AttributeCollection<DataEnumAttribute>(this);
			_unitTypeName = unitTypeName;
		}
		#endregion

		public override void Print(TextWriter printer)
		{
			printer.WriteLine("ENUM: " + Name + GetTagString());
			foreach (var att in Attributes.Attributes)
			{
				printer.WriteLine("\t" + att.Name);
			}
		}

		public override void Generate(Generation generation)
		{
			CSEnum et = new CSEnum(Name);
			foreach (DataEnumAttribute tag in Attributes.Attributes)
			{
				et.AddTag(tag.Name);
			}
			generation.AddEnum(this, et);
		}

		public override void LinkParents(Generation generation){ /* Nothing ot do */ }
		public override void CreateAttributes(Generation generation) { /* Nothing ot do */ }
	}

	/// <summary>
	/// Attribute of an Enum entity.
	/// </summary>
	public class DataEnumAttribute : DataEntityAttribute
	{
		public DataEnumAttribute(string name) : base(name) { }
	}
}