using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4COM1_App
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        string Calculated;
        double num1;
        double num2;
        string option;
        double result;

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "1";
            }
            else
            {
                txtDisplay.Text += "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "2";
            }
            else
            {
                txtDisplay.Text += "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "3";
            }
            else
            {
                txtDisplay.Text += "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "4";
            }
            else
            {
                txtDisplay.Text += "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "5";
            }
            else
            {
                txtDisplay.Text += "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "6";
            }
            else
            {
                txtDisplay.Text += "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "7";
            }
            else
            {
                txtDisplay.Text += "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "8";
            }
            else
            {
                txtDisplay.Text += "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "9";
            }
            else
            {
                txtDisplay.Text += "9";
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "0";
            }
            else
            {
                txtDisplay.Text += "0";
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            option = btnAdd.Text;
            num1 = double.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            option = btnSub.Text;
            num1 = double.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            option = btnMul.Text;
            num1 = double.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            option = btnDiv.Text;
            num1 = double.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void btnEql_Click(object sender, EventArgs e)
        {
            num2 = double.Parse(txtDisplay.Text);

            if (option.Equals(btnAdd.Text))
                result = num1 + num2;

            if (option.Equals(btnSub.Text))
                result = num1 - num2;

            if (option.Equals(btnMul.Text))
                result = num1 * num2;

            if (option.Equals(btnDiv.Text))
                result = num1 / num2;

            if (option.Equals(btnPerc.Text))
                result = num1 % num2;

            txtDisplay.Text = result + "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            num1 = (0);
            num2 = (0);
            result = (0);
        }

        private void btnPerc_Click(object sender, EventArgs e)
        {
            option = btnPerc.Text;
            num1 = double.Parse(txtDisplay.Text);

            txtDisplay.Clear();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
        }
    }
}
