using AnalaizerClass;
using CalcClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class Form1 : Form
    {
        long memoryResult = 0;
        public Form1()
        {
            InitializeComponent();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += button9.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += button11.Text;
        }
        private void DoubleOperator()
        {
            if (textBox1.Text.EndsWith("+") || textBox1.Text.EndsWith("-") || textBox1.Text.EndsWith("*")
                       || textBox1.Text.EndsWith("/") || textBox1.Text.EndsWith("%"))
            {
                if (textBox1.Text.Length > 0)
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }
            }

        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            DoubleOperator();
            textBox1.Text += buttonDiv.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            DoubleOperator();
            textBox1.Text += button14.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            DoubleOperator();
            textBox1.Text += button15.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            DoubleOperator();
            textBox1.Text += button16.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            DoubleOperator();
            textBox1.Text += "%";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            else
            {
                long result = Convert.ToInt64(Analaizer.RunEstimate());
                Calc.ABS(result);
            }
          
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            textBox1.Text += button22.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            textBox1.Text += button21.Text;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            else
            {
                // textBox1.Text += button20.Text;
            }
            Analaizer.expression = textBox1.Text + button20.Text;
            textBox2.Text = Analaizer.RunEstimate();

        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                return;
            memoryResult = 0;
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
                return;
            memoryResult += Convert.ToInt64(textBox2.Text);           
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            textBox2.Text = memoryResult.ToString();
        }
    }
}
