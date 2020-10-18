using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Wiseacre character1 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);
            Trickster character2 = new Trickster("Хант", 45, "Зеленный", 25, 65, 45, 185, 15);
            StrongMan character3 = new StrongMan("Варвар", 45, "Синий", 20, 65, 45, 185, 36);
            //Wiseacre PowerMan4 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);
            //Wiseacre PowerMan5 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);
            //Wiseacre PowerMan6 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);
            //Wiseacre PowerMan7 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);
            //Wiseacre PowerMan8 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);
            //Wiseacre PowerMan9 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);
            //Wiseacre PowerMa10 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);
            //Wiseacre PowerMan11 = new Wiseacre("Гудвин", 45, "Красный", 20, 65, 45, 185, 6);

            //character2.Invisibele();
            Console.WriteLine($"Скрытая атака {character2.StealthPunch()}");
            character1.HealthHero(character2);
            Console.WriteLine($"{character1.Name} нанес магическая {character1.MagicAttack()} урона");
            character3.RageArt();
            Console.WriteLine($"{character3.Name} нанес {character3.RageAttack()} урона в ярости");
            character3.DefenceHero(character1);
        }
    }
}
