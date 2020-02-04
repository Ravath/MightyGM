using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Generator
{
	public class ActionDefine : ActionTag
	{
		
		public ActionDefine() : base() { }
		public ActionDefine(string tag, string value) : base(tag, value)
		{
		}

		public override void Generation(ref GenerationResult result)
		{
			if (!result.ContainsTag(Tag))
				base.Generation(ref result);
		}
	}
}
