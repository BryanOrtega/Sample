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
using MetroFramework;
using System.Text.RegularExpressions;

namespace Library
{
    public partial class Itemlist :MetroForm
    {
        public Itemlist()
        {
            InitializeComponent();
  
        }
        public string MyProperty { get; set; }
        private void Itemlistcs_Load(object sender, EventArgs e)
        {
            txt_id.Text = (this.MyProperty);
            this.ControlBox = false;
            //loading the datagridview 
            txt_id.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
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
            sqlcommand.CommandText = "SELECT `u_un` as `Account No.`, `b_title` as Title, `b_medium` as `Medium`, `d_requested` as `Date Requested` FROM `tbl_request` WHERE 1";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "req");
            dataGridView2.DataSource = DS;
            dataGridView2.DataMember = "req";
            sqlconnect.Close();


            cmb_category.SelectedIndex = 0;
            cmb_search.SelectedIndex = 0;
            cmb_scategory.SelectedIndex = 0;
            cmb_medium.SelectedIndex = 0;
            cmb_smedium.SelectedIndex = 0;

        }

        private void btn_total_Click(object sender, EventArgs e)
        {
        //total no of accounts available
            MySqlConnection sqlconnect = new MySqlConnection("Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''");
            MySqlCommand sqlcommand = sqlconnect.CreateCommand();
            sqlcommand.CommandText = "select count(*) as myCount from tbl_itemlist ";
            sqlconnect.Open();

            long returnValue = (long)sqlcommand.ExecuteScalar();
            txt_total.Text = returnValue + " total number of titles".ToString();
        }

