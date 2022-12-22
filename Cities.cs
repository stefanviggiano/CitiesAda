using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

            using var routeReader = new StreamReader(routeFileName);
            var route = routeReader.ReadToEnd().Split(",").Select(
                    s => int.Parse(s) - 1);

            var distance = 0;
            foreach (Tuple<int, int> pair in Utils.PairWise(route))
                distance += distances[pair.Item1, pair.Item2];
            Console.WriteLine(distance);
        }


    }
}
