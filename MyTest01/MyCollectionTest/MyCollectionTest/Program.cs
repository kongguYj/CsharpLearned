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
        }
    }

    public class Racer : IComparable<Racer>, IFormattable
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wins { get; set; }
        public string Country { get; set; }
        public Racer(int id, string firstName, string lastName, string country) : this(id, firstName, lastName, country, wins: 0) { }
        public Racer(int id, string firstName, string lastName, string country, int wins)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.Wins = wins;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null) format = "N";
            switch (format.ToUpper())
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "W":
                    return String.Format("{0}, Wins : {1}", ToString(), Wins);
                case "C":
                    return String.Format("{0}, Country: {1}", ToString(), Country);
                case "A":
                    return String.Format("{0}, {1} Wins: {2}", ToString(), Country, Wins);
                default:
                    throw new FormatException(String.Format(formatProvider, "Format {0} is not Supported", format));
            }
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public int CompareTo(Racer other)
        {
            if (other == null) return -1;
            int compare = string.Compare(this.LastName, other.LastName);
            if (compare == 0)
            {
                return string.Compare(this.FirstName, other.FirstName);
            }
            return compare;
        }
    }
 }
