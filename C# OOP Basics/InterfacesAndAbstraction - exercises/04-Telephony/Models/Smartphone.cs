using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ICaller, IBrowser
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {url}!";
            }
        }

        public string Call(string number)
        {
            if (number.All(x => char.IsDigit(x)) == false)
            {
                return "Invalid number!";
            }
            else
            {
                return $"Calling... {number}";
            }
        }
    }
}
