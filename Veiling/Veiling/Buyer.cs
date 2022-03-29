using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling
{
    interface Buyer
    {
        void bid(double price);
        int getBuyersNumber();
    }
}
