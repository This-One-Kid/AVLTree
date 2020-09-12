using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTreee<int> Tre = new AVLTreee<int>();
            //for (int i = 3;i > 0;i --)
            //{
            //    Tre.Add(i);
            //}
            Random gen = new Random();
            for (int i = 0;i < 10;i ++)
            {
                //Tre.Add(1);
            }
            Tre.Print();
            Console.ReadLine();
        }
    }
}
