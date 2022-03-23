using System;
using System.Collections.Generic;
using System.Text;
using Veiling.ObjectsOfSale;

namespace Veiling.States
{
    internal interface State
    {
        void moveObjectOfSale(ObjectOfSale objectOfSale);
        void announceActionState();
    }
}
