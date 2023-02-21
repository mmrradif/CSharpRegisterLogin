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

namespace Login._001
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (inValid())
            {
                //using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\Projects\LogInForm\Login.001\Login.001\Database1.mdf;Integrated Security=True"));
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM login WHERE username='" + txtUserName.Text.Trim() + "' AND password='"+txtPassword.Text.Trim()+"' ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    DataTable dta = new DataTable();
                    sda.Fill(dta);


                    if (dta.Rows.Count==1)
                    {
                        Message message = new Message();
                        this.Hide();
                        message.Show();
                    }
                }
            }
        }


        private bool inValid()
        {
            if (txtUserName.Text.TrimStart()==string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Username", " ERROR");
                return false;
            }
            else if (txtPassword.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Password", " ERROR");
                return false;
            }
            return true;
        }



        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }



        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register fm2 = new Register();
            fm2.Show();
        }



        private void registrationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Register form2 = new Register();
            form2.Show();
        }
    }
}
