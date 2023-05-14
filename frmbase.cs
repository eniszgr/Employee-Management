using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sql_ile_deneme
{
    public partial class frmbase : Form
    {
        public frmbase()
        {
            InitializeComponent();
        }
        void clearfunc()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtJob.Text = "";
            comboCity.Text = "";
            maskedSalary.Text = "";
            radioButton1.Checked = false;
            radioButton1.Checked=false;
           
            txtName.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.table_1TableAdapter2.Fill(this.employeeDataBaseDataSet2.Table_1);
        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-NJT7QHD1\\SQLEXPRESS;Initial Catalog=EmployeeDataBase;Integrated Security=True");

        private void btnList_Click(object sender, EventArgs e)
        {
            this.table_1TableAdapter2.Fill(this.employeeDataBaseDataSet2.Table_1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_add = new SqlCommand("insert into Table_1 (EmployeeName,EmployeeSurname,EmployeeCity,EmployeeSalary,EmployeeJob,EmployeeSituation) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            command_add.Parameters.AddWithValue("@p1", txtName.Text);
            command_add.Parameters.AddWithValue("@p2", txtSurname.Text);
            command_add.Parameters.AddWithValue("@p3", comboCity.Text);
            command_add.Parameters.AddWithValue("@p4", maskedSalary.Text);
            command_add.Parameters.AddWithValue("@p5", txtJob.Text);
            command_add.Parameters.AddWithValue("@p6", label8.Text);
            command_add.ExecuteNonQuery();//run the code update delete save
            connection.Close();
            MessageBox.Show("Successfully");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                label8.Text = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true) label8.Text = "False";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearfunc();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            comboCity.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            maskedSalary.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            txtJob.Text = dataGridView1.Rows[selected].Cells[6].Value.ToString();


        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text== "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text== "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_delete=new SqlCommand("Delete From Table_1 Where EmployeeID=@k1",connection);
            command_delete.Parameters.AddWithValue("@k1",txtID.Text);
            command_delete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show ("successfull");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command_update = new SqlCommand("Update Table_1 Set EmployeeName=@a1, EmployeeSurname=@a2, EmployeeCity=@a3,EmployeeSalary=@a4,EmployeeSituation=@a5,EmployeeJob=@a6 where EmployeeID=@a7", connection);
            command_update.Parameters.AddWithValue("@a1", txtName.Text);
            command_update.Parameters.AddWithValue("@a2", txtSurname.Text);
            command_update.Parameters.AddWithValue("@a3", comboCity.Text);
            command_update.Parameters.AddWithValue("@a4", maskedSalary.Text);
            command_update.Parameters.AddWithValue("@a5", label8.Text);
            command_update.Parameters.AddWithValue("@a6", txtJob.Text);
            command_update.Parameters.AddWithValue("@a7", txtID.Text);
            command_update.ExecuteNonQuery();
            connection.Close();
        }

        private void btnStatics_Click(object sender, EventArgs e)
        {
            Statics frm2= new Statics();
            frm2.Show();
        }

        private void btnGraphs_Click(object sender, EventArgs e)
        {
            graphs frm3=new graphs();
            frm3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reports rep =new Reports();
            rep.Show();
        }
    }
}
