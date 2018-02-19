using DataGenerator.DataModel;
using DataGenerator.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.CSharp {
	public class CSRangeAttribute : CSAttribute {

		public SQLAttribute SqlMinAttribute { get; private set; }
		public SQLAttribute SqlMaxAttribute { get; private set; }

		public CSRangeAttribute( ValueAttribute vatt) : base(vatt) {
			SqlMinAttribute = new SQLAttribute() {
				Name = Name + "_min",
				Type = SQLTypeEnum.Int
			};
			SqlMaxAttribute = new SQLAttribute() {
				Name = Name + "_max",
                Type = SQLTypeEnum.Int
			};
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			CodeWriter cw = new CodeWriter(sb, indentation).
				AddIndLine("[Column(Name=\"" + SqlMinAttribute.Name + "\", Storage=\"" + PascalCaseName + "Min\")]").
				AddIndLine("[HiddenProperty]").
				Property("int", PascalCaseName + "Min",
					"return " + PascalCaseName + ".Min;",
					PascalCaseName + ".Min = value;").nl().
				AddIndLine("[Column(Name=\"" + SqlMaxAttribute.Name + "\", Storage=\"" + PascalCaseName + "Max\")]").
				AddIndLine("[HiddenProperty]").
				Property("int", PascalCaseName + "Max",
					"return " + PascalCaseName + ".Max;",
					PascalCaseName + ".Max = value;").nl().
				AddIndLine("private Range _" + CamelCaseName + " = new Range();").
				Property("Range", PascalCaseName,
					"return _"+ CamelCaseName+";",
                    "_"+CamelCaseName+" = value;").nl();
		}
	}
	public class CSDistanceAttribute : CSUnityValueAttribute {
		public CSDistanceAttribute( ValueAttribute vatt ) : base(vatt, "Distance", "DistanceUnity") { }
	}
	public class CSTimeAttribute : CSUnityValueAttribute {
		public CSTimeAttribute( ValueAttribute vatt ) : base(vatt, "TimePeriod", "TimeUnity") { }
	}
	public class CSUnityValueAttribute : CSAttribute {
		private string unityValueName;
		private string unitName;
		public SQLAttribute SqlValueAttribute { get; private set; }
		public SQLAttribute SqlUnitAttribute { get; private set; }

		public CSUnityValueAttribute( ValueAttribute vatt, string uvTypeName, string unitName ) : base(vatt) {
			this.unityValueName = uvTypeName;
            this.unitName = unitName;
            SqlValueAttribute = new SQLAttribute() {
				Name = Name + "_val",
				Type = SQLTypeEnum.Int
			};
			SqlUnitAttribute = new SQLAttribute() {
				Name = Name + "_unit",
				Type = SQLTypeEnum.Int
			};
		}

		public override void CreateString( StringBuilder sb, IndentationCount indentation ) {
			CodeWriter cw = new CodeWriter(sb, indentation).
				AddIndLine("[Column(Name = \"" + SqlValueAttribute.Name + "\", Storage=\"" + PascalCaseName + "Val\")]").
				AddIndLine("[HiddenProperty]").
				Property("int", PascalCaseName + "Val",
					"return " + PascalCaseName + ".Value;",
					PascalCaseName + ".Value = value;").nl().
				AddIndLine("[Column(Name = \"" + SqlUnitAttribute.Name + "\", Storage=\"" + PascalCaseName + "Unit\")]").
				AddIndLine("[HiddenProperty]").
				Property(unitName, PascalCaseName + "Unit",
					"return " + PascalCaseName + ".Unity;",
					PascalCaseName + ".Unity = value;").nl().
				AddIndLine("private "+ unityValueName +" _" + CamelCaseName + " = new "+ unityValueName +"();").
				Property(unityValueName, PascalCaseName,
					"return _" + CamelCaseName + ";",
					"_" + CamelCaseName + " = value;").nl();
		}
	}
}
