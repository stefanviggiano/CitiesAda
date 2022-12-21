using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities
{
    public static class Utils
    {
        public static IEnumerable<Tuple<int, int>> PairWise(IEnumerable<int> input)
        {
            //Source: https://stackoverflow.com/q/577590
            return input.Zip(input.Skip(1), Tuple.Create);
        }

    }
}
