using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _4COM1_App
{
    public partial class frmProductType : Form
    {
        string strConnect = @"Data Source=DESKTOP-BDOLBMR\SQLEXPRESS;Initial Catalog=miniDB_4com1;Integrated Security=True;";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr;
        SqlDataAdapter dar = null;

        public frmProductType()
        {
            InitializeComponent();
            connectionDB_Checking();
            getData();
        }

        private void getData()
        {
            string sql = "select * from tbProductType";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvShow.DataSource = dt;
            dgvShow.Columns[0].HeaderText = "ລະຫັດປະເພດ";
            dgvShow.Columns[1].HeaderText = "ຊື່ປະເພດ";
        }

        private void connectionDB_Checking()
        {
            conn = new SqlConnection(strConnect);
            conn.Open();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql = "insert into tbProductType values('" +
                txtPtTypeID.Text + "', N'" + txtPtTypeName.Text + "')";
            cmd = new SqlCommand(@sql, conn);
            cmd.ExecuteNonQuery();
            getData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string sql = "update tbProductType set ptType_name= N'" +
                txtPtTypeName.Text + "' where ptType_ID='" + txtPtTypeID.Text + "'";
            cmd = new SqlCommand(@sql, conn);
            cmd.ExecuteNonQuery();
            getData();
        }

        private void dgvShow_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cindex = dgvShow.CurrentRow.Index;
            txtPtTypeID.Text = dgvShow.Rows[cindex].Cells[0].Value.ToString();
            txtPtTypeName.Text = dgvShow.Rows[cindex].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ທ່ານຕ້ອງການລົບຂໍ້ມູນນີ້ບໍ່", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from tbProductType where ptType_ID= '" +
                txtPtTypeName.Text + "'";
                cmd = new SqlCommand(@sql, conn);
                cmd.ExecuteNonQuery();
                getData();
            }
            
        }

        private void txtPtTypeID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
