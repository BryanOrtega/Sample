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

namespace Library
{
    public partial class About : MetroForm
    {
        public About()
        {
            InitializeComponent();
  
        }
        public string MyProperty { get; set; }
        private void About_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            txt_id.Text = (this.MyProperty);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text;
            admin_form frm2 = new admin_form();
            frm2.MyProperty = id;
            frm2.Show();
            this.Hide();
          
        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }
    }
}
