using DataGenerator.CSharp;
using DataGenerator.DataModel.EntityConvert;
using DataGenerator.SQL;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataGenerator.DataModel.Model
{
	public class DataObject : AbsDataStruct
	{
		public DataObject( string name ) : base(name) {
			ModelAttributes = new AttributeCollection<AbsDataStructAttribute>(this);
			ExemplarAttributes = new AttributeCollection<AbsDataStructAttribute>(this);
			DescriptionAttributes = new AttributeCollection<AbsDataStructAttribute>(this);
		}
			public DataObject Parent { get; set; }

		/// <summary>
		/// Get every Attribute defined for the DataObject.
		/// </summary>
		public IEnumerable<AbsDataStructAttribute> Attributes
		{
			get
			{
				return ModelAttributes.Attributes.
					Union(ExemplarAttributes.Attributes).
					Union(DescriptionAttributes.Attributes);
			}
		}

		#region Attributes Collections
		public readonly AttributeCollection<AbsDataStructAttribute> ModelAttributes;
		public readonly AttributeCollection<AbsDataStructAttribute> ExemplarAttributes;
		public readonly AttributeCollection<AbsDataStructAttribute> DescriptionAttributes;
		#endregion

		public override void Print(TextWriter printer)
		{
			printer.WriteLine("DATA: " + Name + " [" + (Parent?.Name ?? "") + "]" + GetTagString());
			printer.WriteLine("\t=MODEL=");
			foreach (var att in ModelAttributes.Attributes)
			{
				att.Print(printer);
			}
			printer.WriteLine("\t=EXEMPLAR=");
			foreach (var att in ExemplarAttributes.Attributes)
			{
				att.Print(printer);
			}
			printer.WriteLine("\t=DESCRIPTION=");
			foreach (var att in DescriptionAttributes.Attributes)
			{
				att.Print(printer);
			}
		}

		public override void Generate(Generation generation)
		{
			//Files Creation
			CsFile genFile = new CsFile(Name);
			CsFile userFile = new CsFile(Name);
			generation.AddPartialCsFile(userFile);
			generation.AddCsFile(genFile);
			//Classes Creation
			CSClass modelClass = new CSDataModel(Name, generation.SchemaSql, IsAbstract);
			CSClass descriptionClass = new CSDataDescription(Name, generation.SchemaSql, IsAbstract);
			CSClass exemplarClass = new CSDataExemplar(Name, generation.SchemaSql, IsAbstract);
			generation.AddDataObject(this, modelClass, exemplarClass, descriptionClass);
			//Link to Files
			foreach (CSClass cs in new CSClass[] { modelClass, descriptionClass, exemplarClass })
			{
				genFile.AddClasse(cs);
				userFile.AddClasse(new CSPartialClass(cs));
				generation.AddToSql(cs.SQLTable);
			}

			//ajouter Propriete description
			if (!IsAbstract)
			{
				CSDescriptionAttribute cd = new CSDescriptionAttribute(descriptionClass);
				modelClass.AddAttribute(cd);
			}
			//tag PJ : ajouter propriété JoueurModel
			if (HasTag(MinorTag.Pj))
			{
				SQLForeignKeyAttribute sfk = new SQLForeignKeyAttribute("Player", "id");
				CSForeignKey fg = new CSForeignKey(sfk, "Player");
				modelClass.AddAttribute(fg);
				modelClass.AddAttribute( new CSOneToOne(new CSClass("Player"), "Player") );
				modelClass.SQLTable.AddAttribute(sfk);
			}
		}

		public override void LinkParents(Generation generation)
		{
			//Retrieve Classes
			CSClass model = generation.GetModelClass(this);
			CSClass exemp = generation.GetExemplarClass(this);
			CSClass descr = generation.GetDescriptionClass(this);
			if (Parent == null)
			{
				//Add Specific Attributes
				exemp.AddParentTemplate(model);
				descr.AddParentTemplate(model);
				model.SQLTable.AddAttribute(new SQLUniqueName());
				model.SQLTable.AddAttribute(new SQLTag());
				descr.SQLTable.AddAttribute(new SQLDescription());
				descr.SQLTable.AddAttribute(new SQLForeignKeyAttribute("model", "id"));
				exemp.SQLTable.AddAttribute(new SQLForeignKeyAttribute("model", "id"));
			}
			else
			{
				//Link to Parent
				model.Parent = generation.GetModelClass(this.Parent);
				exemp.Parent = generation.GetExemplarClass(this.Parent);
				descr.Parent = generation.GetDescriptionClass(this.Parent);
				//Add Necessary Attributes
				foreach (CSClass cs in new CSClass[] { model, exemp, descr })
				{
					cs.SQLTable.Parent = cs.Parent.SQLTable;
					cs.SQLTable.AddConstraint(new SQLPrimaryKey(new SQLID()));
				}
			}
		}

		public override void CreateAttributes(Generation generation)
		{
			//Retrieve Classes
			CSClass model = generation.GetModelClass(this);
			CSClass exemp = generation.GetExemplarClass(this);
			CSClass descr = generation.GetDescriptionClass(this);
			//attributs
			foreach (AbsDataStructAttribute vatt in ModelAttributes.Attributes)
			{
				vatt.AddAttribute(generation, model);
			}
			foreach (AbsDataStructAttribute vatt in ExemplarAttributes.Attributes)
			{
				vatt.AddAttribute(generation, exemp);
			}
			foreach (AbsDataStructAttribute vatt in DescriptionAttributes.Attributes)
			{
				vatt.AddAttribute(generation, descr);
			}
		}
	}
}
