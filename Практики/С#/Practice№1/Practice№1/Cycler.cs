using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_1
{
    class Cycler
    {
        private const int destination = 10000;
        private static int countCyclist;
        private static int countRaceCyclist;
        private string name;
        private string surname;
        private int age;
        private string country;
        private Bicycle[] bicycle = new Bicycle[5];
        private int countBicycle = 0;
        private int averageSpeed;
        private bool OnRace = false;

        public int Age { get => age; set => age = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Name { get => name; set => name = value; }
        public string Country { get => country; set => country = value; }

        private Cycler()
        {
            Console.WriteLine("Участник добавлен");
            countCyclist++;
        }
        public Cycler(string Name, string Surname, int Age, string Country, string NameBike, int MaxSpeedBike, int PriceBike, int AverageSpeed) : this(Surname, Age, Country, NameBike, MaxSpeedBike, PriceBike, AverageSpeed)
        {
            this.Name = Name;
        }
        private Cycler(string Surname, int Age, string Country, string NameBike, int MaxSpeedBike, int PriceBike, int AverageSpeed) : this(Age, Country, NameBike, MaxSpeedBike, PriceBike, AverageSpeed)
        {
            this.Surname = Surname;
        }

        private Cycler(int Age, string Country, string NameBike, int MaxSpeedBike, int PriceBike, int AverageSpeed) : this(Country, NameBike, MaxSpeedBike, PriceBike, AverageSpeed)
        {
            this.Age = Age;
        }

        private Cycler(string Country, string NameBike, int MaxSpeedBike, int PriceBike, int AverageSpeed) : this(NameBike, MaxSpeedBike, PriceBike, AverageSpeed)
        {
            this.Country = Country;
        }
        private Cycler(string NameBike, int MaxSpeedBike, int PriceBike, int AverageSpeed) : this(AverageSpeed)
        {
            bicycle[countBicycle] = new Bicycle(NameBike, MaxSpeedBike, PriceBike);

            countBicycle++;
        }
        private Cycler(int AverageSpeed) : this()
        {

            this.averageSpeed = AverageSpeed;
        }

        public static void ShowCountCyclist()
        {
            Console.WriteLine("Участников гонки " + countCyclist);

        }

        public void GoIn()
        {
            if (this.OnRace == false)
            {
                countRaceCyclist++;
                this.OnRace = true;
            }
            else
            {
                Console.WriteLine("Велосипедист уже на трассе");
            }
            Console.WriteLine($"Количество участников на трассе {countRaceCyclist}");

        }

        public void GoOut()
        {
            if (this.OnRace == true)
            {
                countRaceCyclist--;
                this.OnRace = false;
            }
            else
            {
                Console.WriteLine("Велосипедист уже не на трассе");
            }
            Console.WriteLine($"Количество участников на трассе {countRaceCyclist}");

        }

        public void AddBicycle(string Name, int MaxSpeed, int Price)
        {
            if (countBicycle == 5)
            {
                Console.WriteLine("Нельзя добавить новые велосипеды");
            }
            else
            {
                bicycle[countBicycle] = new Bicycle(Name, MaxSpeed, Price);
                countBicycle++;
            }

        }
        public void ShowCycleArray()
        {

            Console.WriteLine($"Имя и Фамилия {this.Name} {this.Surname} \n Возраст {this.Age} \n Страна {this.Country} \n Велосипеды ");
            for (int i = 0; i < countBicycle; i++)
            {
                ShowBicycle(bicycle[i]);
            }

        }

        public double Finish()
        {
            this.GoOut();
            return (destination / Math.Pow(Age, 2)) / (bicycle[0].MaxSpeed * averageSpeed);


        }

        void ShowBicycle(Bicycle BikeName)
        {
            Console.WriteLine($"Название {BikeName.Name}  Скорость {BikeName.MaxSpeed} Цена {BikeName.Price}");

        }
    }
}
