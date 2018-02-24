namespace DataGenerator.SQL
{
	/// <summary>
	/// The Primary Key Sql Constraint.
	/// </summary>
	public class SQLPrimaryKey : SQLConstraint
	{
		public SQLPrimaryKey() : base("primary key") { }
		public SQLPrimaryKey(SQLAttribute att) : this()
		{
			AddAttributeRef(att);
		}
	}
	/// <summary>
	/// The Unique Sql Constraint.
	/// </summary>
	public class SQLUnique : SQLConstraint
	{
		public SQLUnique() : base("unique") { }
		public SQLUnique(SQLAttribute att) : this()
		{
			AddAttributeRef(att);
		}
	}
}
