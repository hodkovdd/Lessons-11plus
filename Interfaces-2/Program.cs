using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_2
{
    interface IPlay
    {
        void Play();
        void Pause();
        void Stop();
    }

    interface IRecord
    {
        void Record();
        void Pause();
        void Stop();
    }

    class Player : IPlay, IRecord
    {
        public void Play()
        {
            Console.WriteLine("Play");
        }

        public void Record()
        {
            Console.WriteLine("Record");
        }

        void IRecord.Pause()
        {
            Console.WriteLine("Pause record");
        }

        void IPlay.Pause()
        {
            Console.WriteLine("Pause play");
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
        }
    }



    class Program
    {
        static void Choice(int num)
        {
            Player obj = new Player();
            switch (num)
            {
                case 1 :
                    {
                        IPlay play = obj;
                        play.Play();
                        play.Pause();
                        play.Stop();
                        break;
                    }
                case 2 :
                    {
                        IRecord record = obj;
                        record.Record();
                        record.Pause();
                        record.Stop();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("wrong choice");
                        break;
                    }
                
            }
        }

        static void Main(string[] args)
        {
            Choice(1);
            Console.WriteLine();
            Choice(2);
            Console.ReadLine();

        }
    }
}
