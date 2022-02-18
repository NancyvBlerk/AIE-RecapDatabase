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

namespace RecapSessionDBLink
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-CD26AIV\\SQLEXPRESS;Initial Catalog=Recap_Session;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try 
            {
                con.Open();

                string query = "select * from Login where username = @username and password = @password";
                var command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@username", txtuser.Text);
                command.Parameters.AddWithValue("@password", txtpass.Text);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count == 1)
                {
                    Redirected RD = new Redirected();
                    this.Hide();
                    RD.Show();
                }
                else 
                {
                    MessageBox.Show("Username/Password is incorrect");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
