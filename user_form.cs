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
    public partial class user_form : MetroForm
    {
        public user_form(string Value)
        {
            InitializeComponent();
            txt_id.Text = Value;
        }

        private void user_form_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category' FROM `tbl_itemlist` WHERE 1";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
            cmb_smedium.SelectedIndex = 0;
            cmb_medium.SelectedIndex = 0;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var mytime = time.ToString(format);
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();

            MySqlCommand sqlcommand = new MySqlCommand();
            sqlcommand.CommandText = "INSERT INTO `tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "',' Logout' ,'" + txt_id.Text + "' ,'" + mytime + "');";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            Login log = new Login();
            log.Show();
            this.Dispose();
        }

        private void btn_msearch_Click(object sender, EventArgs e)
        {
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category' FROM `tbl_itemlist` WHERE `b_medium` = '" + cmb_smedium.Text + "'";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
        }

        private void btn_tsearch_Click(object sender, EventArgs e)
        {

            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();



            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category' FROM `tbl_itemlist` WHERE `b_title` LIKE '%" + txt_search.Text + "%'";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
        }

        private void btn_request_Click(object sender, EventArgs e)
        {
            if (txt_title.Text == "")
            {
                MessageBox.Show("Incomplete field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss";
                var mytime = time.ToString(format);
                String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
                MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                DataSet DS = new DataSet();
                sqlconnect.Open();
                MySqlCommand sqlcommand = new MySqlCommand();
                sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_request` (`u_un`,`b_title`,`b_medium`,`d_requested`) VALUES ('" + txt_id.Text + "','" + txt_title.Text + "' ,'" + cmb_medium.Text + "','" + mytime + "');";
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlconnect.Close();


                MessageBox.Show("Request sent", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
    }
}
