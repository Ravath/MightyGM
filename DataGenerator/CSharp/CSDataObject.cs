using DataGenerator.DataModel;
using DataGenerator.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.CSharp
{
	public class CSDataObject : CSClass
	{
		static CSDataObject()
		{
			DataObject = new CSClass("DataObject");
			sqlDataObject = new SQLTable(DataObject.Name);
			sqlDataObject.AddAttribute(new SQLID());
		}
		public static readonly CSClass DataObject;
		public static readonly SQLTable sqlDataObject;
		public CSDataObject(string name, SQLSchema schema) : base(name)
		{
			Parent = DataObject;
			//table sql
			SQLTable sql = new SQLTable(name);
			sql.Schema = schema;
			sql.Parent = sqlDataObject;
			AddRelationToSqlTable(sql);
		}
	}

	public class CSStruct : CSDataObject
	{
		public CSStruct(StructTable table, SQLSchema schema) : base(table.Name, schema)
		{
			Abstract = table.IsAbstract;
			Partial = true;
			if (!table.IsAbstract)
				Annotations.AddAnnotation(new CSAnnotation() { Name = "CoreData" });
		}
	}

	public class CSDataModel : CSDataObject
	{
		public CSDataModel(DataTable table, SQLSchema schema) : base(ModelGenerator.ClassNameFromTableName(table.Name, Section.Model), schema)
		{
			Parent = ModelClass;
			Abstract = table.IsAbstract;
			Partial = true;
			if (!table.IsAbstract)
				Annotations.AddAnnotation(new CSAnnotation() { Name = "CoreData" });
		}
		public static readonly CSClass ModelClass = new CSClass("DataModel");
	}

	public class CSDataExemplaire : CSDataObject
	{
		public CSDataExemplaire(DataTable table, SQLSchema schema) : base(ModelGenerator.ClassNameFromTableName(table.Name, Section.Exemplar), schema)
		{
			Parent = ExemplarClass;
			Abstract = table.IsAbstract;
			Partial = true;
		}
		public static readonly CSClass ExemplarClass = new CSClass("DataExemplaire");
	}

	public class CSDataDescription : CSDataObject
	{
		public CSDataDescription(DataTable table, SQLSchema schema) : base(ModelGenerator.ClassNameFromTableName(table.Name, Section.Description), schema)
		{
			Parent = DescriptionClass;
			Abstract = table.IsAbstract;
			Partial = true;
		}
		public static readonly CSClass DescriptionClass = new CSClass("DataDescription");
	}
	/// <summary>
	/// La classe de la table de jointure.
	/// </summary>
	public class CSRelationClass : CSDataObject
	{
		static
		#region members
		private CSClass _c1, _c2;
		private SQLForeignKeyAttribute _k1, _k2;
		private readonly CSClass DataRelation = new CSClass("DataRelation", CSDataObject.sqlDataObject);
		private CSDataRelationAttribute _att1, _att2;
		#endregion

		#region Properties
		public CSDataRelationAttribute Attribute1
		{
			get { return _att1; }
		}
		public CSDataRelationAttribute Attribute2
		{
			get { return _att2; }
		}
		#endregion
		public CSRelationClass(CSClass c1, CSClass c2, SQLSchema schema, string cplName) : base(c1.Name + "To" + c2.Name + "_" + cplName, schema)
		{
			create(c1, c2);
			/* if the jointure is a self reference, 
				must differentiate the names by using the attribute name, 
				because class names aren't enought */
			if (c1.Name == c2.Name)
			{
				_att1.Name += cplName;
				_k1.Name += cplName;
			}
		}
		public CSRelationClass(CSClass c1, CSClass c2, SQLSchema schema, string att1, string att2) : base(c1.Name + att1 + "To" + c2.Name + att2, schema)
		{
			create(c1, c2);
			/* if the jointure is a self reference, 
				must differentiate the names by using the attributes names, 
				because class names aren't enought */
			if (c1.Name == c2.Name)
			{
				_att1.Name += att1;
				_att2.Name += att2;
				_k1.Name += att1;
				_k1.Name += att2;
			}
		}
		private void create(CSClass c1, CSClass c2)
		{
			//creation classe et table
			_c1 = c1;
			_c2 = c2;
			Parent = DataRelation;
			AddParentTemplate(c1);
			AddParentTemplate(c2);
			//creation des colonnes sql
			_k1 = new SQLForeignKeyAttribute(c1.Name, "join");
			_k2 = new SQLForeignKeyAttribute(c2.Name, "join");
			//SQLTable.AddAttribute(new SQLID());
			SQLTable.AddAttribute(_k1);
			SQLTable.AddAttribute(_k2);
			_att1 = new CSDataRelationAttribute(_c1, _k1, 1);
			_att2 = new CSDataRelationAttribute(_c2, _k2, 2);
			AddAttribute(_att1);
			AddAttribute(_att2);
		}
	}
	/// <summary>
	/// Used for the relation From[]-[*]Value.
	/// That is : Many elementary values.
	/// </summary>
	public class CSDataValueClass : CSDataObject
	{

		private static readonly CSClass rParent = new CSClass("DataValue");

		private CSClass _class;
		AbstractCSValueAttribute _att;
		CSDataValueReferenceToClass _classReference;

		public CSClass ReferedClass { get { return _class; } }
		public AbstractCSValueAttribute ValueAttribute { get { return _att; } }
		public CSDataValueReferenceToClass Conteneur { get { return _classReference; } }

		public CSDataValueClass(CSClass from, CSValueAttribute value, SQLAttribute sqlValue, SQLSchema schema)
				: base(value.Name + "From" + from.Name, schema)
		{
			_class = from;
			_att = new CSDataValueProperty(value);
			Parent = rParent;
			AddParentTemplate(from);
			AddParentTemplate(value.Type);
			//attributs de la table sql
			SQLForeignKeyAttribute sqlForeignKey = new SQLForeignKeyAttribute(from, "from");
			//SQLTable.AddAttribute(new SQLID());
			SQLTable.AddAttribute(sqlForeignKey);
			SQLTable.AddAttribute(sqlValue);
			//attributs de la classe C#
			//référence vers le conteneur
			CSDataValueForeignKey foreignKey = new CSDataValueForeignKey(sqlForeignKey, from.Name);
			_classReference = new CSDataValueReferenceToClass(from, foreignKey, from.Name);
			AddAttribute(_att);
			AddAttribute(foreignKey);
			AddAttribute(Conteneur);
		}
	}
}
