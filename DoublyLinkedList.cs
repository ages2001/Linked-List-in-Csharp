using System;

namespace StudentDoublyLinkedList
{
    class DoublyLinkedList
    {
        class Node
        {
            public Student studentData;
            public Node prev;
            public Node next;

            public Student getStudentData()
            {
                return studentData;
            }

            public void setStudentData(Student studentData)
            {
                this.studentData = studentData;
            }

            public Node getPrev()
            {
                return prev;
            }

            public void setPrev(Node prev)
            {
                this.prev = prev;
            }

            public Node getNext()
            {
                return next;
            }

            public void setNext(Node next)
            {
                this.next = next;
            }

            public Node(Student studentData)
            {
                setStudentData(studentData);
                setPrev(null);
                setNext(null);
            }

            public Node(Student studentData, Node prev, Node next)
            {
                setStudentData(studentData);
                setPrev(prev);
                setNext(next);
            }

        }

        private Node head = null;
        private Node tail = null;

        public Boolean isEmpty()
        {
            return head == null;
        }

        public void addStudent(Student ogrenci)
        { 
            Node newCurrent = new Node(ogrenci);

            if (isEmpty())
            {
                head = newCurrent;
                tail = newCurrent;
                return;
            }

            Node current = head;

            while (current != null)
            {
                if (ogrenci.getOgrenciNo() > current.getStudentData().getOgrenciNo())
                {
                    current = current.getNext();
                }

                else
                {
                    if (current == head)
                    {
                        Node newCurrent2 = new Node(ogrenci, null, head);
                        head.setPrev(newCurrent2);
                        head = newCurrent2;
                    }

                    else
                    {
                        Node newCurrent2 = new Node(ogrenci, current.getPrev(), current);
                        current.getPrev().setNext(newCurrent2);
                        current.setPrev(newCurrent2);
                    }

                    return;

                }

            }

            Node newCurrent3 = new Node(ogrenci, tail, null);
            tail.setNext(newCurrent3);
            tail = newCurrent3;

        }

        public void findStudent(string adSoyad)
        {
            Node current = head;
            int count = 0;

            if (isEmpty())
            {
                Console.WriteLine("\nOgrenci listesi bos! ");
                return;
            }

            while (current != null)
            {

                if (current.getStudentData().getOgrenciAdSoyad().Equals(adSoyad))
                {
                    count++;
                    Console.WriteLine("\nBulunan ogrenci " + count + ": ");
                    Console.WriteLine("--------------------");
                    Console.WriteLine(current.getStudentData());
                }

                current = current.getNext();

            }

            if (count == 0)
            {
                Console.WriteLine("\nOgrenci bulunamadi! ");
            }

            else
            {
                Console.WriteLine("\nBulunan ogrenci sayisi: " + count);
            }

        }

        public void deleteStudent(int no)
        {
            if (isEmpty())
            {
                Console.WriteLine("\nOgrenci listesi bos! ");
                return;
            }

            Node current = head;

            while (current != null)
            {
                if (current.getStudentData().getOgrenciNo() == no)
                {
                    break;
                }

                current = current.getNext();

            }

            if (current == null)
            {
                Console.WriteLine("\nOgrenci bulunamadi! ");
                return;
            }

            if (current == head && current == tail)
            {
                head = null;
                tail = null;
            }

            else if (current == head)
            {
                current.getNext().setPrev(null);
                head = current.getNext();
            }

            else if (current == tail)
            {
                current.getPrev().setNext(null);
                tail = current.getPrev();
            }

            else
            {
                current.getPrev().setNext(current.getNext());
                current.getNext().setPrev(current.getPrev());
                current = null;
            }            

            Console.WriteLine("\nOgrenci basariyla kaldirildi! ");

        }

        public void sortStudents(DoublyLinkedList ogrenciListesi)
        {
            if (isEmpty())
            {
                Console.WriteLine("Ogrenci listesi bos! ");
                return;
            }

            Node current = head;
            int count = 0;

            while (current != null)
            {
                count++;
                Console.WriteLine("\nOgrenci " + count + ": ");
                Console.WriteLine("--------------------");
                Console.WriteLine(current.getStudentData());
                current = current.getNext();

            }

        }

        public void reverseSortStudents(DoublyLinkedList ogrenciListesi)
        {
            if (isEmpty())
            {
                Console.WriteLine("Ogrenci listesi bos! ");
                return;
            }

            Node current = tail;
            int count = 0;

            while (current != null)
            {
                count++;
                Console.WriteLine("\nOgrenci " + count + ": ");
                Console.WriteLine("--------------------");
                Console.WriteLine(current.getStudentData());
                current = current.getPrev();

            }

        }

    }
}
