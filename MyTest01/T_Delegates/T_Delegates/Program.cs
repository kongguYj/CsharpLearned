using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Delegates
{
    public delegate void GreetingDelegate(string name);
    class Program
    {
        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Moring," + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好，" + name);
        }

        private static void GreetPeople(string name, GreetingDelegate makeGreeting)
        {
            makeGreeting(name);
        }
        //static void One()
        //{
        //    Console.WriteLine("One");
        //    throw new Exception("Error in one");
        //}

        //static void Two()
        //{
        //    Console.WriteLine("Two");
        //}
        
        static void Main(string[] args)
        {
            //Action d1 = One;
            //d1 += Two;

            //Delegate[] delegates = d1.GetInvocationList();
            //foreach (Action d in delegates)
            //{
            //    try
            //    {
            //        d();
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("Exception caught");
            //        //console.readline();
            //    }
            //}
            //Console.ReadLine();

            //Func<string, string> anonDel = delegate (string param)
            //{
            //    param += mid;
            //    param += "and this was added to the string.";
            //    return param;
            //};
            //Console.WriteLine(anonDel("Start of string"));
            //Console.WriteLine(anonDel("Test of string2"));
            //Console.ReadLine();

            GreetPeople("Jim", EnglishGreeting);
            GreetPeople("老张", ChineseGreeting);
            Console.ReadLine();

            GreetingDelegate gd1, gd2;
            gd1 = EnglishGreeting;
            gd2 = ChineseGreeting;

            GreetPeople("Jim", gd1);
            GreetPeople("老张", gd2);
            Console.ReadKey();

            GreetingDelegate gd3;
            gd3 = EnglishGreeting;
            gd3 += ChineseGreeting;

            GreetPeople("Jim", gd3);
            Console.ReadKey();

            gd3 -= EnglishGreeting;
            gd3("老张");
            Console.ReadKey();

            
        }
    }
}
