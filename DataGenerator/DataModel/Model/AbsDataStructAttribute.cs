using DataGenerator.CSharp;
using DataGenerator.SQL;
using System.IO;

namespace DataGenerator.DataModel.Model
{
	public abstract class AbsDataStructAttribute : DataEntityAttribute
	{
		public string TypeName { get; protected set; }
		public bool CanBeNull { get; set; }
		public bool IsCollection { get; set; }

		public AbsDataStructAttribute(string name) : base(name) { }

		public virtual void Print(TextWriter printer)
		{
			printer.WriteLine(string.Format("\t{0} {1} [{2}-{3}] {4}", GetTypeName(), Name, (CanBeNull ? "0" : " "), (IsCollection ? "*" : " "), GetBonus()));
		}

		protected virtual object GetBonus() { return ""; }

		protected virtual string GetTypeName()
		{
			return TypeName;
		}

		protected abstract CSAttribute GeneratedSpecific(Generation generation, CSClass cs);
		protected abstract SQLTypeEnum GetSqlType();

		public virtual void AddAttribute(Generation generation, CSClass cs)
		{
			CSAttribute csAtt = GeneratedSpecific(generation, cs);
			if (IsCollection)
			{//collection => créer une table des valeurs
				CSDataValueClass colTab = CreateCollectionValueTable(generation, cs, csAtt);
				//Link the collection table to SQL
				foreach (SQLAttribute sqlAtt in csAtt.GetSQLAttributes())
				{
					colTab.SQLTable.AddAttribute(sqlAtt);
				}
			}
			else
			{
				cs.AddAttribute(csAtt);
				//Link the class to SQL
				foreach (SQLAttribute sqlAtt in csAtt.GetSQLAttributes())
				{
					cs.SQLTable.AddAttribute(sqlAtt);
				}
			}
		}

		protected CSDataValueClass CreateCollectionValueTable(Generation generation, CSClass from, CSAttribute csAtt)
		{
			//la valeur à collectionner
			csAtt.IsCollection = false;
			csAtt.IsNullable = false;
			//créer une table et classe des valeurs
			CSDataValueClass collectionClass = new CSDataValueClass(from, (CSValueAttribute)csAtt, generation.SchemaSql);
			//ajouter aux listes
			generation.AddToSql(collectionClass.SQLTable);
			generation.JoinFile.AddClasse(collectionClass);
			//attribut de collection du conteneur
			CSDataValueCollectionReference collection = new CSDataValueCollectionReference(collectionClass, csAtt.Name);
			from.AddAttribute(collection);
			from.AddDataValue(collectionClass);
			return collectionClass;
		}
	}
}