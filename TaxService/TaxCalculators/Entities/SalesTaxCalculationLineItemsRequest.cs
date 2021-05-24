using System;
using System.Collections.Generic;
using System.Text;

namespace TaxService.TaxCalculators.Entities
{
    public class SalesTaxCalculationLineItemsRequest
    {     
        public string id
        {
            get; set;
        }
        public int quantity
        {
            get; set;
        }
        public string product_tax_code
        {
            get; set;
        }
        public int unit_price
        {
            get; set;
        }
        public int discount
        {
            get; set;
        }
    }
}
