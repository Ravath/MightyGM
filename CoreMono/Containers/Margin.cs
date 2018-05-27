using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.GUI.Containers
{
	public class Margin : GuiSingleChildElement
	{
		private int left;
		private int right;
		private int up;
		private int down;

		public Margin(int margin) : base()
		{
			SetMargin(margin);
		}

		public void SetMargin(int margin)
		{
			SetMargin(margin, margin, margin, margin);
		}

		public void SetMargin(int left, int right, int up, int down)
		{
			this.left = left;
			this.right = right;
			this.up = up;
			this.down = down;
			ManageChild();
		}

		public override void ManageChild()
		{
			Child?.Resize(
				Position.X + left, 
				Position.Y + up, 
				Position.Width - (left + right), 
				Position.Height - (up + down));
		}
	}
}
