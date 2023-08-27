using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Reception
{
    public partial class FormAdminLogin : Form
    {
        public FormAdminLogin()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=KAAN\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True");

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            connect.Open();
            string sql = "SELECT * FROM AdminLogin WHERE Username = @Username AND Password = @Password"; // Fix the query
            SqlParameter prm1 = new SqlParameter("Username", TxtUsername.Text.Trim());
            SqlParameter prm2 = new SqlParameter("Password", TxtPassword.Text.Trim());
            SqlCommand command = new SqlCommand(sql, connect);
            command.Parameters.Add(prm1);
            command.Parameters.Add(prm2);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                FormMain fr = new FormMain();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

            connect.Close(); // Close the connection

        }

        private void FormAdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
