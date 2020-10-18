using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Trickster : Hero
    {
        private int stealth;
        public int Stealth { get => stealth; set => stealth = value; }

        public Trickster(string name, int weight, string color, int power, int intellegence, int agility, int height, int stealth) : base(name, weight, color, power, intellegence, agility, height)
        {
            this.Stealth = stealth;
        }

        public void Invisible()
        {
            this.Stealth *= 2;
            this.Agility -= 5;
            Console.WriteLine($"{this.Name} стал невидимым");
        }



        public double StealthPunch()
        {
            if (this.Stealth > 20)
            {
                this.Power += 5;
                return this.Punch();
            }
            else
            {
                return 0;
            }
        }



    }
}
