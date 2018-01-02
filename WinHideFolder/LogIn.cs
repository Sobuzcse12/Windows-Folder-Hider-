
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHideFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ForgetPassward fp = new ForgetPassward();
            fp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginText.Text == "123")
            {
                FolderHide fd = new FolderHide();
                fd.Show();
                
               
            }
            else
            {
                MessageBox.Show("Wrong Passward!!!!");
            }
        }

        private void mEnter(object sender, EventArgs e)
        {
            label1.ForeColor=System.Drawing.Color.Blue ;
          
        }

        private void mleave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.White;
        }
    }
}
