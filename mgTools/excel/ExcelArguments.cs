using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgTools.ImportExcel
{
	class ExcelArguments : Arguments
	{
		public string SubProcess { get; set; }
		public string DllPath { get; set; }
		public string ExcelPath { get; set; }
		public string TypeName { get; set; }

		public ExcelArguments(string[] args) : base(args) { }

		public override bool ParseArguments()
		{
			if (CheckMin(3) && CheckMax(4))
			{
				SubProcess = GetNext();
				DllPath = GetNext();
				ExcelPath = GetNext();
				if(HasNext())
				{
					TypeName = GetNext();
				}
				return true;
			}
			return false;
		}
	}
}
