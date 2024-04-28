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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        String con = "Data Source=UDOY\\SQLEXPRESS;Initial Catalog=csharpcrud;Integrated Security=True";


        private void button2_Click(object sender, EventArgs e)
        {

                string email = textBox1.Text;
                string password = textBox2.Text;

                if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
                {
                    if (RegisterUser(email, password))
                    {
                        MessageBox.Show("Registration successful!");
                        // Optionally, you can close the registration form or navigate to another form
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Email and password cannot be empty.");
                }
            

        }

        private bool RegisterUser(string email, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    string query = "INSERT INTO Login_Tab (email, password) VALUES (@Email, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            if (AuthenticateUser(email, password))
            {
                MessageBox.Show("Login successful!");
                // Proceed to main application or next form
                this.Hide();
                crud crud = new crud();
                crud.Show();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }
        private bool AuthenticateUser(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                string query = "SELECT COUNT(*) FROM Login_Tab WHERE email = @Email AND password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
