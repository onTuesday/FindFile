﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FindFile;

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
            if (Client.error != null)
            {
                MessageBox.Show(Client.error, "Ошибка!");
                return;
            }
            
            Form2 newForm = new Form2();
            newForm.Show();
            Client.result.Clear();
            Client a = new Client();
            a.Find(Path.GetFullPath(textBox1.Text), textBox2.Text);

            Form2.treeView1.BeginUpdate();
            Form2.treeView1.Nodes.Clear();
            foreach (string elem in Client.result)
            {

                if (Form2.stop == true)
                {
                    break;
                }
                
                Form2.treeView1.Nodes.Add(elem);
            }
            Form2.treeView1.EndUpdate();
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

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("На покушать нашей замечательной команде \n" +
                "Сбер :", "Поддержание команды разработчиков", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ЗДЕСЬ МОГЛА БЫ БЫТЬ ВАША РЕКЛАМА \n" +
                "Контакты: Вайбер       - \n" +
                "                   Телеграмм - \n" +
                "                   Вк                - \n" +
                "                   Вотс            - \n", "Реклама", MessageBoxButtons.OK);
        }
    }
}
