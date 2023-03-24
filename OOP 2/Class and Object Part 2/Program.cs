using System;

namespace HeroSuper
{
    class Hero
    {
        static void Main(string[] args)
        {
            HeroMarksman mm = new HeroMarksman();
            mm.NamaHero = "Toga";
            mm.PowerHero = 1000;
            mm.HealthHero = 1000;

            Console.WriteLine("Nama Hero = " + mm.NamaHero +
                "\n Power Hero = " + mm.PowerHero +
                "\n Health Hero = " + mm.HealthHero);
        }
    }

    public class HeroMarksman
    {
        string nama;
        int power;
        int health;

        public string NamaHero
        {
            get { return nama; }
            set { nama = value; }
        }

        public int PowerHero
        {
            get { return power; }
            set { power = value; }
        }

        public int HealthHero
        {
            get { return health; } 
            set { health = value; }
        }
    }
}