using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Contracts
{
    public interface ICaller
    {
        string Call(string number);
    }
}
