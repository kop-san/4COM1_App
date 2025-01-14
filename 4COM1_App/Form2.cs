using System;
using System.Windows.Forms;

namespace _4COM1_App
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);

            txtResult.Text = (num1 + num2).ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);

            txtResult.Text = (num1 - num2).ToString();

        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);

            txtResult.Text = (num1 * num2).ToString();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(txtNum1.Text);
            double num2 = double.Parse(txtNum2.Text);

            txtResult.Text = (num1 / num2).ToString();
        }
    }
}
