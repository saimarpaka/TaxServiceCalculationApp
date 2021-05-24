using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TaxService.TaxCalculators;
using TaxService.TaxCalculators.Entities;

namespace TaxService.Common
{
    public class LoggingTaxCalculatorClient : ITaxCalculator
    {
        private readonly ITaxCalculator taxCalculator;
        private readonly ILogger<LoggingTaxCalculatorClient> logger;

        public LoggingTaxCalculatorClient( ITaxCalculator taxCalculator, ILogger<LoggingTaxCalculatorClient> logger )
        {
            if( taxCalculator == null || logger == null )
            {
                throw new ArgumentException();
            }

            this.taxCalculator = taxCalculator;
            this.logger = logger;
        }

        public async Task<SalesTaxCalculationResponse> GetCalculatedTaxesForOrder( SalesTaxCalculationRequest request )
        {            
            return await ExecuteAsync( async () => {
                var requestJson = JsonConvert.SerializeObject( request );
                this.logger.LogInformation( $"Executing {nameof( GetTaxRatesForLocation )} with request : {requestJson}" );
                return await this.taxCalculator.GetCalculatedTaxesForOrder( request );
            } );
        }       

        public async Task<TaxRateLocationResponse> GetTaxRatesForLocation( string zip, TaxRateLocationRequest optionalRequest = null )
        {
            return await ExecuteAsync(async () => {
                var optionalRequestJson = JsonConvert.SerializeObject( optionalRequest );
                this.logger.LogInformation( $"Executing {nameof( GetTaxRatesForLocation )} with zip : {zip}, optionalRequest : {optionalRequestJson}" );
                return await this.taxCalculator.GetTaxRatesForLocation( zip, optionalRequest );
            } );
        }

        private async Task<K> ExecuteAsync<K>(            
            Func<Task<K>> action,
            [CallerMemberName] string memberName = "")
        {           
            try
            {
                this.logger.LogInformation( $"Begin Execution {memberName} " );
                var response = await action();
                this.logger.LogInformation( $"End Execution {memberName} with response {JsonConvert.SerializeObject(response)}" );

                return response;
            }
            catch( Exception e )
            {
                this.logger.LogError( e, $"Error while Execution of {memberName}" );
                throw;
            }
        }
    }
}
