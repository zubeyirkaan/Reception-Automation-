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
    public partial class FormNewCustomer : Form
    {
        public FormNewCustomer()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source=KAAN\\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True");
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnRoom101_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "101";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room101 (Name, Surname) values ('"+ TxtName.Text+"','"+TxtSurname.Text+"')",connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoom102_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "102";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room102 (Name, Surname) values ('" + TxtName.Text + "','" + TxtSurname.Text + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoom103_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "103";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room103 (Name, Surname) values ('" + TxtName.Text + "','" + TxtSurname.Text + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoom104_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "104";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room104 (Name, Surname) values ('" + TxtName.Text + "','" + TxtSurname.Text + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoom105_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "105";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room105 (Name, Surname) values ('" + TxtName.Text + "','" + TxtSurname.Text + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoom106_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "106";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room106 (Name, Surname) values ('" + TxtName.Text + "','" + TxtSurname.Text + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoom107_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "107";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room107 (Name, Surname) values ('" + TxtName.Text + "','" + TxtSurname.Text + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoom108_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "108";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room108 (Name, Surname) values ('" + TxtName.Text + "','" + TxtSurname.Text + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoom109_Click(object sender, EventArgs e)
        {
            TxtRoomNumber.Text = "109";
            connect.Open();
            SqlCommand command = new SqlCommand("insert into Room109 (Name, Surname) values ('" + TxtName.Text + "','" + TxtSurname.Text + "')", connect);
            command.ExecuteNonQuery();
            connect.Close();
        }

        private void BtnRoomFull_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Red buttons shows occupied rooms.");
        }

        private void BtnRoomEmpty_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Green buttons show empty rooms.");
        }

        private void DtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            DateTime checkInDate = DtpCheckIn.Value; // Assuming DtpCheckIn is your check-in date picker
            DateTime checkOutDate = DtpCheckOut.Value;

            TimeSpan difference = checkOutDate - checkInDate;
            int numberOfDays = (int)difference.TotalDays;

            label10.Text = numberOfDays.ToString();

            int price = numberOfDays * 50;
            TxtPrice.Text = price.ToString();
        }

        private void NewCustomerSave_Click(object sender, EventArgs e)
        {
            connect.Open();
            string query = "INSERT INTO AddCustomer (Name, Surname, Phone, EMail, TC, RoomNo, Price, CheckIn, CheckOut) VALUES ('" + TxtName.Text.Replace("'", "''") + "', '" + TxtSurname.Text.Replace("'", "''") + "', '" + MskTxtPhone.Text.Replace("'", "''") + "', '" + TxtMail.Text.Replace("'", "''") + "', '" + TxtTC.Text.Replace("'", "''") + "', '" + TxtRoomNumber.Text.Replace("'", "''") + "', '" + TxtPrice.Text.Replace("'", "''") + "', '" + DtpCheckIn.Value.ToString("yyyy-MM-dd") + "', '" + DtpCheckOut.Value.ToString("yyyy-MM-dd") + "')";
            SqlCommand command = new SqlCommand(query, connect);
            command.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("New customer added!");
        }

        private void FormNewCustomer_Load(object sender, EventArgs e)
        {
            //room101
            connect.Open();
            SqlCommand command1 = new SqlCommand("Select * from Room101", connect);
            SqlDataReader read1 = command1.ExecuteReader();

            while (read1.Read())
            {
                BtnRoom101.Text = read1["Name"].ToString() + " " + read1["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom101.Text != "101")
            {
                BtnRoom101.BackColor = Color.Red;
                BtnRoom101.Enabled = false;
            }

            //room102
            connect.Open();
            SqlCommand command2 = new SqlCommand("Select * from Room102", connect);
            SqlDataReader read2 = command2.ExecuteReader();

            while (read2.Read())
            {
                BtnRoom102.Text = read2["Name"].ToString() + " " + read2["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom102.Text != "102")
            {
                BtnRoom102.BackColor = Color.Red;
                BtnRoom102.Enabled = false;
            }

            //room103
            connect.Open();
            SqlCommand command3 = new SqlCommand("Select * from Room103", connect);
            SqlDataReader read3 = command3.ExecuteReader();

            while (read3.Read())
            {
                BtnRoom103.Text = read3["Name"].ToString() + " " + read3["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom103.Text != "103")
            {
                BtnRoom103.BackColor = Color.Red;
                BtnRoom103.Enabled = false;
            }

            //room104
            connect.Open();
            SqlCommand command4 = new SqlCommand("Select * from Room104", connect);
            SqlDataReader read4 = command4.ExecuteReader();

            while (read4.Read())
            {
                BtnRoom104.Text = read4["Name"].ToString() + " " + read4["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom104.Text != "104")
            {
                BtnRoom104.BackColor = Color.Red;
                BtnRoom104.Enabled = false;
            }


            //room105
            connect.Open();
            SqlCommand command5 = new SqlCommand("Select * from Room105", connect);
            SqlDataReader read5 = command5.ExecuteReader();

            while (read5.Read())
            {
                BtnRoom105.Text = read5["Name"].ToString() + " " + read5["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom105.Text != "105")
            {
                BtnRoom105.BackColor = Color.Red;
                BtnRoom105.Enabled = false;
            }


            //room106
            connect.Open();
            SqlCommand command6 = new SqlCommand("Select * from Room106", connect);
            SqlDataReader read6 = command6.ExecuteReader();

            while (read6.Read())
            {
                BtnRoom106.Text = read6["Name"].ToString() + " " + read6["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom106.Text != "106")
            {
                BtnRoom106.BackColor = Color.Red;
                BtnRoom106.Enabled = false;
            }


            //room107
            connect.Open();
            SqlCommand command7 = new SqlCommand("Select * from Room107", connect);
            SqlDataReader read7 = command7.ExecuteReader();

            while (read7.Read())
            {
                BtnRoom107.Text = read7["Name"].ToString() + " " + read7["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom107.Text != "107")
            {
                BtnRoom107.BackColor = Color.Red;
                BtnRoom107.Enabled = false;
            }


            //room108
            connect.Open();
            SqlCommand command8 = new SqlCommand("Select * from Room108", connect);
            SqlDataReader read8 = command8.ExecuteReader();

            while (read8.Read())
            {
                BtnRoom108.Text = read8["Name"].ToString() + " " + read8["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom108.Text != "108")
            {
                BtnRoom108.BackColor = Color.Red;
                BtnRoom108.Enabled = false;
            }


            //room109
            connect.Open();
            SqlCommand command9 = new SqlCommand("Select * from Room109", connect);
            SqlDataReader read9 = command9.ExecuteReader();

            while (read9.Read())
            {
                BtnRoom109.Text = read9["Name"].ToString() + " " + read9["Surname"].ToString();
            }
            connect.Close();
            if (BtnRoom109.Text != "109")
            {
                BtnRoom109.BackColor = Color.Red;
                BtnRoom109.Enabled = false;
            }
        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

//Data Source=KAAN\ZUBEYIRKAAN;Initial Catalog=Reception;Integrated Security=True