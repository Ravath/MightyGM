using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contexts;

namespace MightyGmCtrl.Controleurs
{
	public class FilesControl : Controleur
	{
		/// <summary>
		/// Application local path;
		/// </summary>
		public string UiTypeName { get; set; }
		public string LocalPath { get; }
		public string ModulesDirectory { get { return LocalPath + "\\Modules"; } }
		public string TexturesDirectory { get { return LocalPath + "\\Textures"; } }

		public FilesControl(Context ctx, string uiTypeName) : base(ctx)
		{
			LocalPath = Directory.GetCurrentDirectory();
			UiTypeName = uiTypeName;
		}

		#region Find File Dialog

		private bool GetFile(string filter, bool multiselect, bool fileExists, out string filePath)
		{
			bool success = false;
			filePath = GetMessageRessource("ABORT");

			try
			{
				// Create an instance of the open file dialog box.
				System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog
				{
					// Set filter options and filter index.
					Filter = filter,
					Multiselect = multiselect,
					CheckFileExists = fileExists
				};
				// Show the dialog and get result.
				System.Windows.Forms.DialogResult result = openFileDialog1.ShowDialog();

				//return values
				success = (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes);
				if (success)
				{
					filePath = openFileDialog1.FileName;
				}
			}
			catch (Exception ex)
			{
				ReportException(ex);
			}

			return success;
		}

		/// <summary>
		/// Make user choose an excel file from computer.
		/// </summary>
		/// <param name="outString">Filename if success, error message if failure.</param>
		/// <returns></returns>
		public bool GetExcelFile(out string outMessage, bool fileExists)
		{
			return GetFile("Excel Files(.excel) | *.xlsx; *.xls", false, fileExists, out outMessage);
		}

		/// <summary>
		/// Make user choose an word file from computer.
		/// </summary>
		/// <param name="outString">Filename if success, error message if failure.</param>
		/// <returns></returns>
		public bool GetWordFile(out string outMessage, bool fileExists)
		{
			return GetFile("Document Word|*.docx", false, fileExists, out outMessage);
		}
		#endregion

		#region Dll management
		/// <summary>
		/// Find the path to every Jdr dll module.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<FileInfo> FindJdrModules()
		{
			List<FileInfo> assems = new List<FileInfo>();
			foreach (string dirpath in Directory.EnumerateDirectories(ModulesDirectory))
			{
				DirectoryInfo dir = new DirectoryInfo(dirpath);
				FileInfo fi = GetDllFile(dir.Name, "");
				if (fi.Exists)
				{
					assems.Add(fi);
				}
			}
			return assems;
		}

		public IJdrContextUI GetUIDll(string name)
		{
			IJdrContextUI result = null;
			FileInfo fi = GetDllFile(name, UiTypeName);
			if (fi.Exists)
			{
				result = GlobalContext.Dll.GetUiContext(fi.FullName, GlobalContext);
			}
			else
			{
				ReportMessageRef(MessageType.ERROR, "UI_DLL_NOT_FOUND", name);
			}
			return result;
		}

		public FileInfo GetDllFile(string moduleName, string dllSuffixe)
		{
			return new FileInfo(ModulesDirectory + "\\" + moduleName + "\\" + moduleName + dllSuffixe + ".dll");
		} 
		#endregion
	}
}
