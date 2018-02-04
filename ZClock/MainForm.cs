using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZClock
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clock1.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clock1.Stop();
        }
	}
}
