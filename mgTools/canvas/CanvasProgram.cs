using MightyGmCtrl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgTools.canvas
{
	public class CanvasProgram : IExecute
	{
		public void Exec(Arguments args)
		{
			CanvasArguments a = (CanvasArguments)args;
			Context ctx = Context.MightyGmContext("");
			ctx.ReportManager.ProcessExceptionEvent += ReportManager_ProcessExceptionEvent;
			ctx.Dll.SetAssembly(a.DllPath);
			//FileInfo dllFi = ctx.Files.GetDllFile(a.DllPath, "");
			FileInfo fi = new FileInfo(a.OutPath);

			Console.WriteLine("Export Tables");
			ctx.DataExport.ExportDataToExcel(fi.FullName, ctx.Dll.RawDataTables, true);
			string outMessage = fi.FullName.Remove(fi.FullName.Length - fi.Extension.Length);
			Console.WriteLine("Export Joints");
			ctx.DataExport.ExportDataToExcel(outMessage + "_joint" + fi.Extension, ctx.Dll.JointDataTables, true);
		}

		private void ReportManager_ProcessExceptionEvent(Exception percentage)
		{
			Console.WriteLine(percentage);
		}
	}
}