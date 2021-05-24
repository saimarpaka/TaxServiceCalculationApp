using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxService.TaxCalculators.Entities;

namespace TaxService.TaxCalculators.Services
{
    public class TaxCalculatorService : ITaxCalculator
    {
        private readonly ITaxCalculator taxCalculatorClient;


        public TaxCalculatorService( ITaxCalculator taxCalculatorClient )
        {
            this.taxCalculatorClient = taxCalculatorClient;
        }

        public async Task<SalesTaxCalculationResponse> GetCalculatedTaxesForOrder( SalesTaxCalculationRequest request )
        {
            if( request == null )
            {
                throw new ArgumentException();
            }

            return await this.taxCalculatorClient.GetCalculatedTaxesForOrder( request );
        }

        public async Task<TaxRateLocationResponse> GetTaxRatesForLocation( string zip, TaxRateLocationRequest optionalRequest )
        {
            if( string.IsNullOrEmpty( zip ) )
            {
                throw new ArgumentException();
            }
            return await this.taxCalculatorClient.GetTaxRatesForLocation(zip, optionalRequest );
        }        
    }
}
