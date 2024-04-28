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

namespace csharpcrud
{
    public partial class crud : Form
    {
        public crud()
        {
            InitializeComponent();
            BindData();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=UDOY\\SQLEXPRESS;Initial Catalog=csharpcrud;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand($"insert into ProductInfo_Tab values({int.Parse(textBox1.Text)},'{textBox1.Text}','{textBox2.Text}','{comboBox1.Text}', getdate())", con);
            command.ExecuteNonQuery();
            con.Close();
            BindData();
            MessageBox.Show("Successfully Inserted.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand($"UPDATE ProductInfo_Tab SET ItemName = '{textBox1.Text}', Design = '{textBox2.Text}', Color = '{comboBox1.Text}', UpdateDate = GETDATE() WHERE ProductID = {int.Parse(textBox1.Text)}", con);
            command.ExecuteNonQuery();
            con.Close();
            BindData();
            MessageBox.Show("Successfully Updated.");
        }


        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from ProductInfo_Tab", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
