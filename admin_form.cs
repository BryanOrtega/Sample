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
    public partial class admin_form : MetroForm
    {
        public admin_form()
        {
            InitializeComponent();
     
        }
        public string MyProperty { get; set; }
        private void admin_form_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            txt_id.Text=(this.MyProperty);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            //returnning to login
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

        private void btn_registermod_Click(object sender, EventArgs e)
        {

           
        }

        private void btn_listmod_Click(object sender, EventArgs e)
        {
        
        }

        private void btn_borrowmod_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            //opening registration module

            string id = txt_id.Text;
            Registration frm2 = new Registration();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void btn_summod_Click(object sender, EventArgs e)
        {

        }

        private void btn_penaltymod_Click(object sender, EventArgs e)
        {

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            //opening borrow module
            string id = txt_id.Text;
            borrow frm2 = new borrow();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void btn_returnmod_Click(object sender, EventArgs e)
        {

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            //opening itemlist module
            string id = txt_id.Text;
            Itemlist frm2 = new Itemlist();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            //opening return module

            string id = txt_id.Text;
          returned frm2 = new returned();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            //opening actvitiy log module

            string id = txt_id.Text;
           Activitylog frm2 = new Activitylog();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            //opening new and old items module

            string id = txt_id.Text;
            newolditems frm2 = new newolditems();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            //opening about us module

            string id = txt_id.Text;
          About frm2 = new About();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            //opening penalty module
            string id = txt_id.Text;
            Penaltymod frm2 = new Penaltymod();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
        }
    }
}
