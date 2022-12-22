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

            Console.Write("Digite o número de cidades: ");
            int.TryParse(Console.ReadLine(), out int numCities);
            var distances = new int[numCities, numCities];

            for (int i = 0; i < numCities; i++)
            {
                for (int j = i+1; j < numCities; j++)
                {
                    Console.Write($"Digite a distância entre a cidade {i+1} e a"
                        + $" cidade {j+1}: ");
                    int.TryParse(Console.ReadLine(), out int dist);
                    distances[i, j] = dist;
                    distances[j, i] = dist;
                }
            }

            return distances;
        }

        public static int[] GetRoute()
        {

            Console.Write("Digite o número de cidades na sua rota: ");
            int.TryParse(Console.ReadLine(), out int routeLength);
            var route = new int[routeLength];

            for (int i = 0; i < routeLength; i++)
            {
                string adjective = (i==0 ? "primeira" : "próxima");
                Console.Write($"Digite a {adjective} cidade: ");
                int.TryParse(Console.ReadLine(), out int city);
                route[i] = city - 1;
            }
            return route;
        }
    }
}
