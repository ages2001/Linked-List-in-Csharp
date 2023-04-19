using System;
using System.Collections;

namespace StudentDoublyLinkedList
{
    class Student
    {
        private int ogrenciNo;
        private string ogrenciAdSoyad;
        private ArrayList telNoBilgileri;

        public int getOgrenciNo()
        {
            return this.ogrenciNo;
        }

        public void setOgrenciNo(int ogrenciNo)
        {
            this.ogrenciNo = ogrenciNo;
        }

        public string getOgrenciAdSoyad()
        {
            return this.ogrenciAdSoyad;
        }

        public void setOgrenciAdSoyad(string ogrenciAdSoyad)
        {
            this.ogrenciAdSoyad = ogrenciAdSoyad;
        }

        public string getTelNoBilgileri()
        {
            string telNo = "";

            foreach (string telNoBilgisi in this.telNoBilgileri)
            {
                telNo += "\n" + telNoBilgisi;
            }

            return telNo;

        }

        public void setTelNoBilgileri(ArrayList telNoBilgileri)
        {
            this.telNoBilgileri = telNoBilgileri;
        }

        public Student()
        {
            setOgrenciAdSoyad(null);
            setTelNoBilgileri(null);
        }

        public Student(int ogrenciNo, string ogrenciAdSoyad)
        {
            setOgrenciNo(ogrenciNo);
            setOgrenciAdSoyad(ogrenciAdSoyad);
            setTelNoBilgileri(new ArrayList());
        }

        public Student(Student copyStudent)
        {
            setOgrenciNo(copyStudent.ogrenciNo);
            setOgrenciAdSoyad(copyStudent.ogrenciAdSoyad);
            setTelNoBilgileri(new ArrayList());

            foreach (string telNo in copyStudent.telNoBilgileri)
            {
                this.telNoBilgileri.Add(telNo);
            }

        }

        public void telNoEkle(String telNo)
        { 
            this.telNoBilgileri.Add(telNo);
        }

        override public string ToString()
        {
            return "\nOgrenci ad-soyad: " + getOgrenciAdSoyad() + "\nOgrenci no: " + getOgrenciNo() + "\nOgrenci Tel No: " + getTelNoBilgileri();
        }

    }
}
