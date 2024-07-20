using Npgsql;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Microsoft.VisualBasic;

namespace ödev2deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost; Port=5432; Database=postgres; Username=postgres; Password=1234;");
        public void Deneme(string txt)
        {

        }
        public void VeriListele()
        {
            NpgsqlConnection baglanti = null;
            try
            {
                baglanti = new NpgsqlConnection("Server=localhost; Port=5432; Database=postgres; Username=postgres; Password=1234;");
                baglanti.Open();

                NpgsqlDataAdapter kmt = new NpgsqlDataAdapter("select * from  hasta ", baglanti);

                DataSet data = new DataSet();
                kmt.Fill(data, "personel");
                dataGridView1.DataSource = (data.Tables[0]);
                dataGridView2.DataSource = (data.Tables[0]);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Listeleme
        {
            NpgsqlConnection baglanti = null;
            try
            {
                baglanti = new NpgsqlConnection("Server=localhost; Port=5432; Database=postgres; Username=postgres; Password=1234;");
                baglanti.Open();

                NpgsqlDataAdapter kmt = new NpgsqlDataAdapter("select * from  hasta ", baglanti);

                DataSet data = new DataSet();
                kmt.Fill(data, "personel");
                dataGridView1.DataSource = (data.Tables[0]);
                dataGridView2.DataSource = (data.Tables[0]);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)//Ekle
        {
            //baglanti.Open();
            //NpgsqlCommand verikayit = new NpgsqlCommand("insert into  hasta(tcno,ad,soyad,telefon,dogumtarihi,dogumyeri,adres,hastalik,ilac) values(@tcno,@ad,@soyad,@telefon,@dogumyeri,@adres,@hastalik,@ilac)", baglanti);
            //verikayit.Parameters.AddWithValue("@tcno",int.Parse( textBox1.Text));
            //verikayit.Parameters.AddWithValue("@ad", textBox3.Text);
            //verikayit.Parameters.AddWithValue("@soyad", textBox11.Text);
            //verikayit.Parameters.AddWithValue("@telefon",int.Parse(textBox2.Text));
            //verikayit.Parameters.AddWithValue("@dogumyeri", textBox7.Text);
            //verikayit.Parameters.AddWithValue("@dogumtarihi", textBox4.Text);
            //verikayit.Parameters.AddWithValue("@adres", textBox8.Text);
            //verikayit.Parameters.AddWithValue("@hastalik", textBox5.Text);
            //verikayit.Parameters.AddWithValue("@ilac", textBox6.Text);
            //NpgsqlCommand verikayıt = new NpgsqlCommand("insert into hasta(tcno,ad,soyad,telefon,dogumtarihi,dogumyeri,adres,hastalik,ilac) values('" + textBox1.Text + "'," + textBox3.Text + "',"+textBox11.Text +"'," + textBox2.Text + "'," + textBox7.Text + "'," + textBox4.Text + "'," + textBox8.Text + "'," + textBox5.Text + "'," + textBox6.Text + "')", baglanti);
            //verikayit.ExecuteNonQuery();
            //baglanti.Close();
            //MessageBox.Show("Veriler Eklendi...");
            //Listele();
            baglanti.Open();
            NpgsqlCommand komutekle = new NpgsqlCommand("insert into hasta(tcno,ad,soyad,telefon,dogumtarihi,dogumyeri,adres,hastalik,ilac) values(@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9)", baglanti);
            komutekle.Parameters.AddWithValue("@k1", int.Parse(textBox1.Text));
            komutekle.Parameters.AddWithValue("@k2", textBox3.Text);
            komutekle.Parameters.AddWithValue("@k3", textBox11.Text);
            komutekle.Parameters.AddWithValue("@k4", int.Parse(textBox2.Text));
            komutekle.Parameters.AddWithValue("@k5", int.Parse(textBox4.Text));
            komutekle.Parameters.AddWithValue("@k6", textBox7.Text);
            komutekle.Parameters.AddWithValue("@k7", textBox8.Text);
            komutekle.Parameters.AddWithValue("@k8", textBox5.Text);
            komutekle.Parameters.AddWithValue("@k9", textBox6.Text);
            komutekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kayıt ekleme işlemi başarılı.");
        }

        private void button2_Click(object sender, EventArgs e)//Sil
        {
            baglanti.Open();
            NpgsqlCommand verisil = new NpgsqlCommand("Delete from hasta where tcno=@tcno", baglanti);
            verisil.Parameters.AddWithValue("@tcno", int.Parse(textBox1.Text));
            verisil.ExecuteNonQuery();
            baglanti.Close();
            VeriListele();
            MessageBox.Show("Veriler Silindi...");
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            NpgsqlDataAdapter datas = new NpgsqlDataAdapter("Select * from hasta Where lower(hastalik) like lower('%" + textBox9.Text + "%')", baglanti);
            datas.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            NpgsqlConnection baglanti = null;
            try
            {
                baglanti = new NpgsqlConnection("Server=localhost; Port=5432; Database=postgres; Username=postgres; Password=1234;");
                baglanti.Open();

                NpgsqlDataAdapter kmt = new NpgsqlDataAdapter("select * from  hasta ", baglanti);

                DataSet data = new DataSet();
                kmt.Fill(data, "personel");
                dataGridView1.DataSource = (data.Tables[0]);
                dataGridView2.DataSource = (data.Tables[0]);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)//Güncelle
        {
            baglanti.Open();
            MessageBox.Show("Güncelleme yapmak istediğiniz kisinin tc sini giriniz...");
            NpgsqlCommand komut = new NpgsqlCommand("update hasta set ad=@ad,soyad=@soyad,telefon=@telefon,dogumtarihi=@dogumtarihi,dogumyeri=@dogumyeri,adres=@adres,hastalik=@hastalik,ilac=@ilac where tcno=@tcno", baglanti);
            komut.Parameters.AddWithValue("@ad", txtad.Text);
            komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            komut.Parameters.AddWithValue("@telefon", int.Parse(txttel.Text));
            komut.Parameters.AddWithValue("@dogumtarihi", txtdate.Text);
            komut.Parameters.AddWithValue("@dogumyeri", txtyer.Text);
            komut.Parameters.AddWithValue("@adres", txtadres.Text);
            komut.Parameters.AddWithValue("@hastalik", txtteshis.Text);
            komut.Parameters.AddWithValue("@ilac", txtilac.Text);
            komut.Parameters.AddWithValue("@tcno", int.Parse(txttc.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgiler Güncellendi");
            VeriListele();

        }

        private void textBox10_TextChanged(object sender, EventArgs e)//Ad a göre arama
        {
            DataTable data = new DataTable();
            NpgsqlDataAdapter datas = new NpgsqlDataAdapter("Select * from hasta Where lower(ad) like lower('%" + textBox10.Text + "%')", baglanti);
            datas.Fill(data);
            dataGridView1.DataSource = data;
            //SELECT* FROM trees WHERE LOWER(trees.title) LIKE LOWER('%elm%');
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex--;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }
    }
}