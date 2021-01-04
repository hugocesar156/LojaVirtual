using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WSCorreios
{
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [ServiceContractAttribute(ConfigurationName="WSCorreios.CalcPrecoPrazoWSSoap")]
    public interface CalcPrecoPrazoWSSoap
    {
        [OperationContractAttribute(Action="http://tempuri.org/CalcPrecoPrazo", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrecoPrazoAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcPrecoPrazoData", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrecoPrazoDataAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento, string sDtCalculo);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcPrecoPrazoRestricao", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrecoPrazoRestricaoAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento, string sDtCalculo);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcPreco", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrecoAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcPrecoData", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrecoDataAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento, string sDtCalculo);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcPrazo", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrazoAsync(string nCdServico, string sCepOrigem, string sCepDestino);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcPrazoData", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrazoDataAsync(string nCdServico, string sCepOrigem, string sCepDestino, string sDtCalculo);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcPrazoRestricao", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrazoRestricaoAsync(string nCdServico, string sCepOrigem, string sCepDestino, string sDtCalculo);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcPrecoFAC", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> CalcPrecoFACAsync(string nCdServico, string nVlPeso, string strDataCalculo);
        
        [OperationContractAttribute(Action="http://tempuri.org/CalcDataMaxima", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultadoObjeto> CalcDataMaximaAsync(string codigoObjeto);
        
        [OperationContractAttribute(Action="http://tempuri.org/ListaServicos", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultadoServicos> ListaServicosAsync();
        
        [OperationContractAttribute(Action="http://tempuri.org/ListaServicosSTAR", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultadoServicos> ListaServicosSTARAsync();
        
        [OperationContractAttribute(Action="http://tempuri.org/VerificaModal", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultadoModal> VerificaModalAsync(string nCdServico, string sCepOrigem, string sCepDestino);
        
        [OperationContractAttribute(Action="http://tempuri.org/getVersao", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<versao> getVersaoAsync();
        
        [OperationContractAttribute(Action="http://tempuri.org/calcPrazoNovo", ReplyAction="*")]
        [XmlSerializerFormatAttribute(SupportFaults=true)]
        Task<cResultado> calcPrazoNovoAsync(string nCdServico, string sCepOrigem, string sCepDestino, string sDtCalculo, string strVerificaRestricao);
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cResultado
    {
        [XmlArrayAttribute(Order=0)]
        [XmlArrayItemAttribute(IsNullable=false)]
        public cServico[] Servicos { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cServico
    {
        [XmlElementAttribute(Order = 0)]
        public int Codigo { get; set; }
        
        [XmlElementAttribute(Order = 1)]
        public string Valor { get; set; }

        [XmlElementAttribute(Order = 2)]
        public string PrazoEntrega { get; set; }

        [XmlElementAttribute(Order = 3)]
        public string ValorMaoPropria { get; set; }

        [XmlElementAttribute(Order = 4)]
        public string ValorAvisoRecebimento { get; set; }

        [XmlElementAttribute(Order = 5)]
        public string ValorValorDeclarado { get; set; }

        [XmlElementAttribute(Order = 6)]
        public string EntregaDomiciliar { get; set; }

        [XmlElementAttribute(Order = 7)]
        public string EntregaSabado { get; set; }
      
        [XmlElementAttribute(Order = 8)]
        public string Erro { get; set; }

        [XmlElementAttribute(Order = 9)]
        public string MsgErro { get; set; }

        [XmlElementAttribute(Order = 10)]
        public string ValorSemAdicionais { get; set; }

        [XmlElementAttribute(Order = 11)]
        public string obsFim { get; set; }

        [XmlElementAttribute(Order = 12)]
        public string DataMaxEntrega { get; set; }

        [XmlElementAttribute(Order = 13)]
        public string HoraMaxEntrega { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class versao
    {
        [XmlElementAttribute(Order = 0)]
        public string versaoAtual { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cModal
    {
        [XmlElementAttribute(Order = 0)]
        public string codigo { get; set; }
        
        [XmlElementAttribute(Order = 1)]
        public string modal { get; set; }
        
        [XmlElementAttribute(Order = 2)]
        public string obs { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cResultadoModal
    {
        [XmlArrayAttribute(Order = 0)]
        [XmlArrayItemAttribute(IsNullable = false)]
        public cModal[] ServicosModal { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cServicosCalculo
    {
        [XmlElementAttribute(Order = 0)]
        public string codigo { get; set; }

        [XmlElementAttribute(Order = 1)]
        public string descricao { get; set; }

        [XmlElementAttribute(Order = 2)]
        public string calcula_preco { get; set; }

        [XmlElementAttribute(Order = 3)]
        public string calcula_prazo { get; set; }

        [XmlElementAttribute(Order = 4)]
        public string erro { get; set; }

        [XmlElementAttribute(Order = 5)]
        public string msgErro { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cResultadoServicos
    {
        [XmlArrayAttribute(Order = 0)]
        [XmlArrayItemAttribute(IsNullable = false)]
        public cServicosCalculo[] ServicosCalculo { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cObjeto
    { 
        [XmlElementAttribute(Order = 0)]
        public string codigo { get; set; }
        
        [XmlElementAttribute(Order = 1)]
        public string servico { get; set; }
        
        [XmlElementAttribute(Order = 2)]
        public string cepOrigem { get; set; }
        
        [XmlElementAttribute(Order = 3)]
        public string cepDestino { get; set; }
        
        [XmlElementAttribute(Order = 4)]
        public int prazoEntrega { get; set; }
        
        [XmlElementAttribute(Order = 5)]
        public string dataPostagem { get; set; }
        
        [XmlElementAttribute(Order = 6)]
        public string dataPostagemCalculo { get; set; }
        
        [XmlElementAttribute(Order = 7)]
        public string dataMaxEntrega { get; set; }
        
        [XmlElementAttribute(Order = 8)]
        public string postagemDH { get; set; }
        
        [XmlElementAttribute(Order = 9)]
        public string dataUltimoEvento { get; set; }
        
        [XmlElementAttribute(Order = 10)]
        public string codigoUltimoEvento { get; set; }
        
        [XmlElementAttribute(Order = 11)]
        public string tipoUltimoEvento { get; set; }
        
        [XmlElementAttribute(Order = 12)]
        public string descricaoUltimoEvento { get; set; }
        
        [XmlElementAttribute(Order = 13)]
        public string erro { get; set; }
        
        [XmlElementAttribute(Order = 14)]
        public string msgErro { get; set; }
        
        [XmlElementAttribute(Order = 15)]
        public string nuTicket { get; set; }
        
        [XmlElementAttribute(Order = 16)]
        public string formaPagamento { get; set; }
        
        [XmlElementAttribute(Order = 17)]
        public string valorPagamento { get; set; }
        
        [XmlElementAttribute(Order = 18)]
        public string nuContrato { get; set; }
        
        [XmlElementAttribute(Order = 19)]
        public string nuCartaoPostagem { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [DebuggerStepThroughAttribute()]
    [XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class cResultadoObjeto
    {   
        [XmlArrayAttribute(Order = 0)]
        [XmlArrayItemAttribute(IsNullable = false)]
        public cObjeto[] Objetos { get; set; }
    }
    
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface CalcPrecoPrazoWSSoapChannel : CalcPrecoPrazoWSSoap, IClientChannel { }
    
    [DebuggerStepThroughAttribute()]
    [GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class CalcPrecoPrazoWSSoapClient : ClientBase<CalcPrecoPrazoWSSoap>, CalcPrecoPrazoWSSoap
    {
        static partial void ConfigureEndpoint(ServiceEndpoint serviceEndpoint, ClientCredentials clientCredentials);
        
        public CalcPrecoPrazoWSSoapClient(EndpointConfiguration endpointConfiguration) : base(CalcPrecoPrazoWSSoapClient.GetBindingForEndpoint(endpointConfiguration), CalcPrecoPrazoWSSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CalcPrecoPrazoWSSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : base(CalcPrecoPrazoWSSoapClient.GetBindingForEndpoint(endpointConfiguration), new EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CalcPrecoPrazoWSSoapClient(EndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress) : base(CalcPrecoPrazoWSSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CalcPrecoPrazoWSSoapClient(Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : base(binding, remoteAddress) { }
        
        public Task<cResultado> CalcPrecoPrazoAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento)
        {
            return base.Channel.CalcPrecoPrazoAsync(nCdEmpresa, sDsSenha, nCdServico, sCepOrigem, sCepDestino, nVlPeso, nCdFormato, nVlComprimento, nVlAltura, nVlLargura, nVlDiametro, sCdMaoPropria, nVlValorDeclarado, sCdAvisoRecebimento);
        }
        
        public Task<cResultado> CalcPrecoPrazoDataAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento, string sDtCalculo)
        {
            return base.Channel.CalcPrecoPrazoDataAsync(nCdEmpresa, sDsSenha, nCdServico, sCepOrigem, sCepDestino, nVlPeso, nCdFormato, nVlComprimento, nVlAltura, nVlLargura, nVlDiametro, sCdMaoPropria, nVlValorDeclarado, sCdAvisoRecebimento, sDtCalculo);
        }
        
        public Task<cResultado> CalcPrecoPrazoRestricaoAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento, string sDtCalculo)
        {
            return base.Channel.CalcPrecoPrazoRestricaoAsync(nCdEmpresa, sDsSenha, nCdServico, sCepOrigem, sCepDestino, nVlPeso, nCdFormato, nVlComprimento, nVlAltura, nVlLargura, nVlDiametro, sCdMaoPropria, nVlValorDeclarado, sCdAvisoRecebimento, sDtCalculo);
        }
        
        public Task<cResultado> CalcPrecoAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento)
        {
            return base.Channel.CalcPrecoAsync(nCdEmpresa, sDsSenha, nCdServico, sCepOrigem, sCepDestino, nVlPeso, nCdFormato, nVlComprimento, nVlAltura, nVlLargura, nVlDiametro, sCdMaoPropria, nVlValorDeclarado, sCdAvisoRecebimento);
        }
        
        public Task<cResultado> CalcPrecoDataAsync(string nCdEmpresa, string sDsSenha, string nCdServico, string sCepOrigem, string sCepDestino, string nVlPeso, int nCdFormato, decimal nVlComprimento, decimal nVlAltura, decimal nVlLargura, decimal nVlDiametro, string sCdMaoPropria, decimal nVlValorDeclarado, string sCdAvisoRecebimento, string sDtCalculo)
        {
            return base.Channel.CalcPrecoDataAsync(nCdEmpresa, sDsSenha, nCdServico, sCepOrigem, sCepDestino, nVlPeso, nCdFormato, nVlComprimento, nVlAltura, nVlLargura, nVlDiametro, sCdMaoPropria, nVlValorDeclarado, sCdAvisoRecebimento, sDtCalculo);
        }
        
        public Task<cResultado> CalcPrazoAsync(string nCdServico, string sCepOrigem, string sCepDestino)
        {
            return base.Channel.CalcPrazoAsync(nCdServico, sCepOrigem, sCepDestino);
        }
        
        public Task<cResultado> CalcPrazoDataAsync(string nCdServico, string sCepOrigem, string sCepDestino, string sDtCalculo)
        {
            return base.Channel.CalcPrazoDataAsync(nCdServico, sCepOrigem, sCepDestino, sDtCalculo);
        }
        
        public Task<cResultado> CalcPrazoRestricaoAsync(string nCdServico, string sCepOrigem, string sCepDestino, string sDtCalculo)
        {
            return base.Channel.CalcPrazoRestricaoAsync(nCdServico, sCepOrigem, sCepDestino, sDtCalculo);
        }
        
        public Task<cResultado> CalcPrecoFACAsync(string nCdServico, string nVlPeso, string strDataCalculo)
        {
            return base.Channel.CalcPrecoFACAsync(nCdServico, nVlPeso, strDataCalculo);
        }
        
        public Task<cResultadoObjeto> CalcDataMaximaAsync(string codigoObjeto)
        {
            return base.Channel.CalcDataMaximaAsync(codigoObjeto);
        }
        
        public Task<cResultadoServicos> ListaServicosAsync()
        {
            return base.Channel.ListaServicosAsync();
        }
        
        public Task<cResultadoServicos> ListaServicosSTARAsync()
        {
            return base.Channel.ListaServicosSTARAsync();
        }
        
        public Task<cResultadoModal> VerificaModalAsync(string nCdServico, string sCepOrigem, string sCepDestino)
        {
            return base.Channel.VerificaModalAsync(nCdServico, sCepOrigem, sCepDestino);
        }
        
        public Task<versao> getVersaoAsync()
        {
            return base.Channel.getVersaoAsync();
        }
        
        public Task<WSCorreios.cResultado> calcPrazoNovoAsync(string nCdServico, string sCepOrigem, string sCepDestino, string sDtCalculo, string strVerificaRestricao)
        {
            return base.Channel.calcPrazoNovoAsync(nCdServico, sCepOrigem, sCepDestino, sDtCalculo, strVerificaRestricao);
        }
        
        public virtual Task OpenAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginOpen(null, null), new Action<IAsyncResult>(((ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual Task CloseAsync()
        {
            return Task.Factory.FromAsync(((ICommunicationObject)(this)).BeginClose(null, null), new Action<IAsyncResult>(((ICommunicationObject)(this)).EndClose));
        }
        
        private static Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CalcPrecoPrazoWSSoap))
            {
                return new BasicHttpBinding 
                {
                    MaxBufferSize = int.MaxValue,
                    ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                    MaxReceivedMessageSize = int.MaxValue,
                    AllowCookies = true
                };
            }

            if ((endpointConfiguration == EndpointConfiguration.CalcPrecoPrazoWSSoap12))
            {
                var result = new CustomBinding();

                var textBindingElement = new TextMessageEncodingBindingElement 
                {
                    MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None)
                };

                result.Elements.Add(textBindingElement);

                result.Elements.Add(new HttpTransportBindingElement
                {
                    AllowCookies = true,
                    MaxBufferSize = int.MaxValue,
                    MaxReceivedMessageSize = int.MaxValue
                });

                return result;
            }

            throw new InvalidOperationException(string.Format("Não foi possível encontrar o ponto de extremidade com o nome \'{0}\'.", endpointConfiguration));
        }
        
        private static EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CalcPrecoPrazoWSSoap))
                return new EndpointAddress("http://ws.correios.com.br/calculador/CalcPrecoPrazo.asmx");

            if ((endpointConfiguration == EndpointConfiguration.CalcPrecoPrazoWSSoap12))
                return new EndpointAddress("http://ws.correios.com.br/calculador/CalcPrecoPrazo.asmx");

            throw new InvalidOperationException(string.Format("Não foi possível encontrar o ponto de extremidade com o nome \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            CalcPrecoPrazoWSSoap,
            CalcPrecoPrazoWSSoap12,
        }
    }
}