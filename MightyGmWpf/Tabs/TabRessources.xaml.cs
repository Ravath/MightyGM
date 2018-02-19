using MightyGmWPF.Tabs.Ressources;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MightyGmCtrl;

namespace MightyGmWPF.Tabs
{
	/// <summary>
	/// Logique d'interaction pour TabRessources.xaml
	/// </summary>
	public partial class TabRessources : UserControl
	{
		private List<UserControl> _workSpaces = new List<UserControl>();

		public Context Context { get; }
		public TabRessources(Context context)
		{
			InitializeComponent();
			Context = context;
			AddItem("Options", null);
			//groupe, maj, BDs en ligne, torrent
			AddItem("Network", null);
			//Musique, micro
			AddItem("Audio", null);
			AddItem("Texture Maps", new WrkTextureMaps(Context));
			AddItem("Sprites", new WrkSprites(Context));
		}

		private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListView l = sender as ListView;
			workspace.Content = _workSpaces[l?.SelectedIndex??0];
		}

		public void AddItem(String name, UserControl ctrl)
		{
			xList.Items.Add(new TextBlock() { Text = name });
			_workSpaces.Add(ctrl);
		}
	}
}
