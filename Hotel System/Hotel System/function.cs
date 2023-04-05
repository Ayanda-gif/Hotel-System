using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_System
{
    class function
    {
        protected SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=UNBREAKABLE23\\SQLEXPRESS;Initial Catalog=myHotel;Integrated Security=True";
            return con;
        }
        public DataSet getData(String query) // To Obtain The Data From Database
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dw = new DataSet();
            da.Fill(dw);
            return dw;
        }

        public void setData(String query, String message) //Used  tO iNSERT, Delete, Update
        {
            SqlConnection con = GetConnection();          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("'"+message+"'","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
       public SqlDataReader getforCombo(String query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;

        }
    }
}
