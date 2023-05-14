//UserName Enis Password 123
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

namespace sql_ile_deneme
{
    public partial class entering : Form
    {
        public entering()
        {
            InitializeComponent();
        }
        int counter = 1;
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-NJT7QHD1\\SQLEXPRESS;Initial Catalog=EmployeeDataBase;Integrated Security=True");
        private void label3_Click(object sender, EventArgs e)
        {
            if (counter % 2 == 1)
            {
                label4.Visible = true;
                counter++;
            }
            else
            {
                label4.Visible = false;
                counter++;
            }
            
        }       

        private void login_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command1 = new SqlCommand("Select * from Admistor where UserName=@p1 and password=@p2", connection);
            command1.Parameters.AddWithValue("@p1",txtUsername.Text);
            command1.Parameters.AddWithValue("@p2",txtPassword.Text);
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.Read())
            {
                frmbase frm= new frmbase();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            connection.Close();
        }
    }
}
