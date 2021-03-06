﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DigitalSignageUI.PrmissionServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserInfoWTO", Namespace="http://schemas.datacontract.org/2004/07/DigitalServices.Model")]
    [System.SerializableAttribute()]
    public partial class UserInfoWTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int companyIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string usernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int companyId {
            get {
                return this.companyIdField;
            }
            set {
                if ((this.companyIdField.Equals(value) != true)) {
                    this.companyIdField = value;
                    this.RaisePropertyChanged("companyId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string fName {
            get {
                return this.fNameField;
            }
            set {
                if ((object.ReferenceEquals(this.fNameField, value) != true)) {
                    this.fNameField = value;
                    this.RaisePropertyChanged("fName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lName {
            get {
                return this.lNameField;
            }
            set {
                if ((object.ReferenceEquals(this.lNameField, value) != true)) {
                    this.lNameField = value;
                    this.RaisePropertyChanged("lName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                if ((object.ReferenceEquals(this.usernameField, value) != true)) {
                    this.usernameField = value;
                    this.RaisePropertyChanged("username");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PrmissionServices.Ipermission")]
    public interface Ipermission {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ipermission/login", ReplyAction="http://tempuri.org/Ipermission/loginResponse")]
        Aryaban.Engine.Core.WebService.ResultMessage<DigitalSignageUI.PrmissionServices.UserInfoWTO> login(DigitalSignageUI.PrmissionServices.UserInfoWTO userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ipermission/login", ReplyAction="http://tempuri.org/Ipermission/loginResponse")]
        System.Threading.Tasks.Task<Aryaban.Engine.Core.WebService.ResultMessage<DigitalSignageUI.PrmissionServices.UserInfoWTO>> loginAsync(DigitalSignageUI.PrmissionServices.UserInfoWTO userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ipermission/signup", ReplyAction="http://tempuri.org/Ipermission/signupResponse")]
        Aryaban.Engine.Core.WebService.ResultMessage<DigitalSignageUI.PrmissionServices.UserInfoWTO> signup(DigitalSignageUI.PrmissionServices.UserInfoWTO userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ipermission/signup", ReplyAction="http://tempuri.org/Ipermission/signupResponse")]
        System.Threading.Tasks.Task<Aryaban.Engine.Core.WebService.ResultMessage<DigitalSignageUI.PrmissionServices.UserInfoWTO>> signupAsync(DigitalSignageUI.PrmissionServices.UserInfoWTO userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ipermission/ChangePassword", ReplyAction="http://tempuri.org/Ipermission/ChangePasswordResponse")]
        Aryaban.Engine.Core.WebService.ResultMessage<bool> ChangePassword(long id, string OldPass, string NewPass, string ReNewPass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Ipermission/ChangePassword", ReplyAction="http://tempuri.org/Ipermission/ChangePasswordResponse")]
        System.Threading.Tasks.Task<Aryaban.Engine.Core.WebService.ResultMessage<bool>> ChangePasswordAsync(long id, string OldPass, string NewPass, string ReNewPass);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IpermissionChannel : DigitalSignageUI.PrmissionServices.Ipermission, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IpermissionClient : System.ServiceModel.ClientBase<DigitalSignageUI.PrmissionServices.Ipermission>, DigitalSignageUI.PrmissionServices.Ipermission {
        
        public IpermissionClient() {
        }
        
        public IpermissionClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IpermissionClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IpermissionClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IpermissionClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Aryaban.Engine.Core.WebService.ResultMessage<DigitalSignageUI.PrmissionServices.UserInfoWTO> login(DigitalSignageUI.PrmissionServices.UserInfoWTO userInfo) {
            return base.Channel.login(userInfo);
        }
        
        public System.Threading.Tasks.Task<Aryaban.Engine.Core.WebService.ResultMessage<DigitalSignageUI.PrmissionServices.UserInfoWTO>> loginAsync(DigitalSignageUI.PrmissionServices.UserInfoWTO userInfo) {
            return base.Channel.loginAsync(userInfo);
        }
        
        public Aryaban.Engine.Core.WebService.ResultMessage<DigitalSignageUI.PrmissionServices.UserInfoWTO> signup(DigitalSignageUI.PrmissionServices.UserInfoWTO userInfo) {
            return base.Channel.signup(userInfo);
        }
        
        public System.Threading.Tasks.Task<Aryaban.Engine.Core.WebService.ResultMessage<DigitalSignageUI.PrmissionServices.UserInfoWTO>> signupAsync(DigitalSignageUI.PrmissionServices.UserInfoWTO userInfo) {
            return base.Channel.signupAsync(userInfo);
        }
        
        public Aryaban.Engine.Core.WebService.ResultMessage<bool> ChangePassword(long id, string OldPass, string NewPass, string ReNewPass) {
            return base.Channel.ChangePassword(id, OldPass, NewPass, ReNewPass);
        }
        
        public System.Threading.Tasks.Task<Aryaban.Engine.Core.WebService.ResultMessage<bool>> ChangePasswordAsync(long id, string OldPass, string NewPass, string ReNewPass) {
            return base.Channel.ChangePasswordAsync(id, OldPass, NewPass, ReNewPass);
        }
    }
}
