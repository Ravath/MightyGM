using DataGenerator.DataModel.AttributeConvert;
using DataGenerator.DataModel.Model;
using DataGenerator.Parser;

namespace DataGenerator.DataModel.EntityConvert
{
	/// <summary>
	/// Base class of every converter from RawTable to DataEntity.
	/// </summary>
	public abstract class AbsEntityConverter
	{
		protected AbsEntityNameConverter	NameConverter		{ get; set; }
		protected AbsMajorTagConverter		MajorTagConverter	{ get; set; }
		protected AbsMinorTagConverter		MinorTagConverter	{ get; set; }
		protected AttributeConverter		AttributeConverter	{ get; set; }

		public abstract string EntityTag { get; }


		#region Init
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public AbsEntityConverter()
		{
			NameConverter = AbsEntityNameConverter.DefaultEntityNameConverter;
		}
		#endregion

		/// <summary>
		/// Add the entity to the DataModel.
		/// </summary>
		/// <param name="dm"></param>
		/// <param name="tabName"></param>
		/// <returns></returns>
		public abstract DataEntity AddEntity(DatabaseModel dm, string tabName);

		/// <summary>
		/// Get the Name of the entity in model.
		/// </summary>
		/// <param name="tab"></param>
		/// <returns></returns>
		public string GetName(RawTable tab)
		{
			return NameConverter.GetName(tab);
		}

		/// <summary>
		/// Manage the Minor Tags of the entity.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="tab"></param>
		public void GetTags(DataEntity entity, RawTable tab)
		{
			MinorTagConverter.ConvertTags(entity, tab.MinorTags);
		}

		/// <summary>
		/// Manage the Major Tag of the entity. mainly ocnsists in inheritance.
		/// </summary>
		/// <param name="dm"></param>
		/// <param name="entity"></param>
		/// <param name="tab"></param>
		public void LinkInheritance(DatabaseModel dm, DataEntity entity, RawTable tab)
		{
			MajorTagConverter.ConvertTag(dm, entity, tab);
		}

		/// <summary>
		/// Manage the creation of the attributes of the entity.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="tab"></param>
		public void CreateAttributes(DataEntity entity, RawTable tab)
		{
			foreach (RawAttribute att in tab.Attributes)
			{
				AttributeConverter.AddAttribute(entity, att);
			}
		}

		/// <summary>
		/// Manage the links between attributes of entities.
		/// </summary>
		/// <param name="dm"></param>
		/// <param name="entity"></param>
		/// <param name="tab"></param>
		public void LinkAttributes(DatabaseModel dm, DataEntity entity, RawTable tab)
		{
			AttributeConverter.ReflexReferenceConverter.Convert(dm, entity, tab);
		}
	}
}
