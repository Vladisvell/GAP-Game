using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Media;

namespace Gaym
{
	public partial class GameForm : Form
	{	
		Image DrawImage1()
        {
			return Image.FromFile("chmonya.bmp");
        }

		public void NoMoneySound()
        {
			SoundPlayer surprise = new SoundPlayer("Fuck you.wav");
			surprise.Play();
        }

		private Button kekButton;
		private Button buyZavod;
		private Label zavodCount;
		private Label zavodCost;

		public Button GetKekButton() => kekButton;
		public Button GetBuyZavod() => buyZavod;
		public Label GetZavodCount() => zavodCount;
		public Label GetZavodCost() => zavodCost;

		public GameForm()
		{
			InitializeComponent();

			this.BackColor = Color.LightGray;

			kekButton = new Button
			{
				Location = new Point(0, 0),
				Size = new Size(1920, 1080 / 2),
				ForeColor = Color.White,
				BackgroundImage = DrawImage1()
			};
			Controls.Add(kekButton);

			buyZavod = new Button
			{
				Location = new Point(0, 541),
				Size = new Size(200, 200),
				BackColor = Color.FromArgb(200,200,200)
			};
			Controls.Add(buyZavod);

			zavodCount = new Label
			{
				Location = new Point(buyZavod.Location.X + 250, 541),
				Size = new Size(100, 30),
			};
			Controls.Add(zavodCount);

			zavodCost = new Label
			{
				Location = new Point(buyZavod.Location.X + 250, 590),
				Size = new Size(100, 30),
			};
			Controls.Add(zavodCost);

			this.WindowState = FormWindowState.Maximized;

			Controller.RunLogic(this);
		}
    }
}
