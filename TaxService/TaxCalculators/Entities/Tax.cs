using System;
using System.Collections.Generic;
using System.Text;
using static TaxService.TaxCalculators.Entities.SalesTaxCalculationResponse;

namespace TaxService.TaxCalculators.Entities
{
    public class Tax
    {
        public float order_total_amount
        {
            get; set;
        }
        public float shipping
        {
            get; set;
        }
        public float taxable_amount
        {
            get; set;
        }
        public float amount_to_collect
        {
            get; set;
        }
        public float rate
        {
            get; set;
        }
        public bool has_nexus
        {
            get; set;
        }
        public bool freight_taxable
        {
            get; set;
        }
        public string tax_source
        {
            get; set;
        }
        public Jurisdictions jurisdictions
        {
            get; set;
        }
        public Breakdown breakdown
        {
            get; set;
        }
        public SalesTaxCalculationLineItems[] line_items
        {
            get;set;
        }
    }
}
