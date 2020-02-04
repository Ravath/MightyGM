using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core.Generator;

namespace MightyGenerator
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private static string SubDirName = "Generators";

		private Dictionary<string, Generator> _generators = new Dictionary<string, Generator>();
		private String _lastSelectedKey;
		private Generator _selected;

		public MainWindow()
		{
			InitializeComponent();
			LoadFiles();
			DataContext = this;
		}

		bool firstCopy = true;
		ICommand copyCommand;
		public ICommand CopyCommand
		{
			get {
				if (copyCommand == null)
				{
					copyCommand = new ActionCommand(() =>
					{
						Clipboard.SetText(Text.Text);
						if (firstCopy)
						{
							MessageBox.Show("Copy Done (shown only once)");
							firstCopy = false;
						}
					});
				}
				return copyCommand;
			}
		}

		private void LoadFiles()
		{
			_generators.Clear();
			List.Items.Clear();
			Text.Text = "";

			if (!Directory.Exists(SubDirName))
			{
				Directory.CreateDirectory(SubDirName);
			}

			TreeViewItem t = LoadDirectory(SubDirName);

			while (t.Items.Count != 0)
			{
				object ti = t.Items.GetItemAt(0);
				t.Items.RemoveAt(0);
				List.Items.Add(ti);
			}
		}

		private TreeViewItem LoadDirectory(string dirPath)
		{
			DirectoryInfo dir = new DirectoryInfo(dirPath);
			TreeViewItem dirNode = new TreeViewItem() { Header = dir.Name };

			//Generator files
			foreach (var item in dir.GetFiles("*.xml"))
			{
				try
				{
					Generator g = Generator.FromFile(item.FullName);
					string usedName = String.IsNullOrWhiteSpace(g.Name) ? item.Name : g.Name;
					if (_generators.ContainsKey(usedName))
					{
						int i = 1;
						while (_generators.ContainsKey(usedName + "_" + i)) { i++; }
						usedName = usedName + "_" + i;
					}
					_generators.Add(usedName, g);
					dirNode.Items.Add(usedName);
				}
				catch (Exception e)
				{
					Text.Text += "File : " + item + "\n";
					PopUpException(e);
				}
			}
			//Sub Directories
			foreach (var item in dir.GetDirectories())
			{
				try
				{
					dirNode.Items.Add(LoadDirectory(item.FullName));
				}
				catch (Exception e)
				{
					Text.Text += "File : " + item + "\n";
					PopUpException(e);
				}
			}

			return dirNode;
		}

		private void PopUpException(Exception e)
		{
#if DEBUG
			Text.Text += e.StackTrace + "\n";
#endif
			Exception ei = e;
			while (ei != null)
			{
				Text.Text += ei.Message + "\n";
				ei = ei.InnerException;
			}

			Text.Text += "\n";
		}

		private void SelectGenerator(string genName)
		{
			if (!String.IsNullOrWhiteSpace(genName))
			{
				_generators.TryGetValue(genName, out _selected);
				_lastSelectedKey = genName;
			}
			else
			{
				_selected = null;
			}
		}

		private void ButtonReload_Click(object sender, RoutedEventArgs e)
		{
			LoadFiles();
			SelectGenerator(_lastSelectedKey);
		}

		private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
		{
			if(_selected == null)
			{
				Text.Text = "Select a generator first";
			}
			else
			{
				try
				{
					Text.Text = _selected.Generate().FinalText;
				}
				catch (Exception ex)
				{
					PopUpException(ex);
				}
			}
		}

		private void List_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			SelectGenerator(e.NewValue as String);
		}
	}
}
