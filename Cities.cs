//Enunciado
//A distância entre várias cidades pode ser expressada por uma tabela, conforme a
//imagem abaixo.
//
//
//00, 15, 30, 05, 12
//15, 00, 10, 17, 28
//30, 10, 00, 03, 11
//05, 17, 03, 00, 80
//12, 28, 11, 80, 00
//
//
//
//
//Implemente um programa que:
//
//1) leia a tabela acima em um array bidimensional. O programa não deve perguntar
//distâncias já informadas (por exemplo, se o usuário já forneceu a distância
//        entre 1 e 3 não é necessário informar a distância entre 3 e 1, que é a
//        mesma) e também não deve perguntar a distância entre uma cidade e ela
//mesma, que é sempre 0;
//
//2) leia um percurso fornecido pelo usuário e armazene em um array
//unidimensional.
//
//Após isso, calcule e mostre a distância percorrida pelo usuário. Por exemplo,
//    para o percurso 1, 2, 3, 2, 5, 1, 4 teremos 15 + 10 + 10+ 28 + 12 + 5 = 80
//    km.
//
//    Crie um repositório público no GitHub e submeta o link para o seu
//    repositório.

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

            var numCities = 5;
            var distancies = new int[,]
            {
                { 00, 15, 30, 05, 12 },
                { 15, 00, 10, 17, 28 },
                { 30, 10, 00, 03, 11 },
                { 05, 17, 03, 00, 80 },
                { 12, 28, 11, 80, 00 }
            };

            var route = new int[] {0, 1, 2, 3, 4};

            var distance = 0;
            foreach (Tuple<int, int> pair in Utils.PairWise(route))
                distance += distancies[pair.Item1, pair.Item2];
            Console.WriteLine(distance);
        }

    }
}
