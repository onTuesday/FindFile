using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindFile;
using System.Diagnostics;

namespace WinForm
{
    public partial class Form2 : Form
    {
        public static bool stop = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Process.Start(treeView1.SelectedNode.Text);
        }
    }
}
