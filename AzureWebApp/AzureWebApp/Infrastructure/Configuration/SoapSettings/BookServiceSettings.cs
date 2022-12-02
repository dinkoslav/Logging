namespace AzureWebApp.Infrastructure.Configuration.SoapSettings;

using Apex.Common.Settings;
using Apex.Common.Soap;

[ApexSettings("soapServices:BookService")]
public class BookServiceSettings : SoapClientSettings
{
}
