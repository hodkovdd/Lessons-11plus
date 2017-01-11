using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_3
{
    class Employer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Employer(string firstn, string lastn, int age)
        {
            FirstName = firstn;
            LastName = lastn;
            Age = age;
        }

        public override string ToString()
        {
            return String.Format("name - {0}, surname - {1}, age - {2}", FirstName, LastName, Age);
        }
    }

    class GroupOfEmoloyers : IEnumerable, IEnumerator
    {
        private int index = 0;
        private int point = -1;
        object IEnumerator.Current
        {
            get
            {
                return group[point];
            }
        }
        public int Length
        {
            get
            {
                return group.Length;
            }
        }
        public int Capacity
        {
            get
            {
                return index;
            }
        }
        public Employer this[int id]
        {
            get
            {
                if (id < Capacity)
                    return group[id];
                else
                    return null;
            }
        }
        private Employer[] group = null;
        public GroupOfEmoloyers(int size)
        {
            group = new Employer[size];
        }
        public void Fill(Employer emp)
        {
            if (index < group.Length)
                group[index++] = emp;
            else
                Console.WriteLine("Group is full!");
        }
        public IEnumerator GetEnumerator()
        {
            return this as IEnumerator;
        }
        bool IEnumerator.MoveNext()
        {

            if (point < Capacity - 1)
            {
                point++;
                return true;
            }
            else
            {
                ((IEnumerator)this).Reset();
                return false;
            }
            
        }
        void IEnumerator.Reset()
        {
            point = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GroupOfEmoloyers group1 = new GroupOfEmoloyers(4);
            group1.Fill(new Employer("Pavel", "Ivanov", 34));
            group1.Fill(new Employer("Pavel", "Novikov", 36));
            group1.Fill(new Employer("Sasha", "Ivanov", 32));

            for (int i = 0; i < group1.Capacity; i++)
            {
                Console.WriteLine(group1[i]);
            }
            Console.WriteLine();
            foreach (Employer employer in group1)
            {
                Console.WriteLine(employer);
            }
            
            Console.WriteLine();
            foreach (Employer employer in group1)
            {
                Console.WriteLine(employer);
            }
            Console.ReadLine();
        }
    }
}
