using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Library
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            cmb_loginas.SelectedIndex = 0;
            PENALTY();
        }
    
       

            public void PENALTY()
        {
            String day, week;
            {







                String sqlconstring1 = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";

                MySqlConnection sqlConnect1 = new MySqlConnection(sqlconstring1);
                MySqlCommand sqlCommand1 = new MySqlCommand();
                MySqlDataReader sqlDataReader1;

                sqlConnect1.Open();
                sqlCommand1.CommandText = "SELECT * FROM tbl_penalty WHERE b_no='PENALTY'";
                sqlCommand1.CommandType = CommandType.Text;
                sqlCommand1.Connection = sqlConnect1;
                sqlDataReader1 = sqlCommand1.ExecuteReader();
                sqlDataReader1.Read();

                day = sqlDataReader1[5].ToString();
                week = sqlDataReader1[6].ToString();







                sqlConnect1.Close();

            }

            //get all info and dates to get penalty

            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";

            MySqlConnection sqlConnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlCommand = new MySqlCommand();
            MySqlDataReader sqlDataReader;

            sqlConnect.Open();
            sqlCommand.CommandText = "SELECT * FROM tbl_penalty";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnect;
            sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            while (sqlDataReader.Read())
            {


                //textBox1.Text = sqlDataReader[4].ToString();
                //textBox2.Text = sqlDataReader[1].ToString();
                //textBox3.Text = sqlDataReader[2].ToString();
                String num = sqlDataReader[0].ToString();
                String sn = sqlDataReader[1].ToString();
                String date1 = sqlDataReader[2].ToString();


                DateTime d1 = Convert.ToDateTime(date1);
                DateTime d2 = DateTime.Today;

                TimeSpan t = d2 - d1;
                double nrofdays = t.TotalDays;
                int days = Convert.ToInt32(nrofdays);




                int day1 = Convert.ToInt32(day);
                int week1 = Convert.ToInt32(week);


                if (days == 7)
                {
                    num = sqlDataReader[0].ToString();
                    sn = sqlDataReader[1].ToString();

                    MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                    DataSet DS = new DataSet();
                    sqlconnect.Open();

                    MySqlCommand sqlcommand = new MySqlCommand();
                    sqlcommand.CommandText = "UPDATE tbl_penalty SET fine='" + week1 + "' WHERE d_borrowed ='" + d1.ToString("yyyy/MM/dd") + "' AND  b_no ='" + num.ToString() + "' AND u_un ='" + sn.ToString() + "' ";
                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;


                    //textBox1.Text = ""+ d1.ToString("yyyy/MM/dd"); ;
                    
                }
                if (days >= 8)
                {


                    num = sqlDataReader[0].ToString();
                    sn = sqlDataReader[1].ToString();
                    sn = sqlDataReader[1].ToString();


                    int total = days - 7;
                    int total1 = total * day1;

                    int fine = week1 + total1;




                    MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                    DataSet DS = new DataSet();
                    sqlconnect.Open();

                    MySqlCommand sqlcommand = new MySqlCommand();
                    sqlcommand.CommandText = "UPDATE tbl_penalty SET fine='" + fine + "' WHERE d_borrowed ='" + d1.ToString("yyyy/MM/dd") + "' AND  b_no ='" + num.ToString() + "' AND u_un ='" + sn.ToString() + "' ";
                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;

                   


                    //textBox1.Text = "" + days;
                }
               

            }



            
            sqlConnect.Close();



        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            //login button checking for users table of faculty and students from tbl_user directing to user form
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();

            if (cmb_loginas.SelectedIndex == 1)
            {
                MySqlConnection connection = new MySqlConnection("Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''");
                MySqlDataAdapter adapter;
                DataTable table = new DataTable();

                adapter = new MySqlDataAdapter("SELECT `u_un`, `u_pass` FROM `tbl_user` WHERE `u_un` = '" + txt_accno.Text + "' AND `u_pass` = '" + txt_pass.Text + "'", connection);
                adapter.Fill(table);

                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show("Invalid Username or Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
                }

                else
                {
                    //saving the login activity to tbl_activity
                    DateTime time = DateTime.Now;
                    string format = "yyyy-MM-dd HH:mm:ss";
                    var mytime = time.ToString(format);

                    MySqlCommand sqlcommand = new MySqlCommand();
                    sqlcommand.CommandText = "INSERT INTO `tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_accno.Text + "',' Login' ,'" + txt_accno.Text + "' ,'" + mytime + "');";
                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;
                    user_form uf = new user_form(txt_accno.Text);
                    uf.Show();
                    this.Hide();
                }

            }
            else
            {
                //login button checking for librarian's accounts from tbl_admin directing to admin/librarian form
                MySqlConnection connection = new MySqlConnection("Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''");
                MySqlDataAdapter adapter;
                DataTable table = new DataTable();

                adapter = new MySqlDataAdapter("SELECT `a_un`, `a_pass` FROM `tbl_admin` WHERE `a_un` = '" + txt_accno.Text + "' AND `a_pass` = '" + txt_pass.Text + "'", connection);
                adapter.Fill(table);

                if (table.Rows.Count <= 0)
                {

                    MessageBox.Show("Invalid Username or Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    DateTime time = DateTime.Now;
                    string format = "yyyy-MM-dd HH:mm:ss";
                    var mytime = time.ToString(format);
                    //saving the login activity to tbl_activity
                    MySqlCommand sqlcommand = new MySqlCommand();
                    sqlcommand.CommandText = "INSERT INTO `tbl_activitylog`(`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_accno.Text + "',' Login' ,'" + txt_accno.Text + "' ,'" + mytime + "');";
                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;
                  
                    string id = txt_accno.Text;
                    admin_form af = new admin_form();
                    af.MyProperty = id;
                    af.Show();
                    this.Hide();
                    this.Hide();
                }
            }
        }

        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            txt_pass.PasswordChar = cb_showpass.Checked ? '\0' : '*';
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //canecl button shut down system
            Application.Exit();
        }

        private void txt_accno_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
