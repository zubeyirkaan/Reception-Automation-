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
    public partial class Profit : Form
    {
        public Profit()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=KAAN\\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void LblCosts_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand command = new SqlCommand("", connect);
            SqlDataReader read = command.ExecuteReader();
            connect.Close();
        }

        private void Profit_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=KAAN\\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True"; 

            // Sum of Price from AddCustomer
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand command = new SqlCommand("SELECT SUM(Price) AS sum FROM AddCustomer", connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    LblIncome.Text = read["sum"].ToString();
                }
                connect.Close();
            }

            // Sum of CleaningSupplies from Cost
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand command1 = new SqlCommand("SELECT SUM(CleaningSupplies) AS sum FROM Cost", connect);
                SqlDataReader read1 = command1.ExecuteReader();
                while (read1.Read())
                {
                    LblIncome.Text = read1["sum"].ToString(); // Use a different label for this value
                }
                connect.Close();
            }

            // Sum of PersonalCareProducts from Cost
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand command2 = new SqlCommand("SELECT SUM(PersonalCareProducts) AS sum FROM Cost", connect);
                SqlDataReader read2 = command2.ExecuteReader();
                while (read2.Read())
                {
                    LblIncome.Text = read2["sum"].ToString(); // Use a different label for this value
                }
                connect.Close();
            }

            // Calculate Staff Salaries
            int staff;
            if (int.TryParse(textBox1.Text, out staff))
            {
                LblStaffSalaries.Text = (staff * 1500).ToString();
            }
            
        }
    }
}
