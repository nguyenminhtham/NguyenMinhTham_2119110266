using Cau1.BAL;
using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1.GUI
{
    public partial class CongNoGUI : Form
    {
        CongNoBAL cnBAL = new CongNoBAL();
        public CongNoGUI()
        {
            InitializeComponent();
        }

        private void CongNoGUI_Load(object sender, EventArgs e)
        {
            List<CongNoDTO> lstCongNo = cnBAL.ReadCongNo();
            foreach (CongNoDTO cn in lstCongNo)
            {
                dgvCongNo.Rows.Add(cn.makhachhang, cn.tenkhachhang, cn.sodienthoai,cn.sotienno);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CongNoDTO cn = new CongNoDTO();

            if (tbId.Text.Equals("") || tbName.Text.Equals("")|| tbSdt.Text.Equals("") || tbSotienno.Text.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống", "Thông báo");
            }
            else
            {
                cn.sotienno = decimal.Parse(tbSotienno.Text);
                cn.makhachhang = tbId.Text;
                cn.tenkhachhang = tbName.Text;
                cn.sodienthoai = tbSdt.Text;
                cnBAL.ThemCongNo(cn);

                dgvCongNo.Rows.Add(cn.makhachhang, cn.tenkhachhang, cn.sodienthoai,cn.sotienno);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CongNoDTO cn = new CongNoDTO();
            cn.sotienno = decimal.Parse(tbSotienno.Text);
            cn.makhachhang = tbId.Text;
            cn.tenkhachhang = tbName.Text;
            cn.sodienthoai = tbSdt.Text;
            int idx = dgvCongNo.CurrentCell.RowIndex;
            cnBAL.XoaCongNo(cn);
            dgvCongNo.Rows.RemoveAt(idx);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            CongNoDTO cn = new CongNoDTO();

            if (tbId.Text.Equals("") || tbName.Text.Equals("") || tbSdt.Text.Equals("") || tbSotienno.Text.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống", "Thông báo");
            }
            else
            {
                cn.sotienno = decimal.Parse(tbSotienno.Text);
                cn.makhachhang = tbId.Text;
                cn.tenkhachhang = tbName.Text;
                cn.sodienthoai = tbSdt.Text;
                cnBAL.SuaCongNo(cn);
                using DataGridViewRow row = dgvCongNo.CurrentRow;
                row.Cells[0].Value = cn.makhachhang;
                row.Cells[1].Value = cn.tenkhachhang;
                row.Cells[2].Value = cn.sodienthoai;
                row.Cells[3].Value = cn.sotienno;

            }
        }

        private void dgvCongNo_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvCongNo.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbId.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbSdt.Text = row.Cells[2].Value.ToString();
                tbSotienno.Text = row.Cells[3].Value.ToString();
            }
        }

        private void CongNoGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show( "BẠN MUỐN ĐÓNG FORM?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
