﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RaspberryPi_UdpBroadcastReceiver.MarsvinService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/MarsvinServiceSOAP")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PhoneNoField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mail {
            get {
                return this.MailField;
            }
            set {
                if ((object.ReferenceEquals(this.MailField, value) != true)) {
                    this.MailField = value;
                    this.RaisePropertyChanged("Mail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PhoneNo {
            get {
                return this.PhoneNoField;
            }
            set {
                if ((this.PhoneNoField.Equals(value) != true)) {
                    this.PhoneNoField = value;
                    this.RaisePropertyChanged("PhoneNo");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Measurement", Namespace="http://schemas.datacontract.org/2004/07/MarsvinServiceSOAP")]
    [System.SerializableAttribute()]
    public partial class Measurement : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageLinkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int dBField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageLink {
            get {
                return this.ImageLinkField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageLinkField, value) != true)) {
                    this.ImageLinkField = value;
                    this.RaisePropertyChanged("ImageLink");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int dB {
            get {
                return this.dBField;
            }
            set {
                if ((this.dBField.Equals(value) != true)) {
                    this.dBField = value;
                    this.RaisePropertyChanged("dB");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MarsvinService.IMarsvinService")]
    public interface IMarsvinService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/GetAllUsers", ReplyAction="http://tempuri.org/IMarsvinService/GetAllUsersResponse")]
        RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/GetAllUsers", ReplyAction="http://tempuri.org/IMarsvinService/GetAllUsersResponse")]
        System.Threading.Tasks.Task<RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/GetUserByPhoneNo", ReplyAction="http://tempuri.org/IMarsvinService/GetUserByPhoneNoResponse")]
        RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[] GetUserByPhoneNo(int phoneno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/GetUserByPhoneNo", ReplyAction="http://tempuri.org/IMarsvinService/GetUserByPhoneNoResponse")]
        System.Threading.Tasks.Task<RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[]> GetUserByPhoneNoAsync(int phoneno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/GetUserByMail", ReplyAction="http://tempuri.org/IMarsvinService/GetUserByMailResponse")]
        RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[] GetUserByMail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/GetUserByMail", ReplyAction="http://tempuri.org/IMarsvinService/GetUserByMailResponse")]
        System.Threading.Tasks.Task<RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[]> GetUserByMailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/AddUser", ReplyAction="http://tempuri.org/IMarsvinService/AddUserResponse")]
        int AddUser(RaspberryPi_UdpBroadcastReceiver.MarsvinService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/AddUser", ReplyAction="http://tempuri.org/IMarsvinService/AddUserResponse")]
        System.Threading.Tasks.Task<int> AddUserAsync(RaspberryPi_UdpBroadcastReceiver.MarsvinService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/DeleteUser", ReplyAction="http://tempuri.org/IMarsvinService/DeleteUserResponse")]
        void DeleteUser(RaspberryPi_UdpBroadcastReceiver.MarsvinService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/DeleteUser", ReplyAction="http://tempuri.org/IMarsvinService/DeleteUserResponse")]
        System.Threading.Tasks.Task DeleteUserAsync(RaspberryPi_UdpBroadcastReceiver.MarsvinService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/AddMeasurement", ReplyAction="http://tempuri.org/IMarsvinService/AddMeasurementResponse")]
        int AddMeasurement(RaspberryPi_UdpBroadcastReceiver.MarsvinService.Measurement measurement);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/AddMeasurement", ReplyAction="http://tempuri.org/IMarsvinService/AddMeasurementResponse")]
        System.Threading.Tasks.Task<int> AddMeasurementAsync(RaspberryPi_UdpBroadcastReceiver.MarsvinService.Measurement measurement);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/AddMeasurementNoLink", ReplyAction="http://tempuri.org/IMarsvinService/AddMeasurementNoLinkResponse")]
        int AddMeasurementNoLink(RaspberryPi_UdpBroadcastReceiver.MarsvinService.Measurement measurement);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMarsvinService/AddMeasurementNoLink", ReplyAction="http://tempuri.org/IMarsvinService/AddMeasurementNoLinkResponse")]
        System.Threading.Tasks.Task<int> AddMeasurementNoLinkAsync(RaspberryPi_UdpBroadcastReceiver.MarsvinService.Measurement measurement);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMarsvinServiceChannel : RaspberryPi_UdpBroadcastReceiver.MarsvinService.IMarsvinService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MarsvinServiceClient : System.ServiceModel.ClientBase<RaspberryPi_UdpBroadcastReceiver.MarsvinService.IMarsvinService>, RaspberryPi_UdpBroadcastReceiver.MarsvinService.IMarsvinService {
        
        public MarsvinServiceClient() {
        }
        
        public MarsvinServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MarsvinServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MarsvinServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MarsvinServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[] GetUserByPhoneNo(int phoneno) {
            return base.Channel.GetUserByPhoneNo(phoneno);
        }
        
        public System.Threading.Tasks.Task<RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[]> GetUserByPhoneNoAsync(int phoneno) {
            return base.Channel.GetUserByPhoneNoAsync(phoneno);
        }
        
        public RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[] GetUserByMail(string email) {
            return base.Channel.GetUserByMail(email);
        }
        
        public System.Threading.Tasks.Task<RaspberryPi_UdpBroadcastReceiver.MarsvinService.User[]> GetUserByMailAsync(string email) {
            return base.Channel.GetUserByMailAsync(email);
        }
        
        public int AddUser(RaspberryPi_UdpBroadcastReceiver.MarsvinService.User user) {
            return base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task<int> AddUserAsync(RaspberryPi_UdpBroadcastReceiver.MarsvinService.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public void DeleteUser(RaspberryPi_UdpBroadcastReceiver.MarsvinService.User user) {
            base.Channel.DeleteUser(user);
        }
        
        public System.Threading.Tasks.Task DeleteUserAsync(RaspberryPi_UdpBroadcastReceiver.MarsvinService.User user) {
            return base.Channel.DeleteUserAsync(user);
        }
        
        public int AddMeasurement(RaspberryPi_UdpBroadcastReceiver.MarsvinService.Measurement measurement) {
            return base.Channel.AddMeasurement(measurement);
        }
        
        public System.Threading.Tasks.Task<int> AddMeasurementAsync(RaspberryPi_UdpBroadcastReceiver.MarsvinService.Measurement measurement) {
            return base.Channel.AddMeasurementAsync(measurement);
        }
        
        public int AddMeasurementNoLink(RaspberryPi_UdpBroadcastReceiver.MarsvinService.Measurement measurement) {
            return base.Channel.AddMeasurementNoLink(measurement);
        }
        
        public System.Threading.Tasks.Task<int> AddMeasurementNoLinkAsync(RaspberryPi_UdpBroadcastReceiver.MarsvinService.Measurement measurement) {
            return base.Channel.AddMeasurementNoLinkAsync(measurement);
        }
    }
}
