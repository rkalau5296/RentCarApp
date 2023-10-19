using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCarApp.Entities
{
    public class Lender : Borrower
    {
        public override string ToString() => base.ToString() + " (Lender)";
    }
}
