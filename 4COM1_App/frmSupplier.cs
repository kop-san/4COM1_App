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
    public partial class frmSupplier : Form
    {
        string strConnect = @"Data Source=DESKTOP-BDOLBMR\SQLEXPRESS;Initial Catalog=miniDB_4com1;Integrated Security=True;";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr;
        SqlDataAdapter dar = null;
        public frmSupplier()
        {
            InitializeComponent();
            connectionDB_Checking();
            getData();
        }
        private void getData()
        {
            string sql = "select * from tbSuppliers";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvShow.DataSource = dt;
            dgvShow.Columns[0].HeaderText = "ລະຫັດຜຸ້ສະໜອງ";
            dgvShow.Columns[1].HeaderText = "ຊື່ບໍລິສັດ";
            dgvShow.Columns[2].HeaderText = "ຊື່ຜູ້ຕິດຕໍ່";
            dgvShow.Columns[3].HeaderText = "ເບີໂທ";
            dgvShow.Columns[4].HeaderText = "ທີ່ຢູ່";
            dgvShow.Columns[5].HeaderText = "ອີເມວ";
        }
        private void connectionDB_Checking()
        {
            conn = new SqlConnection(strConnect);
            conn.Open();
        }

        private void dgvShow_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cindex = dgvShow.CurrentRow.Index;
            txtSupID.Text = dgvShow.Rows[cindex].Cells[0].Value.ToString();
            txtSupName.Text = dgvShow.Rows[cindex].Cells[1].Value.ToString();
            txtContrName.Text = dgvShow.Rows[cindex].Cells[2].Value.ToString();
            txtTel.Text = dgvShow.Rows[cindex].Cells[3].Value.ToString();
            txtAddress.Text = dgvShow.Rows[cindex].Cells[4].Value.ToString();
            txtEmail.Text = dgvShow.Rows[cindex].Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tbSuppliers VALUES('" + txtSupID.Text + "',N'" + txtSupName.Text + "', '" + txtContrName.Text + "','" + txtTel.Text + "', '" + txtAddress.Text + "', '" + txtEmail.Text + "')";
            cmd = new SqlCommand(@sql, conn);
            cmd.ExecuteNonQuery();
            getData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tbSuppliers SET supplier_name=N'" + txtSupName.Text + "', contract_name='" + txtContrName.Text + "', address='" + txtAddress.Text + "', telephone='" + txtTel.Text + "', email='" + txtEmail.Text + "' WHERE supplier_id = '" + txtSupID.Text + "'";
            cmd = new SqlCommand(@sql, conn);
            cmd.ExecuteNonQuery();
            getData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ທ່ານຕ້ອງການລຶບຂໍ້ມູນນີ້ບໍ", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "DELETE FROM tbSuppliers WHERE supplier_id = '" + txtSupID.Text + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                getData();
            }
        }
    }
}
