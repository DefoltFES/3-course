using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class StrongMan : Hero
    {
        private int rage;

        public StrongMan(string name, int weight, string color, int power, int intellegence, int agility, int height, int rage) : base(name, weight, color, power, intellegence, agility, height)
        {
            Rage = rage;
        }

        public int Rage { get => rage; set => rage = value; }

        public double RageAttack()
        {
            this.Intellegence -= 5;
            return this.Punch() + this.Rage * 2;

        }

        public void RageArt()
        {
            this.Rage += 3;
            this.Power -= 2;
            Console.WriteLine($"Силач {this.Name} в Ярости");
        }

        public void DefenceHero(Hero hero)
        {
            Console.WriteLine($"{this.Name} защищает {hero.Name}");
        }




    }
}
