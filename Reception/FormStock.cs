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
    public partial class FormStock : Form
    {
        public FormStock()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=KAAN\\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True");

        private void datas()
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("select * from Cost", connect);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["CleaningSupplies"].ToString();
                add.SubItems.Add(read["PersonalCareProducts"].ToString());
                add.SubItems.Add(read["Food"].ToString());
                listView1.Items.Add(add);
            }
            connect.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=KAAN\\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True"; // Replace with your actual connection string

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                string insertQuery = "INSERT INTO Cost (CleaningSupplies, PersonalCareProducts, Food) VALUES (@Cleaning, @Personal, @Food)";

                using (SqlCommand command = new SqlCommand(insertQuery, connect))
                {
                    command.Parameters.AddWithValue("@Cleaning", TxtCleaning.Text);
                    command.Parameters.AddWithValue("@Personal", TxtPersonel.Text);
                    command.Parameters.AddWithValue("@Food", TxtFoodDrinks.Text);

                    command.ExecuteNonQuery();
                }

                connect.Close();
            }

            datas();

        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            datas();
        }
    }
}
