using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxService.TaxCalculators.Entities;

namespace TaxService.TaxCalculators
{
    public interface ITaxCalculator
    {
        Task<TaxRateLocationResponse> GetTaxRatesForLocation(string zip, TaxRateLocationRequest optionalRequest = null);        
        Task<SalesTaxCalculationResponse> GetCalculatedTaxesForOrder(SalesTaxCalculationRequest request);
    }
}
