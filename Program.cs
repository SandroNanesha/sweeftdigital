using System;
using System.Collections.Generic;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Linq;

namespace SweeftDigitalSolutions
{
    class Program
    {
        
        //#1
        public static Boolean isPalindrome(String text)
        {
            if (text == null) return false;

            if (text.Length == 1 || text.Length == 0) return true;

            if (text[0] != text[text.Length - 1]) return false;

            return isPalindrome(text.Substring(1, text.Length - 2));

        }
        //#2
        public static int minSplit(int amount)
        {
            if (amount < 0) return -1;
            
            List<int> coins = new List<int>();
            coins.Add(50);
            coins.Add(20);
            coins.Add(10);
            coins.Add(5);

            int counter = 0;
            int res;

            foreach (int i in coins)
            {
                res = amount % i;

                if (res == 0) return amount / i;

                if (amount != res)
                    counter += amount / i;
                
                amount = res;
            }
            return counter + amount;
        }

        //#3
        public static int notContains(int[] array)
        {
            if (array == null) return -1;
            if (array.Length == 0) return 1;
            //if (array.Length == 1) return array[0]-1;

            List<int> newArr = new List<int>(array);
            newArr.Sort();

            for(int i=0; i<newArr.Count; i++)
            {
                if(newArr[i] > 0)
                {
                    for(int j=0; j<newArr.Count-i; j++)
                    {
                        if (newArr[i + j] != j + 1) return j + 1;
                    }
                    return newArr[newArr.Count - 1] + 1;
                }
            }
            return 1;
        }

        //#4
        public static Boolean isProperly(String sequence)
        {
            int counter = 0;
            foreach (char ch in sequence)
            {
                if (counter < 0) return false;
                if (ch == '(') counter++;
                if (ch == ')') counter--;
            }
            return counter == 0;
        }

        //#5
        public static int countVariants(int stearsCount)
        {
            if (stearsCount == 0) return 1;
            if (stearsCount < 0) return 0;

            return countVariants(stearsCount - 1) + countVariants(stearsCount - 2);

        }

        //#8 Res ex: 1 EUR = x USD
        public static Double exchangeRate(String from, String to)
        {
            String url = "http://www.nbg.ge/rss.php";
            XmlReader reader = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            
            SyndicationItem item = feed.Items.OrderByDescending(x => x.PublishDate).FirstOrDefault();
            String summary = item.Summary.Text;

            String regularExpressionPattern1 = @"(?<=<td>)(.*?)(?=<\/td>)";
            Regex regex = new Regex(regularExpressionPattern1, RegexOptions.Singleline);
            MatchCollection collection = regex.Matches(summary.ToString());

            Double fromToLari = 0;
            Double toToLari = 0;

            for(int i=0; i<collection.Count; i+=5)
            {
                Match m = collection[i];
                var stripped = m.Groups[1].Value;
                if(stripped == from)
                {
                    Match exchangeMatch = collection[i + 2];
                    fromToLari = double.Parse(exchangeMatch.Groups[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    
                }

                if (stripped == to)
                {
                    Match exchangeMatch = collection[i + 2];
                    toToLari = double.Parse(exchangeMatch.Groups[1].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);

                }     
            }

            if (fromToLari == 0 || toToLari == 0)
            {
                Console.WriteLine("No such valute detected");
                return -1;
            }
            //Console.WriteLine("1 " + from + " = " + fromToLari / toToLari + " " + to);
            return fromToLari / toToLari;
        }





        static void Main(string[] args)
        {
            //############# Usage of O(1) removal data structure problem 6

            //ConstantRemoveTimeClass cr = new ConstantRemoveTimeClass();
            //cr.AddElem(12);
            //cr.AddElem(32);
            //cr.AddElem(74);

            //Console.WriteLine(cr.ToString());
            //cr.RemoveElem(32);
            //Console.WriteLine(cr.ToString());
        }


    }
}
