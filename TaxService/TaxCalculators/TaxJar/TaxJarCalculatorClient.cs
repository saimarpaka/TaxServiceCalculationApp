using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TaxService.TaxCalculators.Entities;

namespace TaxService.TaxCalculators.TaxJar
{
    public class TaxJarCalculatorClient : ITaxCalculator
    {
        private readonly TaxJarRequestBuilder taxJarRequestBuilder;
        private readonly RestClient restClient;

        public TaxJarCalculatorClient( TaxJarRequestBuilder taxJarRequestBuilder, RestClient restClient )
        {
            this.taxJarRequestBuilder = taxJarRequestBuilder;
            this.restClient = restClient;
        }

        public async Task<SalesTaxCalculationResponse> GetCalculatedTaxesForOrder( SalesTaxCalculationRequest request )
        {
            RestRequest restRequest =
               this.taxJarRequestBuilder.CreatePostRequest( request, EndpointType.Taxes );         
            return await ExecuteRequestAsync<SalesTaxCalculationRequest, SalesTaxCalculationResponse>( restRequest );
        }

        public async Task<TaxRateLocationResponse> GetTaxRatesForLocation(string zip, TaxRateLocationRequest optionalRequest = null )
        {
            RestRequest restRequest = 
                this.taxJarRequestBuilder.CreateGetRequest( optionalRequest, EndpointType.Rates );           
            restRequest.AddUrlSegment( "zip", zip );           
            return await ExecuteRequestAsync<TaxRateLocationRequest,TaxRateLocationResponse>(restRequest);
        }       

        private async Task<K> ExecuteRequestAsync<T, K>(RestRequest restRequest)
        {            
            IRestResponse restResponse = await this.restClient.ExecuteAsync( restRequest );
            string response = restResponse.Content;

            if( HttpStatusCode.OK != restResponse.StatusCode )
            {
                throw new IOException( response );
            }

            var responsePayload = JsonConvert.DeserializeObject<K>( response );
            return responsePayload;
        }
    }
}
