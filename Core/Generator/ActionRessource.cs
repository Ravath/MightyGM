using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public class ActionRessource : AbsNode
	{
		[XmlAttribute("Tag")]
		public string RessourceTag { get; set; }

		public ActionRessource()
		{

		}

		public ActionRessource(string ressourceTag)
		{
			RessourceTag = ressourceTag;
		}

		public override void Generation(ref GenerationResult result)
		{
			string currentTag = result.ReplaceTags(RessourceTag);
			result.UseRessource(currentTag);
		}
	}
}
