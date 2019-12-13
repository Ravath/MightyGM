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

		private List<Generator> _generators = new List<Generator>();
		private Generator _selected;

		public MainWindow()
		{
			InitializeComponent();

			LoadFiles();

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

			string[] files = Directory.GetFiles(SubDirName, "*.xml");
			foreach (var item in files)
			{
				try
				{
					Generator g = Generator.FromFile(item);
					_generators.Add(g);
					List.Items.Add(g.Name);
				}
				catch (Exception e)
				{
					Text.Text += "File : " + item + "\n";
					PopUpException(e);
				}
			}
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

		private void ButtonReload_Click(object sender, RoutedEventArgs e)
		{
			LoadFiles();
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

		private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (List.SelectedIndex < 0 || List.SelectedIndex >= _generators.Count)
			{
				_selected = null;
			}
			else
			{
				_selected = _generators[List.SelectedIndex];
			}
		}
	}
}
