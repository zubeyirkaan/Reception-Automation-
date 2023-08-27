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
    public partial class FormCustomers : Form
    {
        public FormCustomers()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=KAAN\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True");
        
        private void showdata()
        {
            listView1.Items.Clear();
            using (SqlConnection connect = new SqlConnection(@"Data Source=KAAN\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True"))
            {
                connect.Open();
                SqlCommand command = new SqlCommand("select * from AddCustomer", connect);
                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = read["CustomerID"].ToString();
                    add.SubItems.Add(read["Name"].ToString());
                    add.SubItems.Add(read["Surname"].ToString());
                    add.SubItems.Add(read["Phone"].ToString());
                    add.SubItems.Add(read["Email"].ToString());
                    add.SubItems.Add(read["TC"].ToString());
                    add.SubItems.Add(read["RoomNo"].ToString());
                    add.SubItems.Add(read["Price"].ToString());
                    add.SubItems.Add(read["CheckIn"].ToString());
                    add.SubItems.Add(read["CheckOut"].ToString());

                    listView1.Items.Add(add);
                }
                read.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showdata();
        }

        int id = 0;

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSurname.Text = listView1.SelectedItems[0].SubItems[2].Text;
            MskTxtPhone.Text = listView1.SelectedItems[0].SubItems[3].Text;
            TxtMail.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtTC.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtRoomNumber.Text = listView1.SelectedItems[0].SubItems[6].Text;
            TxtPrice.Text = listView1.SelectedItems[0].SubItems[7].Text;
            DtpCheckIn.Text = listView1.SelectedItems[0].SubItems[8].Text;
            DtpCheckOut.Text = listView1.SelectedItems[0].SubItems[9].Text;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (TxtRoomNumber.Text == "101")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room101", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }

            if (TxtRoomNumber.Text == "102")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room102", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }

            if (TxtRoomNumber.Text == "103")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room103", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }

            if (TxtRoomNumber.Text == "104")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room104", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }

            if (TxtRoomNumber.Text == "105")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room105", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }

            if (TxtRoomNumber.Text == "106")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room106", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }

            if (TxtRoomNumber.Text == "107")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room107", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }

            if (TxtRoomNumber.Text == "108")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room108", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }
            
            if (TxtRoomNumber.Text == "109")
            {
                connect.Open();
                SqlCommand command = new SqlCommand("delete from Room109", connect);
                command.ExecuteNonQuery();
                connect.Close();
                showdata();
            }

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtName.Clear();
            TxtSurname.Clear();
            MskTxtPhone.Clear();
            TxtMail.Clear();
            TxtTC.Clear();
            TxtRoomNumber.Clear();
            TxtPrice.Clear();
            DtpCheckIn.Text = "";
            DtpCheckOut.Text = "";

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            connect.Open();
            string updateQuery = "UPDATE AddCustomer SET " + "Name = '" + TxtName.Text.Replace("'", "''") + "', " + "Surname = '" + TxtSurname.Text.Replace("'", "''") + "', " + "Phone = '" + MskTxtPhone.Text.Replace("'", "''") + "', " +"EMail = '" + TxtMail.Text.Replace("'", "''") + "', " + "TC = '" + TxtTC.Text.Replace("'", "''") + "', " + "RoomNo = '" + TxtRoomNumber.Text.Replace("'", "''") + "', " + "Price = '" + TxtPrice.Text.Replace("'", "''") + "', " + "CheckIn = '" + DtpCheckIn.Value.ToString("yyyy-MM-dd") + "', " + "CheckOut = '" + DtpCheckOut.Value.ToString("yyyy-MM-dd") + "' " + "WHERE CustomerID = " + id;
            SqlCommand command = new SqlCommand(updateQuery, connect);
            command.ExecuteNonQuery();

            connect.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            using (SqlConnection connect = new SqlConnection(@"Data Source=KAAN\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True"))
            {
                connect.Open();
                string searchQuery = "SELECT * FROM AddCustomer WHERE Name LIKE '%' + @SearchText + '%'";
                SqlCommand command = new SqlCommand(searchQuery, connect);
                command.Parameters.AddWithValue("@SearchText", textBox1.Text);

                SqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    ListViewItem add = new ListViewItem();
                    add.Text = read["CustomerID"].ToString();
                    add.SubItems.Add(read["Name"].ToString());
                    add.SubItems.Add(read["Surname"].ToString());
                    add.SubItems.Add(read["Phone"].ToString());
                    add.SubItems.Add(read["Email"].ToString());
                    add.SubItems.Add(read["TC"].ToString());
                    add.SubItems.Add(read["RoomNo"].ToString());
                    add.SubItems.Add(read["Price"].ToString());
                    add.SubItems.Add(read["CheckIn"].ToString());
                    add.SubItems.Add(read["CheckOut"].ToString());

                    listView1.Items.Add(add);
                }
                read.Close();

            }
        }
    }
}

//Data Source=KAAN\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True

//SqlCommand command = new SqlCommand("delete from AddCustomer where CustomerID=("+ id +")",connect);