using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Generator
{
	/// <summary>
	/// The result of a generation.
	/// </summary>
	public class GenerationResult
	{
		private Generator _generator;

		private StringBuilder _text = new StringBuilder();
		private Dictionary<string,string> _tags = new Dictionary<string, string>();

		public delegate void Report(string message);
		public event Report ErrorReport;

		public string FinalText { get { return _text.ToString(); } }

		internal GenerationResult(Generator generator)
		{
			_generator = generator;
		}

		/// <summary>
		/// Called at the start of the generation.
		/// </summary>
		public void StartGeneration()
		{
			// Clean tools
			_text.Clear();
			_tags.Clear();
		}

		/// <summary>
		/// Called at the end of the generation.
		/// </summary>
		public void EndGeneration()
		{
			// Replace every tag in generated text.
			foreach (var item in _tags)
			{
				_text.Replace("{" + item.Key + "}", item.Value);
			}
		}

		/// <summary>
		/// Add text at the end of the generation.
		/// </summary>
		/// <param name="text">Text to append.</param>
		public void AddText(string text)
		{
			_text.Append(text);
		}

		/// <summary>
		/// Use the ressource with given tag-name.
		/// </summary>
		/// <param name="ressourceTag">The identifier of the ressource to use.</param>
		public void UseRessource(string ressourceTag)
		{
			_generator.UseRessource(ressourceTag, this);
		}

		/// <summary>
		/// Add the given tag to the dictionnary.
		/// </summary>
		/// <param name="tag">Identifier in the generated text.</param>
		/// <param name="value">Value that will replace the tag at generation.</param>
		public void SetTag(string tag, string value)
		{
			if (!ContainsTag(tag))
				_tags.Add(tag, value);
			else
				_tags[tag] = value;
		}

		public bool ContainsTag(string tag)
		{
			return _tags.ContainsKey(tag);
		}

		public string GetTagValue(string tag)
		{
			return _tags[tag];
		}

		public string ReplaceTags(string value)
		{
			Regex r = new Regex(@"{[^}]*}");

			// Find first
			Match m = r.Match(value);
			string tagMatch = m.Value;

			// If something found
			if (!String.IsNullOrWhiteSpace(tagMatch))
			{
				string tag = tagMatch.Substring(1, tagMatch.Length - 2);

				if (ContainsTag(tag))
				{
					value = value.Replace(tagMatch, GetTagValue(tag));
				}

				// Try find next
				m = r.Match(value);
				tagMatch = m.Value;
			}
			return value;
		}

		public IRoll GetRoll(String value)
		{
			String macro = "";
			try
			{
				macro = ReplaceTags(value);
				return Dice.Procedures.Parse(macro);
			} catch(Exception pe)
			{
				throw new Exception("Couldn't Parse the Expression : " + value + " / " + macro, pe);
			}
		}

		/// <summary>
		/// Reports a occured error.
		/// </summary>
		/// <param name="message"></param>
		internal void ReportError(string message)
		{
			ErrorReport?.Invoke(message);
		}
	}
}
