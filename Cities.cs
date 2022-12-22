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
            string desktopPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Desktop);
            string distancesFileName = System.IO.Path.Combine(
                    desktopPath, "matrix.txt");
            string routeFileName = System.IO.Path.Combine(
                    desktopPath, "caminho.txt");

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using var distancesReader = new StreamReader(distancesFileName);
            using var distancesParser = new CsvParser(distancesReader, config);

            if (!distancesParser.Read())
                return;

            int numCities = distancesParser.Record.Length;
            var distances = new int[numCities, numCities];


            for (int i = 0; i < numCities; i++)
            {
                string[] dists = distancesParser.Record;
                for (int j = 0; j < numCities; j++)
                {
                    int.TryParse(dists[j], out int dist);
                    distances[i, j] = dist;
                    distances[j, i] = dist;
                }

            distancesParser.Read();
            }

            using var routeReader = new StreamReader(routeFileName);
            using var routeParser = new CsvParser(routeReader, config);
            if (!routeParser.Read())
                return;

            var route = routeParser.Record.Select(s => int.Parse(s) - 1);

            var distance = 0;
            foreach (Tuple<int, int> pair in Utils.PairWise(route))
                distance += distances[pair.Item1, pair.Item2];
            Console.WriteLine(distance);

        }
    }
}
