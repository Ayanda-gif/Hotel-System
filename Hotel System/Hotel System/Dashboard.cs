using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            addRoom1.BringToFront();
            addRoom1.Visible = true;
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            
            customerRegistration1.Visible = true;
            customerRegistration1.BringToFront();
           
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
           
            customerCheckout1.BringToFront();
            
            
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            customerDetails1.Visible = true;
            customerDetails1.BringToFront();
            
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
           
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void addRoom1_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            addRoom1.Visible = false;
            customerRegistration1.Visible = false;
            btnAddRoom.PerformClick();

        }

        private void customerRegistration1_Load(object sender, EventArgs e)
        {

        }
    }
}
