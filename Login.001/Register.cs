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

namespace Login._001
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login fm1 = new Login();
            fm1.Show();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into login(userName,password) values('"+txtUserID.Text+"','"+txtUserPassword.Text+"')",con);
            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Inserted Successfully","Message");


            txtUserID.Clear();
            txtUserPassword.Clear();


            
        }
    }
}
