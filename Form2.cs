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
    public partial class Form2 : Form
    {
    

  
        public Form2()
        {
            InitializeComponent();
      
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sqlconstring = "Data Source = LOCALHOST; Initial Catalog = it_2d; username = root; password = ''";
            MySqlConnection sqlconnect = new MySqlConnection(sqlconstring);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter();
            DataSet DS = new DataSet();
            sqlconnect.Open();
            MySqlCommand sqlcommand = new MySqlCommand();
            sqlcommand.CommandText = "DELETE FROM `tbl_itemlist` WHERE `b_no` = ('" + textBox1.Text + "') ";

            sqlcommand.CommandType = CommandType.Text;
            sqlcommand.Connection = sqlconnect;
            sqlcommand.ExecuteNonQuery();
            sqlDataAdapter.SelectCommand = sqlcommand;
            string id = textBox2.Text;
            Penaltymod frm2 = new Penaltymod();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
            sqlconnect.Close();
       

        }
        public string MyProperty { get; set; }
        public string MyProperty2 { get; set; }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            textBox1.Text=(this.MyProperty);
            textBox2.Text = (this.MyProperty2);
            MySqlConnection sqlcon = new MySqlConnection("DATA SOURCE= 127.0.0.1; INITIAL CATALOG=it_2d; UID=root; Convert Zero Datetime = True");
            MySqlCommand sqlcom = new MySqlCommand("SELECT * FROM tbl_receipt where u_un = '"+textBox1.Text+"'", sqlcon);
            MySqlDataAdapter sqlDA = new MySqlDataAdapter();
            DataSet2 ds = new DataSet2();

            sqlcon.Open();
            sqlcom.CommandType = CommandType.Text;
            sqlDA.SelectCommand = sqlcom;
            sqlDA.Fill(ds, "receipts");
            // dataGridView1.DataSource = ds;
            // dataGridView1.DataMember = "tbl_penalty";


            receiptss cry = new receiptss();
            cry.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cry;
            sqlcon.Close();
        }
    }
}
