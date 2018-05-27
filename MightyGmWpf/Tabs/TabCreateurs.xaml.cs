using MightyGmCtrl;
using MightyGmWPF.MapDrawings;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MightyGmWPF.Tabs
{
	/// <summary>
	/// Logique d'interaction pour TabCreateurs.xaml
	/// </summary>
	public partial class TabCreateurs : UserControl
	{
		//private WpfAdapter _display = new WpfAdapter();

		/*private SquareGrid _map = new SquareGrid(30, 30);
		private SquareMapDrawer _drawer;
		private SquareDrawer _squareDrawer;
		private SquareDrawer _squareSpriteDrawer;
		private MapBrush _brush = new MapBrush() { Radius = 1, Shape = BrushShape.Circle };

		private MapCommand _command;
		private MapCommand _altCommand;
		private GrabCommand _grabCommand;
		private ScaleCommand _scaleCommand;
		private WallDrawerCommand _wallDrawer;
		private EmptyDrawerCommand _emptyDrawer;

		public MapBrush Brush
		{
			get { return _brush; }
		}*/

		public Context Context { get; }

		public TabCreateurs(Context context)
		{
			InitializeComponent();
			DataContext = this;
			Context = context;
			cbBrushShapes.ItemsSource = Enum.GetValues(typeof(BrushShape)).Cast<BrushShape>();
			string abspath = Directory.GetCurrentDirectory();

			/*WallSprites sprites = new WallSprites(abspath + "\\TilesI.png");
			_squareDrawer = new DefaultSquareDrawer();
			_squareSpriteDrawer = new SpriteSquareDrawer(sprites);
			_drawer = new SquareMapDrawer(_map, cvMap, _squareSpriteDrawer);
			_wallDrawer = new WallDrawerCommand() { Brush = _brush };
			_emptyDrawer = new EmptyDrawerCommand() { Brush = _brush };
			_grabCommand = new GrabCommand();
			_scaleCommand = new ScaleCommand();
			_command = _grabCommand;
			_drawer.Draw();*/

			//CanvasContainer.Content = _display;
		}

		#region MouseEvents
		private void cvMap_MouseDown( object sender, MouseButtonEventArgs e ) {
			//_command.MouseDown(_drawer, e);
		}

		private void cvMap_MouseUp( object sender, MouseButtonEventArgs e ) {
			//_command.MouseUp(_drawer, e);
		}

		private void cvMap_MouseMove( object sender, MouseEventArgs e ) {
			//_command.MouseMove(_drawer, e);
		}
		#endregion

		#region WindowsEvent
		private void CanvasContainer_SizeChanged( object sender, SizeChangedEventArgs e ) {
			//_drawer.SetDimension(CanvasContainer.ActualWidth, CanvasContainer.ActualHeight);
		}

		private void DockPanel_KeyDown( object sender, KeyEventArgs e ) {
			if(e.IsRepeat) { return; }
			switch(e.Key) {
				case Key.LeftShift:
				//_altCommand = _command;
				//_command = _grabCommand;
                break;
				case Key.LeftCtrl:
				break;
				case Key.System:
				/*if(e.SystemKey == Key.LeftAlt) {
					_altCommand = _command;
					_command = _scaleCommand;
				}*/
				break;
				default:
				break;
			}
		}

		private void DockPanel_KeyUp( object sender, KeyEventArgs e ) {
			/*if(_altCommand == null) { return; } 
			else {
				_command = _altCommand;
				_altCommand = null;
            }*/
		}
		#endregion

		#region WallToolsEvents
		private void WallTool_Click( object sender, RoutedEventArgs e ) {
			//_command = _wallDrawer;
        }
		private void VoidTool_Click( object sender, RoutedEventArgs e ) {
			//_command = _emptyDrawer;
		}
		private void SetEmpty_Click( object sender, RoutedEventArgs e ) {
			//_drawer.SetAllMap(FloorType.Empty);
		}

		private void SetFloor_Click( object sender, RoutedEventArgs e )
		{
			//_drawer.SetAllMap(FloorType.Floor);
		}

		private void SetWall_Click( object sender, RoutedEventArgs e )
		{
			//_drawer.SetAllMap(FloorType.Wall);
		}
		#endregion

		#region MapToolsEvents
		private void ComboBox_SelectionChanged( object sender, SelectionChangedEventArgs e ) {

		}

		private void Print_Click( object sender, RoutedEventArgs e ) {

			//NOPE

			//Canvas canvas = _drawer?.Canvas;
			//if(canvas == null) {
			//	MessageBox.Show("You must create a map first.");
			//	return;
			//}
			////Select the file
			//var dialog = new System.Windows.Forms.SaveFileDialog();
			//dialog.Filter = "Image|*.jpg";
			//System.Windows.Forms.DialogResult result = dialog.ShowDialog();
			//if(result == System.Windows.Forms.DialogResult.OK
			//	|| result == System.Windows.Forms.DialogResult.Yes) {
			//	//If ok, try to export.
			//	int w = (int)canvas.RenderSize.Width;
			//	int h = (int)canvas.RenderSize.Height;
			//	RenderTargetBitmap rtb = new RenderTargetBitmap(
			//		w, h, 96d, 96d, System.Windows.Media.PixelFormats.Default);
			//	rtb.Render(canvas);

			//	var crop = new CroppedBitmap(rtb, new Int32Rect(0, 0, w, h));

			//	BitmapEncoder pngEncoder = new PngBitmapEncoder();
			//	pngEncoder.Frames.Add(BitmapFrame.Create(crop));

			//	using(var fs = System.IO.File.OpenWrite(dialog.FileName)) {
			//		pngEncoder.Save(fs);
			//	}
			//	MessageBox.Show("Export completed");
			//}
		}
		#endregion

		#region ToolBar Events
		private void Resize_Click( object sender, RoutedEventArgs e ) {
			/*_drawer.Zoom = 1;
			_drawer.XOffset = 0;
			_drawer.YOffset = 0;*/
		}
		private void GrabTool_Click( object sender, RoutedEventArgs e ) {
			//_command = _grabCommand;
		}
		private void ScaleTool_Click( object sender, RoutedEventArgs e ) {
			//_command = _scaleCommand;
		}
		#endregion
	}
}
