using System;

class PriceChangeAlert
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        double limit = double.Parse(Console.ReadLine());
        double lastPrice = double.Parse(Console.ReadLine());

        for (int price = 0; price < number - 1; price++)
        {

            double currPrice = double.Parse(Console.ReadLine());
            double diff = GetDifferencePercentage(lastPrice, currPrice);
            bool isSignificantDifference = IsThereASignificantDifference(diff, limit);

            string message = GetTextForResult(currPrice, lastPrice, diff, isSignificantDifference);
            Console.WriteLine(message);

            lastPrice = currPrice;
        }
    }

    static string GetTextForResult(double currPrice, double lastPrice, double diff, bool isSignificantDifference)
    {
        string message = string.Empty;
        if (diff == 0)
        {
            message = string.Format("NO CHANGE: {0}", currPrice);
        }
        else if (isSignificantDifference == false)
        {
            message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currPrice, diff);
        }
        else if (isSignificantDifference && (diff > 0))
        {
            message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currPrice, diff);
        }
        else if (isSignificantDifference && (diff < 0))
            message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currPrice, diff);
        return message;
    }

    static bool IsThereASignificantDifference(double limit, double diff)
    {
        if (Math.Abs(limit) >= diff)
        {
            return true;
        }
        return false;
    }

    static double GetDifferencePercentage(double lastPrice, double currPrice)
    {
        double percentage = (currPrice - lastPrice) / lastPrice;
        return percentage;
    }
}
