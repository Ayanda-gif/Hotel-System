using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_System.All_User_Control
{
    public partial class CustomerCheckout : UserControl
    {
        function fn = new function();
        String query;
        public CustomerCheckout()
        {
            InitializeComponent();
        }

        private void CustomerCheckout_Load(object sender, EventArgs e)
        {
            query = "select customer.cid,customer.cname,customer.phone,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";
            DataSet dw = fn.getData(query);
            guna2DataGridView1.DataSource = dw.Tables[0];
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid,customer.cname,customer.phone,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname  like '" + txtName.Text + "%' and chekout = 'NO'";
            DataSet dw = fn.getData(query);
            guna2DataGridView1.DataSource = dw.Tables[0];
        }
        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (txtCName.Text != "")
            {
                if (MessageBox.Show("Are You sure?.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    String cdate = txtCheckoutDate.Text;
                    query = "update customer set chekout = 'YES', Checkout = '" + cdate + "'where cid = " + id + "update rooms set booked = 'NO' where roomNo = '" + txtRoom.Text + "'";
                    fn.setData(query, "Check Out Successfully.");
                    CustomerCheckout_Load(this, null);
                    clearAll();
                }
            }
            else
            {
                MessageBox.Show("No Customer Selected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoom.Clear();
            txtCheckoutDate.ResetText();
        }

        private void CustomerCheckout_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
