using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4COM1_App
{
    public partial class frmCustomer : Form
    {
        string strConnect = @"Data Source=DESKTOP-BDOLBMR\SQLEXPRESS;Initial Catalog=miniDB_4com1;Integrated Security=True;";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr;
        SqlDataAdapter dar = null;

        public frmCustomer()
        {
            InitializeComponent();
            connectionDB_Checking();
            getData();
        }

        private void getData()
        {
            string sql = "select * from tbCustomers";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvShowdata.DataSource = dt;
            dgvShowdata.Columns[0].HeaderText = "ລະຫັດລູກຄ້າ";
            dgvShowdata.Columns[1].HeaderText = "ຊື່ລູກຄ້າ";
            dgvShowdata.Columns[2].HeaderText = "ທີ່ຢູ່";
            dgvShowdata.Columns[3].HeaderText = "ເບີໂທ";
        }
        private void connectionDB_Checking()
        {
            conn = new SqlConnection(strConnect);
            conn.Open();
        }

        private void dgvShowdata_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cindex = dgvShowdata.CurrentRow.Index;
            txtCusID.Text = dgvShowdata.Rows[cindex].Cells[0].Value.ToString();
            txtCusName.Text = dgvShowdata.Rows[cindex].Cells[1].Value.ToString();
            txtCusAddr.Text = dgvShowdata.Rows[cindex].Cells[2].Value.ToString();
            txtCusTel.Text = dgvShowdata.Rows[cindex].Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tbCustomers VALUES('" + txtCusID.Text + "',N'" + txtCusName.Text + "', '" + txtCusAddr.Text + "','" + txtCusTel.Text + "')";
            cmd = new SqlCommand(@sql, conn);
            cmd.ExecuteNonQuery();
            getData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tbCustomers SET cust_Name=N'" + txtCusName.Text + "', cust_Address='" + txtCusAddr.Text + "', telephone='" + txtCusTel.Text + "' WHERE cust_id = '" + txtCusID.Text + "'";
            cmd = new SqlCommand(@sql, conn);
            cmd.ExecuteNonQuery();
            getData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ທ່ານຕ້ອງການລຶບຂໍ້ມູນນີ້ບໍ", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tbCustomers WHERE cust_id = '" + txtCusID.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                getData();
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
