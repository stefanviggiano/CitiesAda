using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Formats.Asn1;
using System.Globalization;
using System.Runtime.InteropServices;
using CsvHelper;
using CsvHelper.Configuration;


namespace Cities
{
    public class Cities
    {
        static void Main()
        {
            int[,] distances = Utils.GetDistances();
            int[] route = Utils.GetRoute();

            var distance = 0;
            foreach (Tuple<int, int> pair in Utils.PairWise(route))
                distance += distances[pair.Item1, pair.Item2];

            Console.WriteLine($"O caminho tem tamânho {distance}.");
        }
    }
}
