using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot_Yapımı_Güzel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dongu = 0;
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            LblHız.Text = trackBar1.Value.ToString() + "ms";//TrackBar'daki değer değiştiği an Label'imize yazsın dedik ama ilk önce Labelimizin üzerinde sağ tuş yaptık bring to front Seçeneğini tıkladık
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtMesaj.Text != "")
            {
                System.Threading.Thread.Sleep(3500);//Programı 3,5 saniye beklemeye alıcak
                Timer.Interval = trackBar1.Value;//Timer'imizin  İntervalini TrackBar'a eşitliyoruz  hızını ayarlıyoruz
                Timer.Enabled = true;//Timer Başlasın
               // dongu = Convert.ToInt32(numericUpDown1.Value);//Tekrarlama değerini tutmak için oluşturduğumuz döngü değerini numericUpDown1'e eşitliyoruz

                numericUpDown1.Enabled = false;//Değişken Barındıran bölümleri pasif hale getiriyoruz
                TxtMesaj.Enabled = false;//Değişken Barındıran bölümleri pasif hale getiriyoruz
                button1.Enabled = false;//Değişken Barındıran bölümleri pasif hale getiriyoruz
                trackBar1.Enabled = false;//Değişken Barındıran bölümleri pasif hale getiriyoruz

            }
            else
            {
                MessageBox.Show("Lütfen Metin Girişi Yapınız", "C# Bot", MessageBoxButtons.OK, MessageBoxIcon.Warning);//Metin kutusu Boş ise uyarı vermesi için mesaj ayarlıyoruz 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Timer.Enabled = false;//İşlemi iptal etmek için Timer'imizi durduruyoruz 
            dongu = 0;//İşlem tamamlandığı için Timer'i sıfırlıyoruz

            numericUpDown1.Enabled = true;//Değişken Barındıran bölümleri Aktif hale getiriyoruz
            TxtMesaj.Enabled = true;//Değişken Barındıran bölümleri Aktif hale getiriyoruz
            button1.Enabled = true;//Değişken Barındıran bölümleri Aktif hale getiriyoruz
            trackBar1.Enabled = true;//Değişken Barındıran bölümleri Aktif hale getiriyoruz

            MessageBox.Show("İşlem İptal Edildi", "C# Bot", MessageBoxButtons.OK, MessageBoxIcon.Warning);//Metin kutusu Boş ise uyarı vermesi için mesaj ayarlıyoruz 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dongu != Convert.ToInt32(numericUpDown1.Value))//Dinamik döngü değerini her seferinde kontrol ediyoruz ve tekrarlama değerinden küçük ise işlem gerçekleştiriyor
            {
                SendKeys.Send(TxtMesaj.Text + "\n");//SendKeys==Ekrana metni yazdırmak için kullandığımız method ve ("\n")=== Bir Alt satıra Geçmek için kullanılan komut
                dongu += 1;//dongüyü tamamlamak için her seferinde 1 ekliyoruz taki tekrarlama eşit olana kadar 

            }
            if (dongu == Convert.ToInt32(numericUpDown1.Value))//döngü değeri sona erdiğinde çalıştırılacak komutlar için koşul oluşturuyoruz
            {
                Timer.Enabled = false;//Timer'imizi pasif yapıyoruz yani sonlandırıyoruz 
                dongu = 0;//İşlem tamamlandığı için Timer'i sıfırlıyoruz

                numericUpDown1.Enabled = true;//Değişken Barındıran bölümleri Aktif hale getiriyoruz
                TxtMesaj.Enabled = true;//Değişken Barındıran bölümleri Aktif hale getiriyoruz
                button1.Enabled = true;//Değişken Barındıran bölümleri Aktif hale getiriyoruz
                trackBar1.Enabled = true;//Değişken Barındıran bölümleri Aktif hale getiriyoruz

                MessageBox.Show("İşlem Tamamlandı", "C# Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);//Metin kutusu Boş ise uyarı vermesi için mesaj ayarlıyoruz 
            }
        }
    }
}
