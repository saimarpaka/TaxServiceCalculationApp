using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TaxService.TaxCalculators.Entities
{
    public class TaxRateLocationRequest
    {      
        public string city
        {
            get; set;
        }
       
        public string state
        {
            get; set;
        }

        
        public string country
        {
            get; set;
        }
               
        public string street
        {
            get; set;
        }
    }
}
