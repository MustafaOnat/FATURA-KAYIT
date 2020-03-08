using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp78
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    public static string gonderveri;
    public void button1_Click(object sender, EventArgs e)
    {
            gonderveri =(string) listBox1.SelectedItem;
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
    }
       
    }
 }

