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
namespace firstApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection("Data Source=LAPTOP-J4U5D1OV\\SQLEXPRESS;Initial Catalog=new;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into form1(username, password) values('" + textBox1.Text + "','" + textBox2.Text + "')", con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Data saved");
            }
            else
            {

                MessageBox.Show("error!!");
            }
            con.Close();
            //display_data();
           
        }

            public void display_data()
            {

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Bhushan\\source\repos\firstApp\firstApp\Database1.mdf;Integrated Security=True");
            con.Open();
            //SqlCommand cmd = con.CreateCommand();
           // cmd.CommandType = commandType.Text;
            SqlCommand cmd = new SqlCommand("select * from [form1]",con);
            cmd.ExecuteNonQuery();

            DataTable dta = new DataTable();
                SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
                dataadp.Fill(dta);
                dataGridView1.DataSource = dta;
               con.Close();
            }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            display_data();
        }
    }
}
