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
using MetroFramework.Forms;

namespace Library
{
    public partial class Activitylog : MetroForm
    {
        public Activitylog()
        {
            InitializeComponent();
  
        }
        public string MyProperty { get; set; }
        private void Activitylog_Load(object sender, EventArgs e)
        {
            txt_id.Text = (this.MyProperty);
            this.ControlBox = false;
            //automatically display and load data form tbl_activitylog to datagridview
            txt_id.Enabled = false;

        
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT `librarian_id` as 'Account No.', `activity` as 'Activity', `account_no` as 'Affected Account/Item No.', `date_activity` as 'Date of Activity' FROM `tbl_activitylog` WHERE 1 order by date_activity DESC";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            //return to admin_form
            string id = txt_id.Text;
            admin_form frm2 = new admin_form();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            //display all the activities
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''; Convert Zero Datetime=True; Allow Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();

            sqlcommand.CommandText = "SELECT `librarian_id` as 'Account No.', `activity` as 'Activity', `account_no` as 'Affected Account/Item No.', `date_activity` as 'Date of Activity' FROM tbl_activitylog WHERE 1 Order By date_activity Desc";


            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //display current activities
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''; Convert Zero Datetime=True; Allow Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();


            sqlcommand.CommandText = "SELECT `librarian_id` as 'Account No.', `activity` as 'Activity', `account_no` as 'Affected Account/Item No.', `date_activity` as 'Date of Activity' FROM tbl_activitylog WHERE `date_activity` >= @todayDate And date_activity < @nextDay Order By date_activity Desc";


            sqlcommand.Parameters.AddWithValue("@todayDate", DateTime.Today);
            sqlcommand.Parameters.AddWithValue("@nextDay", DateTime.Today.AddDays(1));

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
        }
    }
    }
