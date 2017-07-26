using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Remotion.Utilities;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter code, please!");
            string code = Console.ReadLine();
            
            string filename = "Postnummerregister_ansi.txt";

            if (File.Exists(filename))

            { 
                StreamReader sr = new StreamReader(filename);
                string text = sr.ReadToEnd();
                text = text.Replace("\n", "");
                text = text.Replace("\r", "");

                string[] data = text.Split('\t');

                List<string> codes = new List<string>();
                List<string> cities = new List<string>();
                for (int i = 0; i < data.Length - 1; i += 4)
                {

                    codes.Add((data[i]));
                    cities.Add(data[i + 1]);

                    if (i > 0)
                    {
                        data[i] = data[i].Remove(0, 1);
                        codes.Add((data[i]));
                        cities.Add(data[i + 1]);
                    }

                }

                int idx = codes.IndexOf(code);

                string answer = cities[idx];
                Console.WriteLine(answer);

            }
        }
    }
}



