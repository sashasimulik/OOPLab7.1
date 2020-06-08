using System;
using System.Collections;

namespace OOPLab7._1
{
    public class System : IComparable
    {
        public string Name;
        public string Provider;
        public int Number_of_versions;
        public int Price;
        public double Year;

        public System() { }

        public System(string Name, string Provider, int Number_of_versions, int Price, double Year)
        {
            this.Name = Name;
            
            this.Provider = Provider;
            this.Number_of_versions = Number_of_versions;
            this.Price = Price;
            this.Year = Year;
        }

        int IComparable.CompareTo(object obj)
        {
            System h = obj as System;
            if (h != null)
            {
                if (this.Price < h.Price)
                    return -1;
                else if (this.Price > h.Price)
                    return 1;
                else
                    return 0;
            }
            else
            {
                throw new Exception("Параметр повинен бути типу System!");
            }
        }

        public class SortByPrice : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                System h1 = (System)x;
                System h2 = (System)y;
                if (h1.Price < h2.Price)
                    return -1;
                else if (h1.Price > h2.Price)
                    return 1;
                else
                    return 0;
            }
        }

        public class SortByYear : IComparer
        {
            public int Compare(object x, object y)
            {
                System h1 = (System)x;
                System h2 = (System)y;
                if (h1.Year < h2.Year)
                    return -1;
                else if (h1.Year > h2.Year)
                    return 1;
                else
                    return 0;
            }
        }
    }

    class Systems : IEnumerable
    {
        private System[] _systems;
        public Systems(System[] hs)
        {
            _systems = new System[hs.Length];
            for (int i = 0; i < hs.Length; i++)
                _systems[i] = hs[i];
        }

        public SystemsEnum GetEnumerator()
        {
            return new SystemsEnum(_systems);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public class SystemsEnum : IEnumerator
        {
            public System[] _systems;

            int position = -1;

            public SystemsEnum(System[] list)
            {
                _systems = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _systems.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public System Current
            {
                get
                {
                    try
                    {
                        return _systems[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            System s1 = new System("System 1", "Microsoft corp.", 13, 59, 2011);
            System s2 = new System("System 2", "Apple corp.", 1, 99, 2009);
            System s3 = new System("System 3", "Ubuntu corp.", 9, 0, 2018);
            System s4 = new System("System 4", "Google corp.", 20, 19, 2020);
            System s5 = new System("System 5", "Amazon corp.", 3, 159, 2010);
            System s6 = new System("System 6", "Adobe corp.", 5, 199, 2019);
            System s7 = new System("System 7", "Linux corp.", 2, 0, 2020);
            System s8 = new System("System 8", "Xiaomi corp.", 8, 13, 2015);
            System s9 = new System("System 9", "LG corp.", 3, 299, 2018);
            System s10 = new System("System 10", "Huawei corp.", 1, 49, 2020);

            System[] systems = new System[10];
            systems[0] = s1;
            systems[1] = s2;
            systems[2] = s3;
            systems[3] = s4;
            systems[4] = s5;
            systems[5] = s6;
            systems[6] = s7;
            systems[7] = s8;
            systems[8] = s9;
            systems[9] = s10;

            string prn01 = "Назва:\t\tВиробник:\t\tКiлькiсть версiй:\tЦiна ($):\tРiк випуску:";

            Console.WriteLine("Список без сортування");
            Console.WriteLine(prn01);
            for (int i = 0; i < systems.Length; i++)
                Console.WriteLine(systems[i].Name + "\t" + systems[i].Provider + "\t\t" + systems[i].Number_of_versions + "\t\t\t" + systems[i].Price + "\t\t" + systems[i].Year);

            while (true)
            {
                Console.WriteLine("\nНатиснiть на одну з вказаних клавiш, щоб вибрати режим роботи: ");
                Console.WriteLine("Реалiзацiя iнтерфейсу  IComparable для порiвняння систем за цiною  - 1");
                Console.WriteLine("Реалiзацiя в класi iнтерфейсу IComparer для порiвняння систем за цiною i за роком випуску - 2");
                Console.WriteLine("Реалiзацiя iнтерфейсу IEnumerable - 3");
                Console.WriteLine("Вихiд з програми - будь-яка iнша клавiша");

                ConsoleKeyInfo cki;
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.NumPad1)
                {
                    Array.Sort(systems);
                    Console.WriteLine("\nСортування за цiною");
                    Console.WriteLine(prn01);
                    for (int i = 0; i < systems.Length; i++)
                        Console.WriteLine(systems[i].Name + "\t" + systems[i].Provider + "\t\t" + systems[i].Number_of_versions + "\t\t\t" + systems[i].Price + "\t\t" + systems[i].Year);
                }
                else if (cki.Key == ConsoleKey.NumPad2)
                {
                    Array.Sort(systems, new System.SortByPrice());
                    Console.WriteLine("\nСортування за цiною");
                    Console.WriteLine(prn01);
                    for (int i = 0; i < systems.Length; i++)
                        Console.WriteLine(systems[i].Name + "\t" + systems[i].Provider + "\t\t" + systems[i].Number_of_versions + "\t\t\t" + systems[i].Price + "\t\t" + systems[i].Year);

                    Array.Sort(systems, new System.SortByYear());
                    Console.WriteLine("\nСортування за роком");
                    Console.WriteLine(prn01);
                    for (int i = 0; i < systems.Length; i++)
                        Console.WriteLine(systems[i].Name + "\t" + systems[i].Provider + "\t\t" + systems[i].Number_of_versions + "\t\t\t" + systems[i].Price + "\t\t" + systems[i].Year);
                }
                else if (cki.Key == ConsoleKey.NumPad3)
                {
                    Array.Sort(systems, new System.SortByPrice());
                    Systems SystemCollections01 = new Systems(systems);

                    Console.WriteLine("\nСортування за цiною");
                    Console.WriteLine(prn01);
                    foreach (var system in SystemCollections01)
                        Console.WriteLine(system.Name + "\t" + system.Provider + "\t\t" + system.Number_of_versions + "\t\t\t" + system.Price + "\t\t" + system.Year);

                    Array.Sort(systems, new System.SortByYear());
                    Systems SystemCollections02 = new Systems(systems);

                    Console.WriteLine("\nСортування за площею");
                    Console.WriteLine(prn01);
                    foreach (var system in SystemCollections02)
                        Console.WriteLine(system.Name + "\t" + system.Provider + "\t\t" + system.Number_of_versions + "\t\t\t" + system.Price + "\t\t" + system.Year);
                }
                else
                    break;
            }
        }
    }
}

