using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Queries.Results
{
    public class GetTotalPaymentResponse
    {
        public decimal TotalAmount { get; set; }

        public GetTotalPaymentResponse(decimal totalAmount)
        {
            TotalAmount = totalAmount;
        }
    }
}
