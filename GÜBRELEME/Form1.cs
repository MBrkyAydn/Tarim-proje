using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GÜBRELEME
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <bağlantı>



        /// </bağlantı>

        OleDbConnection baglan = new OleDbConnection("provider=microsoft.ace.oledb.12.0; data source=bilgiler.accdb");
        string durum, tuz, ph, kirec, OM, fosfor, potasyum;

        double x1, x2, x3, x4, x5, x6, x7;

        private void timer2_Tick(object sender, EventArgs e)
        {
            ////hata uyarı ısıgı
            label10.Visible = !label10.Visible;
            label11.Visible = !label11.Visible;
            label12.Visible = !label12.Visible;
            label13.Visible = !label13.Visible;
            label14.Visible = !label14.Visible;
            label15.Visible = !label15.Visible;
            label16.Visible = !label16.Visible;

            ///hata düzeltme sonrası kod
            if (comboBox3.SelectedIndex >= 0) { label10.Visible = false; }
            if (comboBox4.SelectedIndex >= 0) { label11.Visible = false; }
            if (comboBox5.SelectedIndex >= 0) { label12.Visible = false; }
            if (comboBox6.SelectedIndex >= 0) { label13.Visible = false; }
            if (comboBox7.SelectedIndex >= 0) { label14.Visible = false; }
            if (comboBox8.SelectedIndex >= 0) { label15.Visible = false; }
            if (comboBox9.SelectedIndex >= 0) { label16.Visible = false; }
        }

        DialogResult msj;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void combof()
        {
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
            comboBox8.Enabled = false;
            comboBox9.Enabled = false;
            button1.Enabled = false;    
        }

    private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            { comboBox2.Enabled = false;
                 button1.Enabled = false;
            }
            else
            { comboBox2.Enabled = true; 
                
            }

            if (comboBox2.SelectedIndex == -1)
            {


                combof();

            }
            else
            {
                button1.Enabled = true;
                foreach (System.Windows.Forms.ComboBox ac in this.Controls.OfType<System.Windows.Forms.ComboBox>())
                {
                    ac.Enabled = true;
                    

                }
           
            
            }
            
             


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// Boş bırakma hata satırları////
            if (comboBox3.SelectedIndex == -1) { msj = MessageBox.Show("Lütfen Su ile Doymuşluk Yüzdesini Giriniz...", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error); timer2.Start(); label10.Text = "***"; label10.ForeColor = Color.Red;  }
           
            
            else
                if (comboBox4.SelectedIndex == -1) { msj = MessageBox.Show("Lütfen Toplam Tuz Yüzdesini Giriniz...", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error); timer2.Start(); label11.Text = "***"; label11.ForeColor = Color.Red; }
            else
                    if (comboBox5.SelectedIndex == -1) { msj = MessageBox.Show("Lütfen Ph (Doymuş Toprakta) Yüzdesini Giriniz...", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error); timer2.Start(); label12.Text = "***"; label12.ForeColor = Color.Red; }
            else
                        if (comboBox6.SelectedIndex == -1) { msj = MessageBox.Show("Lütfen Kireç (Caco3)  Yüzdesini Giriniz...", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error); timer2.Start(); label13.Text = "***"; label13.ForeColor = Color.Red; }
            else
                            if (comboBox7.SelectedIndex == -1) { msj = MessageBox.Show("Lütfen Organik Madde Yüzdesini Giriniz...", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error); timer2.Start(); label14.Text = "***"; label14.ForeColor = Color.Red; }
            else
                                if (comboBox8.SelectedIndex == -1) { msj = MessageBox.Show("Lütfen Fosfor (Kg/Da) Oranını Giriniz...", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error); timer2.Start(); label15.Text = "***"; label15.ForeColor = Color.Red; }
            else
                                    if (comboBox9.SelectedIndex == -1) { msj = MessageBox.Show("Lütfen Potasyum (Kg/Da) Oranını Giriniz...", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error); timer2.Start(); label16.Text = "***"; label16.ForeColor = Color.Red; }
            else
            { 
            /// HESaplama başlıyor   ////
            
            }



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {comboBox2.Items.Clear();   

            if (comboBox1.SelectedIndex == 0)
            {

                // ürünler combobox 
                baglan.Open();
                OleDbCommand combo1 = new OleDbCommand("select * from karadeniz_bolgesi", baglan);
                OleDbDataReader oku = combo1.ExecuteReader();
                while (oku.Read())
                {
                    comboBox2.Items.Add(oku["karadeniz_urunler"]);

                }

                baglan.Close();



            }
        }

       
        /// <summary>
        void guncelle()
        {
            string sql = "select * from sonuc";

            OleDbDataAdapter adaptor = new OleDbDataAdapter(sql, baglan);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();

        }
        /// </summary>
   
        private void Form1_Load(object sender, EventArgs e)

        {
            comboBox3.Items.Add("ksdfhfd");
            comboBox1.Sorted= true;
            comboBox1.Items.Add("Karadeniz Bölgesi");



        }
    }
}
