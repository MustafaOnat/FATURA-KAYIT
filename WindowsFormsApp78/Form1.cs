using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp78
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<TextBox> tbl = new List<TextBox>();
        List<ComboBox> cbl = new List<ComboBox>();
        DataTable tablo = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            tablo.Columns.Add("CARİ ÜNVANI", typeof(string));
            tablo.Columns.Add("STOK NO", typeof(object));
            tablo.Columns.Add("STOK ADI", typeof(object));
            tablo.Columns.Add("BİRİM", typeof(string));
            tablo.Columns.Add("BİRİM FİYAT", typeof(int));
            tablo.Columns.Add("MİKTAR", typeof(int));
            tablo.Columns.Add("KDV ORANI", typeof(string));
            tablo.Columns.Add("SATIŞ İNDİRİMİ", typeof(int));
            tablo.Columns.Add("GENEL TOPLAM", typeof(double));
            dataGridView1.DataSource = tablo;
            textBox1.Text = Form2.gonderveri;
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                    tbl.Add((TextBox)item);
            }
            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                    cbl.Add((ComboBox)item);
            }
        }
        bool b = true;
        private void button1_Click(object sender, EventArgs e)
        {
            {
                b = true;
                foreach(ComboBox cb in cbl)
                {
                    if (cb.Text == "")
                        b = false;
                }
                foreach (TextBox tb in tbl)
                    if (tb.Text == "")
                        b = false;
                if (b == true)
                {
                    double gecici = Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox5.Text);
                    double sonuc = 0;
                    if (comboBox2.Text == "%1")
                    {
                        sonuc = gecici * 1.01;
                    }
                    else if (comboBox2.Text == "%8")
                    {
                        sonuc = gecici * 1.08;
                    }
                    else if (comboBox2.Text == "%18")
                    {
                        sonuc = gecici * 1.18;
                    }
                    else if (comboBox2.Text == "%0")
                    {
                        sonuc = gecici;
                    }
                    else if (comboBox2.Text != "%0" || comboBox2.Text != "%1" || comboBox2.Text != "%8" || comboBox2.Text != "%18")
                    {
                        MessageBox.Show("Lütfen Geçerli Bir KDV Oranı Giriniz");
                        comboBox2.ResetText();
                    }
                   
                    sonuc -= Convert.ToDouble(textBox6.Text);
                    tablo.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem, textBox4.Text, textBox5.Text, comboBox2.SelectedItem, textBox6.Text, sonuc);
                    dataGridView1.DataSource = tablo;
                }
                else
                {
                    MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                }
            }
               
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Lüffen silinecek satırı seçin.");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Visible = false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
   }

