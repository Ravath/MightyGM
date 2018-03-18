using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgTools.canvas
{
	public class CanvasArguments : Arguments
	{
		public string DllPath { get; set; }
		public string OutPath { get; set; }

		public CanvasArguments(string[] args) : base(args) { }

		public override bool ParseArguments()
		{
			if(CheckArgsNumber(2))
			{
				DllPath = GetNext();
				OutPath = GetNext();
				return true;
			}
			return false;
		}
	}
}
