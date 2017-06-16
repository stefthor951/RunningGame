using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunningGame.Screens
{
    public partial class WinScreen : UserControl
    {
        public WinScreen()
        {
            InitializeComponent();
        }

        private void WinScreen_Load(object sender, EventArgs e)
        {
            scoreLabel.Text = "You ran " + Form1.currentScore + " metres";
            Point labelPoint = new Point(this.Width / 2 - (scoreLabel.Width / 2), scoreLabel.Location.Y);
            scoreLabel.Location = labelPoint;
        }
    }
}
