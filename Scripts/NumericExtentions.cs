namespace CodeHelper
{
    internal static class NumericExtentions
    {
        internal static int Add(ref this int self, int additional)  => self += additional;
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

    }
}

