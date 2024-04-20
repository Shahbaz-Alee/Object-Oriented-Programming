using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int count;
        public Form1()
        {
            InitializeComponent();
            /*Button m = new Button();
            m.Text = "OK";
            m.ForeColor = Color.Blue;
            this.Controls.Add(m);*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            addNum();
        }
        private void addNum()
        {
            string num1 = richTextBox1.Text;
            string num2 = richTextBox2.Text;
            double result = double.Parse(num1) + double.Parse(num2);
            label7.Text = "Result: " + result.ToString();
        }
        private void subNum()
        {
            string num1 = richTextBox1.Text;
            string num2 = richTextBox2.Text;
            double result = double.Parse(num1) - double.Parse(num2);
            label7.Text = "Result: " + result.ToString();
        }
        private void mulNum()
        {
            string num1 = richTextBox1.Text;
            string num2 = richTextBox2.Text;
            double result = double.Parse(num1) * double.Parse(num2);
            label7.Text = "Result: " + result.ToString();
        }
        private void divideNum()
        {
            string num1 = richTextBox1.Text;
            string num2 = richTextBox2.Text;
            double result = double.Parse(num1) / double.Parse(num2);
            label7.Text = "Result: " + result.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            subNum();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            mulNum();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            divideNum();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
