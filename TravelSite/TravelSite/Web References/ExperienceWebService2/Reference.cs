﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace TravelSite.ExperienceWebService2 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ActivitiesServiceSoap", Namespace="http://tempuri.org/")]
    public partial class ActivitiesService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetActivityAgenciesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetActivitiesOperationCompleted;
        
        private System.Threading.SendOrPostCallback FindActivitiesOperationCompleted;
        
        private System.Threading.SendOrPostCallback FindActivities1OperationCompleted;
        
        private System.Threading.SendOrPostCallback FindActivities2OperationCompleted;
        
        private System.Threading.SendOrPostCallback loginCheckOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReserveOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ActivitiesService() {
            this.Url = global::TravelSite.Properties.Settings.Default.TravelSite_ExperienceWebService2_ActivitiesService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetActivityAgenciesCompletedEventHandler GetActivityAgenciesCompleted;
        
        /// <remarks/>
        public event GetActivitiesCompletedEventHandler GetActivitiesCompleted;
        
        /// <remarks/>
        public event FindActivitiesCompletedEventHandler FindActivitiesCompleted;
        
        /// <remarks/>
        public event FindActivities1CompletedEventHandler FindActivities1Completed;
        
        /// <remarks/>
        public event FindActivities2CompletedEventHandler FindActivities2Completed;
        
        /// <remarks/>
        public event loginCheckCompletedEventHandler loginCheckCompleted;
        
        /// <remarks/>
        public event ReserveCompletedEventHandler ReserveCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetActivityAgencies", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetActivityAgencies(string city, string state) {
            object[] results = this.Invoke("GetActivityAgencies", new object[] {
                        city,
                        state});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetActivityAgenciesAsync(string city, string state) {
            this.GetActivityAgenciesAsync(city, state, null);
        }
        
        /// <remarks/>
        public void GetActivityAgenciesAsync(string city, string state, object userState) {
            if ((this.GetActivityAgenciesOperationCompleted == null)) {
                this.GetActivityAgenciesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetActivityAgenciesOperationCompleted);
            }
            this.InvokeAsync("GetActivityAgencies", new object[] {
                        city,
                        state}, this.GetActivityAgenciesOperationCompleted, userState);
        }
        
        private void OnGetActivityAgenciesOperationCompleted(object arg) {
            if ((this.GetActivityAgenciesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetActivityAgenciesCompleted(this, new GetActivityAgenciesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetActivities", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetActivities(Agencies agencies, string city, string state) {
            object[] results = this.Invoke("GetActivities", new object[] {
                        agencies,
                        city,
                        state});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetActivitiesAsync(Agencies agencies, string city, string state) {
            this.GetActivitiesAsync(agencies, city, state, null);
        }
        
        /// <remarks/>
        public void GetActivitiesAsync(Agencies agencies, string city, string state, object userState) {
            if ((this.GetActivitiesOperationCompleted == null)) {
                this.GetActivitiesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetActivitiesOperationCompleted);
            }
            this.InvokeAsync("GetActivities", new object[] {
                        agencies,
                        city,
                        state}, this.GetActivitiesOperationCompleted, userState);
        }
        
        private void OnGetActivitiesOperationCompleted(object arg) {
            if ((this.GetActivitiesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetActivitiesCompleted(this, new GetActivitiesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FindActivities", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet FindActivities(Activity activity, string city, string state) {
            object[] results = this.Invoke("FindActivities", new object[] {
                        activity,
                        city,
                        state});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void FindActivitiesAsync(Activity activity, string city, string state) {
            this.FindActivitiesAsync(activity, city, state, null);
        }
        
        /// <remarks/>
        public void FindActivitiesAsync(Activity activity, string city, string state, object userState) {
            if ((this.FindActivitiesOperationCompleted == null)) {
                this.FindActivitiesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFindActivitiesOperationCompleted);
            }
            this.InvokeAsync("FindActivities", new object[] {
                        activity,
                        city,
                        state}, this.FindActivitiesOperationCompleted, userState);
        }
        
        private void OnFindActivitiesOperationCompleted(object arg) {
            if ((this.FindActivitiesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FindActivitiesCompleted(this, new FindActivitiesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName="FindActivities1")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/findbyvenue", RequestElementName="findbyvenue", RequestNamespace="http://tempuri.org/", ResponseElementName="findbyvenueResponse", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("findbyvenueResult")]
        public System.Data.DataSet FindActivities(Venue venue, Activity activity, string city, string state) {
            object[] results = this.Invoke("FindActivities1", new object[] {
                        venue,
                        activity,
                        city,
                        state});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void FindActivities1Async(Venue venue, Activity activity, string city, string state) {
            this.FindActivities1Async(venue, activity, city, state, null);
        }
        
        /// <remarks/>
        public void FindActivities1Async(Venue venue, Activity activity, string city, string state, object userState) {
            if ((this.FindActivities1OperationCompleted == null)) {
                this.FindActivities1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnFindActivities1OperationCompleted);
            }
            this.InvokeAsync("FindActivities1", new object[] {
                        venue,
                        activity,
                        city,
                        state}, this.FindActivities1OperationCompleted, userState);
        }
        
        private void OnFindActivities1OperationCompleted(object arg) {
            if ((this.FindActivities1Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FindActivities1Completed(this, new FindActivities1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName="FindActivities2")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/findbyAgency", RequestElementName="findbyAgency", RequestNamespace="http://tempuri.org/", ResponseElementName="findbyAgencyResponse", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("findbyAgencyResult")]
        public System.Data.DataSet FindActivities(Agencies agency, Activity activity, string city, string state) {
            object[] results = this.Invoke("FindActivities2", new object[] {
                        agency,
                        activity,
                        city,
                        state});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void FindActivities2Async(Agencies agency, Activity activity, string city, string state) {
            this.FindActivities2Async(agency, activity, city, state, null);
        }
        
        /// <remarks/>
        public void FindActivities2Async(Agencies agency, Activity activity, string city, string state, object userState) {
            if ((this.FindActivities2OperationCompleted == null)) {
                this.FindActivities2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnFindActivities2OperationCompleted);
            }
            this.InvokeAsync("FindActivities2", new object[] {
                        agency,
                        activity,
                        city,
                        state}, this.FindActivities2OperationCompleted, userState);
        }
        
        private void OnFindActivities2OperationCompleted(object arg) {
            if ((this.FindActivities2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FindActivities2Completed(this, new FindActivities2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/loginCheck", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool loginCheck(string id, string pass) {
            object[] results = this.Invoke("loginCheck", new object[] {
                        id,
                        pass});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void loginCheckAsync(string id, string pass) {
            this.loginCheckAsync(id, pass, null);
        }
        
        /// <remarks/>
        public void loginCheckAsync(string id, string pass, object userState) {
            if ((this.loginCheckOperationCompleted == null)) {
                this.loginCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnloginCheckOperationCompleted);
            }
            this.InvokeAsync("loginCheck", new object[] {
                        id,
                        pass}, this.loginCheckOperationCompleted, userState);
        }
        
        private void OnloginCheckOperationCompleted(object arg) {
            if ((this.loginCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.loginCheckCompleted(this, new loginCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Reserve", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Reserve(Agencies agency, Activity activity, Customer customer, string travelSiteiID, string travelSitePassword) {
            object[] results = this.Invoke("Reserve", new object[] {
                        agency,
                        activity,
                        customer,
                        travelSiteiID,
                        travelSitePassword});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ReserveAsync(Agencies agency, Activity activity, Customer customer, string travelSiteiID, string travelSitePassword) {
            this.ReserveAsync(agency, activity, customer, travelSiteiID, travelSitePassword, null);
        }
        
        /// <remarks/>
        public void ReserveAsync(Agencies agency, Activity activity, Customer customer, string travelSiteiID, string travelSitePassword, object userState) {
            if ((this.ReserveOperationCompleted == null)) {
                this.ReserveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReserveOperationCompleted);
            }
            this.InvokeAsync("Reserve", new object[] {
                        agency,
                        activity,
                        customer,
                        travelSiteiID,
                        travelSitePassword}, this.ReserveOperationCompleted, userState);
        }
        
        private void OnReserveOperationCompleted(object arg) {
            if ((this.ReserveCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReserveCompleted(this, new ReserveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Agencies {
        
        private string agenciesIDField;
        
        private string agenciesNameField;
        
        private string agenciesAddressField;
        
        private string agenciesCityField;
        
        private string agenciesStateField;
        
        /// <remarks/>
        public string agenciesID {
            get {
                return this.agenciesIDField;
            }
            set {
                this.agenciesIDField = value;
            }
        }
        
        /// <remarks/>
        public string agenciesName {
            get {
                return this.agenciesNameField;
            }
            set {
                this.agenciesNameField = value;
            }
        }
        
        /// <remarks/>
        public string agenciesAddress {
            get {
                return this.agenciesAddressField;
            }
            set {
                this.agenciesAddressField = value;
            }
        }
        
        /// <remarks/>
        public string agenciesCity {
            get {
                return this.agenciesCityField;
            }
            set {
                this.agenciesCityField = value;
            }
        }
        
        /// <remarks/>
        public string agenciesState {
            get {
                return this.agenciesStateField;
            }
            set {
                this.agenciesStateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Customer {
        
        private string customerIDField;
        
        private string customerFirstNameField;
        
        private string customerLastNameField;
        
        private string customerAddressField;
        
        private string customerCityField;
        
        private string customerZipField;
        
        private string customerStateField;
        
        /// <remarks/>
        public string customerID {
            get {
                return this.customerIDField;
            }
            set {
                this.customerIDField = value;
            }
        }
        
        /// <remarks/>
        public string customerFirstName {
            get {
                return this.customerFirstNameField;
            }
            set {
                this.customerFirstNameField = value;
            }
        }
        
        /// <remarks/>
        public string customerLastName {
            get {
                return this.customerLastNameField;
            }
            set {
                this.customerLastNameField = value;
            }
        }
        
        /// <remarks/>
        public string customerAddress {
            get {
                return this.customerAddressField;
            }
            set {
                this.customerAddressField = value;
            }
        }
        
        /// <remarks/>
        public string customerCity {
            get {
                return this.customerCityField;
            }
            set {
                this.customerCityField = value;
            }
        }
        
        /// <remarks/>
        public string customerZip {
            get {
                return this.customerZipField;
            }
            set {
                this.customerZipField = value;
            }
        }
        
        /// <remarks/>
        public string customerState {
            get {
                return this.customerStateField;
            }
            set {
                this.customerStateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Venue {
        
        private string venueNameField;
        
        private string venueAddressField;
        
        private string venueCityField;
        
        private string venueStateField;
        
        /// <remarks/>
        public string venueName {
            get {
                return this.venueNameField;
            }
            set {
                this.venueNameField = value;
            }
        }
        
        /// <remarks/>
        public string venueAddress {
            get {
                return this.venueAddressField;
            }
            set {
                this.venueAddressField = value;
            }
        }
        
        /// <remarks/>
        public string venueCity {
            get {
                return this.venueCityField;
            }
            set {
                this.venueCityField = value;
            }
        }
        
        /// <remarks/>
        public string venueState {
            get {
                return this.venueStateField;
            }
            set {
                this.venueStateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Activity {
        
        private string activityIDField;
        
        private string activityTypeField;
        
        private string activityTimeField;
        
        private string activityDayField;
        
        private int activityPriceField;
        
        private string venueNameField;
        
        private string venueCityField;
        
        private string venueStateField;
        
        /// <remarks/>
        public string activityID {
            get {
                return this.activityIDField;
            }
            set {
                this.activityIDField = value;
            }
        }
        
        /// <remarks/>
        public string activityType {
            get {
                return this.activityTypeField;
            }
            set {
                this.activityTypeField = value;
            }
        }
        
        /// <remarks/>
        public string activityTime {
            get {
                return this.activityTimeField;
            }
            set {
                this.activityTimeField = value;
            }
        }
        
        /// <remarks/>
        public string activityDay {
            get {
                return this.activityDayField;
            }
            set {
                this.activityDayField = value;
            }
        }
        
        /// <remarks/>
        public int activityPrice {
            get {
                return this.activityPriceField;
            }
            set {
                this.activityPriceField = value;
            }
        }
        
        /// <remarks/>
        public string venueName {
            get {
                return this.venueNameField;
            }
            set {
                this.venueNameField = value;
            }
        }
        
        /// <remarks/>
        public string venueCity {
            get {
                return this.venueCityField;
            }
            set {
                this.venueCityField = value;
            }
        }
        
        /// <remarks/>
        public string venueState {
            get {
                return this.venueStateField;
            }
            set {
                this.venueStateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void GetActivityAgenciesCompletedEventHandler(object sender, GetActivityAgenciesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetActivityAgenciesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetActivityAgenciesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void GetActivitiesCompletedEventHandler(object sender, GetActivitiesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetActivitiesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetActivitiesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void FindActivitiesCompletedEventHandler(object sender, FindActivitiesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FindActivitiesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FindActivitiesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void FindActivities1CompletedEventHandler(object sender, FindActivities1CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FindActivities1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FindActivities1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void FindActivities2CompletedEventHandler(object sender, FindActivities2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FindActivities2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FindActivities2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void loginCheckCompletedEventHandler(object sender, loginCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class loginCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal loginCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    public delegate void ReserveCompletedEventHandler(object sender, ReserveCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2558.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReserveCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReserveCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591