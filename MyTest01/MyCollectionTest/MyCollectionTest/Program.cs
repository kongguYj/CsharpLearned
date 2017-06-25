using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var laoliu = new Racer(7, "刘", "建东", "China", 14);
            var chenF = new Racer(13, "陈", "峰", "USA", 12);
            var yin = new Racer(16, "银", "废", "UK", 14);

            var racers = new List<Racer>(20) { laoliu, chenF, yin };
            racers.Add(new Racer(19, "王", "峰","Germany", 91));
            racers.Add(new Racer(23, "曹", "晨", "Finland", 20));

            racers.AddRange(new Racer[] {
            new Racer(14,"赵","驰","Janpan",25),
            new Racer (22, "李","三","Indians",28)});

            racers.Insert(3, new Racer(2, "陈", "苏翀", "Rasssia", 10));

            for(int i = 0; i < racers.Count; i++)
            {
                Console.WriteLine(racers[i].ToString ("A"));
            }

            Console.ReadKey();

            racers.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
 }
