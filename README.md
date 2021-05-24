# TaxServiceCalculationApp
Class diagram of the project
![image](https://user-images.githubusercontent.com/12286885/119293573-b1080400-bc20-11eb-8004-84a0501836b0.png)

Documentation :
  Goal:
    - To be able to use Different implementations of ITaxCalculator, depending on the customer
    
  - Requirements   
    - Create a common interface "ITaxCalculator" , which provides the following 2 methods
      1) GetTaxRatesForLocation
      2) GetCalculatedTaxesForOrder
      
    - Create the TaxCalculatorService and implement ITaxCalculator interface
    
    - Create the LoggingTaxCalculatorClient and implement ITaxCalculator interface
      - This class is responsible for logging the requests, and responses of ITaxCalculator injected clients
      
    - Create the TaxJarCalculatorClient with the following requirements
      - Implement ITaxCalculator interface
      - Inject TaxJarRequestBuilder
        - The responsibility of this class is to handle building of the RestRequests
      - Inject RestClient
      - Handle the response of the requests made by the concrete implementations of ITaxCalculatorInterface
    
    - Create the TaxJarRequestBuilder for TaxJarCalculatorClient class, whose responsibilities are as follows
      - Create the following requests
        - CreateGetRequest
        - CreatePostRequest
      - Set the url of the requests depending on the EndpointType passed 
        - url for TaxRates for a location : https://api.taxjar.com/v2/rates/:zip (GET)
        - url for Calculated Taxes for order : https://api.taxjar.com/v2/taxes (POST)
        
    - Create the RequestBuilder for TaxJarRequestBuilder class, whose responsibilites are as follows
      - CreateGetRestRequest
      - CreatePostRestRequest
      - Add authentication headers to the created requests using the IAuthenticationProvider
     
    - Create TaxJarAuthenticationProvider by implementing the IAuthenticationProvider interface
      - Inject the apiToken to this class, by construction injection, by getting the apiToken from a secure storage like Azure KeyVault(not implemented for this instance)
      - Add the "Authorization" header as "Bearer {apiToken}" for the RestRequest
     
      
