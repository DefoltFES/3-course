using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_1
{
    class Bicycle
    {
        private string name;
        private int maxSpeed;
        private int price;

        public Bicycle(string NewName,int NewMaxSpeed,int NewPrice)
        {
            this.Name = NewName;
            this.MaxSpeed = NewMaxSpeed;
            this.Price = NewPrice;

        }
       

        public string Name { get => name; private set => name = value; }
        public int Price { get => price; private set => price = value; }
        public int MaxSpeed { get => maxSpeed; private set => maxSpeed = value; }
    }

}
