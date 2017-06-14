using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyStringTest
{
	class Program
	{
        static void Main(string[] args)
        {
            #region  StringBuilder 已测试完成
            //StringBuilder greetingBuilder = new StringBuilder("Hello from all the guys at wrox press.", 150);
            //greetingBuilder.AppendFormat("We do hope you enjoy this book as much as we " + "enjoyed writing it");

            //Console.WriteLine("Not Encode:\n" + greetingBuilder);

            //for (int i = 'z'; i > 'a'; i--)
            //{
            //    char old1 = (char)i;
            //    char new1 = (char)(i + 1);

            //    greetingBuilder = greetingBuilder.Replace(old1, new1);
            //}

            //for (int i = 'Z'; i > 'A'; i--)
            //{
            //    char old1 = (char)i;
            //    char new1 = (char)(i + 1);

            //    greetingBuilder = greetingBuilder.Replace(old1, new1);
            //}

            //Console.WriteLine("Encoded:\n" + greetingBuilder);

            //double d = 13.45;
            //int i1 = 45;
            //Console.WriteLine("The double is {0,10:E} and the int contains {1,0:D}. ", d, i1);
            #endregion

            #region ToString  格式化已测试完成
            //Vector v1 = new Vector(1, 32, 5);
            //Vector v2 = new Vector(845.3, 34.45, 23.1);

            //Console.WriteLine("\nIn IJK format, \nv1 is {0,30:IJK}\nv2 is {1,30:IJK}",v1, v2);
            //Console.WriteLine("\nIn default format, \nv1 is {0,30}\nv2 is {1,30}");
            //Console.WriteLine("\nIn Ve formart, \nv1 is {0,30:ve}\nv2 is {1,30:vE}", v1, v2);
            //Console.WriteLine("\nNorms are:\nv1 is {0,30:N}\nv2 is {1,30:n}", v1, v2);
            //Console.WriteLine("\nIn VE format,");
            #endregion

            const string myText = @"This comprehensive coompendium provides as broad and thorough investigation of all aspects of programming with ASP.NET. Entirely revised and updated for the fourth release of .NET, this book will give you the information you need to master ASP.NET and build a dynamic ,successful , enterprise Web appliction.";
            const string pattern = "ion";
            MatchCollection myMatches = Regex.Matches(myText, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

            foreach (Match nextMatch in myMatches)
            {
                Console.WriteLine(nextMatch.Index);
            }

            Console.ReadKey();

            Find2();
            Console.ReadKey();
        }

        static void  WriteMatches(string text, MatchCollection matches)
        {
            Console.WriteLine("Original text was :\n\n" + text + "\n");
            Console.WriteLine("No. of matches :" + matches.Count);

            foreach(Match nextMatch in matches)
            {
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;

                Console.WriteLine("Index : {0}, \tString: {1}, \t{2}", index, result, text.Substring(index - charsBefore, charsToDisplay));
            }
        }

        static void Find2()
        {
            string text = @"This comprehensive compendium provides a broad and thorough investigation of all aspects of programming with ASP.NET. Entirely revised and updated for 3.5 Release of .NET, this book will give you the information you need to master ASP.NET and build a dynamic , successful , enterprise Web application.";
            string pattern = @"\ba";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);
            WriteMatches(text, matches);
        }

	}

    struct Vector : IFormattable
    {
        private  double x, y, z;


        public Vector(double x, double y, double z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public string ToString (string format , IFormatProvider formatProvider)
        {
            if (format == null)
            {
                return ToString();
            }

            string formatUpper = format.ToUpper();

            switch(formatUpper )
            {
                case "N":
                    return "||" + Norm().ToString() + "||";
                case "VE":
                    return String.Format("({0:E},{1:E},{2:E})", x, y, z);
                case "IJK":
                    StringBuilder sb = new StringBuilder(x.ToString(), 30);
                    sb.AppendFormat(" i + ");
                    sb.AppendFormat(y.ToString());
                    sb.AppendFormat(" j + ");
                    sb.AppendFormat(z.ToString());
                    sb.AppendFormat(" k");
                    return sb.ToString();
                default:
                    return ToString();
            }
        }

        public double Norm()
        {
            return x * x + y * y + z * z;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
    }
}
