using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel_System.All_User_Control
{
    public partial class CustomerRegistration : UserControl
    {
        function fn = new function();
        String query;
        public CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getforCombo(query);
            while (sdr.Read())
            {
                for (int i=0; i < sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();

        }

        private void CustomerRegistration_Load(object sender, EventArgs e)
        {

        }

        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
            query = "select roomNo from rooms where bed = '" + cbxBed.Text + "' and roomType  = '" + txtRoom.Text + "' and booked = 'NO'";
            setComboBox(query, txtRoomNo);
        }

        private void cbxBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
        }
        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price,roomid from rooms where roomNo = '"+txtRoomNo.Text+"'";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtNo.Text != "" && CbGender.Text != "" && DtpDob.Text != "" && txtIDProof.Text != "" && txtAddress.Text != "" && DtpCheckIn.Text != "")
            {
                String name = txtName.Text;
                Int64 phone = Int64.Parse(txtNo.Text);
                String gender = CbGender.Text;
                String dob = DtpDob.Text;
                String idproof = txtIDProof.Text;
                String address = txtAddress.Text;
                String checkin = DtpCheckIn.Text;

                query = "Insert into customer(cname,phone,gender,dob,idproof,addres,checkin,roomid)values ('"+name+"',"+phone+",'"+gender+"', '"+dob+"' , '"+idproof+"', '"+address+"', '"+checkin+"', "+rid+") update rooms set booked = 'YES' where roomNo = '"+txtRoomNo.Text+"'";
                fn.setData(query, "Room No" + txtRoomNo.Text + " Allocation Successful.");
                clearAll();
            }
            else
            {
                MessageBox.Show("All Fields Are Important", "Information !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtNo.Clear();
            CbGender.SelectedIndex = -1;
            DtpDob.ResetText();
            txtIDProof.Clear();
            txtAddress.Clear();
            DtpCheckIn.ResetText();
            cbxBed.SelectedIndex = -1;
            txtRoom.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
        }

        private void CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
    }

