using DataGenerator.CSharp;
using System.IO;

namespace DataGenerator.DataModel.Model
{
	public class DataDice : DataEntity
	{
		#region Attributes Collection
		private AttributeCollection<DataDiceAttribute> _attributes;
		public AttributeCollection<DataDiceAttribute> Attributes
		{
			get { return _attributes; }
		}
		#endregion

		#region Init
		public DataDice(string name) : base(name)
		{
			_attributes = new AttributeCollection<DataDiceAttribute>(this);
		}
		#endregion

		public override void Print(TextWriter printer)
		{
			printer.WriteLine("DICE: " + Name + GetTagString());
			foreach (var att in Attributes.Attributes)
			{
				printer.WriteLine("\t" + att.Name + " : "+att.Odds);
			}
		}

		public override void Generate(Generation generation)
		{
			//Enum class
			CSEnum et = new CSEnum(Name);
			foreach(DataDiceAttribute tag in Attributes.Attributes)
			{
				et.AddTag(tag.Name);
			}
			generation.AddEnum(this, et);

			//Dice class
			//TODO DICE CS_CLASS
		}

		public override void LinkParents(Generation generation) { /* Nothing ot do */ }
		public override void CreateAttributes(Generation generation) { /* Nothing ot do */ }
	}

	public class DataDiceAttribute : DataEntityAttribute{
		public int Odds { get; set; }

		public DataDiceAttribute(string name, int odds) : base(name)
		{
			Odds = odds;
		}
	}
}
