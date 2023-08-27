using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reception
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdminLogin fr = new FormAdminLogin();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormNewCustomer fr = new FormNewCustomer();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCustomers fr = new FormCustomers();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRooms fr = new FormRooms();
            fr.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            FormAdminLogin fr = new FormAdminLogin();
            fr.Show();
            this.Hide();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Profit frm = new Profit();
            frm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FormStock frm = new FormStock();
            frm.Show();
        }
    }
}
