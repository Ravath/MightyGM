using DataGenerator.CSharp;
using DataGenerator.SQL;
using System.IO;

namespace DataGenerator.DataModel.Model
{
	public class DataStruct : AbsDataStruct
	{
		public DataStruct(string name) : base(name) {
			Attributes = new AttributeCollection<AbsDataStructAttribute>(this);
		}

		public DataStruct Parent { get; set; }

		public readonly AttributeCollection<AbsDataStructAttribute> Attributes;

		public override void Print(TextWriter printer)
		{
			printer.WriteLine("STRUCT: " + Name + " [" + (Parent?.Name ?? "") + "]" + GetTagString());
			foreach (var att in Attributes.Attributes)
			{
				att.Print(printer);
			}
		}

		public override void Generate(Generation generation)
		{
			//Class Creation
			CSStruct cs = new CSStruct(Name, generation.SchemaSql, IsAbstract);
			generation.AddStruct(this, cs);
			generation.AddToSql(cs.SQLTable);

			//Files Creation
			CsFile mainFile = new CsFile(Name);
			CsFile secondaryFile = new CsFile(Name);
			mainFile.AddClasse(cs);
			secondaryFile.AddClasse(new CSPartialClass(cs));

			//Files Add
			generation.AddCsFile(mainFile);
			generation.AddPartialCsFile(secondaryFile);
		}

		public override void LinkParents(Generation generation)
		{
			if (Parent != null)
			{
				CSClass cs = generation.GetStruct(this);
				CSClass cl = generation.GetStruct(Parent);
				//Should necessarily be found
				cs.Parent = cl;
				cs.SQLTable.Parent = cl.SQLTable;
				cs.SQLTable.AddConstraint(new SQLPrimaryKey(new SQLID()));
			}
		}

		public override void CreateAttributes(Generation generation)
		{
			CSClass cs = generation.GetStruct(this);
			foreach (AbsDataStructAttribute vatt in Attributes.Attributes)
			{
				vatt.AddAttribute(generation, cs);
			}
		}
	}
}
