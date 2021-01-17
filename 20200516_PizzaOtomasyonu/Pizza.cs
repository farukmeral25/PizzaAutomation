using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200516_PizzaOtomasyonu
{
    class Pizza
    {
        public string Adi { get; set; }
        public Decimal Fiyat { get; set; }
        public Ebat Ebat { get; set; }
        public KenarTip KenarTip { get; set; }
        public List<string> Malzemeler { get; set; }
        public Decimal Tutar 
        { 
            get
            {
                decimal tutar = 0;
                tutar = Fiyat * (decimal) Ebat.Carpan;
                tutar = tutar + KenarTip.EkFiyat;
                return tutar;
            }
        }
        public override string ToString()
        {
            return Adi;
        }
    }
}
