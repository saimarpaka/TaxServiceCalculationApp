using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using TaxService.Common;

namespace TaxService.TaxCalculators.TaxJar
{
    public class TaxJarAuthenticationProvider : IAuthenticationProvider
    {
        private readonly string apiToken;

        public TaxJarAuthenticationProvider( string apiToken )
        {
            this.apiToken = apiToken;
        }

        public void AddAuthenticationHeadersTo( RestRequest restRequest )
        {
            restRequest.AddHeader( "Authorization", $"Bearer {apiToken}" );
        }
    }
}
