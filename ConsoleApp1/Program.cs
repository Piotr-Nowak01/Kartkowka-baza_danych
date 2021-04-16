using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{    class student
    {
        public int ID { set; get; }
        public string Imie { set; get; }
        public string Nazwisko { set; get; }
    }
    class Studenty : DbContext
    {
        public virtual DbSet<student> studenty { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var baza = new Studenty();
            student s1 = new student { Imie = "Adam", Nazwisko = "Kowal" };         
            student s2 = new student { Imie = "Ewa", Nazwisko = "Nowak" };
            baza.studenty.Add(s1);
            baza.studenty.Add(s2);
            baza.SaveChanges();
            var war = (from v in baza.studenty select v).ToList<student>();
            foreach (var x in war)
            {
                Console.Write("ID: "+x.ID.ToString());
                Console.Write(" Imie: "+x.Imie);
                Console.Write(" Nazwisko: " + x.Nazwisko);
            }
            Console.Read();
        }
    }
}
