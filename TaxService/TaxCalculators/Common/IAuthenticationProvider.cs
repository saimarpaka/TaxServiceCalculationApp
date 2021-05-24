using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace TaxService.Common
{
    public interface IAuthenticationProvider
    {
        void AddAuthenticationHeadersTo( RestRequest restRequest );
    }
}
