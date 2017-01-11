using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_dz
{
    abstract class Fighter
    {
        protected Random rnd = new Random();
        public int Health { get; protected set; }
        public int Strength { get; protected set; }
        public int Defence { get; protected set; }
        public string Name { get; protected set; }
        public Fighter(int health, int strength, int defence, string name)
        {
            Health = health;
            Strength = strength;
            Defence = defence;
            Name = name;
        }
        public abstract void Attack(Fighter fighter);
        public abstract void DefenceAction(int attack);
        public void Restore(int health)
        {
            this.Health = health;
        }
    }

    class Quick : Fighter
    {
        public Quick(int health, int strength, int defence, string name) : base(health, strength, defence, name)
        { }
        public override void DefenceAction(int attack)
        {
            int dodge = rnd.Next(0, 2);
            if (dodge == 0)
            {
                int damage = attack - this.Defence;
                Health -= damage;
                Console.WriteLine("{1} got {0} damage, his health remains {2}", damage, this.Name, this.Health);
            }
            else
                Console.WriteLine(" dodged!");
        }
        public override void Attack(Fighter fighter)
        {
            int attack = rnd.Next(Strength, Strength + 2);
            int doubleAttack = rnd.Next(0, 2);
            fighter.DefenceAction(attack);
            if (doubleAttack == 1)
            {
                Console.WriteLine(" double attack!");
                fighter.DefenceAction(attack);
            }
        }

    }
    class Strong : Fighter
    {
        public Strong(int health, int strength, int defence, string name) : base(health, strength, defence, name)
        { }
        public override void DefenceAction(int attack)
        {
            int damage = attack - this.Defence;
            Health -= damage;
            Console.WriteLine("{1} got {0} damage, his health remains {2}", damage, this.Name, this.Health);
        }
        public override void Attack(Fighter fighter)
        {
            int attack = rnd.Next(Strength, Strength + 1);
            fighter.DefenceAction(attack * 2);
        }
    }

    class Program
    {
        static void Fight(Fighter f1, Fighter f2)
        {
            Random r = new Random();
            int f1MaxHealth = f1.Health;
            int f2MaxHealth = f2.Health;
            int step = r.Next(1, 2);
            while (true)
            {
                if ((step & 1) == 1)
                {
                    Console.WriteLine("{0} attacks...", f1.Name);
                    f1.Attack(f2);
                }
                else
                {
                    Console.WriteLine("{0} attacks...", f2.Name);
                    f2.Attack(f1);
                }
                if (f1.Health <= 0)
                {
                    Console.WriteLine("F1 is on the ground...");
                    break;
                }
                else if (f2.Health <= 0)
                {
                    Console.WriteLine("F2 is on the ground...");
                    break;
                }
                step++;
            }
            Console.WriteLine("End of the fight...");
            f1.Restore(f1MaxHealth);
            f2.Restore(f2MaxHealth);
        }

        static Fighter ChooseFighter(int ch)
        {
            switch (ch)
            {
                case 1: return new Quick(12, 3, 2, "q");
                case 2: return new Strong(12, 3, 2, "s");
                default: return null;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Choose Fighter, quick - 1, strong - 2");
            int choice = Int32.Parse(Console.ReadLine());
            Fighter fighter = ChooseFighter(choice);


            //Fighter s1 = new Strong(12, 3, 2, "s1");
            while (true)
            {
                Console.WriteLine("Choose oposite Fighter, quick - 1, strong - 2");
                int choice2 = Int32.Parse(Console.ReadLine());
                Fighter fighter2 = ChooseFighter(choice);

                Fight(fighter, fighter2);
                Console.Write("again? (y/n) ");
                if (Console.ReadLine() == "n")
                    break;
                Console.WriteLine();
                Console.WriteLine("Next fight starts!");
            }

            //Console.ReadLine();
        }
    }
}
