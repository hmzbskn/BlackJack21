using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{
    internal class Kurpiye
    {
        public int AcılanKartSayısı { get; set; }
        public Kart[] KurpiyeKartları { get; set; }
        public int AcılanKartToplam { get; set; }

        public void KartToplam()
        {
            //Bu metot çağırıldığında eğer herhangi bir kart çekme işlemi yapıldıysa acılan kart sayısı değeri artmış olacak
            //Böylece karttoplam değeri değişecek ilk başta kart toplam değerleri atandıktan sonra ve her kart çekildiğinde bu metodun
            //Çağırılması gerekmektedir.
            AcılanKartToplam = 0;
            for (int i = 0; i < AcılanKartSayısı; i++)
            {
                AcılanKartToplam += KurpiyeKartları[i].KartDegeri;
            }
        }
        public void as11mantığı()
        {
            for (int i = 0; i < AcılanKartSayısı; i++)
            {
                if (KurpiyeKartları[i].KartDegeri == 11)
                {
                    KartToplam();
                    if (AcılanKartToplam > 21)
                    {
                        KurpiyeKartları[i].KartDegeri = 1;
                    }
                }
            }
        }
        public bool Kuripye21denBuyukMu()
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
        public bool KurpiyeBJVarMı()
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
        public bool Kurpiye17denKucukMu()
        {
            if (AcılanKartToplam < 17)
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
