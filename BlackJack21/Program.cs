using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen Para Yatırınız");
            int bakiye = int.Parse(Console.ReadLine());
            int bahis = 0;
            Oyuncu o1 = new Oyuncu(bakiye);
            //acılan kart sayısı el başında iki olacak
            Kurpiye k1 = new Kurpiye();
            //acılan kart sayısı el basında bir olacak
            //to string metodu kullanarak kartları daha tatlı şekilde yazabiliriz
            while (true)
            {
                bool oyunsorusu = YeniOyun();
                if (oyunsorusu == true)
                {
                    //oyun oynanacak
                    Console.WriteLine("Lütfen bahsinizi giriniz");
                    bahis = int.Parse(Console.ReadLine());
                    bool bkysorgu = o1.BakiyeOynayabilirMi(bahis);
                    if (bkysorgu == true)
                    {
                        o1.Bakiye = o1.Bakiye - o1.Bahis;
                        Kart[] oyuncukrt = new Kart[10];
                        oyuncukrt = AnaKartVerme();
                        o1.OyuncuKartları = oyuncukrt;
                        o1.AcılanKartSayısı = 2;
                        o1.KartToplam();

                        Kart[] kurpiyekrt = new Kart[10];
                        kurpiyekrt = AnaKartVerme();
                        k1.KurpiyeKartları = kurpiyekrt;
                        k1.AcılanKartSayısı = 1;
                        k1.KartToplam();


                        IlkElAcma(o1, k1, o1.Bahis);

                        bool oyuncubjvarmı = o1.OyuncBJVarMı();
                        bool kurpiyebjvarmı = k1.KurpiyeBJVarMı();
                        if (oyuncubjvarmı == true)
                        {
                            //oyuncu bj 
                            if (kurpiyebjvarmı == true)
                            {
                                //kurpiye elini açıyor bj var
                                //berabere
                                k1.AcılanKartSayısı = 2;
                                k1.KartToplam();
                                EnSonBilgiVerme(o1, k1);
                                KarsılıklıKıyas(o1, k1);
                                continue;
                            }
                            else
                            {
                                //kurpiye elini açıyor bj yok
                                //oyuncu 1.5 katını kazanıyor
                                k1.AcılanKartSayısı = 2;
                                k1.KartToplam();
                                EnSonBilgiVerme(o1, k1);
                                Console.WriteLine("Kazandınız");
                                o1.Bakiye += 2 * o1.Bahis;
                                Console.WriteLine("Güncel Bakiye" + o1.Bakiye);
                                continue;
                            }
                        }
                        else
                        {
                            while (true)
                            {
                                bool kalacakmı = KalCek();
                                if (kalacakmı == true)
                                {
                                    //kullanıcı kart çekiyor
                                    o1.AcılanKartSayısı++;
                                    o1.KartToplam();
                                    SonradanAcılanKartlarıYazdırma(o1, k1);


                                    bool yırmıbırkontrol = o1.Oyuncu21denBuyukMu();
                                    if (yırmıbırkontrol == true)
                                    {
                                        //oyuncu kartları patladı
                                        //kaybettiniz bildirimi vercez
                                        //bakiyeden düşücez
                                        Console.WriteLine("Kaybettiniz");
                                        Console.WriteLine("Güncel Bakiyeniz:" + o1.Bakiye);
                                        Console.WriteLine("& & & & & & & & & & & & & & & & & & & & & & & & & & & & & & ");
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    k1.AcılanKartSayısı++;
                                    k1.KartToplam();
                                    EnSonBilgiVerme(o1, k1);

                                    while (true)
                                    {
                                        //kullanıcı kal dedi
                                        //kurpiye kontolü yapılacak

                                        bool kurpiye21kontrol = k1.Kuripye21denBuyukMu();
                                        if (kurpiye21kontrol == true)
                                        {
                                            Console.WriteLine("Kazandınız");
                                            o1.Bakiye += 2 * o1.Bahis;
                                            Console.WriteLine("Güncel Bakiyeniz:" + o1.Bakiye);
                                            Console.WriteLine("----------KURPİYE 21 DEN BÜYÜK OLDUĞU İÇİN KAZANDIN-----");
                                            Console.WriteLine("& & & & & & & & & & & & & & & & & & & & & & & & & & & & & & ");
                                            break;
                                        }
                                        else
                                        {
                                            bool kurpiye17kontrol = k1.Kurpiye17denKucukMu();
                                            if (kurpiye17kontrol == true)
                                            {
                                                //kurpiye kart çekiyor
                                                k1.AcılanKartSayısı++;
                                                k1.KartToplam();
                                                EnSonBilgiVerme(o1, k1);
                                                continue;

                                            }
                                            else
                                            {
                                                KarsılıklıKıyas(o1, k1);
                                                break;
                                                //kurpiye 21 den küçük 17 den büyük şimdi ikili kıyas yapıcaz
                                            }
                                        }
                                    }
                                }
                                break;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("bakiye yükleyiniz");
                        //bakiye yüklemesi yap diye uyarı
                    }
                }
                else
                {
                    Console.WriteLine("oynamadığınız için tşk");
                    //oyun oynanmayacak bizi tercih etmediniz :(
                }
            }
        }
        public static bool YeniOyun()
        {
            Console.WriteLine("Yeni Oyun oynamak ister misin? Evetse 1 Hayırsa 2");
            int gecici = int.Parse(Console.ReadLine());
            bool yenioyun = false;
            if (gecici == 1)
            {
                yenioyun = true;
            }
            else if (gecici == 2)
            {
                yenioyun = false;
            }
            else
            {
                Console.WriteLine("yanlış tuşlama");

            }
            return yenioyun;
        }
        public static bool KalCek()
        {
            bool tamammımı = false;
            Console.WriteLine("1 - Kal, 2 - Kart Çek");
            Console.WriteLine("------------------------------------");
            int tamammı = int.Parse(Console.ReadLine());
            if (tamammı == 1)
            {
            }
            else
            {
                tamammımı = true;
            }
            return tamammımı;
        }
        public static void IlkElAcma(Oyuncu o1, Kurpiye k1, int bahis)
        {
            Console.Write("Kurpiye                |" + "Sen                     |      " + "Kalan bakiye:" + o1.Bakiye + "     |" + "Bahis:" + o1.Bahis + "|");
            Console.WriteLine();
            Console.Write(k1.KurpiyeKartları[0] + "                         " + o1.OyuncuKartları[0]);
            Console.WriteLine();
            Console.Write("************       " + "              " + o1.OyuncuKartları[1]);
            Console.WriteLine();
            Console.Write("(" + k1.AcılanKartToplam + ")                             (" + o1.AcılanKartToplam + ")");
            Console.WriteLine();
        }
        public static void SonradanAcılanKartlarıYazdırma(Oyuncu o1, Kurpiye k1)
        {
            Console.Write("Kurpiye                |" + "Sen                     |      ");
            Console.WriteLine();
            Console.Write(k1.KurpiyeKartları[0] + "                         " + o1.OyuncuKartları[0]);
            Console.WriteLine();
            Console.Write("************       " + "              " + o1.OyuncuKartları[1]);
            Console.WriteLine();

            for (int i = 2; i < o1.AcılanKartSayısı; i++)
            {
                Console.WriteLine("                                 " + o1.OyuncuKartları[i].KartAdı + "(" + o1.OyuncuKartları[i].KartDegeri + ")");
            }
            Console.WriteLine(k1.AcılanKartToplam + "                " + o1.AcılanKartToplam);
            Console.WriteLine("-   -   -   -   -   -   -   -   -   -   -   -   -");
        }
        public static void EnSonBilgiVerme(Oyuncu o1, Kurpiye k1)
        {
            Console.Write("Kurpiye                |" + "Sen                     |      ");
            Console.WriteLine();
            Console.Write(k1.KurpiyeKartları[0] + "                         " + o1.OyuncuKartları[0]);
            Console.WriteLine();
            Console.Write(k1.KurpiyeKartları[1] + "                       " + o1.OyuncuKartları[1]);
            Console.WriteLine();
            if (o1.AcılanKartSayısı > k1.AcılanKartSayısı)
            {
                for (int i = 2; i < o1.AcılanKartSayısı; i++)
                {
                    for (int j = 2; j < k1.AcılanKartSayısı; j++)
                    {
                        Console.WriteLine(k1.KurpiyeKartları[j].KartAdı + "(" + k1.KurpiyeKartları[j].KartDegeri + ")            " + o1.OyuncuKartları[i].KartAdı + "(" + o1.OyuncuKartları[i].KartDegeri + ")");
                        break;
                    }
                    Console.WriteLine("                                                                                          " + o1.OyuncuKartları[i].KartAdı + "(" + o1.OyuncuKartları[i].KartDegeri + ")");
                }
            }
            else if (o1.AcılanKartSayısı < k1.AcılanKartSayısı)
            {
                for (int i = 2; i < k1.AcılanKartSayısı; i++)
                {
                    for (int j = 2; j < o1.AcılanKartSayısı; j++)
                    {
                        Console.WriteLine(k1.KurpiyeKartları[i].KartAdı + "(" + k1.KurpiyeKartları[i].KartDegeri + ")            " + o1.OyuncuKartları[j].KartAdı + "(" + o1.OyuncuKartları[j].KartDegeri + ")");
                        break;
                    }
                    Console.WriteLine(k1.KurpiyeKartları[i].KartAdı + "(" + k1.KurpiyeKartları[i].KartDegeri + ")");
                }
            }
            else
            {
                for (int i = 2; i < o1.AcılanKartSayısı; i++)
                {
                    Console.WriteLine(k1.KurpiyeKartları[i].KartAdı + "(" + k1.KurpiyeKartları[i].KartDegeri + ")            " + o1.OyuncuKartları[i].KartAdı + "(" + o1.OyuncuKartları[i].KartDegeri + ")");
                }
            }
            Console.WriteLine(k1.AcılanKartToplam + "                " + o1.AcılanKartToplam);
            Console.WriteLine("-   -   -   -   -   -   -   -   -   -   -   -   -");
        }
        public static void KarsılıklıKıyas(Oyuncu o1, Kurpiye k1)
        {
            if (o1.AcılanKartToplam > k1.AcılanKartToplam)
            {
                //oyuncu kazandı
                Console.Write("Kazandınız");
                o1.Bakiye += 2 * o1.Bahis;
                Console.WriteLine("              Güncel bakiye:" + o1.Bakiye);
                Console.WriteLine("KART TOPLAMIN KURPİYEDEN BÜYÜK DİYE KAZANDIN -----------------");
                Console.WriteLine("& & & & & & & & & & & & & & & & & & & & & & & & & & & & & & ");
            }
            else if (o1.AcılanKartToplam == k1.AcılanKartToplam)
            {
                Console.Write("Berabere");
                o1.Bakiye += o1.Bahis;
                Console.WriteLine("güncel bakiye:" + o1.Bakiye);
                Console.WriteLine("KART TOPLAMIN KURPİYEYLE EŞİT");
                Console.WriteLine("& & & & & & & & & & & & & & & & & & & & & & & & & & & & & & ");
                //berabere
            }
            else
            {
                Console.Write("Kaybettiniz");
                Console.WriteLine("güncel bakiye:" + o1.Bakiye);
                Console.WriteLine("KART TOPLAMIN KURPİYEDEN KÜÇÜK");
                Console.WriteLine("& & & & & & & & & & & & & & & & & & & & & & & & & & & & & & ");
                //kasa kazandı
            }
        }
        public static Kart[] AnaKartVerme()
        {
            //bir kurpiye için bir de oyuncu için çağırılacak ve 10 kart açımı yapacak
            string[] sekiller = { "karo", "maça", "sinek", "kupa" };
            char[] degerler = { 'A', 'K', 'Q', 'J', '2', '3', '4', '5', '6', '7', '8', '9', 'B' };

            int sekillerrastgele = 0;
            int degerlerrastgele = 0;

            Kart[] krtlar = new Kart[10];

            Random rastgele = new Random(Guid.NewGuid().GetHashCode());
            //burası chatgpt den alındı :)

            for (int i = 0; i < 10; i++)
            {
                sekillerrastgele = rastgele.Next(0, 4);
                degerlerrastgele = rastgele.Next(0, 13);

                Kart krt = new Kart();
                switch (degerlerrastgele)
                {
                    case 0:
                        krt.KartDegeri = 11;
                        break;
                    case 1:
                    case 2:
                    case 3:
                        krt.KartDegeri = 10;
                        break;
                    case 4:
                        krt.KartDegeri = 2;
                        break;
                    case 5:
                        krt.KartDegeri = 3;
                        break;
                    case 6:
                        krt.KartDegeri = 4;
                        break;
                    case 7:
                        krt.KartDegeri = 5;
                        break;
                    case 8:
                        krt.KartDegeri = 6;
                        break;
                    case 9:
                        krt.KartDegeri = 7;
                        break;
                    case 10:
                        krt.KartDegeri = 8;
                        break;
                    case 11:
                        krt.KartDegeri = 9;
                        break;
                    case 12:
                        krt.KartDegeri = 10;
                        break;
                }
                krt.KartAdı = sekiller[sekillerrastgele] + degerler[degerlerrastgele];
                krtlar[i] = krt;
            }
            return krtlar;
        }
    }
}
