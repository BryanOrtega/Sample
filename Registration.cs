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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
namespace Library
{
    public partial class Registration : MetroForm
    {
        public Registration()
        {
            InitializeComponent();

        }
        public string MyProperty { get; set; }

        private void Registration_Load(object sender, EventArgs e)
        {
            txt_id.Text = (this.MyProperty);
            this.ControlBox = false;
            txt_id.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            cmb_usertype.SelectedIndex = 0;
            cmb_year.SelectedIndex = 0;
            cmb_dept.SelectedIndex = 0;
          

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {

            //back to previous form 
            string id = txt_id.Text;
            admin_form frm2 = new admin_form();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {

            //refresh datagridview
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            if (cmb_usertype.SelectedIndex == 0)
            {
                sqlcommand.CommandText = "SELECT a_un as 'Account No.', a_fname as 'First Name', a_lname as 'Last Name' FROM `tbl_admin` WHERE 1";

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

                sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` WHERE `u_type` = '" + cmb_usertype.Text + "'";

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

        private void btn_total_Click(object sender, EventArgs e)
        {
            //total of all accounts(admin and user)
            if (cmb_usertype.SelectedIndex == 0)
            {
                MySqlConnection sqlconnect = new MySqlConnection("Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''");
                MySqlCommand sqlcommand = sqlconnect.CreateCommand();
                sqlcommand.CommandText = "select count(*) as myCount from tbl_admin ";
                sqlconnect.Open();

                long returnValue = (long)sqlcommand.ExecuteScalar();
                txt_total.Text = returnValue + " admin/s".ToString();
            }
            else
            {
                MySqlConnection sqlconnect = new MySqlConnection("Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''");
                MySqlCommand sqlcommand = sqlconnect.CreateCommand();
                sqlcommand.CommandText = "select count(*) as myCount from tbl_user ";
                sqlconnect.Open();

                long returnValue = (long)sqlcommand.ExecuteScalar();
                txt_total.Text = returnValue + " user/s".ToString();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //save registered accounts
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var mytime = time.ToString(format);
            try
            {
                if (txt_num.Text == "" || txt_pass.Text == "" || txt_conf.Text == "" || txt_fname.Text == "" || txt_lname.Text == "")
                {
                    MessageBox.Show("Incomplete Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
                    MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
                    MySqlCommand sqlcommand = new MySqlCommand();
                    MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                    DataSet DS = new DataSet();
                    sqlconnect.Open();

                    if (txt_pass.Text == txt_conf.Text)
                    {
                        if (txt_pass.Text.Length < 6)
                        {
                            MessageBox.Show("Passwords must be at least 6 characters long.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                           
                         
                        }
                        else
                        {

                            if (cmb_usertype.SelectedIndex == 0)
                            {
                                sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_admin` (`a_un`, `a_pass`,`a_fname`,`a_lname`) VALUES ('" + txt_num.Text + "' ,'" + txt_pass.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "');";

                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;
                                sqlcommand.CommandText = "SELECT a_un as 'Account No.', a_fname as 'First Name', a_lname as 'Last Name' FROM `tbl_admin` WHERE 1";
                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;
                                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                                dataGridView1.DataSource = DS;
                                dataGridView1.DataMember = "KAIBIGAN";

                                sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Insert new Account','" + txt_num.Text + "','" + mytime + "');";
                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;
                                sqlconnect.Close();
                                MessageBox.Show("Account Registered", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txt_num.Clear();
                                txt_pass.Clear();
                                txt_conf.Clear();
                                txt_fname.Clear();
                                txt_lname.Clear();
                                cmb_dept.SelectedIndex = 0;
                                cmb_year.SelectedIndex = 0;
                                txt_total.Clear();
                            }
                            else if (cmb_usertype.SelectedIndex == 1)
                            {
                                sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_user` (`u_un`, `u_pass`,`u_fname`,`u_lname`,`u_type`,`u_dept`,`u_year`) VALUES ('" + txt_num.Text + "' ,'" + txt_pass.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','Student','" + cmb_dept.Text + "','" + cmb_year.Text + "');";
                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;


                                sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Insert new Account','" + txt_num.Text + "','" + mytime + "');";
                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;


                                sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` WHERE `u_type` = '" + cmb_usertype.Text + "'";

                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;
                                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                                dataGridView1.DataSource = DS;
                                dataGridView1.DataMember = "KAIBIGAN";
                                sqlconnect.Close();

                                MessageBox.Show("Account Registered", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txt_num.Clear();
                                txt_pass.Clear();
                                txt_conf.Clear();
                                txt_fname.Clear();
                                txt_lname.Clear();
                                cmb_dept.SelectedIndex = 0;
                                cmb_year.SelectedIndex = 0;
                                txt_total.Clear();
                            }
                            else if (cmb_usertype.SelectedIndex == 2)
                            {
                                sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_user` (`u_un`, `u_pass`,`u_fname`,`u_lname`,`u_type`,`u_dept`,`u_year`) VALUES ('" + txt_num.Text + "' ,'" + txt_pass.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','Faculty','" + cmb_dept.Text + "','" + cmb_fyear.Text + "');";
                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;


                                sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Insert new Account','" + txt_num.Text + "','" + mytime + "');";
                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;

                                sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` WHERE `u_type` = '" + cmb_usertype.Text + "'";

                                sqlcommand.CommandType = CommandType.Text;
                                sqlcommand.Connection = sqlconnect;
                                sqlcommand.ExecuteNonQuery();
                                sqlDataAdapter.SelectCommand = sqlcommand;
                                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                                dataGridView1.DataSource = DS;
                                dataGridView1.DataMember = "KAIBIGAN";
                                sqlconnect.Close();

                                MessageBox.Show("Account Registered", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txt_num.Clear();
                                txt_pass.Clear();
                                txt_conf.Clear();
                                txt_fname.Clear();
                                txt_lname.Clear();
                                cmb_dept.SelectedIndex = 0;
                                cmb_year.SelectedIndex = 0;
                                txt_total.Clear();
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Password didn't match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }



                }
            
            }
            catch (MySqlException er)
            {
                MessageBox.Show(er.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            //edit selected account
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var mytime = time.ToString(format);
            try
            {
                if (txt_num.Text == "" || txt_pass.Text == "" || txt_conf.Text == "" || txt_fname.Text == "" || txt_lname.Text == "")
                {
                    MessageBox.Show("Incomplete Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                   

                        String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
                        MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
                        MySqlCommand sqlcommand = new MySqlCommand();
                        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                        DataSet DS = new DataSet();
                        sqlconnect.Open();

                    if (txt_pass.Text == txt_conf.Text)
                    {


                        if (txt_pass.Text.Length < 6)
                        {
                            MessageBox.Show("Passwords must be at least 6 characters long","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            if (cmb_usertype.SelectedIndex == 0)
                            {

                                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_admin WHERE (`a_un` = '" + txt_num.Text + "') ", sqlconnect);
                                if (check_User_Name.ExecuteScalar() != null)
                                {
                                    long UserExist = (long)check_User_Name.ExecuteScalar();
                                    if (UserExist > 0)
                                    {
                                        sqlcommand.CommandText = "update tbl_admin set a_pass='" + txt_pass.Text + "',a_fname='" + txt_fname.Text + "',a_lname='" + txt_lname.Text + "' where a_un ='" + txt_num.Text + "';";


                                        sqlcommand.CommandType = CommandType.Text;
                                        sqlcommand.Connection = sqlconnect;
                                        sqlcommand.ExecuteNonQuery();
                                        sqlDataAdapter.SelectCommand = sqlcommand;
                                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Edit Account','" + txt_num.Text + "','" + mytime + "');";
                                        sqlcommand.CommandType = CommandType.Text;
                                        sqlcommand.Connection = sqlconnect;
                                        sqlcommand.ExecuteNonQuery();
                                        sqlDataAdapter.SelectCommand = sqlcommand;
                                     
                                        sqlconnect.Close();
                                        MessageBox.Show("Account Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        txt_num.Clear();
                                        txt_pass.Clear();
                                        txt_conf.Clear();
                                        txt_fname.Clear();
                                        txt_lname.Clear();
                                        cmb_dept.SelectedIndex = 0;
                                        cmb_year.SelectedIndex = 0;
                                        txt_total.Clear();


                                    }

                                }
                                else 
                                {
                                    MessageBox.Show("Invalid Account Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }

                            }
                            else if (cmb_usertype.SelectedIndex == 1)
                            {

                                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_user WHERE (`u_un` = '" + txt_num.Text + "') ", sqlconnect);
                                if (check_User_Name.ExecuteScalar() != null)
                                {
                                    long UserExist = (long)check_User_Name.ExecuteScalar();
                                    if (UserExist > 0)
                                    {


                                        sqlcommand.CommandText = "update tbl_user set u_pass='" + txt_pass.Text + "',u_fname='" + txt_fname.Text + "',u_lname='" + txt_lname.Text + "',u_dept='" + cmb_dept.Text + "',u_year='" + cmb_year.Text + "' where u_un ='" + txt_num.Text + "';";


                                        sqlcommand.CommandType = CommandType.Text;
                                        sqlcommand.Connection = sqlconnect;
                                        sqlcommand.ExecuteNonQuery();
                                        sqlDataAdapter.SelectCommand = sqlcommand;
                                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Edit Account','" + txt_num.Text + "','" + mytime + "');";
                                        sqlcommand.CommandType = CommandType.Text;
                                        sqlcommand.Connection = sqlconnect;
                                        sqlcommand.ExecuteNonQuery();
                                        sqlDataAdapter.SelectCommand = sqlcommand;

                                        sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` WHERE `u_type` = '" + cmb_usertype.Text + "'";

                                        sqlcommand.CommandType = CommandType.Text;
                                        sqlcommand.Connection = sqlconnect;
                                        sqlcommand.ExecuteNonQuery();
                                        sqlDataAdapter.SelectCommand = sqlcommand;
                                        sqlDataAdapter.Fill(DS, "KAIBIGAN");
                                        dataGridView1.DataSource = DS;
                                        dataGridView1.DataMember = "KAIBIGAN";
                                        sqlconnect.Close();
                                        MessageBox.Show("Account Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        txt_num.Clear();
                                        txt_pass.Clear();
                                        txt_conf.Clear();
                                        txt_fname.Clear();
                                        txt_lname.Clear();
                                        cmb_dept.SelectedIndex = 0;
                                        cmb_year.SelectedIndex = 0;
                                        txt_total.Clear();

                                    }

                                }

                                else
                                {
                                    MessageBox.Show("Invalid Account Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                            }
                            else if (cmb_usertype.SelectedIndex == 2)
                            {

                                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_user WHERE (`u_un` = '" + txt_num.Text + "') ", sqlconnect);
                                if (check_User_Name.ExecuteScalar() != null)
                                {
                                    long UserExist = (long)check_User_Name.ExecuteScalar();
                                    if (UserExist > 0)
                                    {


                                        sqlcommand.CommandText = "update tbl_user set u_pass='" + txt_pass.Text + "',u_fname='" + txt_fname.Text + "',u_lname='" + txt_lname.Text + "',u_dept='" + cmb_dept.Text + "',u_year='" + cmb_fyear.Text + "' where u_un ='" + txt_num.Text + "';";


                                        sqlcommand.CommandType = CommandType.Text;
                                        sqlcommand.Connection = sqlconnect;
                                        sqlcommand.ExecuteNonQuery();
                                        sqlDataAdapter.SelectCommand = sqlcommand;
                                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Edit Account','" + txt_num.Text + "','" + mytime + "');";
                                        sqlcommand.CommandType = CommandType.Text;
                                        sqlcommand.Connection = sqlconnect;
                                        sqlcommand.ExecuteNonQuery();
                                        sqlDataAdapter.SelectCommand = sqlcommand;

                                        sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` WHERE `u_type` = '" + cmb_usertype.Text + "'";

                                        sqlcommand.CommandType = CommandType.Text;
                                        sqlcommand.Connection = sqlconnect;
                                        sqlcommand.ExecuteNonQuery();
                                        sqlDataAdapter.SelectCommand = sqlcommand;
                                        sqlDataAdapter.Fill(DS, "KAIBIGAN");
                                        dataGridView1.DataSource = DS;
                                        dataGridView1.DataMember = "KAIBIGAN";
                                        sqlconnect.Close();
                                        MessageBox.Show("Account Updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        txt_num.Clear();
                                        txt_pass.Clear();
                                        txt_conf.Clear();
                                        txt_fname.Clear();
                                        txt_lname.Clear();
                                        cmb_dept.SelectedIndex = 0;
                                        cmb_year.SelectedIndex = 0;
                                        txt_total.Clear();

                                    }

                                }

                                else
                                {
                                    MessageBox.Show("Invalid Account Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                            }
                        }
                        }
                        else
                        {
                            MessageBox.Show("Password did not match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }


                }
            }

            catch (MySqlException er)
            {
                MessageBox.Show(er.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //delete selected account
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var mytime = time.ToString(format);
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();


            //transaction in librarian accounts
            if (cmb_usertype.SelectedIndex == 0)
            {
                //checking if the account no exists
                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_admin WHERE (`a_un` = '" + txt_num.Text + "') ", sqlconnect);

                if (check_User_Name.ExecuteScalar() != null)
                {
                    long UserExist = (long)check_User_Name.ExecuteScalar();
                    if (UserExist > 0)
                    {
                        //delete accounts
                        sqlcommand.CommandText = "DELETE FROM `tbl_admin` WHERE `a_un` = ('" + txt_num.Text + "') ";

                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Delete Account','" + txt_num.Text + "','" + mytime + "');";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` WHERE `u_type` = '" + cmb_usertype.Text + "'";

                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        sqlDataAdapter.Fill(DS, "KAIBIGAN");
                        dataGridView1.DataSource = DS;
                        dataGridView1.DataMember = "KAIBIGAN";
                        sqlconnect.Close();
                        MessageBox.Show("Account deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt_num.Clear();
                        txt_pass.Clear();
                        txt_conf.Clear();
                        txt_fname.Clear();
                        txt_lname.Clear();
                        cmb_dept.SelectedIndex = 0;
                        cmb_year.SelectedIndex = 0;
                        txt_total.Clear();
                    }
                }

                else
                {
                    MessageBox.Show("Invalid account no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                //checking if user account exist
                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_user WHERE (`u_un` = '" + txt_num.Text + "') ", sqlconnect);

                if (check_User_Name.ExecuteScalar() != null)
                {
                    long UserExist = (long)check_User_Name.ExecuteScalar();
                    if (UserExist > 0)
                    {
                        //delete accounts
                        sqlcommand.CommandText = "DELETE FROM `tbl_user` WHERE `u_un` = ('" + txt_num.Text + "')";

                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        //save transaction to activity log
                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Delete Account','" + txt_num.Text + "','" + mytime + "');";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` WHERE `u_type` = '" + cmb_usertype.Text + "'";

                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        sqlDataAdapter.Fill(DS, "KAIBIGAN");
                        dataGridView1.DataSource = DS;
                        dataGridView1.DataMember = "KAIBIGAN";
                        sqlconnect.Close();
                        MessageBox.Show("Account deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt_num.Clear();
                        txt_pass.Clear();
                        txt_conf.Clear();
                        txt_fname.Clear();
                        txt_lname.Clear();
                        cmb_dept.SelectedIndex = 0;
                        cmb_year.SelectedIndex = 0;
                        txt_total.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid account no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //clear textbox and combobox
            txt_num.Clear();
            txt_pass.Clear();
            txt_conf.Clear();
            txt_fname.Clear();
            txt_lname.Clear();
            cmb_dept.SelectedIndex = 0;
            cmb_year.SelectedIndex = 0;
            txt_total.Clear();

        }
        private void txt_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {


            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            if (cmb_usertype.SelectedIndex == 0)
            {

                sqlcommand.CommandText = "SELECT a_un as 'Account No.', a_fname as 'First Name', a_lname as 'Last Name' FROM `tbl_admin` WHERE a_un like('" + txt_num.Text + "') ";

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

                sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` WHERE u_un like('" + txt_num.Text + "') ";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (cmb_usertype.SelectedIndex == 0)
                {

                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    txt_num.Text = row.Cells[0].Value.ToString();

                    txt_fname.Text = row.Cells[1].Value.ToString();
                    txt_lname.Text = row.Cells[2].Value.ToString();
                    cmb_usertype.SelectedIndex = 0;
                    txt_conf.Clear();
                    txt_pass.Clear();


                }
                else if (cmb_usertype.SelectedIndex == 1)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    txt_num.Text = row.Cells[0].Value.ToString();

                    txt_fname.Text = row.Cells[1].Value.ToString();
                    txt_lname.Text = row.Cells[2].Value.ToString();
                    cmb_usertype.Text = row.Cells[3].Value.ToString();
                    cmb_dept.Text = row.Cells[4].Value.ToString();
                    cmb_year.Text = row.Cells[5].Value.ToString();
                    txt_conf.Clear();
                    txt_pass.Clear();


                }
                else if (cmb_usertype.SelectedIndex == 2)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    txt_num.Text = row.Cells[0].Value.ToString();

                    txt_fname.Text = row.Cells[1].Value.ToString();
                    txt_lname.Text = row.Cells[2].Value.ToString();
                    cmb_usertype.Text = row.Cells[3].Value.ToString();
                    cmb_dept.Text = row.Cells[4].Value.ToString();
                    cmb_fyear.Text = row.Cells[5].Value.ToString();
                    txt_conf.Clear();
                    txt_pass.Clear();

                }
            }
        }

        private void cmb_usertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            if (cmb_usertype.SelectedIndex == 0)
            {
                lbl_dept.Visible = false;
               lbl_year.Visible = false;
                cmb_dept.Visible = false;
                cmb_year.Visible = false;
                cmb_fyear.Visible = false;

                sqlcommand.CommandText = "SELECT a_un as 'Account No.', a_fname as 'First Name', a_lname as 'Last Name' FROM `tbl_admin`  ";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
                txt_num.Text = "";
                txt_pass.Text = "";
                txt_conf.Text = "";
                txt_fname.Text = "";
                txt_lname.Text = "";



            }
            else if (cmb_usertype.SelectedIndex == 1)
            {
                lbl_dept.Visible = true;
                lbl_year.Visible = true;
                cmb_dept.Visible = true;
                cmb_year.Visible = true;
                cmb_fyear.Visible = false;
                sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` where `u_type` LIKE 'Student'";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
                txt_num.Text = "";
                txt_pass.Text = "";
                txt_conf.Text = "";
                txt_fname.Text = "";
                txt_lname.Text = "";
                cmb_dept.SelectedIndex = 0;
                cmb_year.SelectedIndex = 0;
                cmb_fyear.SelectedIndex = 0;
            }
            else if (cmb_usertype.SelectedIndex == 2)
            {
                lbl_dept.Visible = true;
                lbl_year.Visible = true;
                cmb_dept.Visible = true;
                cmb_year.Visible = false;
                cmb_fyear.Visible = true;
                sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` where `u_type` LIKE 'Faculty'";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
                txt_num.Text = "";
                txt_pass.Text = "";
                txt_conf.Text = "";
                txt_fname.Text = "";
                txt_lname.Text = "";
                cmb_dept.SelectedIndex = 0;
                cmb_year.SelectedIndex = 0;
                cmb_fyear.SelectedIndex = 0;
            }
        
    }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
