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
		public string LocalPath { get; }

		/// <summary>
		/// The Application discriminant for the UI modular DLLs.
		/// </summary>
		public string UiTypeName { get; set; }
		/// <summary>
		/// The directory where RPG modules are stored.
		/// </summary>
		public string ModulesDirectory { get { return LocalPath + "\\Modules"; } }
		/// <summary>
		/// The directory where textures are stored.
		/// </summary>
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

		private FileInfo[] GetFiles(string filter, bool multiselect, bool fileExists, out bool exitSuccess, out string outMessage)
		{
			exitSuccess = false;
			outMessage = GetMessageRessource("ABORT");
			FileInfo[] ret = new FileInfo[0];

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
				exitSuccess = (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes);
				if (exitSuccess)
				{
					ret = new FileInfo[openFileDialog1.FileNames.Length];
					for (int i = 0; i < ret.Length; i++)
					{
						ret[i] = new FileInfo(openFileDialog1.FileNames[i]);
					}
				}
			}
			catch (Exception ex)
			{
				ReportException(ex);
			}

			return ret;
		}

		public FileInfo[] GetAudioFiles(out string outMessage, out bool success)
		{
			return GetFiles(String.Format("Audio Files({0})) | {1}",
				ConcateneExtensions(_soundtrackExtensions, false),
				ConcateneExtensions(_soundtrackExtensions, true)), true, true, out success, out outMessage);
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

		public FileInfo[] GetPictFiles(out string outMessage, out bool success)
		{
			return GetFiles(String.Format("Images Files({0})) | {1}",
				ConcateneExtensions(_imageExtensions, false),
				ConcateneExtensions(_imageExtensions, true)), true, true, out success, out outMessage);
		}
		/// <summary>
		/// concatene the given strings for the 'GetFiles' function use.
		/// I.E: - ".jpg; .png"
		///  or  - "*.jpg; *.png"
		/// </summary>
		/// <param name="extensions">The extensions to concate.</param>
		/// <param name="insertAsterisk">Option for the asterisk before the extension.</param>
		/// <returns></returns>
		private string ConcateneExtensions(string[] extensions, bool insertAsterisk)
		{
			if(extensions.Length == 0)
			{
				return "";
			}
			else
			{
				string res = (insertAsterisk ? "*" : "") + extensions[0];
				for(int i = 1; i<extensions.Length; i++)
				{
					res += (insertAsterisk?"; *":"; ") + extensions[i];
				}
				return res;
			}
		}
		#endregion

		#region Find Folder Dialog
		public DirectoryInfo GetFolder(Boolean canCreateFolder, out string outMessage, out bool exitSuccess)
		{
			exitSuccess = false;
			outMessage = GetMessageRessource("ABORT");
			DirectoryInfo ret = null;
			try
			{
				System.Windows.Forms.FolderBrowserDialog findFolder = new System.Windows.Forms.FolderBrowserDialog()
				{
					Description = "Select a Folder",
					ShowNewFolderButton = canCreateFolder,
				};
				// Show the dialog and get result.
				System.Windows.Forms.DialogResult result = findFolder.ShowDialog();

				//return values
				exitSuccess = (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes);
				if (exitSuccess)
				{
					ret = new DirectoryInfo(findFolder.SelectedPath);
				}
			}
			catch (Exception ex)
			{
				ReportException(ex);
			}

			return ret;
		}
		#endregion

		#region File Compatibility
		private string[] _imageExtensions = { ".jpg", ".jpeg", ".png" };
		public bool IsCompatibleImage(string extension)
		{
			return _imageExtensions.Contains(extension);
		}
		private string[] _soundtrackExtensions = { ".mp3", ".wma" };
		public bool IsCompatibleSoundtrack(string extension)
		{
			return _soundtrackExtensions.Contains(extension);
		}
		private string[] _textExtensions = { ".txt" };
		public bool IsCompatibleText(string extension)
		{
			return _textExtensions.Contains(extension);
		}
		#endregion

		#region Dll management
		/// <summary>
		/// Find the path to every Jdr dll module.
		/// </summary>
		/// <returns></returns>
		internal IEnumerable<FileInfo> FindJdrModules()
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

		internal IJdrContextUI GetUIDll(string name)
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

		internal FileInfo GetDllFile(string moduleName, string dllSuffixe)
		{
			return new FileInfo(ModulesDirectory + "\\" + moduleName + "\\" + moduleName + dllSuffixe + ".dll");
		} 
		#endregion
	}
}
