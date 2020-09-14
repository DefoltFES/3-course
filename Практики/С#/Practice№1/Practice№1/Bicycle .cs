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
            this.name = NewName;
            this.maxSpeed = NewMaxSpeed;
            this.price = NewPrice;

        }
    }
}
