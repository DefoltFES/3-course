using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_1
{
    class Cycler
    {
        private static int countCyclist;
        private static int countRaceCyclist;
        private string name;
        private string surname;
        private int age;
        private string country;
        private static Bicycle[] bicycle=new Bicycle[5];
        private Bicycle personalBicycle;
        private static int CountBicycle=0;
        private int averageSpeed;


        private Cycler()
        {
            countCyclist++;
        }
        public Cycler(string Name, string Surname, int Age, string Country, Bicycle NewBicycle, int AverageSpeed) :this(Surname,  Age,  Country, NewBicycle, AverageSpeed)
        {
            this.name = Name;
        }
        private Cycler(string Surname, int Age,  string Country, Bicycle NewBicycle, int AverageSpeed) : this( Age, Country, NewBicycle, AverageSpeed)
        {
            this.surname = Surname;
        }

        private Cycler(int Age,string Country, Bicycle NewBicycle, int AverageSpeed) : this(Country, NewBicycle, AverageSpeed)
        {
            this.age = Age;
        }

        private Cycler(string Country, Bicycle NewBicycle, int AverageSpeed) : this(NewBicycle, AverageSpeed)
        {
            this.country = Country;
        }
        private Cycler(Bicycle NewBicycle, int AverageSpeed) : this(AverageSpeed)
        {
            bicycle[CountBicycle]= NewBicycle;
            this.personalBicycle = NewBicycle;
            CountBicycle++;
        }
        private Cycler(int AverageSpeed) : this()
        {
            
            this.averageSpeed = AverageSpeed;
        }

        public void ShowCountCyclist()
        {
            Console.WriteLine("Участников гонки "+ countCyclist);
        }

        public void GoIn()
        {
            countRaceCyclist++;
            Console.WriteLine($"Количество участников в гонке {countRaceCyclist}");

        }

        public void GoOut()
        {
            countRaceCyclist--;
            Console.WriteLine($"Количество участников в гонке {countRaceCyclist}");

        }

        public void AddBicycle(Bicycle NewBicycle)
        {
            if (CountBicycle == 4) 
            {

                Console.WriteLine("Нельзя добавить новые велосипеды");
            }
            else
            {

                bicycle[CountBicycle] = NewBicycle;
                CountBicycle++;
            }
           
        }

        public void Finish(Cycler [] CyclerArray)
        {
            foreach(var b in CyclerArray)
            {
                Console.WriteLine($"Время пройденное велосипидистом {b.name} равно {(10000/Math.Pow(b.age,2))/(b.personalBicycle.)}");
            }
        }


    }
}
