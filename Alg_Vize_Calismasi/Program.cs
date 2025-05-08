using System.Collections.Specialized;
namespace Alg_Vize_Calismasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("ogrenciler");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("************************************");
                Console.WriteLine("*       ÖĞRENCİ BİLGİ SİSTEMİ      *");
                Console.WriteLine("************************************");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Lütfen bir seçenek seçin ");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1.  Öğrenci Ekle");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("2.  Öğrenci Sil");
                Console.ResetColor();
                Console.WriteLine("3.  Tüm Öğrencileri Listele");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("4.  Öğrenci Bilgilerini Göster");
                Console.ResetColor();
                Console.WriteLine("5.  Not Girişi");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("6.  Devamsız Ekle");
                Console.ResetColor();
                Console.WriteLine("7.  Başarı Raporu Oluştur");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("8.  En Başarılı Öğrenciyi Bul");
                Console.ResetColor();
                Console.WriteLine("9.  En Başarısız Öğrenciyi Bul");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("10. Sınıf Ortalamasını Göster");
                Console.ResetColor();
                Console.WriteLine("11. Not Ortalaması Histogramı");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("12. Öğrenci Not Grafiğini Göster");
                Console.ResetColor();
                Console.WriteLine("13. Toplam Öğrenci Sayısı");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("0.  Çık");
                Console.ResetColor();
                Console.WriteLine("----------------------------");
                int secim = 0;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Seçimizin: ");
                    Console.ResetColor();
                    string a = Console.ReadLine();
                    Console.WriteLine("----------------------------");

                    if (int.TryParse(a, out secim))
                    {
                        if (secim > 13 || secim < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Lütfen 0 ve 13 Arasındaki Sayıları Kullanın.");
                            Console.ResetColor();
                        }
                        else
                        {
                            break;
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geçerli Bir Sayı Giriniz.");
                        Console.ResetColor();
                    }
                }
                if (secim == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Çıkış yapılıyor...");
                    Console.ResetColor();
                    break;
                }
                else if (secim == 1)
                    OgrenciEkle();
                else if (secim == 2)
                    OgrenciSil();
                else if (secim == 3)
                    TumOgrencileriListele();
                else if (secim == 4)
                    OgrenciBilgileriniGoster();
                else if (secim == 5)
                    NotGiris();
                else if (secim == 6)
                    DevamsizlıkEkle();
                else if (secim == 7)
                    BasariRaporuOlustur();
                else if (secim == 8)
                    EnBasariliOgrenciyiBul();
                else if (secim == 9)
                    EnBasarisizOgrenciyiBul();
                else if (secim == 10)
                    SinifOrtalamasiGoster();
                else if (secim == 11)
                    NotOrtalamasiHistogrami();
                else if (secim == 12)
                    OgrenciNotGrafigi();
                else if (secim == 13)
                    ToplamOgrenciSayisi();


            }

            Console.ReadLine();
        }
        static void Temizlik()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
        static void OgrenciEkle()
        {
            Console.Write("Öğrenci Numarası: ");
            string ogrenciNumarasi = Console.ReadLine();

            if (File.Exists($"ogrenciler/{ogrenciNumarasi}.txt"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bu öğrenci numarası zaten mevcut!?!? Lütfen başka bir numara girin!!!!");
                Console.ResetColor();
                Temizlik();
                return;
            }
            Console.Write("Öğrenci Adı: ");
            string ad = Console.ReadLine();

            Console.Write("Öğrenci Soyadı: ");
            string soyad = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ogrenciNumarasi) || string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Öğrenci Eklenemedi Boş Bırakılan Bir Yer Var!");
                Console.ResetColor();
                Temizlik();
                return;
            }

            string dosyaIcerigi = $"Numara: {ogrenciNumarasi}\nAd: {ad}\nSoyad: {soyad}\nVize: \nFinal: \nDevamsizlik: 0";
            File.WriteAllText($"ogrenciler/{ogrenciNumarasi}.txt", dosyaIcerigi);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Öğrenci {ad} {soyad} başarıyla kaydedildi.");
            Console.ResetColor();
            Temizlik();
        }
        static void OgrenciSil()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Temizlik();
                return;
            }
            Console.Write("Silmek istediğiniz öğrencinin numarasını girin: ");
            string ogrenciNumarasi = Console.ReadLine();

            string dosyaYolu = $"ogrenciler/{ogrenciNumarasi}.txt";

            if (File.Exists(dosyaYolu))
            {
                File.Delete(dosyaYolu);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Öğrenci numarası {ogrenciNumarasi} olan öğrenci silindi.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Numarası {ogrenciNumarasi} olan bir öğrenci bulunamadı.");
                Console.ResetColor();
            }
            Temizlik();
        }

        static void TumOgrencileriListele()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Console.ResetColor();
                Temizlik();
                return;
            }

            foreach (string dosya in dosyalar)
            {
                string[] satirlar = File.ReadAllLines(dosya);
                string numara = satirlar[0].Trim();
                string ad = satirlar[1].Trim();
                string soyad = satirlar[2].Split(":")[1].Trim();
                Console.WriteLine($"{numara} - {ad} {soyad}");
                Console.WriteLine("----------------------------");
            }
            Temizlik();

        }
        static void TumOgrencileriListeleM()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Console.ResetColor();
                Temizlik();
                return;
            }

            foreach (string dosya in dosyalar)
            {
                string[] satirlar = File.ReadAllLines(dosya);
                string numara = satirlar[0].Trim();
                string ad = satirlar[1].Trim();
                string soyad = satirlar[2].Split(":")[1].Trim();
                Console.WriteLine($"{numara} - {ad} {soyad}");
                Console.WriteLine("----------------------------");
            }
        }

        static void OgrenciBilgileriniGoster()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Temizlik();
                return;
            }
            TumOgrencileriListeleM();
            Console.Write("Öğrenci Numarası: ");
            string ogrenciNumarasi = Console.ReadLine();
            Console.WriteLine("----------------------------");

            string dosyaYolu = $"ogrenciler/{ogrenciNumarasi}.txt";

            if (!File.Exists(dosyaYolu))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bu numaraya ait bir öğrenci bulunamadı.");
                Console.ResetColor();
                Temizlik();
                return;
            }

            string[] satirlar = File.ReadAllLines(dosyaYolu);
            Console.WriteLine(string.Join("\n", satirlar));
            string vizeNotuStr = satirlar[3].Split(":")[1].Trim();
            string finalNotuStr = satirlar[4].Split(":")[1].Trim();
            double ortalama = 0;
            if (!string.IsNullOrWhiteSpace(vizeNotuStr) && !string.IsNullOrWhiteSpace(finalNotuStr))
            {
                int vizeNotu = int.Parse(vizeNotuStr);
                int finalNotu = int.Parse(finalNotuStr);
                ortalama = (vizeNotu * 0.4) + (finalNotu * 0.6);
                Console.WriteLine($"Ortalama: {ortalama.ToString("F2")}");
            }
            else
            {
                Console.WriteLine("Ortalama: Vize ve/veya final notu girilmediği için ortalama hesaplanamıyor");
            }

            Temizlik();
        }

        static void NotGiris()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Temizlik();
                return;
            }
            Console.Write("Öğrenci Numarası: ");
            string ogrenciNumarasi = Console.ReadLine();

            string dosyaYolu = $"ogrenciler/{ogrenciNumarasi}.txt";

            if (!File.Exists(dosyaYolu))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bu numaraya ait bir öğrenci bulunamadı.");
                Console.ResetColor();
                Temizlik();
                return;
            }
            string[] satirlar = File.ReadAllLines(dosyaYolu);

            string mevcutVizeNotu = satirlar[3].Split(":")[1].Trim();
            string mevcutFinalNotu = satirlar[4].Split(":")[1].Trim();
            
            Console.Write("Vize Notu: ");
            string V_not = Console.ReadLine();
            if (!int.TryParse(V_not, out int vizeNotu))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçerli bir sayı giriniz!");
                Console.ResetColor();
                Temizlik();
                return;
            }
            
            if (Convert.ToInt32(V_not) > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lütfen 0 ile 100 arasında bir sayı giriniz");
                Console.ResetColor();
                Temizlik();
                return;
            }
            

            Console.Write("Final Notu: ");
            string F_not = Console.ReadLine();
            if (!int.TryParse(F_not, out int finalNotu))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçerli bir sayı giriniz!");
                Console.ResetColor();
                Temizlik();
                return;
            }

            if (Convert.ToInt32(F_not) > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lütfen 0 ile 100 arasında bir sayı giriniz");
                Console.ResetColor();
                Temizlik();
                return;
            }
            

            if (!string.IsNullOrWhiteSpace(mevcutVizeNotu) && !string.IsNullOrWhiteSpace(mevcutFinalNotu))
            {
                mevcutVizeNotu = V_not;
                mevcutFinalNotu = F_not;
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (satirlar[i].StartsWith("Vize:"))
                    {
                        satirlar[i] = $"Vize: {mevcutVizeNotu}";
                    }
                    else if (satirlar[i].StartsWith("Final:"))
                    {
                        satirlar[i] = $"Final: {mevcutFinalNotu}";
                    }
                }
            }
            else
            {
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (satirlar[i].StartsWith("Vize:"))
                    {
                        satirlar[i] = $"Vize: {V_not}";
                    }
                    else if (satirlar[i].StartsWith("Final:"))
                    {
                        satirlar[i] = $"Final: {F_not}";
                    }
                }
            }




            File.WriteAllLines(dosyaYolu, satirlar);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Not başarıyla eklendi.");
            Console.ResetColor();
            Temizlik();
        }

        static void DevamsizlıkEkle()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Temizlik();
                return;
            }
            Console.Write("Öğrenci Numarası: ");
            string ogrenciNumarasi = Console.ReadLine();

            string dosyaYolu = $"ogrenciler/{ogrenciNumarasi}.txt";

            if (!File.Exists(dosyaYolu))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bu numaraya ait bir öğrenci bulunamadı.");
                Console.ResetColor();
                Temizlik();
                return;
            }

            string[] satirlar = File.ReadAllLines(dosyaYolu);
            for (int i = 0; i < satirlar.Length; i++)
            {
                if (satirlar[i].StartsWith("Devamsizlik:"))
                {
                    int devamsizlik = int.Parse(satirlar[i].Split(':')[1].Trim());
                    devamsizlik++;
                    satirlar[i] = $"Devamsizlik: {devamsizlik}";
                    break;
                }
            }

            File.WriteAllLines(dosyaYolu, satirlar);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Devamsızlık başarıyla eklendi.");
            Console.ResetColor();
            Temizlik();
        }

        static void BasariRaporuOlustur()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Temizlik();
                return;
            }
            foreach (string dosya in dosyalar)
            {
                string[] satirlar = File.ReadAllLines(dosya);
                string ogrenciNumarasi = satirlar[0].Split(":")[1].Trim();
                string ad = satirlar[1].Split(":")[1].Trim();
                string soyad = satirlar[2].Split(":")[1].Trim();
                string vizeNotuStr = satirlar[3].Split(":")[1].Trim();
                string finalNotuStr = satirlar[4].Split(":")[1].Trim();
                int devamsızlık = int.Parse(satirlar[5].Split(":")[1].Trim());
                if (!string.IsNullOrWhiteSpace(vizeNotuStr) && !string.IsNullOrWhiteSpace(finalNotuStr))
                {
                    if (Convert.ToInt32(finalNotuStr) >= 60)
                    {
                        string ortalama = "NOTU GİRİLMEDİ";
                        int vizeNotu = int.Parse(vizeNotuStr);
                        int finalNotu = int.Parse(finalNotuStr);
                        ortalama = ((vizeNotu * 0.4) + (finalNotu * 0.6)).ToString("F2");



                        string durum = "";
                        if (devamsızlık >= 4)
                        {
                            durum = "Devamsızlıktan Kaldı";
                        }
                        else if (ortalama != "NOTU GİRİLMEDİ" && double.Parse(ortalama) < 60)
                        {
                            durum = "Kaldı";
                        }
                        else if (ortalama != "NOTU GİRİLMEDİ" && double.Parse(ortalama) >= 60)
                        {
                            durum = "Geçti";
                        }

                        Console.WriteLine($"{ogrenciNumarasi} - {ad} {soyad} - Ort: {ortalama} - Devamsızlık: {devamsızlık} - {durum}");
                    }
                    else
                    {
                        string ortalama = "NOTU GİRİLMEDİ";
                        if (!string.IsNullOrWhiteSpace(vizeNotuStr) && !string.IsNullOrWhiteSpace(finalNotuStr))
                        {
                            int vizeNotu = int.Parse(vizeNotuStr);
                            int finalNotu = int.Parse(finalNotuStr);
                            ortalama = ((vizeNotu * 0.4) + (finalNotu * 0.6)).ToString("F2");
                        }
                        string durum = "Kaldı";
                        Console.WriteLine($"{ogrenciNumarasi} - {ad} {soyad} - Ort: {ortalama} - Devamsızlık: {devamsızlık} - {durum}");
                    }

                }
                else
                {
                    Console.WriteLine($"{ogrenciNumarasi} - {ad} {soyad} - Ort: Not Girilmemiş - Devamsızlık: {devamsızlık} - Not Girilmemiş");
                }
            }
            Temizlik();
        }

        static void EnBasariliOgrenciyiBul()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Temizlik();
                return;
            }
            List<string> enBasariliOgrenciler = new List<string>();
            double enYuksekOrtalama = -1;
            for (int i = 0; i < dosyalar.Length; i++)
            {
                string[] satirlar = File.ReadAllLines(dosyalar[i]);
                string ogrenciNumarasi = satirlar[0].Split(":")[1].Trim();
                string ad = satirlar[1].Split(":")[1].Trim();
                string soyad = satirlar[2].Split(":")[1].Trim();
                string vizeNotuStr = satirlar[3].Split(":")[1].Trim();
                string finalNotuStr = satirlar[4].Split(":")[1].Trim();

                if (!string.IsNullOrWhiteSpace(vizeNotuStr) && !string.IsNullOrWhiteSpace(finalNotuStr))
                {
                    int vizeNotu = int.Parse(vizeNotuStr);
                    int finalNotu = int.Parse(finalNotuStr);
                    double ortalama = ((vizeNotu * 0.4) + (finalNotu * 0.6));

                    if (ortalama > enYuksekOrtalama)
                    {
                        enYuksekOrtalama = ortalama;
                        enBasariliOgrenciler.Clear();
                        enBasariliOgrenciler.Add($"{ogrenciNumarasi} - {ad} {soyad} - Ortalama: {ortalama}");
                    }
                    else if (ortalama == enYuksekOrtalama)
                    {
                        enBasariliOgrenciler.Add($"{ogrenciNumarasi} - {ad} {soyad} - Ortalama: {ortalama}");
                    }
                }
            }

            Console.WriteLine($"En Başarılı Öğrenciler:");
            foreach (string ogrenci in enBasariliOgrenciler)
            {
                Console.WriteLine(ogrenci);
            }
            Temizlik();

        }
        static void EnBasarisizOgrenciyiBul()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Temizlik();
                return;
            }
            List<string> enBasarisizOgrenciler = new List<string>();
            double enDusukOrtalama = 101;
            for (int i = 0; i < dosyalar.Length; i++)
            {
                string[] satirlar = File.ReadAllLines(dosyalar[i]);
                string ogrenciNumarasi = satirlar[0].Split(":")[1].Trim();
                string ad = satirlar[1].Split(":")[1].Trim();
                string soyad = satirlar[2].Split(":")[1].Trim();
                string vizeNotuStr = satirlar[3].Split(":")[1].Trim();
                string finalNotuStr = satirlar[4].Split(":")[1].Trim();

                if (!string.IsNullOrWhiteSpace(vizeNotuStr) && !string.IsNullOrWhiteSpace(finalNotuStr))
                {
                    int vizeNotu = int.Parse(vizeNotuStr);
                    int finalNotu = int.Parse(finalNotuStr);
                    double ortalama = ((vizeNotu * 0.4) + (finalNotu * 0.6));

                    if (ortalama < enDusukOrtalama)
                    {
                        enDusukOrtalama = ortalama;
                        enBasarisizOgrenciler.Clear();
                        enBasarisizOgrenciler.Add($"{ogrenciNumarasi} - {ad} {soyad} - Ortalama: {ortalama}");
                    }
                    else if (ortalama == enDusukOrtalama)
                    {
                        enBasarisizOgrenciler.Add($"{ogrenciNumarasi} - {ad} {soyad} - Ortalama: {ortalama}");
                    }
                }
            }
            Console.WriteLine($"En Başarısız Öğrenciler:");
            foreach(string ogrenci in enBasarisizOgrenciler)
            {
                Console.WriteLine(ogrenci);
            }
            Temizlik();
        }
        static void SinifOrtalamasiGoster()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Console.ResetColor();
                Temizlik();
                return;
            }
            double toplamOrtalama = 0;
            int ogrenciSayisi = 0;
            foreach (string dosya in dosyalar)
            {
                string[] satirlar = File.ReadAllLines(dosya);
                string vizeNotuStr = satirlar[3].Split(":")[1].Trim();
                string finalNotuStr = satirlar[4].Split(":")[1].Trim();

                if (!string.IsNullOrWhiteSpace(vizeNotuStr) && !string.IsNullOrWhiteSpace(finalNotuStr))
                {
                    int vizeNotu = int.Parse(vizeNotuStr);
                    int finalNotu = int.Parse(finalNotuStr);
                    double ortalama = ((vizeNotu * 0.4) + (finalNotu * 0.6));
                    toplamOrtalama += ortalama;
                    ogrenciSayisi++;
                }
            }
            double sinifOrtalamasi = toplamOrtalama / ogrenciSayisi;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Sınıf Ortalaması: {sinifOrtalamasi}");
            Console.ResetColor();
            Temizlik();
        }
        static void NotOrtalamasiHistogrami()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Console.ResetColor();
                Temizlik();
                return;
            }
            string his1s = "";
            string his2s = "";
            string his3s = "";
            string his4s = "";
            string his5s = "";
            foreach (string dosya in dosyalar)
            {
                string[] satirlar = File.ReadAllLines(dosya);
                string vizeNotuStr = satirlar[3].Split(":")[1].Trim();
                string finalNotuStr = satirlar[4].Split(":")[1].Trim();
                if (!string.IsNullOrWhiteSpace(vizeNotuStr) && !string.IsNullOrWhiteSpace(finalNotuStr))
                {
                    int vizeNotu = int.Parse(vizeNotuStr);
                    int finalNotu = int.Parse(finalNotuStr);
                    double ortalama = ((vizeNotu * 0.4) + (finalNotu * 0.6));
                    if (ortalama >= 0 && ortalama < 59)
                        his1s = his1s + "*";
                    else if (ortalama >= 59 && ortalama < 69)
                        his2s = his2s + "*";
                    else if (ortalama >= 69 && ortalama < 79)
                        his3s = his3s + "*";
                    else if (ortalama >= 79 && ortalama < 89)
                        his4s = his4s + "*";
                    else if (ortalama >= 89 && ortalama <= 100)
                        his5s = his5s + "*";
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------Not Ortalaması Histogramı----------------");
            Console.ResetColor();

            Console.WriteLine($"89-100 : {his5s}");
            Console.WriteLine($"79-89  : {his4s}");
            Console.WriteLine($"69-79  : {his3s}");
            Console.WriteLine($"59-69  : {his2s}");
            Console.WriteLine($"0-59   : {his1s}");
            Temizlik();
        }
        static void OgrenciNotGrafigi()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunamadı.");
                Console.ResetColor();
                Temizlik();
                return;
            }
            foreach (string dosya in dosyalar)
            {
                string[] satirlar = File.ReadAllLines(dosya);
                string ad = satirlar[1].Split(":")[1].Trim();
                string soyad = satirlar[2].Split(":")[1].Trim();
                string vizeNotuStr = satirlar[3].Split(":")[1].Trim();
                string finalNotuStr = satirlar[4].Split(":")[1].Trim();

                if (!string.IsNullOrWhiteSpace(vizeNotuStr) && !string.IsNullOrWhiteSpace(finalNotuStr))
                {
                    int vizeNotu = int.Parse(vizeNotuStr);
                    int finalNotu = int.Parse(finalNotuStr);
                    double ortalama = (vizeNotu * 0.4) + (finalNotu * 0.6);
                    int doluKisim = (int)(ortalama / 5);
                    int bosKisim = 20 - doluKisim;
                    string grafik = "";
                    for (int i = 0; i < doluKisim; i++)
                    {
                        grafik = grafik + "#";
                    }
                    for (int i = 0; i < bosKisim; i++)
                    {
                        grafik = grafik + "-";
                    }
                    Console.WriteLine($"{ad} {soyad} : [{grafik}] : {ortalama.ToString("F2")}");

                }
                else
                {
                    Console.WriteLine($"{ad} {soyad} : [--------------------] : NOTU GİRİLMEDİ");
                }
            }
            Temizlik();
        }
        static int ToplamOgrenciSayisiRecursive(string[] dosyalar, int x = 0)
        {
            if (x >= dosyalar.Length)
            {
                return 0;
            }
            return 1 + ToplamOgrenciSayisiRecursive(dosyalar, x + 1);
        }
        static void ToplamOgrenciSayisi()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler", "*.txt");
            if (dosyalar.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Hiç öğrenci bulunmuyor");
                Console.ResetColor();
            }
            else
            {
                int toplamOgrenciSayisi = ToplamOgrenciSayisiRecursive(dosyalar);
                Console.WriteLine($"Toplam Öğrenci Sayısı : {toplamOgrenciSayisi}");
            }
            Temizlik();
        }
    }
}
