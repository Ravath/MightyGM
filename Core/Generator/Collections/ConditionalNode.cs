using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator.Collections
{
	public class ConditionalNode : SequenceCollection
	{
		private string _value;
		private bool _negative;

		[XmlAttribute("Tag")]
		public string Tag { get; set; }
		[XmlAttribute("Value")]
		public string Value
		{
			get
			{
				if (_negative) { return "!" + _value; }
				else { return _value; }
			}
			set
			{
				if (String.IsNullOrWhiteSpace(value))
				{
					_negative = false;
					_value = "";
				}
				else
				{
					_negative = value.StartsWith("!");
					_value = _negative ? value.Substring(1) : value;
				}
			}
		}

		public ConditionalNode() { }
		public ConditionalNode(string tag, string value)
		{
			Tag = tag;
			Value = value;
		}

		protected Boolean IsConditionTrue(GenerationResult result)
		{
			// empty value is specific
			if (String.IsNullOrWhiteSpace(_value))
			{
				// if "!" only means not already defined
				if (!_negative && result.ContainsTag(Tag))
					return true;
				// else, only has to be defined
				else if (_negative && !result.ContainsTag(Tag))
					return true;
			}
			else if (result.ContainsTag(Tag))
			{
				// basic case : value matches
				if (!_negative && result.GetTagValue(Tag) == _value)
					return true;
				// else, ( "!VALUE" ) : value dismatches
				else if (_negative && result.GetTagValue(Tag) != _value)
					return true;
			}
			return false;
		}
	}
}
