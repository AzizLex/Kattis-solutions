using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace MoneyMatters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = ReadLine().Split().Select(s => int.Parse(s)).ToArray();
            int n = nums[0];
            int m = nums[1];
            int[] o = new int[n];
            int[][] xy = new int[m][];

            bool result = true;

            for (int i = 0; i < n; i++)
            {
                o[i] = int.Parse(ReadLine());
            }

            for (int i = 0; i < m; i++)
            {
                xy[i] = ReadLine().Split().Select(s => int.Parse(s)).ToArray();
            }

            List<HashSet<int>> sets = new List<HashSet<int>>();
            sets.Add(new HashSet<int>() { xy[0][0], xy[0][1] });

            for (int i = 1; i < m; i++)
            {
                int posS = -1;
                int j = 0;
                while (j < sets.Count)
                {
                    if (sets[j].Contains(xy[i][0]) || sets[j].Contains(xy[i][1]))
                    {
                        if (posS == -1)
                        {
                            sets[j].Add(xy[i][0]);
                            sets[j].Add(xy[i][1]);
                            posS = j;
                            j++;
                        }
                        else
                        {
                            sets[posS] = sets[posS].Union(sets[j]).ToHashSet();
                            sets.RemoveAt(j);
                        }
                    }
                    else
                    {
                        j++;
                    }
                }
                if (posS == -1)
                {
                    sets.Add(new HashSet<int>() { xy[i][0], xy[i][1] });
                }
            }
            foreach (var set in sets)
            {
                if (set.Sum(fm => o[fm]) != 0)
                {
                    result = false;
                }
            }
            if (result)
            {
                WriteLine("POSSIBLE");

            }
            else
            {
                WriteLine("IMPOSSIBLE");
            }
        }
    }
}