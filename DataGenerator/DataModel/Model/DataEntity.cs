using DataGenerator.DataModel.EntityConvert;
using System.Collections.Generic;
using System.IO;

namespace DataGenerator.DataModel.Model
{
	/// <summary>
	/// The base class of every entity models.
	/// </summary>
	public abstract class DataEntity
	{
		private List<MinorTag> _tags = new List<MinorTag>();

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="name">The Name of the Entity.</param>
		public DataEntity(string name) { Name = name; }


		public string Name { get; set; }
		public bool IsAbstract { get { return _tags.Contains(MinorTag.Abstract); } }
		public void AddTags(IEnumerable<MinorTag> newTags) { _tags.AddRange(newTags); }
		public IEnumerable<MinorTag> Tags { get { return _tags; } }
		public bool HasTag(MinorTag tag) { return _tags.Contains(tag); }


		#region Console Print
		public abstract void Print(TextWriter printer);
		public string GetTagString()
		{
			if (_tags.Count == 0)
			{
				return "";
			}
			string result = "[" + _tags[0].ToString();
			for (int i = 1; i < _tags.Count; i++)
			{
				result += "," + _tags[i].ToString();
			}
			return result + "]";
		} 
		#endregion


		#region Generation processes
		/// <summary>
		/// Generate the Data Entity as classes and tables in the Generation class.
		/// </summary>
		/// <param name="generation">The result of the whole generation to complete.</param>
		public abstract void Generate(Generation generation);
		/// <summary>
		/// Link if necessary the DataEntity to its base classes.
		/// </summary>
		/// <param name="generation">The result of the whole generation to complete.</param>
		public abstract void LinkParents(Generation generation);
		/// <summary>
		/// Add the attributes to the generation.
		/// </summary>
		/// <param name="generation">The result of the whole generation to complete.</param>
		public abstract void CreateAttributes(Generation generation);
		#endregion
	}

	/// <summary>
	/// The base class of every Entity attribute.
	/// </summary>
	public abstract class DataEntityAttribute
	{
		private DataEntity _parent;


		/// <summary>
		/// The name of the attribute;
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The Associated DataEntity.
		/// </summary>
		public DataEntity Parent
		{
			get { return _parent; }
			internal set
			{
				if (_parent != value)
				{
					_parent = value;
				}
			}
		}

		/// <summary>
		/// Default Constructor.
		/// </summary>
		/// <param name="name">The Name of the attribute.</param>
		public DataEntityAttribute(string name)
		{
			Name = name;
		}
	}
}
