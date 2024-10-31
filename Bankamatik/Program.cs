namespace Bankamatik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int anaMenuSecim = 0;
            int hesapBakiye = 25000;
            string krediKartiNumarasi = "123456789012";
            string TCKimlikNo = "12345678901";
            string telefon = "12345678901";
        BASLANGIC:
            Console.WriteLine("****BANKAMATİK****");
            Console.WriteLine("KARTLI İŞLEM  1\n" +
                              "KARTSIZ İŞLEM 2");
            int islemTuru = Convert.ToInt32(Console.ReadLine());
            #region Kartli Islem
            if (islemTuru == 1)
            {
                string sifre = "ab18";
                int sayac = 0;
                SIFREDENEME:
                Console.WriteLine("Lütfen şifre giriniz");
                string girilenSifre = Console.ReadLine();
                if (girilenSifre == sifre)
                {
                KARTLIISLEMANAMENU:
                    Console.WriteLine("****ANA MENU****\n" +
                                      "PARA ÇEKMEK       1\n" +
                                      "PARA YATIRMAK     2\n" +
                                      "PARA TRANSFERLERİ 3\n" +
                                      "EĞİTİM ÖDEMELERİ  4\n" +
                                      "ÖDEMELER          5\n" +
                                      "BİLGİ GÜNCELLEME  6");
                    int kartliIslemSecim = Convert.ToInt32(Console.ReadLine());
                    #region Para Cekme
                    if (kartliIslemSecim == 1) // Hesaptan Para Çekme
                    {
                        Console.WriteLine("Çekilecek para miktarını giriniz");
                        int kartliCekilecekParaMiktari = Convert.ToInt32(Console.ReadLine());
                        if (kartliCekilecekParaMiktari > hesapBakiye)
                        {
                            Console.WriteLine($"{kartliCekilecekParaMiktari} çekilecek para miktarı hesaptaki {hesapBakiye}'den büyüktür. Lütfen daha az miktarda para çekmeyi deneyin.");
                        }
                        else
                        {
                            hesapBakiye -= kartliCekilecekParaMiktari;
                            Console.WriteLine($"Hesaptan {kartliCekilecekParaMiktari} TL kadar para çekilmiştir ve kalan para {hesapBakiye} kadardır.");
                        }
                    ANAMENUHATALISAYI:
                        Console.WriteLine("Ana menü için 9\n" +
                                          "Çıkmak için   0");
                        anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                        if (anaMenuSecim == 9)
                        {
                            goto KARTLIISLEMANAMENU;
                        }
                        else if (anaMenuSecim != 0)
                        {
                            Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                            goto ANAMENUHATALISAYI;
                        }
                    }
                    #endregion
                    #region Para Yatırma
                    else if (kartliIslemSecim == 2)
                    {
                        Console.WriteLine("Kredi Kartına  1\n" +
                                          "Kendi Hesabına 2");
                        int kartliParaYatirmaSecim = Convert.ToInt32(Console.ReadLine());
                        if (kartliParaYatirmaSecim == 1) // Kredi Kartına Para Yatırma
                        {
                            Console.WriteLine("12 haneli kredi kartı numaranızı giriniz");
                            string girilenKrediKartiNumarasi = Console.ReadLine();
                            if (girilenKrediKartiNumarasi == krediKartiNumarasi)
                            {
                                Console.WriteLine("Kredi kartına yatıralacak para miktarını yazınız.");
                                int krediKartiYatirilacakPara = Convert.ToInt32(Console.ReadLine());
                                if (hesapBakiye > krediKartiYatirilacakPara)
                                {
                                    hesapBakiye -= krediKartiYatirilacakPara;
                                    Console.WriteLine($"{krediKartiNumarasi} numaralı kredi kartına {krediKartiYatirilacakPara} TL para yatırılmıştır.\n" +
                                        $"Hesabında toplam {hesapBakiye} TL tutar kalmıştır.");
                                }
                                else
                                {
                                    Console.WriteLine($"{krediKartiYatirilacakPara} kredi kartına yatıralacak para miktarı hesaptaki {hesapBakiye}'den büyüktür. Lütfen daha az miktarda para çekmeyi deneyin.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Girilen {girilenKrediKartiNumarasi} kredi kartı numarası yanlıştır.");
                            }
                        }else if (kartliParaYatirmaSecim == 2) // Kendi Hesabına Para Yatırma
                        {
                            Console.WriteLine("Yatıralacak para miktarını giriniz");
                            int kartliParaYatirmaMiktarı = Convert.ToInt32(Console.ReadLine());
                            hesapBakiye += kartliParaYatirmaMiktarı;
                            Console.WriteLine("Toplam hesap bakiyesi:" + hesapBakiye + " TL");
                        }
                        else
                        {
                            Console.WriteLine("Hatalı sayı girdiniz.");
                        }
                    ANAMENUHATALISAYI:
                        Console.WriteLine("Ana menü için 9\n" +
                                          "Çıkmak için   0");
                        anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                        if (anaMenuSecim == 9)
                        {
                            goto KARTLIISLEMANAMENU;
                        }
                        else if (anaMenuSecim != 0)
                        {
                            Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                            goto ANAMENUHATALISAYI;
                        }
                    }
                    #endregion
                    #region Para Transferi
                    else if (kartliIslemSecim == 3)
                    {
                        Console.WriteLine("Başka Hesaba EFT    1\n" +
                                          "Başka Hesaba Havale 2");
                        int kartliParaTransferSecim = Convert.ToInt32(Console.ReadLine());
                        if (kartliParaTransferSecim == 1) // Başka Hesaba EFT
                        {
                            Console.WriteLine("12 haneli EFT numarasını başında TR olarak giriniz");
                            string girilenEFTNumarasi = Console.ReadLine();
                            
                            if(girilenEFTNumarasi.Length != 14)
                            {
                                Console.WriteLine($"{girilenEFTNumarasi} EFT numarası toplam 14 haneli değildir.");
                            }
                            else if (!(girilenEFTNumarasi.Substring(2).All(char.IsDigit))) // TR'den sonrasını alır ve bütün girilen sayı mı bakar.
                            {
                                Console.WriteLine($"{girilenEFTNumarasi} EFT numarası sayılardan oluşmamaktadır.");
                            } 
                            else if (girilenEFTNumarasi.ToLower().StartsWith("tr"))
                            {
                                Console.WriteLine("EFT yapılacak para miktarını giriniz");
                                int eftYapilacakParaMiktari = Convert.ToInt32(Console.ReadLine());
                                if (eftYapilacakParaMiktari > hesapBakiye)
                                {
                                    Console.WriteLine($"{eftYapilacakParaMiktari} EFT para miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda EFT yapmayı deneyin.");
                                }
                                else
                                {
                                    hesapBakiye -= eftYapilacakParaMiktari;
                                    Console.WriteLine($"Hesaptan {eftYapilacakParaMiktari} TL kadar para EFT yapılmıştır ve hesapta kalan para {hesapBakiye} TL kadardır.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{girilenEFTNumarasi} EFT numarası TR ile başlamıyordur.");
                            }
                        }else if (kartliParaTransferSecim == 2) // Başka Hesaba Havale
                        {
                            Console.WriteLine("11 haneli hesap numaranızı giriniz");
                            string girilenHesapNumarasi = Console.ReadLine();
                            if (girilenHesapNumarasi.Length != 11)
                            {
                                Console.WriteLine($"{girilenHesapNumarasi} Havale numarası toplam 11 haneli değildir.");
                            }
                            else if (girilenHesapNumarasi.All(char.IsDigit))
                            {
                                Console.WriteLine("Havale yapılacak para miktarını giriniz");
                                int havaleYapilacakParaMiktari = Convert.ToInt32(Console.ReadLine());
                                if (havaleYapilacakParaMiktari > hesapBakiye)
                                {
                                    Console.WriteLine($"{havaleYapilacakParaMiktari} havale para miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda havale yapmayı deneyin.");
                                }
                                else
                                {
                                    hesapBakiye -= havaleYapilacakParaMiktari;
                                    Console.WriteLine($"Hesaptan {havaleYapilacakParaMiktari} TL kadar para havale yapılmıştır ve hesapta kalan para {hesapBakiye} TL kadardır.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{girilenHesapNumarasi} havale numarası sayılardan oluşmamaktadır.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı sayı girdiniz.");
                        }
                    ANAMENUHATALISAYI:
                        Console.WriteLine("Ana menü için 9\n" +
                                          "Çıkmak için   0");
                        anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                        if (anaMenuSecim == 9)
                        {
                            goto KARTLIISLEMANAMENU;
                        }
                        else if (anaMenuSecim != 0)
                        {
                            Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                            goto ANAMENUHATALISAYI;
                        }
                    }
                    #endregion
                    #region Egitim Odemeleri
                    else if (kartliIslemSecim == 4)
                    {
                        Console.WriteLine("Eğitim ödemeleri sayfası arızalıdır.");
                    ANAMENUHATALISAYI:
                        Console.WriteLine("Ana menü için 9\n" +
                                          "Çıkmak için   0");
                        anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                        if (anaMenuSecim == 9)
                        {
                            goto KARTLIISLEMANAMENU;
                        }
                        else if (anaMenuSecim != 0)
                        {
                            Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                            goto ANAMENUHATALISAYI;
                        }
                    }
                    #endregion
                    #region Odemeler
                    else if (kartliIslemSecim == 5)
                    {
                        Console.WriteLine("Elektrik Faturası 1\n" +
                                          "Telefon Faturası  2\n" +
                                          "İnternet Faturası 3\n" +
                                          "Su Faturası       4\n" +
                                          "OGS Ödemeleri     5");
                        int kartliFaturaSecim = Convert.ToInt32(Console.ReadLine());
                        int yatirilacakFaturaMiktari = 0;
                        if (kartliFaturaSecim == 1) // Elektrik Faturası
                        {
                            Console.WriteLine("Yatıralacak para miktarını giriniz");
                            yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                            if(hesapBakiye > yatirilacakFaturaMiktari)
                            {
                                hesapBakiye -= yatirilacakFaturaMiktari;
                                Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında elektrik faturası ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                            }
                            else
                            {
                                Console.WriteLine($"{yatirilacakFaturaMiktari} fatura miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                            }
                            
                        }
                        else if (kartliFaturaSecim == 2) // Telefon Faturası
                        {
                            Console.WriteLine("Yatıralacak para miktarını giriniz");
                            yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                            if (hesapBakiye > yatirilacakFaturaMiktari)
                            {
                                hesapBakiye -= yatirilacakFaturaMiktari;
                                Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında telefon faturası ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                            }
                            else
                            {
                                Console.WriteLine($"{yatirilacakFaturaMiktari} fatura miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                            }
                        }
                        else if (kartliFaturaSecim == 3) // İnternet Faturası
                        {
                            Console.WriteLine("Yatıralacak para miktarını giriniz");
                            yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                            if (hesapBakiye > yatirilacakFaturaMiktari)
                            {
                                hesapBakiye -= yatirilacakFaturaMiktari;
                                Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında internet faturası ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                            }
                            else
                            {
                                Console.WriteLine($"{yatirilacakFaturaMiktari} fatura miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                            }
                        }
                        else if (kartliFaturaSecim == 4) // Su Faturası
                        {
                            Console.WriteLine("Yatıralacak para miktarını giriniz");
                            yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                            if (hesapBakiye > yatirilacakFaturaMiktari)
                            {
                                hesapBakiye -= yatirilacakFaturaMiktari;
                                Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında su faturası ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                            }
                            else
                            {
                                Console.WriteLine($"{yatirilacakFaturaMiktari} fatura miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                            }
                        }
                        else if (kartliFaturaSecim == 5) // OGS Ödemeleri
                        {
                            Console.WriteLine("Yatıralacak para miktarını giriniz");
                            yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                            if (hesapBakiye > yatirilacakFaturaMiktari)
                            {
                                hesapBakiye -= yatirilacakFaturaMiktari;
                                Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında OGS ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                            }
                            else
                            {
                                Console.WriteLine($"{yatirilacakFaturaMiktari} OGS miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı sayı girdiniz. Lütfen 1 ile 5 arasında rakam giriniz.");
                        }
                    ANAMENUHATALISAYI:
                        Console.WriteLine("Ana menü için 9\n" +
                                          "Çıkmak için   0");
                        anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                        if (anaMenuSecim == 9)
                        {
                            goto KARTLIISLEMANAMENU;
                        }
                        else if (anaMenuSecim != 0)
                        {
                            Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                            goto ANAMENUHATALISAYI;
                        }
                    }
                    #endregion
                    #region Sifre Degistirme
                    else if (kartliIslemSecim == 6)
                    {
                        Console.WriteLine("Sifre değiştirmek 1");
                        int sifreDegistirmeSecim = Convert.ToInt32(Console.ReadLine());
                        if (sifreDegistirmeSecim == 1)
                        {
                            Console.WriteLine("Yeni şifreyi giriniz");
                            string yeniSifre = Console.ReadLine();
                            Console.WriteLine("Yeni şifreyi tekrardan doğrulayınız");
                            string yeniSifreDogrulama = Console.ReadLine();
                            if (yeniSifre == yeniSifreDogrulama)
                            {
                                sifre = yeniSifre;
                                Console.WriteLine($"{sifre} yeni şifre olarak kaydedilmiştir.");
                                goto SIFREDENEME;
                            }
                            else
                            {
                                Console.WriteLine($"{yeniSifre} yeni şifre ile {yeniSifreDogrulama} doğrulanan şifre birbiri ile eş değildir.");
                            ANAMENUHATALISAYI:
                                Console.WriteLine("Ana menü için 9\n" +
                                                  "Çıkmak için   0");
                                anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                                if (anaMenuSecim == 9)
                                {
                                    goto KARTLIISLEMANAMENU;
                                }
                                else if (anaMenuSecim != 0)
                                {
                                    Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                                    goto ANAMENUHATALISAYI;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı sayıdır.");
                            ANAMENUHATALISAYI:
                            Console.WriteLine("Ana menü için 9\n" +
                                              "Çıkmak için   0");
                            anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                            if (anaMenuSecim == 9)
                            {
                                goto KARTLIISLEMANAMENU;
                            }
                            else if (anaMenuSecim != 0)
                            {
                                Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                                goto ANAMENUHATALISAYI;
                            }
                        } 
                    }
                    #endregion
                    else // Kartlı İşlem Ana Menü'den girilen değer yanlış ise
                    {
                        Console.WriteLine($"{kartliIslemSecim} sayısı hatalıdır. Lütfen 1 ile 6 arasında rakam giriniz.");
                        Console.WriteLine("Ana menü için 9\n" +
                                          "Çıkmak için 0");
                        anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                        if (anaMenuSecim == 9)
                        {
                            goto KARTLIISLEMANAMENU;
                        }
                    }
                }
                else // Gririlen şifre 3 kere yanlış girilince sistemden çıkış yapılır.
                {
                    sayac++;
                    if (sayac == 3)
                    {
                        Console.WriteLine("Şifre 3 kere yanlış girilmiştir. Sistemden çıkış yapılacaktır.");
                    }
                    else
                    {
                        Console.WriteLine($"{girilenSifre} şifre yanlıştır. Lütfen şifreyi tekrar deneyiniz ve {3 - sayac} hakkınız kalmıştır.");
                        goto SIFREDENEME;
                    }
                    
                }
            }
            #endregion
            #region Kartsiz Islem
            else if (islemTuru == 2)
            {

            KARTSIZISLEMANAMENU:
                Console.WriteLine("****ANA MENU****\n" +
                                  "CepBank PARA ÇEKMEK 1\n" +
                                  "PARA YATIRMAK       2\n" +
                                  "KREDİ KARTI ÖDEME   3\n" +
                                  "EĞİTİM ÖDEMELERİ    4\n" +
                                  "ÖDEMELER            5");
                int kartsizIslemSecim = Convert.ToInt32(Console.ReadLine());
                #region CepBank Para Cekme
                if (kartsizIslemSecim == 1)
                {
                    int sayac = 0;
                    CEPBANK:
                    Console.WriteLine("TC Kimlik numarasını giriniz");
                    string girilenTCKimlikNo = Console.ReadLine();
                    Console.WriteLine("Telefon numarasını giriniz");
                    string girilenTelefon = Console.ReadLine();
                    if (TCKimlikNo == girilenTCKimlikNo && telefon == girilenTelefon)
                    {
                        hesapBakiye -= 1000;
                        Console.WriteLine($"1000 TL ödeme yapılmıştır. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                    }
                    else
                    {
                        if(TCKimlikNo != girilenTCKimlikNo)
                        {
                            Console.WriteLine($"{girilenTCKimlikNo} girilen TC kimlik no ile verideki {TCKimlikNo} eşit değildir.");
                        }
                        else if(telefon != girilenTelefon)
                        {
                            Console.WriteLine($"{girilenTelefon} girilen telefon no ile verideki {telefon} eşit değildir.");
                        }
                        sayac++;
                        if (sayac == 3)
                        {
                            Console.WriteLine("1 saat sistem kilitlenmiştir.");
                            Thread.Sleep(TimeSpan.FromHours(1));
                            sayac = 0;
                        }
                        else
                        {
                            Console.WriteLine($"{3-sayac} hakkınız kalmıştır."); // CEPBANK kısmına döner. 3 kere hata yapılınca 1 saat kilitlenir.
                            goto CEPBANK;
                        }
                    }
                ANAMENUHATALISAYI:
                    Console.WriteLine("Ana menü için 9\n" +
                                      "Çıkmak için   0");
                    anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                    if (anaMenuSecim == 9)
                    {
                        goto KARTSIZISLEMANAMENU;
                    }
                    else if (anaMenuSecim != 0)
                    {
                        Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                        goto ANAMENUHATALISAYI;
                    }
                }
                #endregion
                #region Para Yatirma
                else if (kartsizIslemSecim == 2)
                {
                    Console.WriteLine("Nakit Ödeme    1\n" +
                                      "Hesaptan Ödeme 2");
                    int kartsizParaYatirmaSecim = Convert.ToInt32(Console.ReadLine());
                    if (kartsizParaYatirmaSecim == 1) // Nakit Ödeme
                    {
                        Console.WriteLine("Kredi kartı numarasını giriniz");
                        string girilenKrediKartiNo = Console.ReadLine();
                        Console.WriteLine("TC Kimlik numarasını giriniz");
                        string girilenTCKimlikNo = Console.ReadLine();
                        if(girilenKrediKartiNo.Length != 12)
                        {
                            Console.WriteLine($"{girilenKrediKartiNo} kredi kartı 12 haneli değildir.");
                        }
                        else if (!(girilenKrediKartiNo.All(char.IsDigit))){
                            Console.WriteLine($"{girilenKrediKartiNo} kredi kartı sayılardan oluşmamaktadır.");
                        }
                        else if(girilenTCKimlikNo.Length != 11)
                        {
                            Console.WriteLine($"{girilenTCKimlikNo} TC kimlik numarası 11 haneli değildir.");
                        }
                        else if(girilenTCKimlikNo == TCKimlikNo && girilenKrediKartiNo == krediKartiNumarasi)
                        {
                            Console.WriteLine("Nakit ödenecek tutarı giriniz");
                            int kartsizNakitOdenecekMiktar = Convert.ToInt32(Console.ReadLine());
                            hesapBakiye += kartsizNakitOdenecekMiktar;
                            Console.WriteLine("Hesapta toplam bulunan tutar: " + hesapBakiye);
                        }
                        else
                        {
                            Console.WriteLine("Kredi kartı veya Kimlik no hatalı girilmiştir.");
                        }
                    }
                    else if (kartsizParaYatirmaSecim == 2) // Hesaptan Ödeme
                    {
                        Console.WriteLine("Kredi kartı numarasını giriniz");
                        string girilenKrediKartiNo = Console.ReadLine();
                        Console.WriteLine("Hesap numarasını giriniz");
                        string girilenHesapNo = Console.ReadLine();
                        if (girilenKrediKartiNo.Length != 12)
                        {
                            Console.WriteLine($"{girilenKrediKartiNo} kredi kartı 12 haneli değildir.");
                        }
                        else if (!(girilenKrediKartiNo.All(char.IsDigit)))
                        {
                            Console.WriteLine($"{girilenKrediKartiNo} kredi kartı sayılardan oluşmamaktadır.");
                        }
                        else if(girilenHesapNo.Length != 11){
                            Console.WriteLine($"{girilenHesapNo} Havale numarası toplam 11 haneli değildir.");
                        }
                        else if (girilenKrediKartiNo == krediKartiNumarasi)
                        {
                            Console.WriteLine("Nakit ödenecek tutarı giriniz");
                            int kartsizNakitOdenecekMiktar = Convert.ToInt32(Console.ReadLine());
                            hesapBakiye += kartsizNakitOdenecekMiktar;
                            Console.WriteLine("Hesapta toplam bulunan tutar: " + hesapBakiye);
                        }
                        else
                        {
                            Console.WriteLine("Kredi kartı veya Hesap no hatalı girilmiştir.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{kartsizParaYatirmaSecim} hatalı sayıdır, lütfen 1 veya 2 giriniz");
                    }
                ANAMENUHATALISAYI:
                    Console.WriteLine("Ana menü için 9\n" +
                                      "Çıkmak için   0");
                    anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                    if (anaMenuSecim == 9)
                    {
                        goto KARTSIZISLEMANAMENU;
                    }
                    else if (anaMenuSecim != 0)
                    {
                        Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                        goto ANAMENUHATALISAYI;
                    }
                }
                #endregion
                #region Kredi Karti Odeme
                else if (kartsizIslemSecim == 3)
                {
                    Console.WriteLine("Başka Hesaba EFT    1\n" +
                                      "Başka Hesaba Havale 2");
                    int kartsizParaTransferSecim = Convert.ToInt32(Console.ReadLine());
                    if (kartsizParaTransferSecim == 1) // EFT
                    {
                        Console.WriteLine("12 haneli EFT numarasını başında TR olarak giriniz");
                        string girilenEFTNumarasi = Console.ReadLine();

                        if (girilenEFTNumarasi.Length != 14)
                        {
                            Console.WriteLine($"{girilenEFTNumarasi} EFT numarası toplam 14 haneli değildir.");
                        }
                        else if (!(girilenEFTNumarasi.Substring(2).All(char.IsDigit)))
                        {
                            Console.WriteLine($"{girilenEFTNumarasi} EFT numarası sayılardan oluşmamaktadır.");
                        }
                        else if (girilenEFTNumarasi.ToLower().StartsWith("tr"))
                        {
                            Console.WriteLine("EFT yapılacak para miktarını giriniz");
                            int eftYapilacakParaMiktari = Convert.ToInt32(Console.ReadLine());
                            if (eftYapilacakParaMiktari > hesapBakiye)
                            {
                                Console.WriteLine($"{eftYapilacakParaMiktari} EFT para miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda EFT yapmayı deneyin.");
                            }
                            else
                            {
                                hesapBakiye -= eftYapilacakParaMiktari;
                                Console.WriteLine($"Hesaptan {eftYapilacakParaMiktari} TL kadar para EFT yapılmıştır ve hesapta kalan para {hesapBakiye} TL kadardır.");
                            }

                        }
                        else
                        {
                            Console.WriteLine($"{girilenEFTNumarasi} EFT numarası TR ile başlamıyordur.");
                        }
                    }
                    else if (kartsizParaTransferSecim == 2) // Havale
                    {
                        Console.WriteLine("11 haneli hesap numaranızı giriniz");
                        string girilenHesapNumarasi = Console.ReadLine();
                        if (girilenHesapNumarasi.Length != 11)
                        {
                            Console.WriteLine($"{girilenHesapNumarasi} Havale numarası toplam 11 haneli değildir.");
                        }
                        else if (girilenHesapNumarasi.All(char.IsDigit))
                        {
                            Console.WriteLine("Havale yapılacak para miktarını giriniz");
                            int havaleYapilacakParaMiktari = Convert.ToInt32(Console.ReadLine());
                            if (havaleYapilacakParaMiktari > hesapBakiye)
                            {
                                Console.WriteLine($"{havaleYapilacakParaMiktari} havale para miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda havale yapmayı deneyin.");
                            }
                            else
                            {
                                hesapBakiye -= havaleYapilacakParaMiktari;
                                Console.WriteLine($"Hesaptan {havaleYapilacakParaMiktari} TL kadar para havale yapılmıştır ve hesapta kalan para {hesapBakiye} TL kadardır.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{girilenHesapNumarasi} havale numarası sayılardan oluşmamaktadır.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı sayı girdiniz.");
                    }
                ANAMENUHATALISAYI:
                    Console.WriteLine("Ana menü için 9\n" +
                                      "Çıkmak için   0");
                    anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                    if (anaMenuSecim == 9)
                    {
                        goto KARTSIZISLEMANAMENU;
                    }
                    else if (anaMenuSecim != 0)
                    {
                        Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                        goto ANAMENUHATALISAYI;
                    }
                }
                #endregion
                #region Egitim Odemeleri
                else if (kartsizIslemSecim == 4)
                {
                    Console.WriteLine("Eğitim ödemeleri sayfası arızalıdır.");
                ANAMENUHATALISAYI:
                    Console.WriteLine("Ana menü için 9\n" +
                                      "Çıkmak için   0");
                    anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                    if (anaMenuSecim == 9)
                    {
                        goto KARTSIZISLEMANAMENU;
                    }
                    else if (anaMenuSecim != 0)
                    {
                        Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                        goto ANAMENUHATALISAYI;
                    }
                }
                #endregion
                #region Odemeler
                else if (kartsizIslemSecim == 5)
                {
                    Console.WriteLine("Elektrik Faturası 1\n" +
                                      "Telefon Faturası  2\n" +
                                      "İnternet Faturası 3\n" +
                                      "Su Faturası       4\n" +
                                      "OGS Ödemeleri     5");
                    int kartsizFaturaSecim = Convert.ToInt32(Console.ReadLine());
                    int yatirilacakFaturaMiktari = 0;
                    if (kartsizFaturaSecim == 1) // Elektrik Faturası
                    {
                        Console.WriteLine("Yatıralacak para miktarını giriniz");
                        yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                        if (hesapBakiye > yatirilacakFaturaMiktari)
                        {
                            hesapBakiye -= yatirilacakFaturaMiktari;
                            Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında elektrik faturası ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                        }
                        else
                        {
                            Console.WriteLine($"{yatirilacakFaturaMiktari} fatura miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                        }

                    }
                    else if (kartsizFaturaSecim == 2) // Telefon Faturası
                    {
                        Console.WriteLine("Yatıralacak para miktarını giriniz");
                        yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                        if (hesapBakiye > yatirilacakFaturaMiktari)
                        {
                            hesapBakiye -= yatirilacakFaturaMiktari;
                            Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında telefon faturası ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                        }
                        else
                        {
                            Console.WriteLine($"{yatirilacakFaturaMiktari} fatura miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                        }
                    }
                    else if (kartsizFaturaSecim == 3) // İnternet Faturası
                    {
                        Console.WriteLine("Yatıralacak para miktarını giriniz");
                        yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                        if (hesapBakiye > yatirilacakFaturaMiktari)
                        {
                            hesapBakiye -= yatirilacakFaturaMiktari;
                            Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında internet faturası ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                        }
                        else
                        {
                            Console.WriteLine($"{yatirilacakFaturaMiktari} fatura miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                        }
                    }
                    else if (kartsizFaturaSecim == 4) // Su Faturası
                    {
                        Console.WriteLine("Yatıralacak para miktarını giriniz");
                        yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                        if (hesapBakiye > yatirilacakFaturaMiktari)
                        {
                            hesapBakiye -= yatirilacakFaturaMiktari;
                            Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında su faturası ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                        }
                        else
                        {
                            Console.WriteLine($"{yatirilacakFaturaMiktari} fatura miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                        }
                    }
                    else if (kartsizFaturaSecim == 5) // OGS Ödemeleri
                    {
                        Console.WriteLine("Yatıralacak para miktarını giriniz");
                        yatirilacakFaturaMiktari = Convert.ToInt32(Console.ReadLine());
                        if (hesapBakiye > yatirilacakFaturaMiktari)
                        {
                            hesapBakiye -= yatirilacakFaturaMiktari;
                            Console.WriteLine($"{yatirilacakFaturaMiktari} tutarında OGS ödenmiştir. Hesapta toplamda {hesapBakiye} TL kalmıştır.");
                        }
                        else
                        {
                            Console.WriteLine($"{yatirilacakFaturaMiktari} OGS miktarı hesaptaki para miktarı {hesapBakiye}'den büyüktür. Lütfen daha az miktarda fatura yatırmayı deneyin.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı sayı girdiniz. Lütfen 1 ile 5 arasında rakam giriniz.");
                    }
                ANAMENUHATALISAYI:
                    Console.WriteLine("Ana menü için 9\n" +
                                      "Çıkmak için   0");
                    anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                    if (anaMenuSecim == 9)
                    {
                        goto KARTSIZISLEMANAMENU;
                    }
                    else if (anaMenuSecim != 0)
                    {
                        Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                        goto ANAMENUHATALISAYI;
                    }
                }
                #endregion
                else // Kartsız İşlem Ana Menü hatalı sayı girişi
                {
                    Console.WriteLine($"{kartsizIslemSecim} sayısı hatalıdır. Lütfen 1 ile 5 arasında rakam giriniz.");
                ANAMENUHATALISAYI:
                    Console.WriteLine("Ana menü için 9\n" +
                                      "Çıkmak için   0");
                    anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                    if (anaMenuSecim == 9)
                    {
                        goto KARTSIZISLEMANAMENU;
                    }
                    else if (anaMenuSecim != 0)
                    {
                        Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                        goto ANAMENUHATALISAYI;
                    }
                }
            }
            #endregion
            else // Başlangıç hatalı sayı girişi
            {
                Console.WriteLine("Hatalı sayı girdiniz, lütfen 1 veya 2 giriniz");
                ANAMENUHATALISAYI:
                Console.WriteLine("Ana menü için 9\n" +
                                  "Çıkmak için   0");
                anaMenuSecim = Convert.ToInt32(Console.ReadLine());
                if (anaMenuSecim == 9)
                {
                    goto BASLANGIC; ;
                }else if(anaMenuSecim != 0)
                {
                    Console.WriteLine("Lütfen çıkmak için 0 rakamını giriniz");
                    goto ANAMENUHATALISAYI;
                }
            }
            
        }
    }
}
