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
    public partial class Statics : Form
    {
        public Statics()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-NJT7QHD1\\SQLEXPRESS;Initial Catalog=EmployeeDataBase;Integrated Security=True");
        private void Statics_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_count = new SqlCommand("select count(*) From Table_1 ",connection);
            SqlDataReader reader1 = command_count.ExecuteReader();
            while(reader1.Read()) lbltotalemp.Text = reader1[0].ToString(); 
            connection.Close();

            connection.Open();
            SqlCommand command_married = new SqlCommand("select count (*) From Table_1 where EmployeeSituation=1", connection);
            SqlDataReader reader2 = command_married.ExecuteReader();
            while(reader2.Read()) lblmarriedemp.Text = reader2[0].ToString();
            connection.Close();

            connection.Open();
            SqlCommand command_single = new SqlCommand("select count (*) From Table_1 where EmployeeSituation=0", connection);
            SqlDataReader reader3= command_single.ExecuteReader();
            while(reader3.Read()) lblsingleemp.Text = reader3[0].ToString();
            connection.Close();

            connection.Open ();
            SqlCommand command_city = new SqlCommand("select count(distinct(EmployeeCity)) from Table_1", connection);
            SqlDataReader reader4 = command_city.ExecuteReader();
            while(reader4.Read()) lblcitynum.Text = reader4[0].ToString();
            connection.Close();

            connection.Open ();
            SqlCommand command_totalsalary = new SqlCommand("Select sum(EmployeeSalary) from Table_1", connection);
            SqlDataReader reader5 = command_totalsalary.ExecuteReader();
            while(reader5.Read()) lbltotalsalary.Text = reader5[0].ToString();
            connection.Close();
            
            connection.Open ();
            SqlCommand command_avgsalary = new SqlCommand("Select sum(EmployeeSalary) from Table_1", connection);
            SqlDataReader reader6 = command_avgsalary.ExecuteReader();
            while(reader6.Read())lblaveragesalary.Text = reader6[0].ToString();
            connection.Close();

        }
    }
}
