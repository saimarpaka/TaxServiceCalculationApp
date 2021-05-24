using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace TaxService.TaxCalculators.TaxJar
{
    public enum EndpointType
    {
        Rates,
        Taxes
    }

    public class TaxJarRequestBuilder
    {
        private readonly RequestBuilder requestBuilder;
        private readonly string ratesUrl;
        private readonly string taxesUrl;

        public TaxJarRequestBuilder(
            RequestBuilder requestBuilder,
            string ratesUrl,
            string taxesUrl )
        {
            this.requestBuilder = requestBuilder;
            this.ratesUrl = ratesUrl;
            this.taxesUrl = taxesUrl;
        }

        public RestRequest CreateGetRequest<T>(T payload, EndpointType endpointType)
        {
            var restRequest =
                GetRestRequest( 
                    ( string url) => requestBuilder.CreateGetRestRequest( url ),
                    endpointType);

            restRequest.AddJsonBody( payload );

            return restRequest;
        }
        public RestRequest CreatePostRequest<T>( T payload, EndpointType endpointType )
        {
            var restRequest =
                GetRestRequest(
                    (string url) => requestBuilder.CreatePostRestRequest(url),
                    endpointType);

            restRequest.AddJsonBody( payload );

            return restRequest;
        }

        private RestRequest GetRestRequest(Func<string, RestRequest> action, EndpointType endpointType )
        {
            return endpointType switch
            {
                EndpointType.Rates => action( ratesUrl ),
                EndpointType.Taxes => action( taxesUrl ),
                _ => throw new Exception( "Not supported" ),
            };
        }
    }
}
