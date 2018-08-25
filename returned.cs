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
    public partial class returned : MetroForm
    {
        public returned()
        {
            InitializeComponent();
            
        }
        public string MyProperty { get; set; }
        private void returned_Load(object sender, EventArgs e)
        {
            txt_id.Text = (this.MyProperty);
            this.ControlBox = false;
            //loading datagridview from tbl_borrow , data of all borrowers
            txt_id.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_title` as 'Title', `b_author` as 'Author', `u_un` as 'Account No.', `d_borrowed` as 'Date Borrowed' FROM `tbl_borrow` WHERE 1  ";

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
            //return to admin form
            string id = txt_id.Text;
            admin_form frm2 = new admin_form();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //transferring the data to textboxes
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txt_borrowed.Text = row.Cells[4].Value.ToString();
                txt_num.Text = row.Cells[3].Value.ToString();
                txt_bnum.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btn_borrow_Click(object sender, EventArgs e)
        {
            //button for borrowing
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            //check if the user already borrowed an item that needed to be returned
            MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_borrow WHERE (`b_no` = '" + txt_bnum.Text + "') ", sqlconnect);
            if (txt_bnum.Text == "" || txt_id.Text == "" || txt_num.Text == "")
            {
                MessageBox.Show("Incomplete Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (check_User_Name.ExecuteScalar() != null)
                {
                    string UserExist = check_User_Name.ExecuteScalar().ToString();

                    if (UserExist != null)
                    {

                        DateTime time = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss";
                        var mytime = time.ToString(format);
                        MySqlCommand sqlcommand = new MySqlCommand();
                        //update the copies deduction
                        sqlcommand.CommandText = "UPDATE `tbl_itemlist` SET `b_copies` = `b_copies` + 1 where `b_no` = '" + txt_bnum.Text + "'";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        //update tbl_penalty for record
                        sqlcommand.CommandText = "update tbl_penalty set d_returned='" + this.dtp_returned.Text + "' where b_no='" + txt_bnum.Text + "'AND `u_un` = '" + txt_num.Text + "';";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        //insert the transaction to return
                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_return` (`b_no`, `u_un`,`d_returned`) VALUES ('" + txt_bnum.Text + "' ,'" + txt_num.Text + "','" + this.dtp_returned.Text + "');";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        //delete the user account
                        sqlcommand.CommandText = "DELETE FROM `tbl_borrow` WHERE `u_un` = ('" + txt_num.Text + "') ";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        //display and refresh the datagridview
                        sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_title` as 'Title', `b_author` as 'Author', `u_un` as 'Account No.', `d_borrowed` as 'Date Borrowed' FROM `tbl_borrow` WHERE 1 ";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        sqlDataAdapter.Fill(DS, "KAIBIGAN");
                        dataGridView1.DataSource = DS;
                        dataGridView1.DataMember = "KAIBIGAN";
                        //insert the transaction to activitylog
                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Return Item','" + txt_num.Text + "','" + mytime + "');";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;

                        MessageBox.Show("Item Returned", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txt_num.Clear();
                        txt_bnum.Clear();
                        txt_borrowed.Clear();


                    }

                    else
                    {
                        //accession no. doesnt exist
                        MessageBox.Show("Invalid accession no.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //searching account number
            //checking if account number existing
            if (txt_saccno.Text == "")
            {
                MessageBox.Show("Incomplete field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //display accounts
                String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
                MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                DataSet DS = new DataSet();
                sqlconnect.Open();
                MySqlCommand sqlcommand = new MySqlCommand();
                //checking if the user account actually borrowed


                //display data from tbl_borrow
                sqlcommand.CommandText = "SELECT ``b_no` as 'Accession No.', `b_title` as 'Title', `b_author` as 'Author', `u_un` as 'Account No.', `d_borrowed` as 'Date Borrowed' FROM `tbl_borrow` WHERE `b_no` = '" + txt_saccno.Text + "'";

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

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
