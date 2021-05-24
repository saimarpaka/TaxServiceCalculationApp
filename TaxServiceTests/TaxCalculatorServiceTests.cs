using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxService.Common;
using System;
using System.Collections.Generic;
using System.Text;
using TaxService.TaxCalculators;
using TaxService.TaxCalculators.Services;
using TaxService.TaxCalculators.TaxJar;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading.Tasks;
using TaxService.TaxCalculators.Entities;

namespace TaxService.Tests
{
    [TestClass()]
    public class TaxCalculatorServiceTests
    {
        private ITaxCalculator taxCalculatorService;

        [TestInitialize]
        public void Initialize()
        {
            ILogger<LoggingTaxCalculatorClient> logger =
                LoggerFactory
                    .Create( logging => logging.AddConsole() )
                        .CreateLogger<LoggingTaxCalculatorClient>();

            this.taxCalculatorService =
                new TaxCalculatorService(
                    new LoggingTaxCalculatorClient(
                        new TaxJarCalculatorClient(
                                new TaxJarRequestBuilder(
                                    new RequestBuilder(
                                        new TaxJarAuthenticationProvider( "5da2f821eee4035db4771edab942a4cc" )),
                                    "https://api.taxjar.com/v2/rates/{zip}",
                                    "https://api.taxjar.com/v2/taxes" ),
                                new RestSharp.RestClient() ),
                        logger ));
        }

        [TestMethod]
        public async Task GetTaxRatesForLocation_Test()
        {
            var zip = "90404-3370";
            var ratesForLocation =
                await this.taxCalculatorService.GetTaxRatesForLocation( zip );

            Assert.IsNotNull( ratesForLocation );
        }

        [TestMethod]
        public async Task GetTaxRatesForLocation_With_Optional_Request_Test()
        {
            var zip = "90404-3370";
            var request = new TaxRateLocationRequest
            {
                city = "Santa Monica",
                state = "CA",
                country = "US"
            };
            var ratesForLocation =
                await this.taxCalculatorService.GetTaxRatesForLocation( zip, request );

            Assert.IsNotNull( ratesForLocation );
        }

        [TestMethod]
        public async Task GetCalculatedTaxesForOrder_Test()
        {
            var request =
                new SalesTaxCalculationRequest
                {
                    from_country = "US",
                    from_zip = "92093",
                    from_state = "CA",
                    from_city = "La Jolla",
                    from_street = "9500 Gilman Drive",
                    to_country = "US",
                    to_zip = "90002",
                    to_state = "CA",
                    to_city = "Los Angeles",
                    to_street = "1335 E 103rd St",
                    amount = 15,
                    shipping = 1.5F,
                    nexus_addresses =
                    new Nexus_Addresses[] {
                            new Nexus_Addresses {
                              id = "Main Location",
                              country = "US",
                              zip = "92093",
                              state = "CA",
                              city = "La Jolla",
                              street = "9500 Gilman Drive",
                            }
                          },
                    line_items =
                    new SalesTaxCalculationLineItemsRequest[] {
                        new SalesTaxCalculationLineItemsRequest{
                          id = "1",
                          quantity = 1,
                          product_tax_code = "20010",
                          unit_price = 15,
                          discount = 0
                        }}};

            var response =
                await this.taxCalculatorService.GetCalculatedTaxesForOrder( request );

            Assert.IsNotNull( response );
        }
    }
}