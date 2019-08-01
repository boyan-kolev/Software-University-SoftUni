using System;
using System.Collections.Generic;
using System.Text;

class DateModifier
{
    public double DifferenceBetweenTwoDates(string firstDate, string secondDate)
    {
        DateTime startDate = DateTime.Parse(firstDate);
        DateTime endDate = DateTime.Parse(secondDate);

        TimeSpan difference = startDate - endDate;
        double days = Math.Abs(difference.TotalDays);

        return days;
    }
}
