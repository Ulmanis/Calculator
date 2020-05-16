﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        char decimalSeparator;
        double numOne = 0;
        double numTwo = 0;
        string operation;
        bool scifiMode = false;
        const int widthSmall = 300;
        const int widthLarge = 900;


        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            this.BackColor = Color.DarkGray;
            this.Width = widthSmall;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            string buttonName = null;
            Button button = null;
            Display.Text = "0";
            Display.TabStop = false;

            for(int i = 0; i<10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.DarkGray;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = SystemColors.Control;
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            bool weHaveDot = Display.Text.Contains(decimalSeparator);
            if (!weHaveDot)
            {
                if(Display.Text == string.Empty)
                {
                    Display.Text += "0" + decimalSeparator;
                }
                else
                {
                    Display.Text += decimalSeparator;
                }

            }
        }

        private void buttonBackSpace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;

            if (s.Length > 1)
            {
                if ((s.Contains("-") == true) && (s.Length == 2))
                {
                    s = "0";
                }
                else
                {
                    s = s.Substring(0, (s.Length - 1));
                }

            }
            else
            {
                s = "0";
            }

            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = number.ToString();
            }
            catch
            {

            }
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(button.Text == "Sqrt")
            {
                Display.Text = Math.Sqrt(numOne).ToString();
                return;
            }
            numOne = Convert.ToDouble(Display.Text);
            Display.Text = string.Empty;
            operation = button.Text;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            double result = 0;
            numTwo = Convert.ToDouble(Display.Text);

            if(operation == "+")
            {
                result = numOne + numTwo;
            }
            else if(operation == "-")
            {
                result = numOne - numTwo;
            }
            else if (operation == "*")
            {
                result = numOne * numTwo;
            }
            else if (operation == "/")
            {
                result = numOne / numTwo;
            }
            else if (operation == "^")
            {
                result = Math.Pow(numOne, numTwo);
            }

                Display.Text = result.ToString();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            numOne = 0;
            numTwo = 0;
        }

        private void buttonSciFi_Click(object sender, EventArgs e)
        {
            if (scifiMode)
            {
                this.Width = widthSmall;
                scifiMode = !scifiMode;
            }
            else
            {
                this.Width = widthLarge;
            }
            scifiMode = !scifiMode;
        }
    }
}
