namespace hrMaxsubarray
{
    using System;
    using System.Linq;

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
                int bestSum = 0;
                int nonSum = 0;
                int bestNon = Int32.MaxValue;
                for (int i = 0; i < count; ++i)
                {
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
                    int val = curSum + nums[i];
                    if (val > 0)
                    {
                        curSum = val;
                    }
                    else
                    {
                        curSum = 0;
                    }
                    if (curSum > bestSum)
                    {
                        bestSum = curSum;
                    }
                }
                var contSum = bestSum != 0 ? bestSum : bestNon * -1;
                Console.WriteLine(contSum + " " + (nonSum != 0 ? nonSum : (bestNon * -1)));
            }
        }
    }
}
