using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Yolcu_Bilet_Rezervasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string constring = "Data Source = LENOVO; Initial Catalog = YolcuBilet; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLSEFERBILGI", connect);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
         seferlistesi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "1";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "2";
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
            
        } 

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try 
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit= "insert into TBLYOLCUBILGI (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values(@AD,@SOYAD,@TELEFON,@TC,@CINSIYET,@MAIL)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@AD", TxtAd.Text);
                komut.Parameters.AddWithValue("@SOYAD", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@TELEFON", MskTelefon.Text);
                komut.Parameters.AddWithValue("@TC", MskTC.Text);
                komut.Parameters.AddWithValue("@CINSIYET", CmbCinsiyet.Text);
                komut.Parameters.AddWithValue("@MAIL", MskMail.Text);

                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Yolcu Bilgisi Sisteme Kaydedildi.");
            }
            catch(Exception hata) 
            {
                MessageBox.Show("Hata Meydana Geldi." + hata.Message);
            }
        } 
        
        private void BtnKaptan_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into TBLKAPTAN (KAPTANNO,ADSOYAD,TELEFON) values(@KAPTANNO,@ADSOYAD,@TELEFON)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@KAPTANNO", TxtKaptanNo.Text);
                komut.Parameters.AddWithValue("@ADSOYAD", TxtKaptanAd.Text);
                komut.Parameters.AddWithValue("@TELEFON", MskKaptanTelefon.Text);

                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Kaptan Bilgisi Sisteme Kaydedildi.");
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi." + hata.Message);
            }
        }

        private void BtnSeferOluştur_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into TBLSEFERBILGI (SEFERNO,KALKIS,VARIS,TARIH,SAAT,KAPTAN,FIYAT) values(@SEFERNO,@KALKIS,@VARIS,@TARIH,@SAAT,@KAPTAN,@FIYAT)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@SEFERNO", TxtSeferNo.Text);
                komut.Parameters.AddWithValue("@KALKIS", TxtKalkis.Text);
                komut.Parameters.AddWithValue("@VARIS", TxtVaris.Text);
                komut.Parameters.AddWithValue("@TARIH", MskTarih.Text);
                komut.Parameters.AddWithValue("@SAAT", MskSaat.Text);
                komut.Parameters.AddWithValue("@KAPTAN", MskKaptan.Text);
                komut.Parameters.AddWithValue("@FIYAT", TxtFiyat.Text);

                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi.");
                seferlistesi();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi." + hata.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtSeferNumara.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "3";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "4";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "5";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "6";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "7";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "8";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "9";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "10";
        }

        private void BtnRezervasyon_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = "insert into TBLSEFERDETAY (SEFERNO,YOLCUTC,KOLTUK) values(@SEFERNO,@YOLCUTC,@KOLTUK)";
                SqlCommand komut = new SqlCommand(kayit, connect);

                komut.Parameters.AddWithValue("@SEFERNO", TxtSeferNumara.Text);
                komut.Parameters.AddWithValue("@YOLCUTC", MskYolcuTC.Text);
                komut.Parameters.AddWithValue("@KOLTUK", TxtKoltukNo.Text);

                komut.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Rezervasyon İşleminiz Yapıldı.");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Meydana Geldi." + hata.Message);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Btn11_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "12";
        }

        private void Btn12_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "12";
        }

        private void Btn13_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "13";
        }

        private void Btn14_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "14";
        }

        private void Btn15_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "15";
        }

        private void Btn16_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "16";
        }

        private void Btn17_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "17";
        }

        private void Btn18_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "18";
        }

        private void Btn19_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "19";
        }

        private void Btn20_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "20";
        }

        private void Btn21_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "21";
        }

        private void Btn22_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "22";
        }

        private void Btn23_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "23";
        }
    }
}
