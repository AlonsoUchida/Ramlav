﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bonus.BusinessServices.WsBonusDocumentos {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="AppBonus", ConfigurationName="WsBonusDocumentos.wslistipdoSoapPort")]
    public interface wslistipdoSoapPort {
        
        // CODEGEN: Generating message contract since the wrapper name (wslistipdo.Execute) of message ExecuteRequest does not match the default value (Execute)
        [System.ServiceModel.OperationContractAttribute(Action="AppBonusaction/AWSLISTIPDO.Execute", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Bonus.BusinessServices.WsBonusDocumentos.ExecuteResponse Execute(Bonus.BusinessServices.WsBonusDocumentos.ExecuteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="AppBonusaction/AWSLISTIPDO.Execute", ReplyAction="*")]
        System.Threading.Tasks.Task<Bonus.BusinessServices.WsBonusDocumentos.ExecuteResponse> ExecuteAsync(Bonus.BusinessServices.WsBonusDocumentos.ExecuteRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="Listipdoc.ListipdocItem", Namespace="AppBonus")]
    public partial class ListipdocListipdocItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private short tipDocCodField;
        
        private string tipDocNomField;
        
        /// <remarks/>
        public short TipDocCod {
            get {
                return this.tipDocCodField;
            }
            set {
                this.tipDocCodField = value;
                this.RaisePropertyChanged("TipDocCod");
            }
        }
        
        /// <remarks/>
        public string TipDocNom {
            get {
                return this.tipDocNomField;
            }
            set {
                this.tipDocNomField = value;
                this.RaisePropertyChanged("TipDocNom");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="wslistipdo.Execute", WrapperNamespace="AppBonus", IsWrapped=true)]
    public partial class ExecuteRequest {
        
        public ExecuteRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="wslistipdo.ExecuteResponse", WrapperNamespace="AppBonus", IsWrapped=true)]
    public partial class ExecuteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="AppBonus", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Bonus.BusinessServices.WsBonusDocumentos.ListipdocListipdocItem[] Lista;
        
        public ExecuteResponse() {
        }
        
        public ExecuteResponse(Bonus.BusinessServices.WsBonusDocumentos.ListipdocListipdocItem[] Lista) {
            this.Lista = Lista;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface wslistipdoSoapPortChannel : Bonus.BusinessServices.WsBonusDocumentos.wslistipdoSoapPort, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class wslistipdoSoapPortClient : System.ServiceModel.ClientBase<Bonus.BusinessServices.WsBonusDocumentos.wslistipdoSoapPort>, Bonus.BusinessServices.WsBonusDocumentos.wslistipdoSoapPort {
        
        public wslistipdoSoapPortClient() {
        }
        
        public wslistipdoSoapPortClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public wslistipdoSoapPortClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wslistipdoSoapPortClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wslistipdoSoapPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Bonus.BusinessServices.WsBonusDocumentos.ExecuteResponse Bonus.BusinessServices.WsBonusDocumentos.wslistipdoSoapPort.Execute(Bonus.BusinessServices.WsBonusDocumentos.ExecuteRequest request) {
            return base.Channel.Execute(request);
        }
        
        public Bonus.BusinessServices.WsBonusDocumentos.ListipdocListipdocItem[] Execute() {
            Bonus.BusinessServices.WsBonusDocumentos.ExecuteRequest inValue = new Bonus.BusinessServices.WsBonusDocumentos.ExecuteRequest();
            Bonus.BusinessServices.WsBonusDocumentos.ExecuteResponse retVal = ((Bonus.BusinessServices.WsBonusDocumentos.wslistipdoSoapPort)(this)).Execute(inValue);
            return retVal.Lista;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Bonus.BusinessServices.WsBonusDocumentos.ExecuteResponse> Bonus.BusinessServices.WsBonusDocumentos.wslistipdoSoapPort.ExecuteAsync(Bonus.BusinessServices.WsBonusDocumentos.ExecuteRequest request) {
            return base.Channel.ExecuteAsync(request);
        }
        
        public System.Threading.Tasks.Task<Bonus.BusinessServices.WsBonusDocumentos.ExecuteResponse> ExecuteAsync() {
            Bonus.BusinessServices.WsBonusDocumentos.ExecuteRequest inValue = new Bonus.BusinessServices.WsBonusDocumentos.ExecuteRequest();
            return ((Bonus.BusinessServices.WsBonusDocumentos.wslistipdoSoapPort)(this)).ExecuteAsync(inValue);
        }
    }
}