        private void cmb_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            //visible or not the objects
            if (cmb_search.SelectedIndex == 0)
            {
                cmb_smedium.Visible = false;
                txt_stitle.Visible = false;
                cmb_scategory.Visible = false;
                txt_saccno.Visible = true;
            }
            else if (cmb_search.SelectedIndex == 1)
            {
                txt_stitle.Visible = true;
                cmb_smedium.Visible = false;
                cmb_scategory.Visible = false;
                txt_saccno.Visible = false;
            }
            else if (cmb_search.SelectedIndex == 2)
            {
                txt_stitle.Visible = false;
                cmb_smedium.Visible = true;
                cmb_scategory.Visible = false;
                txt_saccno.Visible = false;
            }
            else if (cmb_search.SelectedIndex == 3)
            {
                cmb_smedium.Visible = false;
                cmb_scategory.Visible = true;
                txt_saccno.Visible = false;
                txt_stitle.Visible = false;
            }
            else if (cmb_search.SelectedIndex == 4)
            {
                cmb_smedium.Visible = false;
                cmb_scategory.Visible = false;
                txt_saccno.Visible = false;
                txt_stitle.Visible = false;
            }
            else if (cmb_search.SelectedIndex == 5)
            {
                cmb_smedium.Visible = false;
                cmb_scategory.Visible = false;
                txt_saccno.Visible = false;
                txt_stitle.Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //transferring data from datagridview to textboxes
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txt_accid.Text = row.Cells[0].Value.ToString();
                cmb_medium.Text = row.Cells[1].Value.ToString();
                txt_title.Text = row.Cells[2].Value.ToString();
                txt_author.Text = row.Cells[3].Value.ToString();
                txt_copies.Text = row.Cells[5].Value.ToString();
                cmb_category.Text = row.Cells[4].Value.ToString();
                dtp_copyright.Text = row.Cells[6].Value.ToString();
                dtp_dadded.Text = row.Cells[7].Value.ToString();
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            //refreshing the datagrid view 
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` ";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //searching either accession no, title , oldest , latest
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            if (cmb_search.SelectedIndex == 0)
            {
                //searching by accession no.
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE b_no like('" + txt_saccno.Text + "') ";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_search.SelectedIndex == 1)
            {
                //searching by title
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE b_title like '%" + txt_stitle.Text + "%'";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_search.SelectedIndex == 2)
            {
                //searching by medium
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE b_medium like('" + cmb_smedium.Text + "') ";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_search.SelectedIndex == 3)
            {
                //searching by categories
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` WHERE b_category like('" + cmb_scategory.Text + "') ";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_search.SelectedIndex == 4)
            {
                //searching from oldest to latest
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` order by b_dateadd ";

                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;
                sqlDataAdapter.Fill(DS, "KAIBIGAN");
                dataGridView1.DataSource = DS;
                dataGridView1.DataMember = "KAIBIGAN";
                sqlconnect.Close();
            }
            else if (cmb_search.SelectedIndex == 5)
            {
                //searching from latest to oldest
                sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` order by b_dateadd desc";

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

        private void btn_add_Click(object sender, EventArgs e)
        {
            //inserting items
            try
            {
                // check if the textboxes are filled
                if (txt_accid.Text == "" || txt_title.Text == "" || txt_author.Text == "" || txt_copies.Text == "")
                {
                    MessageBox.Show("Incomplete Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    if (txt_copies.Text == "0" || txt_copies.Text == "00" || txt_copies.Text == "000" || txt_copies.Text == "000")
                    {
                        MessageBox.Show("Please input atleast 1 copy","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (!txt_accid.Text.Any(Char.IsLetter) || !txt_accid.Text.Any(Char.IsDigit) || txt_accid.Text.Any(Char.IsSymbol))
                        {
                            MessageBox.Show("Invalid Accession No." ,"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else { 
                        //textboxes are filled
                        DateTime time = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss";
                        var mytime = time.ToString(format);
                        String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
                        MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
                        MySqlCommand sqlcommand = new MySqlCommand();
                        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                        DataSet DS = new DataSet();
                        sqlconnect.Open();

                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_itemlist` (`b_no`, `b_medium`,`b_title`,`b_author`,`b_category`,`b_copies`,`b_copyright`,`b_dateadd`) VALUES ('" + txt_accid.Text + "' ,'" + cmb_medium.Text + "','" + txt_title.Text + "','" + txt_author.Text + "','" + cmb_category.Text + "','" + txt_copies.Text + "','" + this.dtp_copyright.Text + "','" + this.dtp_dadded.Text + "');";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;

                        sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Insert new item','" + txt_accid.Text + "','" + mytime + "');";
                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;

                        sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` ";

                        sqlcommand.CommandType = CommandType.Text;
                        sqlcommand.Connection = sqlconnect;
                        sqlcommand.ExecuteNonQuery();
                        sqlDataAdapter.SelectCommand = sqlcommand;
                        sqlDataAdapter.Fill(DS, "KAIBIGAN");
                        dataGridView1.DataSource = DS;
                        dataGridView1.DataMember = "KAIBIGAN";
                        sqlconnect.Close();
                        MessageBox.Show("Item Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_accid.Clear();
                        txt_title.Clear();
                        txt_author.Clear();
                        txt_copies.Clear();
                        txt_total.Clear();
                        txt_stitle.Clear();
                        txt_saccno.Clear();
                        cmb_search.SelectedIndex = 0;
                        cmb_category.SelectedIndex = 0;
                        cmb_medium.SelectedIndex = 0;
                        cmb_smedium.SelectedIndex = 0;
                        cmb_scategory.SelectedIndex = 0;
                   } }
                }
            }
            catch (MySqlException er)
            {
                MessageBox.Show(er.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            //editing item data
            //checking if textboxes are filled
            if (txt_accid.Text == "" || txt_title.Text == "" || txt_author.Text == "" || txt_copies.Text == "")
            {
                MessageBox.Show("Incomplete Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else

            {
                if (txt_copies.Text == "0" || txt_copies.Text == "00" || txt_copies.Text == "000" || txt_copies.Text == "000")
                {
                    MessageBox.Show("Please input atleast 1 copy", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    //editing are valid
                    DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss";
                var mytime = time.ToString(format);
                String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
                MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
                MySqlCommand sqlcommand = new MySqlCommand();
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                DataSet DS = new DataSet();
                sqlconnect.Open();
                //checking if the accession no already exist
                MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_itemlist WHERE (`b_no` = '" + txt_accid.Text + "') ", sqlconnect);

                    if (check_User_Name.ExecuteScalar() != null)
                    {
                        string UserExist = check_User_Name.ExecuteScalar().ToString();

                        if (UserExist != null)
                        {



                            sqlcommand.CommandText = "update tbl_itemlist set b_medium ='" + cmb_medium.Text + "',b_title ='" + txt_title.Text + "',b_author='" + txt_author.Text + "',b_category='" + cmb_category.Text + "',b_copies='" + txt_copies.Text + "' ,b_copyright='" + this.dtp_copyright.Text + "',b_dateadd='" + this.dtp_dadded.Text + "'where b_no ='" + txt_accid.Text + "';";
                            sqlcommand.CommandType = CommandType.Text;
                            sqlcommand.Connection = sqlconnect;
                            sqlcommand.ExecuteNonQuery();
                            sqlDataAdapter.SelectCommand = sqlcommand;
                            sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Edit item','" + txt_accid.Text + "','" + mytime + "');";
                            sqlcommand.CommandType = CommandType.Text;
                            sqlcommand.Connection = sqlconnect;
                            sqlcommand.ExecuteNonQuery();
                            sqlDataAdapter.SelectCommand = sqlcommand;
                            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` ";

                            sqlcommand.CommandType = CommandType.Text;
                            sqlcommand.Connection = sqlconnect;
                            sqlcommand.ExecuteNonQuery();
                            sqlDataAdapter.SelectCommand = sqlcommand;
                            sqlDataAdapter.Fill(DS, "KAIBIGAN");
                            dataGridView1.DataSource = DS;
                            dataGridView1.DataMember = "KAIBIGAN";
                            sqlconnect.Close();
                            MessageBox.Show("Item Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txt_accid.Clear();
                            txt_title.Clear();
                            txt_author.Clear();
                            txt_copies.Clear();
                            txt_total.Clear();
                            txt_stitle.Clear();
                            txt_saccno.Clear();
                            cmb_search.SelectedIndex = 0;
                            cmb_category.SelectedIndex = 0;
                            cmb_medium.SelectedIndex = 0;
                            cmb_smedium.SelectedIndex = 0;
                            cmb_scategory.SelectedIndex = 0;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Invalid Accession No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //deleting items
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var mytime = time.ToString(format);
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            //checking if the accession no inputted is existing
            MySqlCommand check_User_Name = new MySqlCommand("SELECT * FROM tbl_itemlist WHERE (`b_no` = '" + txt_accid.Text + "') ", sqlconnect);
            if (check_User_Name.ExecuteScalar() != null)
            {
                string UserExist = check_User_Name.ExecuteScalar().ToString();

                if (UserExist != null)
                {


                    //delete the item
                    sqlcommand.CommandText = "DELETE FROM `tbl_itemlist` WHERE `b_no` = ('" + txt_accid.Text + "') ";

                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;
                    sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Delete item','" + txt_accid.Text + "','" + mytime + "');";
                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;
                    sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` ";

                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;
                    sqlDataAdapter.Fill(DS, "KAIBIGAN");
                    dataGridView1.DataSource = DS;
                    dataGridView1.DataMember = "KAIBIGAN";
                    sqlconnect.Close();

                    MessageBox.Show("Item Removed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_accid.Clear();
                    txt_title.Clear();
                    txt_author.Clear();
                    txt_copies.Clear();
                    txt_total.Clear();
                    txt_stitle.Clear();
                    txt_saccno.Clear();
                    cmb_search.SelectedIndex = 0;
                    cmb_category.SelectedIndex = 0;
                    cmb_medium.SelectedIndex = 0;
                    cmb_smedium.SelectedIndex = 0;
                    cmb_scategory.SelectedIndex = 0;
                ;

            

                }

            }
            else
            {
                MessageBox.Show("Invalid Accession No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT `b_no` as 'Accession No.', `b_medium` as 'Medium', `b_title` as 'Title', `b_author` as 'Author', `b_category` as 'Category', `b_copies` as 'Copies', `b_copyright` as 'Copyright', `b_dateadd` as 'Date Added' FROM `tbl_itemlist` ";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "KAIBIGAN");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "KAIBIGAN";
            sqlconnect.Close();
            //clearing textboxes
            txt_accid.Clear();
            txt_title.Clear();
            txt_author.Clear();
            txt_copies.Clear();
            txt_total.Clear();
            txt_stitle.Clear();
            txt_saccno.Clear();
            cmb_search.SelectedIndex = 0;
            cmb_category.SelectedIndex = 0;
            cmb_medium.SelectedIndex = 0;
            cmb_smedium.SelectedIndex = 0;
            cmb_scategory.SelectedIndex = 0;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            //returning to admin form
            string id = txt_id.Text;
            admin_form frm2 = new admin_form();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void txt_accid_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txt_copies_KeyPress(object sender, KeyPressEventArgs e)
        {
            //limit textbox to numbers only
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void txt_accid_Click(object sender, EventArgs e)
        {

        }

        private void btn_rclear_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var mytime = time.ToString(format);
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
         
                    //delete the item
                    sqlcommand.CommandText = "DELETE FROM `tbl_request` WHERE 1";

                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;
                    sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,'Clear request list','" + txt_id.Text + "','" + mytime + "');";
                    sqlcommand.CommandType = CommandType.Text;
                    sqlcommand.Connection = sqlconnect;
                    sqlcommand.ExecuteNonQuery();
                    sqlDataAdapter.SelectCommand = sqlcommand;
            sqlcommand.CommandText = "SELECT `u_un` as `Account No.`, `b_title` as Title, `b_medium` as `Medium`, `d_requested` as `Date Requested` FROM `tbl_request` WHERE 1";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "req");
            dataGridView2.DataSource = DS;
            dataGridView2.DataMember = "req";
            sqlconnect.Close();

                    MessageBox.Show("Request List cleared", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                


                

            
        }

        private void cmb_medium_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }
    }
}
