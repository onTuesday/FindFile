using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void helpProvider1_Click()
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            Program.CallGetAllFiles(Path.GetFullPath(textBox1.Text));
            //int[] arr = new int[4] { 1, 2, 3, 4 };
            //label1.Text = textBox1.Text;
            //label2.Text = textBox2.Text;
            MessageBox.Show("Здесь будет резёльтат по пойску файлов", "Результат");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Здесь будет справка по работе программы \n" +
                "Введите путь - \n" +
                "Введите маску - \n", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
