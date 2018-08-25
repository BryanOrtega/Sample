using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //borrow
            MySqlConnection sqlcon = new MySqlConnection("DATA SOURCE= 127.0.0.1; INITIAL CATALOG=it_2d; UID=root");
            MySqlCommand sqlcom = new MySqlCommand("SELECT * FROM tbl_borrow", sqlcon);
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet3 ds = new DataSet3();

            sqlcon.Open();
            sqlcom.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlcom;
            sqlDA.Fill(ds, "borrows");
            // dataGridView1.DataSource = ds;
            // dataGridView1.DataMember = "tbl_penalty";


            borroww cry = new borroww();
            cry.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cry;
            sqlcon.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //librarian
            MySqlConnection sqlcon = new MySqlConnection("DATA SOURCE= 127.0.0.1; INITIAL CATALOG=it_2d; UID=root");
            MySqlCommand sqlcom = new MySqlCommand("SELECT * FROM tbl_admin", sqlcon);
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet2 ds = new DataSet2();

            sqlcon.Open();
            sqlcom.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlcom;
            sqlDA.Fill(ds, "adminaccts");
            // dataGridView1.DataSource = ds;
            // dataGridView1.DataMember = "tbl_penalty";


            adminaccts cry = new adminaccts();
            cry.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cry;
            sqlcon.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //useraccts
            MySqlConnection sqlcon = new MySqlConnection("DATA SOURCE= 127.0.0.1; INITIAL CATALOG=it_2d; UID=root");
            MySqlCommand sqlcom = new MySqlCommand("SELECT * FROM tbl_user", sqlcon);
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet2 ds = new DataSet2();

            sqlcon.Open();
            sqlcom.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlcom;
            sqlDA.Fill(ds, "useracc");
            // dataGridView1.DataSource = ds;
            // dataGridView1.DataMember = "tbl_penalty";


            useracc cry = new useracc();
            cry.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cry;
            sqlcon.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //actlog
            MySqlConnection sqlcon = new MySqlConnection("DATA SOURCE= 127.0.0.1; INITIAL CATALOG=it_2d; UID=root");
            MySqlCommand sqlcom = new MySqlCommand("SELECT * FROM tbl_activitylog", sqlcon);
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet2 ds = new DataSet2();

            sqlcon.Open();
            sqlcom.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlcom;
            sqlDA.Fill(ds, "activitylog");
            // dataGridView1.DataSource = ds;
            // dataGridView1.DataMember = "tbl_penalty";


            activitylog cry = new activitylog();
            cry.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cry;
            sqlcon.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //itemlist
            MySqlConnection sqlcon = new MySqlConnection("DATA SOURCE= 127.0.0.1; INITIAL CATALOG=it_2d; UID=root");
            MySqlCommand sqlcom = new MySqlCommand("SELECT * FROM tbl_itemlist", sqlcon);
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet ds = new DataSet();

            sqlcon.Open();
            sqlcom.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlcom;
            sqlDA.Fill(ds, "itemlist");
            // dataGridView1.DataSource = ds;
            // dataGridView1.DataMember = "tbl_penalty";

            itemlist cry = new itemlist();
            cry.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cry;
            sqlcon.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //penalty
            MySqlConnection sqlcon = new MySqlConnection("DATA SOURCE= 127.0.0.1; INITIAL CATALOG=it_2d; UID=root");
            MySqlCommand sqlcom = new MySqlCommand("SELECT b_no,u_un,d_borrowed,fine FROM tbl_penalty where b_no != 'PENALTY' && fine != '0'", sqlcon);
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet2 ds = new DataSet2();

            sqlcon.Open();
            sqlcom.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlcom;
            sqlDA.Fill(ds, "penaltys");
            // dataGridView1.DataSource = ds;
            // dataGridView1.DataMember = "tbl_penalty";

            penaltys cry = new penaltys();
            cry.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cry;
            sqlcon.Close();
        }
    }
}
