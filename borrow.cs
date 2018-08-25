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
    public partial class borrow : MetroForm
    {
        public borrow()
        {
            InitializeComponent();
           
        }
        public string MyProperty { get; set; }
        private void borrow_Load(object sender, EventArgs e)
        {
            txt_id.Text = (this.MyProperty);
            this.ControlBox = false;
            //loading the data for the datagridview
            txt_id.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            //display all itemlist
            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE 1";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";

            //display user (student/faculty) accounts
            sqlcommand.CommandText = "SELECT `u_un` as 'Account No.', `u_fname` as 'First Name', `u_lname` as 'Last Name', `u_type` as 'User Type', `u_dept` as 'Department', `u_year` as 'Year' FROM `tbl_user` where 1";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "users");
            dataGridView2.DataSource = DS;
            dataGridView2.DataMember = "users";
            sqlconnect.Close();

            cmb_category.SelectedIndex = 0;
            cmb_borrow.SelectedIndex = 0;

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            //returning to admin_form
            string id = txt_id.Text;
            admin_form frm2 = new admin_form();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview for pending items, itemlist , most borrowed items
            if (e.RowIndex >= 0)
            {
                if (cmb_borrow.SelectedIndex == 0)
                {

                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];


                    txt_accid.Text = row.Cells[0].Value.ToString();
                    txt_medium.Text = row.Cells[1].Value.ToString();
                    txt_title.Text = row.Cells[2].Value.ToString();
                    txt_author.Text = row.Cells[3].Value.ToString();


                }
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            //display in datagridview all the data int tbl_itemlist
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE 1";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
            cmb_borrow.SelectedIndex = 0;
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview for student/faculty accounts
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];


                txt_num.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //search engine
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            if (cmb_category.SelectedIndex == 0)
            {
               //searching for items accession no.
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE `b_no` = '" + txt_search.Text + "'";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_category.SelectedIndex == 1)
            {
                //searching for items title
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE `b_title` LIKE '%" + txt_search.Text + "%'";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_category.SelectedIndex == 2)
            {
                //searching for items author
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE `b_author` = '" + txt_search.Text + "'";

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

        private void btn_borrow_Click(object sender, EventArgs e)
        {
            //checking if the account number and accession number already set
            if (txt_num.Text == "" || txt_accid.Text == "")
            {
                MessageBox.Show("Incomplete Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //borrowing transaction
                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss";
                var mytime = time.ToString(format);
                String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
                MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                DataSet DS = new DataSet();
                sqlconnect.Open();
                MySqlCommand sqlcommand = new MySqlCommand();

                //checking if the account number already has a pending items or already borrowed an item
                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_borrow WHERE (`u_un` = '" + txt_num.Text + "') ", sqlconnect);
                try
                {
                    MySqlCommand check_User1 = new MySqlCommand("SELECT * FROM tbl_itemlist WHERE (`b_no` = '" + txt_accid.Text + "' && `b_copies` = '1') ", sqlconnect);

                    if (check_User1.ExecuteScalar() != null)
                    {
                        string UserExist3 = check_User1.ExecuteScalar().ToString();

                        if (UserExist3 != null)
                        {

                            MessageBox.Show("Out of Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        MySqlCommand check_User4 = new MySqlCommand("SELECT * FROM `tbl_penalty` WHERE (`u_un` = '" + txt_num.Text + "' &&  fine != '0')", sqlconnect);
                        if (check_User4.ExecuteScalar() != null)
                        {
                           long UserExist4 = Convert.ToInt64(check_User4.ExecuteScalar());
                           
                            if (UserExist4 > 0)
                            {
                                MessageBox.Show("Account no. has existing penalty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            //transaction of the borrowing activity
                            MySqlCommand check_User = new MySqlCommand("SELECT * FROM tbl_user WHERE (`u_un` = '" + txt_num.Text + "') ", sqlconnect);
                            if (check_User.ExecuteScalar() != null)
                            {
                                long UserExist2 = (long)check_User.ExecuteScalar();
                                if (UserExist2 > 0)
                                {

                                    //saving the borrowing transaction in tbl_borrow for reference in returning module
                                    sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_borrow` (`b_no`,`b_title`,`b_author`, `u_un`,`d_borrowed`) VALUES ('" + txt_accid.Text + "','" + txt_title.Text + "' ,'" + txt_author.Text + "','" + txt_num.Text + "','" + this.dtp_dborrowed.Text + "');";
                                    sqlcommand.CommandType = CommandType.Text;
                                    sqlcommand.Connection = sqlconnect;
                                    sqlcommand.ExecuteNonQuery();
                                    sqlDataAdapter.SelectCommand = sqlcommand;
                                    //saving the borrowing transaction for most borrowed item
                                    sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_borrowlist` (`b_no`,`u_un`,`b_title`,`b_author`) VALUES ('" + txt_accid.Text + "','" + txt_num.Text + "','" + txt_title.Text + "' ,'" + txt_author.Text + "');";
                                    sqlcommand.CommandType = CommandType.Text;
                                    sqlcommand.Connection = sqlconnect;
                                    sqlcommand.ExecuteNonQuery();
                                    sqlDataAdapter.SelectCommand = sqlcommand;
                                    //deducting the copies of the item
                                    sqlcommand.CommandText = "UPDATE `tbl_itemlist` SET `b_copies` = `b_copies` - 1 where `b_no` = '" + txt_accid.Text + "'";
                                    sqlcommand.CommandType = CommandType.Text;
                                    sqlcommand.Connection = sqlconnect;
                                    sqlcommand.ExecuteNonQuery();
                                    sqlDataAdapter.SelectCommand = sqlcommand;
                                    //saving transaction for penalty
                                    sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_penalty` (`b_no`, `u_un`,`d_borrowed`) VALUES ('" + txt_accid.Text + "','" + txt_num.Text + "','" + this.dtp_dborrowed.Text + "');";
                                    sqlcommand.CommandType = CommandType.Text;
                                    sqlcommand.Connection = sqlconnect;
                                    sqlcommand.ExecuteNonQuery();
                                    sqlDataAdapter.SelectCommand = sqlcommand;

                                    //displaying and refreshing of the datagridview
                                    sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE 1";
                                    sqlcommand.CommandType = CommandType.Text;
                                    sqlcommand.Connection = sqlconnect;
                                    sqlcommand.ExecuteNonQuery();
                                    sqlDataAdapter.SelectCommand = sqlcommand;
                                    sqlDataAdapter.Fill(DS, "KAIBIGAN");
                                    dataGridView1.DataSource = DS;
                                    dataGridView1.DataMember = "KAIBIGAN";

                                    sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Borrow Item','" + txt_num.Text + "','" + mytime + "');";
                                    sqlcommand.CommandType = CommandType.Text;
                                    sqlcommand.Connection = sqlconnect;
                                    sqlcommand.ExecuteNonQuery();
                                    sqlDataAdapter.SelectCommand = sqlcommand;
                                    sqlconnect.Close();

                                    MessageBox.Show("Item Borrowed", "Informaton", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }


                            else
                            {
                                MessageBox.Show("Invalid Account Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                            

                        }
                        }
                    }
                
                }
                catch (MySqlException er)
                {
                    MessageBox.Show("Item already pending. Please return the item first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
            }
        }

        private void cmb_borrow_SelectedIndexChanged(object sender, EventArgs e)
        {
            //display the list of all items in tbl_itemlist
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            if (cmb_borrow.SelectedIndex == 0)
            {

                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE 1";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_borrow.SelectedIndex == 1)
            {
                //display the pending/borrowed items
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_title` as 'Title', `b_author` as 'Author', `u_un` as 'Account No.', `d_borrowed` as 'Date Borrowed' FROM `tbl_borrow` WHERE 1";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_borrow.SelectedIndex == 2)
            {
                //display the most borrowed items
                sqlcommand.CommandText = "SELECT b_no as 'Accession No.', b_title as 'Title', b_author as 'Author', COUNT(b_no) as 'NoOfTimesBorrowed' FROM tbl_borrowlist GROUP BY b_no ORDER BY NoOfTimesBorrowed DESC LIMIT 10 ";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_borrow.SelectedIndex == 3)
            {
                //display the most active borrowing accounts
                sqlcommand.CommandText = "SELECT u_un as 'Account No.', COUNT(u_un) as 'NoOfTimesBorrowing' FROM tbl_borrowlist GROUP BY u_un ORDER BY NoOfTimesBorrowing DESC LIMIT 10 ";

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

        private void cmb_category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
