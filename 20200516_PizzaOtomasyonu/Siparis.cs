using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200516_PizzaOtomasyonu
{
    class Siparis
    {
        public Pizza pizza { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }
        public override string ToString()
        {
            string siparis = "";
            siparis = siparis + pizza.Adi + " ";
            siparis = siparis + pizza.Ebat.Adi + " ";
            siparis = siparis + pizza.KenarTip.Adi + " ";
            foreach (string malzeme in pizza.Malzemeler)
            {
                siparis = siparis + String.Format("{0},",malzeme);
            }
            siparis = siparis.Remove(siparis.Length - 1,1);
            siparis = siparis + String.Format(" {0} x {1} = {2}", Adet, pizza.Tutar, Adet * pizza.Tutar);
            return siparis;
        }
    }
}
