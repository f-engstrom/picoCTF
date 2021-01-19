using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading;

namespace picoCTF
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("flagparts: ");
            string flagParts = Console.ReadLine();

            List<string> parts = flagParts.Split('&',StringSplitOptions.RemoveEmptyEntries).ToList();

            var orderedParts = parts.OrderBy(
                x => double.Parse(x.Substring(x.IndexOf("(") + 1,
                    x.IndexOf(")") - x.IndexOf("(") - 1)));

            List<string> washedParts = new List<string>();

            foreach (var part in orderedParts)
            {


                

                washedParts.Add(Regex.Replace(part.Substring(20), "[^0-9a-zA-Z _]+", "") ); 
                
            }



            string flag = string.Join("", washedParts);

            flag = Regex.Replace(flag, @"\s+", "");

           Console.WriteLine("picoCTF{" + flag + "}");


           Console.ReadLine();

        }


        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }
    }
}
