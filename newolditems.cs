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
    public partial class newolditems : MetroForm
    {
        public newolditems()
        {
            InitializeComponent();
        
        }
        public string MyProperty { get; set; }
        private void newolditems_Load(object sender, EventArgs e)
        {
            txt_id.Text = (this.MyProperty);
            this.ControlBox = false;
            txt_id.Enabled = false;
          
            cb_new.SelectedIndex = 0;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            admin_form frm2 = new admin_form();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void btn_nsearch_Click(object sender, EventArgs e)
        {

            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''; Convert Zero Datetime=True; Allow Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            if (cb_new.SelectedIndex == 0)
            {

                sqlcommand.CommandText = " SELECT * FROM tbl_itemlist WHERE `b_dateadd` BETWEEN DATE_SUB( CURDATE( ) ,INTERVAL 6 DAY ) AND CURDATE( )order by b_dateadd";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cb_new.SelectedIndex == 1)
            {

                sqlcommand.CommandText = "select * from tbl_itemlist where  `b_dateadd`BETWEEN DATE_SUB( CURDATE( ) ,INTERVAL 3 WEEK ) AND CURDATE( )order by b_dateadd ";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else
            {

                sqlcommand.CommandText = "select * from tbl_itemlist where  `b_dateadd` BETWEEN DATE_SUB(CURDATE(), INTERVAL 11 MONTH)AND CURDATE( ) order by b_dateadd";

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

        private void btn_osearch_Click(object sender, EventArgs e)
        {
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''; Convert Zero Datetime=True; Allow Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = " select * from tbl_itemlist where `b_dateadd` BETWEEN DATE_SUB( CURDATE( ) ,INTERVAL 30 YEAR ) AND DATE_SUB( CURDATE( ) ,INTERVAL 5 YEAR )order by b_dateadd ";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
        }

        private void btn_dispose_Click(object sender, EventArgs e)
        {
            if (txt_bno.Text == "")
            {

                MessageBox.Show("Incomplete Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
                MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                DataSet DS = new DataSet();
                sqlconnect.Open();
                MySqlCommand sqlcommand = new MySqlCommand();
                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_itemlist WHERE (`b_no` = '" + txt_bno.Text + "') ", sqlconnect);
                if (check_User_Name.ExecuteScalar() != null)
                {
                    string UserExist = check_User_Name.ExecuteScalar().ToString();

                    if (UserExist != null)
                    {


                        sqlcommand.CommandText = "DELETE FROM `tbl_itemlist` WHERE `b_no` = ('" + txt_bno.Text + "') ";

                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;

                        sqlconnect.Close();
                        MessageBox.Show("Item Removed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Invalid Accession No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }
    }
}
