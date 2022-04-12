using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final643450647_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text == "")
            {
                MessageBox.Show("กรุณาป้อนราคาสินค้า", "แจ้งเตือน");
                txtPrice.Focus();
                return;
            }
            if (txtCount.Text == "")
            {
                MessageBox.Show("กรุณาป้อนราคาสินค้า", "แจ้งเตือน");
                txtCount.Focus();
                return;
            }
            int PriceProduct = 0, Count = 0, Sum = 0;

            PriceProduct = Convert.ToInt32(txtPrice.Text);
            Count = Convert.ToInt32(txtCount.Text);
            if (PriceProduct < 1)
            {
                MessageBox.Show("กรุณาป้อนราคาสินค้าที่มากกว่า 0", "แจ้งเตือน");
                txtPrice.SelectAll();
                return;
            }
            if (Count < 1)
            {
                MessageBox.Show("กรุณาป้อนราคาสินค้าที่มากกว่า 0", "แจ้งเตือน");
                txtCount.SelectAll();
                return;
            }
            Sum = PriceProduct * Count;
            txtTotal.Text = Sum.ToString();
            txtTotalprice.Text = Sum.ToString();
            txtChange.Focus();

            txtSelected.Text = comboBox1.Text;
        }

        private void txtPrice_TextChanged(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtCount_TextChanged(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPay_TextChanged(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            int Pay = Convert.ToInt32(txtPay.Text);
            int Total = Convert.ToInt32(txtTotal.Text);
            if (txtPay.Text == "")
            {
                MessageBox.Show("กรุณาป้อนจำนวนเงินที่จ่าย", "แจ้งเตือน");
                txtPay.Focus();
                return;
            }
            int change = Pay - Total;

            txtChange.Text = change.ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);

                string readAllText = File.ReadAllText(openFileDialog.FileName);
                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string allDATARAW = readAllLine[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView2.Rows.Add(allDATASplited[0], allDATASplited[1], allDATASplited[2]);
                }
            }
        }

        private void Calculate_Coupon_Click(object sender, EventArgs e)
        {
            string Selected = txtSelected.Text;
            string Totalprice = txtTotalprice.Text;
            string Discount = txtDiscount.Text;
            string Coupon = txtCoupon.Text;
            
            int n = dataGridView1.Rows.Add();

            dataGridView1.Rows[n].Cells[0].Value = Selected;
            dataGridView1.Rows[n].Cells[1].Value = Totalprice;
            dataGridView1.Rows[n].Cells[2].Value = Discount;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV (*.csv) | *.csv";
                bool fileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        int columnCount = dataGridView1.Columns.Count;
                        string column = "";
                        string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                        for (int i = 0; i < columnCount; i++)
                        {
                            column += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                        }
                        outputCSV[0] += column;
                        for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                            }
                        }
                        File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
