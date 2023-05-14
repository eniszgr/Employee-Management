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

namespace sql_ile_deneme
{
    public partial class graphs : Form
    {
        public graphs()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-NJT7QHD1\\SQLEXPRESS;Initial Catalog=EmployeeDataBase;Integrated Security=True");
        private void graphs_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_chart1 = new SqlCommand("Select EmployeeCity,count(*) from Table_1 group by EmployeeCity", connection);
            SqlDataReader reader = command_chart1.ExecuteReader();
            while (reader.Read()) chartCity.Series["Cities"].Points.AddXY(reader[0], reader[1]);
            connection.Close();

            connection.Open();
            SqlCommand command_chart2 = new SqlCommand("select EmployeeJob,Avg(EmployeeSalary) from Table_1 group by EmployeeJob", connection);
            SqlDataReader reader2 = command_chart2.ExecuteReader();
            while (reader2.Read()) chart2.Series["Salary"].Points.AddXY(reader2[0], reader2[1]);
            connection.Close();
        }
    }
}
