using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyGmCtrl.Controleurs
{
	public class JdrAssembly
	{
		internal JdrAssembly() { }
		public string Name { get; internal set; }
		public FileInfo DllPath { get; internal set; }
	}
}
