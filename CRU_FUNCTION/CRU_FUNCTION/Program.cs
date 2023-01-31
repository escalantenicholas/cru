internal class Program
{
    static double Lx(double[,] mortalityTable, int ageInMonths)
    {
        return mortalityTable[ageInMonths, 1];
    }

    static double CRU(int ageInMonths, double discountRate, int deferralPeriod, double[,] mortalityTable)
    {
        double benefitPercentage = 0.01;
        double sum = 0.0;
        int W = mortalityTable.GetLength(0);

        for (int t = deferralPeriod; t < W; t++)
        {
            double numerator = Lx(mortalityTable, ageInMonths + t);
            double denominator = Lx(mortalityTable, ageInMonths);
            sum += Math.Pow(discountRate, t) * (numerator / denominator);
        }

        return benefitPercentage * sum;
    }

    static void Main(string[] args)
    {
        int age = 60;
        int ageInMonths = age/12;
        double discountRate = 0.03;
        int deferralPeriod = 12;
        double[,] mortalityTable = {
                { 0, 0.9998 },
                { 1, 0.9995 },
                { 2, 0.9992 },
                // ...
                { 1196, 0.0124 }
            };

        double result = CRU(ageInMonths, discountRate, deferralPeriod, mortalityTable);
        Console.WriteLine("El valor del CRU es: " + result);
    }
}