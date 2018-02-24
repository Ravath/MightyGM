using DataGenerator.DataModel.Model;
using DataGenerator.SQL;
using System.Text;

namespace DataGenerator.CSharp
{
	/// <summary>
	/// A C# Attribute for int values [min-max]
	/// </summary>
	public class CSRangeAttribute : CSAttribute {

		public SQLAttribute SqlMinAttribute { get; private set; }
		public SQLAttribute SqlMaxAttribute { get; private set; }

		public CSRangeAttribute(DataObjectRangeAttribute vatt) : base(vatt)
		{
			SqlMinAttribute = new SQLAttribute()
			{
				Name = Name + "_min",
				Type = SQLTypeEnum.Int
			};
			SqlMaxAttribute = new SQLAttribute()
			{
				Name = Name + "_max",
				Type = SQLTypeEnum.Int
			};
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			CodeWriter cw = new CodeWriter(sb, indentation).
				AddIndLine("[Column(Name=\"" + SqlMinAttribute.Name + "\", Storage=\"" + PascalCaseName + "Min\")]").
				Property("int", PascalCaseName + "Min",
					"return " + PascalCaseName + ".Min;",
					PascalCaseName + ".Min = value;").nl().
				AddIndLine("[Column(Name=\"" + SqlMaxAttribute.Name + "\", Storage=\"" + PascalCaseName + "Max\")]").
				Property("int", PascalCaseName + "Max",
					"return " + PascalCaseName + ".Max;",
					PascalCaseName + ".Max = value;").nl().
				AddIndLine("private Range _" + CamelCaseName + " = new Range();").
				AddIndLine("[HiddenProperty]").
				Property("Range", PascalCaseName,
					"return _"+ CamelCaseName+";",
                    "_"+CamelCaseName+" = value;").nl();
		}
	}

	/// <summary>
	/// A C# property for values [val:UNIT]
	/// </summary>
	public class CSUnityValueAttribute : CSAttribute {
		private string unityValueName;
		private string unitName;
		public SQLAttribute SqlValueAttribute { get; private set; }
		public SQLAttribute SqlUnitAttribute { get; private set; }

		public CSUnityValueAttribute(DataObjectUnitAttribute vatt, string uvTypeName, string unitName) : base(vatt)
		{
			this.unityValueName = uvTypeName;
			this.unitName = unitName;
			SqlValueAttribute = new SQLAttribute()
			{
				Name = Name + "_val",
				Type = SQLTypeEnum.Int
			};
			SqlUnitAttribute = new SQLAttribute()
			{
				Name = Name + "_unit",
				Type = SQLTypeEnum.Int
			};
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			CodeWriter cw = new CodeWriter(sb, indentation).
				AddIndLine("[Column(Name = \"" + SqlValueAttribute.Name + "\", Storage=\"" + PascalCaseName + "Val\")]").
				Property("int", PascalCaseName + "Val",
					"return " + PascalCaseName + ".Value;",
					PascalCaseName + ".Value = value;").nl().
				AddIndLine("[Column(Name = \"" + SqlUnitAttribute.Name + "\", Storage=\"" + PascalCaseName + "Unit\")]").
				Property(unitName, PascalCaseName + "Unit",
					"return " + PascalCaseName + ".Unity;",
					PascalCaseName + ".Unity = value;").nl().
				AddIndLine("private "+ unityValueName +" _" + CamelCaseName + " = new "+ unityValueName +"();").
				AddIndLine("[HiddenProperty]").
				Property(unityValueName, PascalCaseName,
					"return _" + CamelCaseName + ";",
					"_" + CamelCaseName + " = value;").nl();
		}
	}
}
