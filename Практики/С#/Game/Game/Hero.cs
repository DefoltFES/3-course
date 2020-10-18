using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Game
{
    class Hero
    {
        private string name;
        private int weight;
        private int height;
        private string color;
        private int power;
        private int intellegence;
        private int agility;
        private static int countHeroes = 0;

        public string Name { get => name; set => name = value; }
        public int Weight { get => weight; set => weight = value; }
        public int Power { get => power; set => power = value; }
        public int Intellegence { get => intellegence; set => intellegence = value; }
        public int Agility { get => agility; set => agility = value; }
        public string Color { get => color; set => color = value; }
        public int Height { get => height; set => height = value; }

        public Hero(string name, int weight, string color, int power, int intellegence, int agility, int height)
        {
            this.Name = name;
            this.Weight = weight;
            this.Color = color;
            this.Power = power;
            this.Intellegence = intellegence;
            this.Agility = agility;
            this.Height = height;
            if (countHeroes >= 10)
            {
                Console.WriteLine("Уоу, уоу, остуди свой компьютер, он уже нагрет");
                countHeroes--;
                this.Name = "";
                this.Weight = 0;
                this.Color = "";
                this.Power = 0;
                this.Intellegence = 0;
                this.Agility = 0;
                this.Height = 0;
            }
            else
            {
                countHeroes++;
            }
        }




        public double Punch()
        {
            return (this.Power + this.Intellegence + this.Agility) / this.Weight * this.Height;
        }

    }
}
