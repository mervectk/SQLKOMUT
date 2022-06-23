using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//kütüphane ekle

namespace SQLKOMUT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //global alana baglantı adresini tanımladık
        SqlConnection baglantim = new SqlConnection("Data Source=DESKTOP-U3C0E9Q;Initial Catalog=Kitaplik;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dk = new SqlDataAdapter("select * from Kitap", baglantim);
            //sqldatadapter dataset ile sql arasında köprüyü sağlar.
            DataSet ds = new DataSet();
            dk.Fill(ds,"Kitap");
            //dk.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0]; ile de çalışır!!
          

            dataGridView1.DataSource = ds.Tables["Kitap"];

            //tables[0]--ilk tablom
            //tables[1]--2.tablo olur
            //her click de datagridview kitap table ile dolduruyoruz

            //dataGridView1.DataSource = null;ise her click de grid içini temizliyor

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand kayitekle = new SqlCommand("insert into Kitap(KitapNo,KitapAd,KitapYazar,KitapSayfa,KitapFiyat,KitapTarih,KitapYayinEvi,Vergi) " +
                "values(@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8)",baglantim);
            /*
             * txtbox veri cekme yöntemi 2 tanedir
             * a.txtboxt1.text
             * b.parametre ile --biz @parametre ile karışıklığı onledik
              */
            kayitekle.Parameters.AddWithValue("@k1", textBox1.Text);
            kayitekle.Parameters.AddWithValue("@k2", textBox2.Text);
            kayitekle.Parameters.AddWithValue("@k3", textBox3.Text);
            kayitekle.Parameters.AddWithValue("@k4", textBox4.Text);
            kayitekle.Parameters.AddWithValue("@k5", textBox5.Text);
            kayitekle.Parameters.AddWithValue("@k6", textBox6.Text);
            kayitekle.Parameters.AddWithValue("@k7", textBox7.Text);
            kayitekle.Parameters.AddWithValue("@k8", textBox8.Text);

            kayitekle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Eklendi");
            baglantim.Close();
                //executenonquery--parametre uzerinde değişiklik için kullanılır.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand kayitsil = new SqlCommand("delete from Kitap where KitapAd=@ad", baglantim);
            kayitsil.Parameters.AddWithValue("@ad",textBox2.Text);
            //textbox2 girilen kitap adını silecek
            kayitsil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
            baglantim.Close();
            //SqlConnection ,open baglanti açar, bazı özelliklerini görüntüler.
            //Bağlantı, bloğun sonunda otomatik olarak kapatılır (close)

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DATAGRIEDVIEW EVENTS-CELLCLICK ÇİFT TIKLA!!
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            //secilen satırı hafızaya aldı!!
            string kitapno = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            string kitapad = dataGridView1.Rows[secim].Cells[1].Value.ToString();

            string kitapyazar = dataGridView1.Rows[secim].Cells[2].Value.ToString();

            
            string kitapsayfa = dataGridView1.Rows[secim].Cells[3].Value.ToString();

            string kitapfiyat = dataGridView1.Rows[secim].Cells[4].Value.ToString();

            string kitaptarih = dataGridView1.Rows[secim].Cells[5].Value.ToString();

            string kitapyayinevi = dataGridView1.Rows[secim].Cells[6].Value.ToString();

            string vergi = dataGridView1.Rows[secim].Cells[7].Value.ToString();
            //hafızaya sırayla her sütunu yazdık yani indeksleri yazdık!!
            textBox1.Text = kitapno;
            textBox2.Text = kitapad;
            textBox3.Text = kitapyazar;
            textBox4.Text = kitapsayfa;
            textBox5.Text = kitapfiyat;
            textBox6.Text = kitaptarih;
            textBox7.Text = kitapyayinevi;
            textBox8.Text = vergi;






        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand kayitgüncelleme = new SqlCommand("update Kitap set KitapNo=@m1,KitapAd=@m2,KitapYazar=@m3,KitapSayfa=@m4," +
                "KitapFiyat=@m5,KitapTarih=@m6,KitapYayinEvi=@m7,Vergi=@m8 where KitapNo=@m1",baglantim);
            kayitgüncelleme.Parameters.AddWithValue("@m1", textBox1.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m2", textBox2.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m3", textBox3.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m4", textBox4.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m5", textBox5.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m6", textBox6.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m7", textBox7.Text);
            kayitgüncelleme.Parameters.AddWithValue("@m8", textBox8.Text);

            kayitgüncelleme.ExecuteNonQuery();
            MessageBox.Show("Güncelleme Gerçekleşti");
            baglantim.Close();
            //sql ya select çek ya da edit bölümünden execute sql de değişimi göster!!
            //sql fiyatı smallmoney int veri tipi yap yoksa exception fırlatıyor!!
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //baglantim.Open();
            ////dataadapter kullanırsan baglantı açıp kapadığı için open-close yapmaya gerek yok!!
            SqlDataAdapter db = new SqlDataAdapter("select * from Kitap where KitapAd ='" + textBox9.Text + "'", baglantim);
            DataSet ds = new DataSet();
            db.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            textBox9.Clear();


            //sql ' ' arasına veri girdiğimiz için tek tırnak kullanıldı
            //c# da "" arasına veri yazdığımız için kullanıldı
            //direk textbox yazılamaz.Syntax hatası olur!!


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand hesapla = new SqlCommand("SELECT MAX(KitapFiyat) from Kitap",baglantim);
            SqlDataReader okuma = hesapla.ExecuteReader();
            while(okuma.Read())
            {
                label11.Text = okuma[0].ToString();
                //0.indeks =max fiyat baska bir okuma işlemi yok!!
            }
            baglantim.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
           //aynı değişken adı versen de komutlar çalışır!
            baglantim.Open();
            SqlCommand hesapla1 = new SqlCommand("select count(KitapNo) from Kitap", baglantim);
            SqlDataReader okuma1 = hesapla1.ExecuteReader();
            while (okuma1.Read())
            {
                label13.Text = okuma1[0].ToString();
                //0.indeks =max fiyat baska bir okuma işlemi yok!!
            }
            baglantim.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand hesapla1 = new SqlCommand("select sum(KitapFiyat) from Kitap", baglantim);
            SqlDataReader okuma1 = hesapla1.ExecuteReader();
            while (okuma1.Read())
            {
                label16.Text = okuma1[0].ToString();
             
            }
            baglantim.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand hesapla1 = new SqlCommand("select avg(KitapFiyat) from Kitap", baglantim);
            SqlDataReader okuma1 = hesapla1.ExecuteReader();
            while (okuma1.Read())
            {
                label17.Text = okuma1[0].ToString();
                
            }
            baglantim.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
