using System;
using System.Collections.Generic;
using System.Text;

namespace TaxService.TaxCalculators.Entities
{
    public class SalesTaxCalculationRequest
    {               
        public string from_country
        {
            get; set;
        }
        public string from_zip
        {
            get; set;
        }
        public string from_state
        {
            get; set;
        }
        public string from_city
        {
            get; set;
        }
        public string from_street
        {
            get; set;
        }
        public string to_country
        {
            get; set;
        }
        public string to_zip
        {
            get; set;
        }
        public string to_state
        {
            get; set;
        }
        public string to_city
        {
            get; set;
        }
        public string to_street
        {
            get; set;
        }
        public int amount
        {
            get; set;
        }
        public float shipping
        {
            get; set;
        }
        public Nexus_Addresses[] nexus_addresses
        {
            get; set;
        }
        public SalesTaxCalculationLineItemsRequest[] line_items
        {
            get; set;
        }     
    }
}
