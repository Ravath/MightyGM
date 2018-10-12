using MightyGmCtrl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgTools.ImportExcel
{
	class ExcelProgram : IExecute
	{
		public void Exec(Arguments args)
		{
			ExcelArguments a = (ExcelArguments)args;
			Context ctx = Context.MightyGmContext("");
			ctx.ReportManager.ProcessExceptionEvent += ReportManager_ProcessExceptionEvent;
			ctx.ReportManager.MessageEvent += ReportManager_MessageEvent;
			ctx.ReportManager.ProgressEvent += ReportManager_ProgressEvent;
			ctx.ReportManager.EndOfProcessEvent += ReportManager_EndOfProcessEvent;

			// Get JDR DLL
			ctx.Dll.SetAssembly(a.DllPath);

			// Get Excel File
			FileInfo fi = new FileInfo(a.ExcelPath);
			if (!fi.Exists)
			{
				Console.WriteLine("Can't find file : " + fi.FullName);
				return;
			}

			switch (a.SubProcess.ToLower())
			{
				case "check":
					Console.WriteLine("Check Excel "+ fi.FullName);
					ctx.DataImport.CheckExcelData(fi.FullName);
					break;
				case "import":
					Console.WriteLine("SubProcess 'import' is not implemented yet");
					break;
				case "importall":
					Console.WriteLine("Import Excel " + fi.FullName);
					ctx.DataImport.ExcelImport(fi.FullName, ctx.Dll.RawDataTables);
					break;
				case "importjoint":
					Console.WriteLine("Import Excel " + fi.FullName);
					ctx.DataImport.ExcelImport(fi.FullName, ctx.Dll.JointDataTables);
					break;
				default:
					Console.WriteLine("Can't find mgTools:Excel Subprocess " + a.SubProcess);
					break;
			}
		}

		private void ReportManager_EndOfProcessEvent(string processName, bool success)
		{
			Console.WriteLine(processName + " ended with success = "+success);
		}

		private void ReportManager_ProgressEvent(double percentage)
		{
			/* NOTHING */
		}

		private void ReportManager_MessageEvent(Core.Contexts.MessageType type, string message)
		{
			Console.WriteLine(type+" : "+message);
		}

		private void ReportManager_ProcessExceptionEvent(Exception percentage)
		{
			Console.WriteLine(percentage);
		}
	}
}
