using System;
using System.Linq;

namespace hrMaxsubarray
{
    class Program
    {
        static void Main()
        {
            var numCases = Int32.Parse(Console.ReadLine());
            while (numCases-- > 0)
            {
                var count = Int32.Parse(Console.ReadLine());
                var nums = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
                int curSum = 0;
                int curIndex = -1;
                int bestSum = 0;
                int bestStartIndex = -1;
                int bestEndIndex = -1;
                int nonSum = 0;
                int bestNon = Int32.MaxValue;
                for (int i = 0; i < count; ++i)
                {
                    // non-contiguous
                    if (nums[i] > 0)
                    {
                        nonSum += nums[i];
                    }
                    else
                    {
                        var pos = nums[i] * -1;
                        if (pos < bestNon)
                        {
                            bestNon = pos;
                        }
                    }
                    // contiguous
                    int val = curSum + nums[i];
                    if (val > 0)
                    {
                        //if (curSum == 0)
                        //{
                        //    curIndex = i;
                        //}
                        curSum = val;
                    }
                    else
                    {
                        curSum = 0;
                    }
                    if (curSum > bestSum)
                    {
                        bestSum = curSum;
                        //bestStartIndex = curIndex;
                        //bestEndIndex = i;
                    }
                }
                var contSum = bestSum != 0 ? bestSum : bestNon * -1;
                Console.WriteLine(contSum + " " + (nonSum != 0 ? nonSum : (bestNon * -1)));
            }
        }
    }
}
