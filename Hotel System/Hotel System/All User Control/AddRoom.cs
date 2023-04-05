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
    public partial class AddRoom : UserControl
    {
        function fn = new function();
        String query;
        public AddRoom()
        {
            InitializeComponent();
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
           DataSet ds = fn.getData(query);
            DataGridView1.DataSource = ds.Tables[0];
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtRoomNo.Text != "" && txtType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomno = txtRoomNo.Text;
                String type = txtType.Text;
                String bed = txtBed.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                query = "insert into rooms (roomNo,roomType,bed,price) values ('" + roomno + "', '" + type + "', '" + bed + "', " + price + ")";
                fn.setData(query, "Room Added");
                AddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Fill All Fields.", "Warning !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clearAll()
        {
            txtRoomNo.Clear();
            txtType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void AddRoom_Enter(object sender, EventArgs e)
        {
            AddRoom_Load(this, null);
        }

        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
