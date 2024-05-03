using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{
    internal class Oyuncu
    {
        public int AcılanKartSayısı { get; set; }
        public Kart[] OyuncuKartları { get; set; }
        public int Bakiye { get; set; }
        public int AcılanKartToplam { get; set; }
        public int Bahis { get; set; }

        public Oyuncu(int _bakiye)
        {
            this.Bakiye = _bakiye;
        }
        public void KartToplam()
        {
            //Bu metot çağırıldığında eğer herhangi bir kart çekme işlemi yapıldıysa acılan kart sayısı değeri artmış olacak
            //Böylece karttoplam değeri değişecek ilk başta kart toplam değerleri atandıktan sonra ve her kart çekildiğinde bu metodun
            //Çağırılması gerekmektedir.
            int toplam = 0;
            for (int i = 0; i < AcılanKartSayısı; i++)
            {
                toplam += OyuncuKartları[i].KartDegeri;
            }
            AcılanKartToplam = toplam;
        }
        public void as11mantığı()
        {
            for (int i = 0; i < AcılanKartSayısı; i++)
            {
                if (OyuncuKartları[i].KartDegeri == 11)
                {
                    KartToplam();
                    if (AcılanKartToplam > 21)
                    {
                        OyuncuKartları[i].KartDegeri = 1;
                    }
                }
            }
        }
        public bool Oyuncu21denBuyukMu()
        {
            if (AcılanKartToplam > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool OyuncBJVarMı()
        {
            if (AcılanKartToplam == 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool BakiyeOynayabilirMi(int _bahis)
        {
            this.Bahis = _bahis;
            if (Bakiye >= Bahis)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
