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
    public partial class Penaltymod : MetroForm
    {
        public Penaltymod()
        {
            InitializeComponent();
       
        }

        private void Penaltymod_Load(object sender, EventArgs e)
        {
            txt_id.Text = (this.MyProperty);
            this.ControlBox = false;
            LOAD();
            PENALTY();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            admin_form frm2 = new admin_form();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();

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
                    LOAD();
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

                    LOAD();


                    //textBox1.Text = "" + days;
                }
                LOAD();

            }



            txt_day.Text = day;
            txt_week.Text = week;
            sqlConnect.Close();














        }
        public void LOAD()
        {
            //load and display data from mysql to database
            this.WindowState = FormWindowState.Maximized;
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT   tbl_itemlist.b_no as 'Accession No.',tbl_itemlist.b_title as 'Title' ,tbl_penalty.u_un as 'Account No.', tbl_penalty.d_borrowed as 'Date Borrowed', tbl_penalty.fine as 'Fine'  FROM tbl_penalty INNER JOIN tbl_itemlist ON tbl_penalty.b_no = tbl_itemlist.b_no Where fine != 0";

            //sqlcommand.CommandText = "SELECT   b_no as 'Accession No.', u_un as 'Account No.',d_borrowed as 'Date Borrowed', fine as 'Fine'  FROM tbl_penalty where fine != '0'";
            //sqlcommand.CommandText =" Select tbl_a.b_no, tbl_b.b_no, tbl_b.b_title From tbl_penalty tbl_a     join tbl_itemlist tbl_b    on tbl_a.b_no = tbl_b.b_no";
            //sqlcommand.CommandText = "SELECT s.u_un,s.d_borrowed, h.b_title FROM tbl_penalty s LEFT JOIN tbl_borrowlist h ON s.b_no = h.b_no";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "penalty");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "penalty";



            sqlconnect.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //click cell will display on textbox
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                String date = row.Cells[2].Value.ToString();
                DateTime a = Convert.ToDateTime(date);
                textBox1.Text = row.Cells[0].Value.ToString();
                
                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = a.ToString("yyyy/MM/dd");
                textBox5.Text = row.Cells[4].Value.ToString();
                //txt_bnum.Text = row.Cells[0].Value.ToString();
            }
        }
        public void PAID()
        {
           
                //paid user and delete row
                String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
                MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
                DataSet DS = new DataSet();
                sqlconnect.Open();

                MySqlCommand sqlcommand = new MySqlCommand();


                sqlcommand.CommandText = "DELETE FROM tbl_penalty WHERE d_borrowed ='" + textBox4.Text + "' AND  b_no ='" + textBox1.Text + "' AND u_un ='" + textBox3.Text + "' AND fine = '" + textBox5.Text + "'";
                sqlcommand.CommandType = CommandType.Text;
                sqlcommand.Connection = sqlconnect;
                sqlcommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlcommand;

                sqlconnect.Close();
               
            

        }
        public void RECORD() {

            //save logs
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var mytime = time.ToString(format);
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();

            MySqlCommand sqlcommand = new MySqlCommand();
            sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_activitylog` (`librarian_id`, `activity`,`account_no`,`date_activity`) VALUES ('" + txt_id.Text + "' ,' Paid Fine','" + textBox3.Text + "','" + mytime + "');";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlconnect.Close();


        }
        public void RECEIPT()
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            var mytime = time.ToString(format);
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();

            MySqlCommand sqlcommand = new MySqlCommand();
            sqlcommand.CommandText = "INSERT INTO `it_2d`.`tbl_receipt` (`u_un`, `b_no`,`d_receipt`,`librarian_id`,`fine`,`cash`,`fchange`) VALUES ('" + textBox3.Text + "','" + textBox1.Text + "' ,'" + mytime + "','" + txt_id.Text + "','" + textBox5.Text + "','" + metroTextBox1.Text + "','" + metroTextBox2.Text +"');";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlconnect.Close();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Invalid Account No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (metroTextBox1.Text == "")
                {
                    MessageBox.Show("Invalid Cash", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else {
                    double cash = Convert.ToDouble(metroTextBox1.Text);
                    double change; //Convert.ToDouble(metroTextBox2.Text);
                    double fine = Convert.ToDouble(textBox5.Text);

                    change = cash - fine;
                    if (change < 0)
                    {
                        MessageBox.Show("Insufficient cash", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);  
                    }
                    else {
                        MessageBox.Show("You have a change " + change, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        metroTextBox2.Text = change.ToString();
                        PAID();
                        LOAD();
                        RECORD();
                        RECEIPT();
                        MessageBox.Show("Penalty Paid", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        string uun = textBox3.Text;
                        string id = txt_id.Text;
                        Form2 frm2 = new Form2();
                        frm2.MyProperty = uun;
                        frm2.MyProperty2 = id;
                        frm2.Show();
                        this.Hide();
                       
                        
                        metroTextBox1.Clear();
                 
                    }
                }
            }
        }
         public string MyProperty { get; set; }
        public string MyProperty2 { get; set; }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //click cell and display selected on textbox
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                String date = row.Cells[3].Value.ToString();
                DateTime a = Convert.ToDateTime(date);
                textBox1.Text = row.Cells[0].Value.ToString();
                
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = a.ToString("yyyy/MM/dd");
                textBox5.Text = row.Cells[4].Value.ToString();
                //txt_bnum.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            //search user account number and display to textbox
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlCommand sqlcommand = new MySqlCommand();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            sqlcommand.CommandText = "SELECT   tbl_itemlist.b_no as 'Accession No.',tbl_itemlist.b_title as 'Title' ,tbl_penalty.u_un as 'Account No.', tbl_penalty.d_borrowed as 'Date Borrowed', tbl_penalty.d_returned as 'Date Returned', tbl_penalty.fine as 'Fine'  FROM tbl_penalty INNER JOIN tbl_itemlist ON tbl_penalty.b_no = tbl_itemlist.b_no Where tbl_penalty.u_un = '"+txt_num.Text +"'";
            //sqlcommand.CommandText =" Select tbl_a.b_no, tbl_b.b_no, tbl_b.b_title From tbl_penalty tbl_a     join tbl_itemlist tbl_b    on tbl_a.b_no = tbl_b.b_no";
            //sqlcommand.CommandText = "SELECT s.u_un,s.d_borrowed, h.b_title FROM tbl_penalty s LEFT JOIN tbl_borrowlist h ON s.b_no = h.b_no";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.Fill(DS, "penalty");
            dataGridView1.DataSource = DS;
            dataGridView1.DataMember = "penalty";



            sqlconnect.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            LOAD();
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_week_Click(object sender, EventArgs e)
        {

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = '';Convert Zero Datetime=True";

            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();

            MySqlCommand sqlcommand = new MySqlCommand();
            sqlcommand.CommandText = "UPDATE tbl_penalty SET fineday='" + txt_day.Text + "' , fineweek= '" + txt_week.Text + " '  WHERE b_no ='PENALTY'";
            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;

            PENALTY();
            LOAD();
        }

        private void metroLabel8_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }
    }
        }
