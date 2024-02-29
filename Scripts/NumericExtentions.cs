using System.Collections.Generic;

namespace CodeHelper
{
    internal static class NumericExtentions
    {
        internal static int Add(ref this int self, int additional) => self += additional;
        internal static float Add(ref this float self, float additional) => self += additional;
        internal static decimal Add(ref this decimal self, decimal additional) => self += additional;
        internal static double Add(ref this double self, double additional) => self += additional;

        internal static int Remove(ref this int self, int removable) => self -= removable;
        internal static float Remove(ref this float self, float removable) => self -= removable;
        internal static decimal Remove(ref this decimal self, decimal removable) => self -= removable;
        internal static double Remove(ref this double self, double removable) => self -= removable;

        internal static int Multiply(ref this int self, int additional) => self *= additional;
        internal static float Multiply(ref this float self, float additional) => self *= additional;
        internal static decimal Multiply(ref this decimal self, decimal additional) => self *= additional;
        internal static double Multiply(ref this double self, double additional) => self *= additional;

        internal static int Percent(this int self, int percents) => self / 100 * percents;
        internal static float Percent(this float self, float percents) => self / 100 * percents;
        internal static decimal Percent(this decimal self, decimal percents) => self / 100 * percents;
        internal static double Percent(this double self, double percents) => self / 100 * percents;


        internal static int[] ToArray(this int self)
        {
            var st = self.ToString();
            List<int> results = new();
            foreach (var item in st) results.Add(int.Parse(item.ToString()));
            return results.ToArray();
        }

        internal static int Reverse(ref this int self)
        {
            var arr = self.ToArray();
            int res = 0, multiply = 1;
            for(int i = 0; i < arr.Length; i++)
            {
                res += arr[i] * multiply;
                multiply *= 10;
            }
            self = res;
            return self;
        }


        /// <returns>True if number % 2 == 0</returns>
        internal static bool IsEven(this int self) => self % 2 == 0;
    }
}

