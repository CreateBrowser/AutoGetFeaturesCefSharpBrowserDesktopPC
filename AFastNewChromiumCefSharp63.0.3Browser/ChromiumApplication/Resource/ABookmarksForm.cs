using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromiumApplication
{
    public partial class ABookmarksForm : MetroFramework.Forms.MetroForm
    {
        public void SetAllBookmarks(List<string> input)
        {
            foreach (string s in input)
            {
                listBox1.Items.Add(s);

            }
        }

        public ABookmarksForm()
        {
            InitializeComponent();
        }
        private void bEarese_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        public void listBox1_DoubleClick(object sender, EventArgs e)
        {



        }
    }
}
