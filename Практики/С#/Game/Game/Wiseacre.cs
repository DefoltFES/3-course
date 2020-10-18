using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Wiseacre : Hero
    {
        private int illumination;

        public int Illumination { get => illumination; set => illumination = value; }
        public Wiseacre(string name, int weight, string color, int power, int intellegence, int agility, int height, int illumination) : base(name, weight, color, power, intellegence, agility, height)
        {
            this.Illumination = illumination;
        }

        public double MagicAttack()
        {
            this.Agility -= 10;
            return this.Punch() + illumination;
        }

        public void HealthHero(Hero hero)
        {
            hero.Power += 5;
            Console.WriteLine($"{this.Name} лечит героя {hero.Name}");
        }


    }
}
