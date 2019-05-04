using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardTest
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }
        public int off;
        private void Label1_Click(object sender, EventArgs e) { }

        private void Game_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (Black.Checked)
            {
                off = Common.BLACK_OFF;
            }
            else if(White.Checked)
            {
                off = Common.WHITE_OFF;
            }
        }
    }
}
