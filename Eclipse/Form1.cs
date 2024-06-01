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

namespace Eclipse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\Eclipse\Eclipse\Cleaner.mdf;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT RealName FROM Login WHERE UserName='" + 
            txtLogin.Text + "' AND Password='" +
            txtPass.Text + "'", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            object[] login = table.Rows[0].ItemArray;
            string realName = login[0].ToString();


            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Добро пожаловать," + realName);
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль неверные");
                txtLogin.Text = "";
                txtPass.Text = "";
                txtLogin.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
