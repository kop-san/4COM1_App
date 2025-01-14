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
using System.IO;

namespace miniWorkshop_EV
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }
        string pid = "";
        SqlConnection sqlCon = null;
        SqlCommand sqlCmd = null;
        string strConn = @"Data Source=DESKTOP-BDOLBMR\SQLEXPRESS;Initial Catalog=miniPro_Workshop_EV;Integrated Security=True";
        private void frmProducts_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strConn);
            sqlCon.Open();
            sqlCmd = new SqlCommand("select * from tbProductType", sqlCon);
            SqlDataReader sqlDr = sqlCmd.ExecuteReader();
            DataTable dtPT = new DataTable();
            dtPT.Load(sqlDr);
            cboType.DataSource = dtPT;
            cboType.DisplayMember = "ptType_name";
            cboType.ValueMember = "ptType_ID";
            showData();
        }
        private void showData()
        {
            sqlCmd = new SqlCommand("select * from tbProducts", sqlCon);
            SqlDataReader sqlDr = sqlCmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sqlDr);
            dgvShowdata.DataSource = dt;
            dgvShowdata.Columns[0].HeaderText = "ລຳດັບ";
            dgvShowdata.Columns[1].HeaderText = "ຊື່ສິນຄ້າ";
            dgvShowdata.Columns[2].HeaderText = "ຈຳນວນ";
            dgvShowdata.Columns[3].HeaderText = "ລາຄາຕໍ່ໜ່ວຍ";
            dgvShowdata.Columns[4].HeaderText = "ຫົວໜ່ວຍ";
            dgvShowdata.Columns[5].HeaderText = "ປະເພດສິນຄ້າ";
            dgvShowdata.Columns[6].HeaderText = "ເກນສິນຄ້າເຫຼືອ";
            dgvShowdata.Columns[7].HeaderText = "ຮູບພາບ";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] btimg = ms.GetBuffer();
            string sqlstr = "insert into tbProducts(pro_id,pro_name,qty,price,unit,instock,pro_img,ptType_ID) values(@proNo,@productName,@Quantity,@UnitPrice,@Units,@Instock,@picture,@productTypeid)";
            sqlCmd = new SqlCommand(sqlstr, sqlCon);
            sqlCmd.Parameters.AddWithValue("@proNo", txtProNo.Text);
            sqlCmd.Parameters.AddWithValue("@productName", txtProName.Text);
            sqlCmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
            sqlCmd.Parameters.AddWithValue("@UnitPrice", txtPrice.Text);
            sqlCmd.Parameters.AddWithValue("@Units", txtUnit.Text);
            sqlCmd.Parameters.AddWithValue("@Instock", txtInstock.Text);
            sqlCmd.Parameters.AddWithValue("@picture", btimg);
            sqlCmd.Parameters.AddWithValue("@productTypeid", cboType.SelectedValue);
            sqlCmd.ExecuteNonQuery();
            showData();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFdl = new OpenFileDialog();
            //opFdl.Filter = "(Image Type .png;.jpg;.gif)|.png;.jpg;.gif";
            if (opFdl.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opFdl.FileName);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ທ່ານຕ້ອງການລົບຂໍ້ມູນນີ້ຫຼືບໍ່?", "Question",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sqlstr = "Delete from tbProducts where pro_id='" + pid + "'";
                sqlCmd = new SqlCommand(sqlstr, sqlCon);
                sqlCmd.ExecuteNonQuery();
                showData();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] btimg = ms.GetBuffer();
            string sqlstr = "Update tbProducts set pro_id=@proNo,pro_name=@productName,qty=@Quantity,price=@UnitPrice,unit=@Units,instock=@Instock,pro_img=@picture,ptType_ID=@productTypeid where pro_id='" + pid + "'";
            sqlCmd = new SqlCommand(sqlstr, sqlCon);
            sqlCmd.Parameters.AddWithValue("@proNo", txtProNo.Text);
            sqlCmd.Parameters.AddWithValue("@productName", txtProName.Text);
            sqlCmd.Parameters.AddWithValue("@Quantity", txtQty.Text);
            sqlCmd.Parameters.AddWithValue("@UnitPrice", txtPrice.Text);
            sqlCmd.Parameters.AddWithValue("@Units", txtUnit.Text);
            sqlCmd.Parameters.AddWithValue("@Instock", txtInstock.Text);
            sqlCmd.Parameters.AddWithValue("@picture", btimg);
            sqlCmd.Parameters.AddWithValue("@productTypeid", cboType.SelectedValue);
            sqlCmd.ExecuteNonQuery();
            showData();
        }

        private void dgvShowdata_CellMouseClick(object sender, DataGridViewCellEventArgs e)
        {
            int cindex = dgvShowdata.CurrentRow.Index;
            pid = dgvShowdata.Rows[cindex].Cells[0].Value.ToString();
            txtProNo.Text = dgvShowdata.Rows[cindex].Cells[0].Value.ToString();
            txtProName.Text = dgvShowdata.Rows[cindex].Cells[1].Value.ToString();
            txtQty.Text = dgvShowdata.Rows[cindex].Cells[2].Value.ToString();
            txtPrice.Text = dgvShowdata.Rows[cindex].Cells[3].Value.ToString();
            txtUnit.Text = dgvShowdata.Rows[cindex].Cells[4].Value.ToString();
            txtInstock.Text = dgvShowdata.Rows[cindex].Cells[6].Value.ToString();
            var img = (byte[])dgvShowdata.Rows[cindex].Cells[7].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            cboType.SelectedValue = dgvShowdata.Rows[cindex].Cells[5].Value.ToString();
        }
    }
}