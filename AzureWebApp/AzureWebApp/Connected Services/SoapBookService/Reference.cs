﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoapBookService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.cleverbuilder.com/BookService/", ConfigurationName="SoapBookService.BookService")]
    public interface BookService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cleverbuilder.com/BookService/GetBook", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<SoapBookService.GetBookResponse> GetBookAsync(SoapBookService.GetBookRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cleverbuilder.com/BookService/AddBook", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<SoapBookService.AddBookResponse> AddBookAsync(SoapBookService.AddBookRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.cleverbuilder.com/BookService/GetAllBooks", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<SoapBookService.GetAllBooksResponse> GetAllBooksAsync(SoapBookService.GetAllBooksRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.cleverbuilder.com/BookService/")]
    public partial class Book
    {
        
        private string idField;
        
        private string titleField;
        
        private string authorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string Author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetBook", WrapperNamespace="http://www.cleverbuilder.com/BookService/", IsWrapped=true)]
    public partial class GetBookRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.cleverbuilder.com/BookService/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ID;
        
        public GetBookRequest()
        {
        }
        
        public GetBookRequest(string ID)
        {
            this.ID = ID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetBookResponse", WrapperNamespace="http://www.cleverbuilder.com/BookService/", IsWrapped=true)]
    public partial class GetBookResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.cleverbuilder.com/BookService/", Order=0)]
        public SoapBookService.Book Book;
        
        public GetBookResponse()
        {
        }
        
        public GetBookResponse(SoapBookService.Book Book)
        {
            this.Book = Book;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddBook", WrapperNamespace="http://www.cleverbuilder.com/BookService/", IsWrapped=true)]
    public partial class AddBookRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.cleverbuilder.com/BookService/", Order=0)]
        public SoapBookService.Book Book;
        
        public AddBookRequest()
        {
        }
        
        public AddBookRequest(SoapBookService.Book Book)
        {
            this.Book = Book;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddBookResponse", WrapperNamespace="http://www.cleverbuilder.com/BookService/", IsWrapped=true)]
    public partial class AddBookResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.cleverbuilder.com/BookService/", Order=0)]
        public SoapBookService.Book Book;
        
        public AddBookResponse()
        {
        }
        
        public AddBookResponse(SoapBookService.Book Book)
        {
            this.Book = Book;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAllBooks", WrapperNamespace="http://www.cleverbuilder.com/BookService/", IsWrapped=true)]
    public partial class GetAllBooksRequest
    {
        
        public GetAllBooksRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAllBooksResponse", WrapperNamespace="http://www.cleverbuilder.com/BookService/", IsWrapped=true)]
    public partial class GetAllBooksResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.cleverbuilder.com/BookService/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Book")]
        public SoapBookService.Book[] Book;
        
        public GetAllBooksResponse()
        {
        }
        
        public GetAllBooksResponse(SoapBookService.Book[] Book)
        {
            this.Book = Book;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface BookServiceChannel : SoapBookService.BookService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class BookServiceClient : System.ServiceModel.ClientBase<SoapBookService.BookService>, SoapBookService.BookService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public BookServiceClient() : 
                base(BookServiceClient.GetDefaultBinding(), BookServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BookServiceSOAP.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BookServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(BookServiceClient.GetBindingForEndpoint(endpointConfiguration), BookServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BookServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(BookServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BookServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(BookServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BookServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<SoapBookService.GetBookResponse> GetBookAsync(SoapBookService.GetBookRequest request)
        {
            return base.Channel.GetBookAsync(request);
        }
        
        public System.Threading.Tasks.Task<SoapBookService.AddBookResponse> AddBookAsync(SoapBookService.AddBookRequest request)
        {
            return base.Channel.AddBookAsync(request);
        }
        
        public System.Threading.Tasks.Task<SoapBookService.GetAllBooksResponse> GetAllBooksAsync(SoapBookService.GetAllBooksRequest request)
        {
            return base.Channel.GetAllBooksAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BookServiceSOAP))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BookServiceSOAP))
            {
                return new System.ServiceModel.EndpointAddress("http://www.example.org/BookService");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return BookServiceClient.GetBindingForEndpoint(EndpointConfiguration.BookServiceSOAP);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return BookServiceClient.GetEndpointAddress(EndpointConfiguration.BookServiceSOAP);
        }
        
        public enum EndpointConfiguration
        {
            
            BookServiceSOAP,
        }
    }
}
