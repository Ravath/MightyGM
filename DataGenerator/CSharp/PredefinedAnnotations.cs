namespace DataGenerator.CSharp
{
	public class CSTableAnnotation : CSAnnotation
	{
		public CSTableAnnotation(string schema, string name) : base("Table")
		{
			AddArgument("Schema", schema);
			AddArgument("Name", name);
		}
	}

	public class CSColumnAnnotation : CSAnnotation
	{
		public CSColumnAnnotation(string storage, string name) : base("Column")
		{
			AddArgument("Storage", storage);
			AddArgument("Name", name);
		}
	}

	public class CSAssociationAnnotation : CSAnnotation
	{
		public CSAssociationAnnotation(string storage, string otherkey) : base("Association")
		{
			AddArgument("ThisKey", "Id");
			AddArgument("CanBeNull", true);
			AddArgument("Storage", storage);
			AddArgument("OtherKey", otherkey);
		}
		public CSAssociationAnnotation(string thisKey, string storage, string otherkey, bool canBeNull) : base("Association")
		{
			AddArgument("ThisKey", thisKey);
			AddArgument("CanBeNull", canBeNull);
			AddArgument("Storage", storage);
			AddArgument("OtherKey", otherkey);
		}
	}
}
