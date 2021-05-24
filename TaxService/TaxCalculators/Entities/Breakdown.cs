﻿namespace TaxService.TaxCalculators.Entities
{
    public class Breakdown
    {
        public float taxable_amount
        {
            get; set;
        }
        public float tax_collectable
        {
            get; set;
        }
        public float combined_tax_rate
        {
            get; set;
        }
        public float state_taxable_amount
        {
            get; set;
        }
        public float state_tax_rate
        {
            get; set;
        }
        public float state_tax_collectable
        {
            get; set;
        }
        public float county_taxable_amount
        {
            get; set;
        }
        public float county_tax_rate
        {
            get; set;
        }
        public float county_tax_collectable
        {
            get; set;
        }
        public float city_taxable_amount
        {
            get; set;
        }
        public float city_tax_rate
        {
            get; set;
        }
        public float city_tax_collectable
        {
            get; set;
        }
        public float special_district_taxable_amount
        {
            get; set;
        }
        public float special_tax_rate
        {
            get; set;
        }
        public float special_district_tax_collectable
        {
            get; set;
        }
        public SalesTaxCalculationLineItems[] line_items
        {
            get; set;
        }
    }    
}