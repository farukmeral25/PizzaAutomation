using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200516_PizzaOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ebat kucuk = new Ebat { Adi = "Küçük", Carpan = 1 };
            Ebat orta = new Ebat { Adi = "Orta", Carpan = 1.25 };
            Ebat buyuk = new Ebat { Adi = "Büyük", Carpan = 1.75 };
            Ebat maxi = new Ebat { Adi = "Maxi", Carpan = 2 };
            cmbEbat.Items.Add(kucuk);
            cmbEbat.Items.Add(orta);
            cmbEbat.Items.Add(buyuk);
            cmbEbat.Items.Add(maxi);

            Pizza klasik = new Pizza { Adi = "Klasik", Fiyat = 14 };
            Pizza karisik = new Pizza { Adi = "Karışık", Fiyat = 17 };
            Pizza turkish = new Pizza { Adi = "Türkish", Fiyat = 20 };
            Pizza tuna = new Pizza { Adi = "Tuna", Fiyat = 21 };
            Pizza akdeniz = new Pizza { Adi = "Akdeniz", Fiyat = 19 };
            Pizza karadeniz = new Pizza { Adi = "Karadeniz", Fiyat = 22 };
            listPizzalar.Items.Add(klasik);
            listPizzalar.Items.Add(karisik);
            listPizzalar.Items.Add(turkish);
            listPizzalar.Items.Add(tuna);
            listPizzalar.Items.Add(akdeniz);
            listPizzalar.Items.Add(karadeniz);

            KenarTip inceKenar = new KenarTip { Adi = "İnce Kenar", EkFiyat = 0 };
            rdbInceKenar.Tag = inceKenar;
            KenarTip kalinKenar = new KenarTip { Adi = "Kalın Kenar", EkFiyat = 2 };
            rdbKalinKenar.Tag = kalinKenar;


        }
        Siparis siparis;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
           
            Pizza pizza = (Pizza)listPizzalar.SelectedItem;
            pizza.Ebat = (Ebat) cmbEbat.SelectedItem;
            pizza.KenarTip = rdbInceKenar.Checked ? (KenarTip)rdbInceKenar.Tag : (KenarTip)rdbKalinKenar.Tag;
            pizza.Malzemeler = new List<string>();
            foreach (CheckBox malzeme in gbxMalzemeler.Controls)
            {
                if (malzeme.Checked)
                {
                    pizza.Malzemeler.Add(malzeme.Text);
                }
            }
            decimal tutar = nudAdet.Value * pizza.Tutar;
            txtTutar.Text = tutar.ToString();
            siparis = new Siparis();
            siparis.pizza = pizza;
            siparis.Adet = (int)nudAdet.Value;
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (siparis != null)
            {
                listSepet.Items.Add(siparis);
            }
        }

        private void btnSiparisOnay_Click(object sender, EventArgs e)
        {
            decimal toplamtutar = 0;
            int adet = 0;
            foreach (Siparis siparis in listSepet.Items)
            {
                toplamtutar = toplamtutar + (siparis.Adet * siparis.pizza.Tutar);
                adet = adet + siparis.Adet;
            }
            lblToplamTutar.Text = toplamtutar.ToString();
            MessageBox.Show(string.Format("Toplam Sipariş Adediniz : {0} \nToplam Sipariş Tutarınız: {1}",adet,toplamtutar));
            listSepet.Items.Clear();
            lblToplamTutar.Text = "";
        }
    }
}
