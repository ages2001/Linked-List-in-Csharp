using System;
using System.IO;

namespace StudentDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Programa hosgeldiniz! \n"
                + " Lutfen asagidaki islemlerden birini seciniz: \n\n"
                + " 1 - Bir dosyadan ogrencileri ekleyin \n"
                + " 2 - Ogrenciyi tum bilgilerini yazarak ekleyin \n"
                + " 3 - Ad - Soyad ile ogrenci bulun \n"
                + " 4 - Ogrenci no girerek listeden ogrenci kaldirin \n"
                + " 5 - Ogrenci no artacak sekilde ogrencileri sirali yazdirin \n"
                + " 6 - Ogrenci no azalacak sekilde ogrencileri sirali yazdirin \n"
                + " 7 - Programdan cikin \n");

            int islem;
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            while (true)
            {
                Console.Write("\nLutfen islem seciniz (1-7): ");
                islem = Convert.ToInt32(Console.ReadLine());

                Console.Write("\n");

                switch (islem)
                {

                    case 1:

                        int ogrNoEkle;
                        string ogrAdSoyadEkle;
                        var file = new StreamReader(@"ogrenciler.txt");
                        string line;

                        while ((line = file.ReadLine()) != null)
                        {

                            string[] veriler = line.Split(',');

                            ogrNoEkle = Convert.ToInt32(veriler[0]);
                            ogrAdSoyadEkle = veriler[1];

                            Student ogrEkle = new Student(ogrNoEkle, ogrAdSoyadEkle);

                            for (int i = 2; i < veriler.Length; i++)
                            {
                                ogrEkle.telNoEkle(veriler[i]);
                            }

                            doublyLinkedList.addStudent(ogrEkle);

                        }

                        Console.WriteLine("Ogrenciler dosyadan basariyla eklendi! ");

                        break;

                    case 2:

                        int ogrenciNo;
                        string ogrenciAdSoyad, telNo;

                        Console.Write("Ogrencinin no giriniz: ");
                        ogrenciNo = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Ogrencinin ad-soyad giriniz: ");
                        ogrenciAdSoyad = Console.ReadLine();

                        Console.Write("Ogrencinin tel no giriniz (Birden fazla varsa ',' ile ayiriniz: ");
                        telNo = Console.ReadLine();

                        Student ogrenci = new Student(ogrenciNo, ogrenciAdSoyad);

                        string[] telNoList = telNo.Split(',');

                        foreach (string ogrenciTelNo in telNoList)
                        {
                            ogrenci.telNoEkle(ogrenciTelNo);
                        }

                        doublyLinkedList.addStudent(ogrenci);

                        Console.WriteLine("\nOgrenci basariyla eklendi! ");

                        break;

                    case 3:

                        string adSoyad;

                        Console.Write("Bulunacak ogrencinin ad-soyad giriniz: ");
                        adSoyad = Console.ReadLine();

                        doublyLinkedList.findStudent(adSoyad);

                        break;

                    case 4:

                        int ogrNo;

                        Console.Write("Silinecek ogrencinin ogrenci no giriniz: ");
                        ogrNo = Convert.ToInt32(Console.ReadLine());

                        doublyLinkedList.deleteStudent(ogrNo);

                        break;

                    case 5:

                        doublyLinkedList.sortStudents(doublyLinkedList);

                        break;

                    case 6:

                        doublyLinkedList.reverseSortStudents(doublyLinkedList);

                        break;

                    case 7:

                        Console.WriteLine("Programi kullandiginiz icin tesekkurler! ");
                        Console.WriteLine("Programdan cikiliyor... \n");
                        Environment.Exit(0);
                        break;

                    default:

                        Console.WriteLine("Gecersiz islem! ");
                        break;

                }

            }

        }
    }
}
