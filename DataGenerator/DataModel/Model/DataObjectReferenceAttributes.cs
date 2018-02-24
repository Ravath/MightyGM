using DataGenerator.CSharp;
using DataGenerator.SQL;
using System;

namespace DataGenerator.DataModel.Model
{
	public abstract class DataObjectReferenceAttribute : AbsDataStructAttribute
	{
		public DataObjectReferenceAttribute(string name) : base(name) { }

		public AbsDataStruct Reference { get; set; }
		public AbsDataStructAttribute Reflexive { get; set; }

		protected override string GetTypeName() { return TypeName + "(" + Reference.Name + ")"; }
		protected override object GetBonus() { return Reflexive?.Name ?? ""; }
		protected abstract CSClass GetReferencedClass(Generation generation);
		protected override SQLTypeEnum GetSqlType() { return SQLTypeEnum.Int; }

		public override void AddAttribute(Generation generation, CSClass cs)
		{
			CSClass refer = GetReferencedClass(generation);
			if (Reflexive == null)
			{
				if (IsCollection)
				{//Reference To Many
					CSOneToManyJoint csAtt = new CSOneToManyJoint(refer, Name);
					cs.AddAttribute(csAtt);
					//Create inderection table
					CSRelationClass csRel = new CSRelationClass(csAtt.Class, csAtt.ReferencedClass, generation.SchemaSql, csAtt.Name);
					generation.AddToSql(csRel.SQLTable);
					generation.JoinFile.AddClasse(csRel);
					csAtt.Joint = csRel;
					csAtt.FromLeft = true;
					csAtt.Class.AddJoint(csAtt, csRel);
					csAtt.Annotations.AddAnnotation(new CSAssociationAnnotation("Id", csAtt.Name, csRel.Attribute1.PublicIdName, false));
				}
				else
				{//Reference To One => have an Id to the reference
					SQLForeignKeyAttribute sfk = new SQLForeignKeyAttribute(refer, Name);
					CSForeignKey fk = new CSForeignKey(sfk, Name);
					CSReferenceToUniqueClass refo = new CSReferenceToUniqueClass(refer, fk, Name);
					cs.SQLTable.AddAttribute(sfk);
					cs.AddAttribute(fk);
					cs.AddAttribute(refo);
				}
			}
			else
			{
				CSReferenceAttribute cra;
				if (IsCollection && Reflexive.IsCollection)//Many to Many
				{
					cra = new CSOneToManyJoint(refer, Name);
				}
				else if (IsCollection)//One To Many
				{
					cra = new CSOneToMany(refer, Name);
				}
				else if (Reflexive.IsCollection)//Many To One
				{
					cra = new CSManyToOne(refer, Name);
					SQLForeignKeyAttribute sk = new SQLForeignKeyAttribute(refer, Name);
					CSForeignKey cf = new CSForeignKey(sk, Name);
					cs.AddAttribute(cf);
					cs.SQLTable.AddAttribute(sk);
				}
				else//One to One
				{
					cra = new CSOneToOne(refer, Name);
					SQLForeignKeyAttribute sk = new SQLForeignKeyAttribute(refer, Name);
					CSForeignKey cf = new CSForeignKey(sk, Name);
					cs.AddAttribute(cf);
					cs.SQLTable.AddAttribute(sk);
				}
				cs.AddAttribute(cra);
				generation.RegisterReference(cra, this);
			}
		}

		/// <summary>
		/// Is not used, and should generate an error.
		/// </summary>
		/// <param name="generation"></param>
		/// <param name="cs"></param>
		/// <returns></returns>
		protected override CSAttribute GeneratedSpecific(Generation generation, CSClass cs) { throw new NotImplementedException(); }
	}


	public class DataObjectModelRefAttribute : DataObjectReferenceAttribute
	{
		public DataObjectModelRefAttribute(string name) : base(name) { TypeName = "ref"; }

		protected override CSClass GetReferencedClass(Generation generation)
		{
			if (Reference is DataStruct ds) { return generation.GetStruct(ds); }
			else { return generation.GetModelClass(Reference); }
		}
	}


	public class DataObjectExemplarRefAttribute : DataObjectReferenceAttribute
	{
		public DataObjectExemplarRefAttribute(string name) : base(name) { TypeName = "refex"; }

		protected override CSClass GetReferencedClass(Generation generation)
		{
			return generation.GetExemplarClass(Reference);
		}
	}
}
