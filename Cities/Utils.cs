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
    public static class Utils
    {
        public static IEnumerable<Tuple<int, int>> PairWise(IEnumerable<int> input)
        {
            //Source: https://stackoverflow.com/q/577590
            return input.Zip(input.Skip(1), Tuple.Create);
        }

        public static int[,] GetDistances()
        {
            string desktopPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Desktop);
            string distancesFileName = System.IO.Path.Combine(
                    desktopPath, "matriz.txt");

            using var distancesReader = new StreamReader(distancesFileName);
            string[] lines = distancesReader.ReadToEnd().Split();

            int numCities = 5;
            var distances = new int[numCities, numCities];

            for (int i = 0; i < numCities; i++)
            {
                string line = lines[i];
                string[] dists = lines[i].Split(",");
                for (int j = 0; j < numCities; j++)
                {
                    int.TryParse(dists[j], out int dist);
                    distances[i, j] = dist;
                    distances[j, i] = dist;
                }
            }

            return distances;
        }

        public static int[] GetRoute()
        {
            string desktopPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Desktop);
            string routeFileName = System.IO.Path.Combine(
                    desktopPath, "caminho.txt");

            using var routeReader = new StreamReader(routeFileName);
            var route = routeReader.ReadToEnd().Split(",").Select(
                    s => int.Parse(s) - 1).ToArray();

            return route;
        }
    }
}
