using System;
using System.IO;
using System.Text;
namespace KundenNew
{
    class Program
    {
        static string path = "kunden.csv";

        public struct Person
        {
            public string FirstName;
            public string LastName;
            public string Country;
            public int Sales;
            public double TaxPercentage;
            public double Taxes;
            public string Curreny;
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            Person[] persons = new Person[lines.Length];

            ReadFile(lines, persons);
            Print(persons);
            Console.ReadKey();
            RandomNumbers(persons, random);
            BubbleSort(persons);
            SaveData(persons, lines);
            Print(persons);
            Console.ReadKey();
        }

        private static void SaveData(Person[] persons, string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = persons[i].FirstName + ";" + persons[i].LastName + ";" + persons[i].Country + ";" + persons[i].Sales + ";" + persons[i].TaxPercentage + ";" + persons[i].Taxes + ";" + persons[i].Curreny;
            } 
            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        private static void BubbleSort(Person[] persons)
        {
            for (int i = 0; i < persons.Length; i++)
            {
                for (int j = 0; j < persons.Length - i - 1; j++)
                {
                    if (persons[j].Sales < persons[j + 1].Sales)
                    {
                        Person temp = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j + 1] = temp;
                    }
                }
            }
        }

        private static void RandomNumbers(Person[] persons, Random random)
        {
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i].Sales = random.Next(1, 101);
            }
        }

        private static void Print(Person[] persons)
        {
            Console.Clear();
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", "FirstName", "LastName", "Country", "Sales", "TaxPercentage", "Taxes");
            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", persons[i].FirstName, persons[i].LastName, persons[i].Country, persons[i].Sales + " " + persons[i].Curreny, persons[i].TaxPercentage + " " + "%", persons[i].Taxes + " " + persons[i].Curreny);
            }
        }

        private static void ReadFile(string[] lines, Person[] persons)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                persons[i].FirstName = parts[0];
                persons[i].LastName = parts[1];
                persons[i].Country = parts[2];
                persons[i].Sales = Convert.ToInt32(parts[3]);
                persons[i].TaxPercentage = Convert.ToDouble(parts[4]);
                persons[i].Taxes = Convert.ToDouble(parts[5]);
                persons[i].Curreny = parts[6];
            }
        }
    }
}
