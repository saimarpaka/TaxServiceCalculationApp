using RestSharp;
using TaxService.Common;

namespace TaxService.TaxCalculators.TaxJar
{    
    public class RequestBuilder
    {
        private readonly IAuthenticationProvider authenticationProvider;       

        public RequestBuilder(
            IAuthenticationProvider authenticationProvider)
        {
            this.authenticationProvider = authenticationProvider;         
        }

        public RestRequest CreateGetRestRequest(string url)
        {
            return CreateRequest(url, Method.GET );
        }

        public RestRequest CreatePostRestRequest( string url)
        {
            return CreateRequest(url, Method.POST );
        }

        private RestRequest CreateRequest(string url, Method requestType )
        {            
            var restRequest = 
                new RestRequest(url, requestType );

            this.authenticationProvider.AddAuthenticationHeadersTo( restRequest );
            return restRequest;
        }
    }
}
