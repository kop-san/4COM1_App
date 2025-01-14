using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4COM1_App
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        string strConnect = @"Data Source=DESKTOP-BDOLBMR\SQLEXPRESS;Initial Catalog=miniDB_4com1;Integrated Security=True;";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pwd = txtPwd.Text;
            string sql = "SELECT * FROM tbusers WHERE userName='" + username + "' AND password_code='" + pwd + "'";
            conn = new SqlConnection(strConnect);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows.Count != 0)
            {
                MessageBox.Show("Login Successfully!");
                frmMainMenu frm = new frmMainMenu();
                frm.Show();
                frm.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password is invalid!");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
    
