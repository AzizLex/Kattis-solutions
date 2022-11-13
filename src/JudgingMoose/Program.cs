using System.Linq;
using static System.Console;

namespace JudgingMoose
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = ReadLine().Split().Select(s => int.Parse(s)).ToArray();
            string result = "";

            if (nums[0] + nums[1] == 0)
            {
                result = "Not a moose";
            } else
            {
                if (nums[0] == nums[1])
                {
                    result = "Even "+(nums[0]+nums[1]);

                } else
                {
                    var num = (nums[0] < nums[1]) ? nums[1] * 2 : nums[0] * 2;
                    result = "Odd " + num;
                }
            }


            WriteLine(result);
        }
    }
}