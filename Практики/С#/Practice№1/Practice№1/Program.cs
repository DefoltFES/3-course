using System;

namespace Practice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cycler [] CyclerList = new Cycler[5];
            CyclerList[0] = new Cycler("Эмиль","Миронов",20,"Россия", "GHOST LECTOR 2.9 LC U 29",185,150000,90);
            CyclerList[1] = new Cycler("Дамир", "Федотов", 22, "Англия", "Bahrain-Merida", 165, 180000, 100);
            CyclerList[2] = new Cycler("Вася", "Ле пупкин", 21, "Франция", "Bora-Hansgrohe", 105, 190000, 60);
            CyclerList[3] = new Cycler("Герман", "Стерлигов", 20, "Германия", "Deceuninck Quick-Step", 125, 250000, 80);
            CyclerList[4] = new Cycler("Шмелев", "Илья", 23, "Казахстан", "Astana Pro Team", 155, 250000, 70);

            Cycler.ShowCountCyclist();
            for (int i =0; i<CyclerList.Length;i++)
            {
                CyclerList[i].GoIn();
            }
            CyclerList[1].GoOut();

            CyclerList[0].AddBicycle("Eddy Merckx", 80,100000 );

            for (int i = 0; i < CyclerList.Length; i++)
            {
                CyclerList[i].ShowCycleArray();
            }

            for (int i =0;i<CyclerList.Length;i++)
            {
               Console.WriteLine($"Велосипедист {CyclerList[i].Name} прошел дистанцию за {CyclerList[i].Finish()}");
            }
            

           
            
        }
    }
}
                       