using System;

namespace mergesortcost
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong n, k;

            string[] s = Console.ReadLine().Split(' ');

            n = ulong.Parse(s[0]);
            k = ulong.Parse(s[1]);

            s = Console.ReadLine().Split(' ');

            ulong[] a = new ulong[k];

            for (ulong i = 0; i < k; i++)
            {
                a[i] = ulong.Parse(s[i]);
            }

            Console.WriteLine(mergesortcost(a, k));
        }

        private static ulong mergesortcost(ulong[] a, ulong k)
        {
            ulong[,] DP = new ulong[k, k];

            ulong[,] path = new ulong[k, k];


            for (ulong len = 1; len < k; len++)
            {
                for (ulong i = 0; i < k - len; i++)
                {
                    ulong j = i + len;

                    if (j >= k)
                        continue;
                    DP[i, j] = ulong.MaxValue;

                    ulong s = 0;

                    for (ulong p = i; p <= j; p++)
                    {
                        s += a[p];
                    }
                    for (ulong m = i; m < j; m++)
                    {
                        if (DP[i, m] + DP[m + 1, j] + s < DP[i, j])
                        {
                            DP[i, j] = DP[i, m] + DP[m + 1, j] + s;
                            path[i, j] = m;
                        }
                    }

                }
            }

            //ulong sum = Sum(DP, path, 0, k - 1);

            //return sum;

            return DP[0, k - 1];
        }


        private static ulong Sum(ulong[,] dP, ulong[,] path, ulong start, ulong end)
        {
            if (start >= end)
                return 0;
            ulong sum = dP[start, end] + Sum(dP, path, start, path[start, end]) + Sum(dP, path, path[start, end] + 1, end);

            return sum;
        }
    }
}
