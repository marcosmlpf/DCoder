﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 12.0.21005.1
// 
namespace MachineLearningEngine.ServiceReference1 {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Post", Namespace="http://schemas.datacontract.org/2004/07/DataServices")]
    public partial class Post : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string BENEFITSField;
        
        private string CAREER_DEVELOPMENTField;
        
        private string CELEBRATIONField;
        
        private string COLLABORATION_CULTUREField;
        
        private string CardIdField;
        
        private string DescriptionField;
        
        private string ENVIR_HEALTHYField;
        
        private string FELLOWSHIPField;
        
        private string HIRING_EFFECTIVITYField;
        
        private string INFRASTRUCTUREField;
        
        private string INNOVATION_CULTUREField;
        
        private int IdField;
        
        private string MANAGEMENT_CULTUREField;
        
        private string MANAGEMENT_FEEDBACKField;
        
        private string MANAGEMENT_RESPECTField;
        
        private string NO_DISCRIMINATIONField;
        
        private string OPEN_COMMUNICATIONField;
        
        private string PAYField;
        
        private string PURPOSEField;
        
        private string PersonTitleField;
        
        private System.Nullable<System.DateTime> PostDateField;
        
        private string PredictionLabelResultField;
        
        private string ProviderUserIdField;
        
        private string RECOGNITIONField;
        
        private string SOCIAL_WORK_BALANCEField;
        
        private string StatusField;
        
        private string TRAININGField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BENEFITS {
            get {
                return this.BENEFITSField;
            }
            set {
                if ((object.ReferenceEquals(this.BENEFITSField, value) != true)) {
                    this.BENEFITSField = value;
                    this.RaisePropertyChanged("BENEFITS");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CAREER_DEVELOPMENT {
            get {
                return this.CAREER_DEVELOPMENTField;
            }
            set {
                if ((object.ReferenceEquals(this.CAREER_DEVELOPMENTField, value) != true)) {
                    this.CAREER_DEVELOPMENTField = value;
                    this.RaisePropertyChanged("CAREER_DEVELOPMENT");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CELEBRATION {
            get {
                return this.CELEBRATIONField;
            }
            set {
                if ((object.ReferenceEquals(this.CELEBRATIONField, value) != true)) {
                    this.CELEBRATIONField = value;
                    this.RaisePropertyChanged("CELEBRATION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string COLLABORATION_CULTURE {
            get {
                return this.COLLABORATION_CULTUREField;
            }
            set {
                if ((object.ReferenceEquals(this.COLLABORATION_CULTUREField, value) != true)) {
                    this.COLLABORATION_CULTUREField = value;
                    this.RaisePropertyChanged("COLLABORATION_CULTURE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardId {
            get {
                return this.CardIdField;
            }
            set {
                if ((object.ReferenceEquals(this.CardIdField, value) != true)) {
                    this.CardIdField = value;
                    this.RaisePropertyChanged("CardId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ENVIR_HEALTHY {
            get {
                return this.ENVIR_HEALTHYField;
            }
            set {
                if ((object.ReferenceEquals(this.ENVIR_HEALTHYField, value) != true)) {
                    this.ENVIR_HEALTHYField = value;
                    this.RaisePropertyChanged("ENVIR_HEALTHY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FELLOWSHIP {
            get {
                return this.FELLOWSHIPField;
            }
            set {
                if ((object.ReferenceEquals(this.FELLOWSHIPField, value) != true)) {
                    this.FELLOWSHIPField = value;
                    this.RaisePropertyChanged("FELLOWSHIP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HIRING_EFFECTIVITY {
            get {
                return this.HIRING_EFFECTIVITYField;
            }
            set {
                if ((object.ReferenceEquals(this.HIRING_EFFECTIVITYField, value) != true)) {
                    this.HIRING_EFFECTIVITYField = value;
                    this.RaisePropertyChanged("HIRING_EFFECTIVITY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string INFRASTRUCTURE {
            get {
                return this.INFRASTRUCTUREField;
            }
            set {
                if ((object.ReferenceEquals(this.INFRASTRUCTUREField, value) != true)) {
                    this.INFRASTRUCTUREField = value;
                    this.RaisePropertyChanged("INFRASTRUCTURE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string INNOVATION_CULTURE {
            get {
                return this.INNOVATION_CULTUREField;
            }
            set {
                if ((object.ReferenceEquals(this.INNOVATION_CULTUREField, value) != true)) {
                    this.INNOVATION_CULTUREField = value;
                    this.RaisePropertyChanged("INNOVATION_CULTURE");
                }
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
        public string MANAGEMENT_CULTURE {
            get {
                return this.MANAGEMENT_CULTUREField;
            }
            set {
                if ((object.ReferenceEquals(this.MANAGEMENT_CULTUREField, value) != true)) {
                    this.MANAGEMENT_CULTUREField = value;
                    this.RaisePropertyChanged("MANAGEMENT_CULTURE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MANAGEMENT_FEEDBACK {
            get {
                return this.MANAGEMENT_FEEDBACKField;
            }
            set {
                if ((object.ReferenceEquals(this.MANAGEMENT_FEEDBACKField, value) != true)) {
                    this.MANAGEMENT_FEEDBACKField = value;
                    this.RaisePropertyChanged("MANAGEMENT_FEEDBACK");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MANAGEMENT_RESPECT {
            get {
                return this.MANAGEMENT_RESPECTField;
            }
            set {
                if ((object.ReferenceEquals(this.MANAGEMENT_RESPECTField, value) != true)) {
                    this.MANAGEMENT_RESPECTField = value;
                    this.RaisePropertyChanged("MANAGEMENT_RESPECT");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NO_DISCRIMINATION {
            get {
                return this.NO_DISCRIMINATIONField;
            }
            set {
                if ((object.ReferenceEquals(this.NO_DISCRIMINATIONField, value) != true)) {
                    this.NO_DISCRIMINATIONField = value;
                    this.RaisePropertyChanged("NO_DISCRIMINATION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OPEN_COMMUNICATION {
            get {
                return this.OPEN_COMMUNICATIONField;
            }
            set {
                if ((object.ReferenceEquals(this.OPEN_COMMUNICATIONField, value) != true)) {
                    this.OPEN_COMMUNICATIONField = value;
                    this.RaisePropertyChanged("OPEN_COMMUNICATION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PAY {
            get {
                return this.PAYField;
            }
            set {
                if ((object.ReferenceEquals(this.PAYField, value) != true)) {
                    this.PAYField = value;
                    this.RaisePropertyChanged("PAY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PURPOSE {
            get {
                return this.PURPOSEField;
            }
            set {
                if ((object.ReferenceEquals(this.PURPOSEField, value) != true)) {
                    this.PURPOSEField = value;
                    this.RaisePropertyChanged("PURPOSE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PersonTitle {
            get {
                return this.PersonTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonTitleField, value) != true)) {
                    this.PersonTitleField = value;
                    this.RaisePropertyChanged("PersonTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> PostDate {
            get {
                return this.PostDateField;
            }
            set {
                if ((this.PostDateField.Equals(value) != true)) {
                    this.PostDateField = value;
                    this.RaisePropertyChanged("PostDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PredictionLabelResult {
            get {
                return this.PredictionLabelResultField;
            }
            set {
                if ((object.ReferenceEquals(this.PredictionLabelResultField, value) != true)) {
                    this.PredictionLabelResultField = value;
                    this.RaisePropertyChanged("PredictionLabelResult");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProviderUserId {
            get {
                return this.ProviderUserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ProviderUserIdField, value) != true)) {
                    this.ProviderUserIdField = value;
                    this.RaisePropertyChanged("ProviderUserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RECOGNITION {
            get {
                return this.RECOGNITIONField;
            }
            set {
                if ((object.ReferenceEquals(this.RECOGNITIONField, value) != true)) {
                    this.RECOGNITIONField = value;
                    this.RaisePropertyChanged("RECOGNITION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SOCIAL_WORK_BALANCE {
            get {
                return this.SOCIAL_WORK_BALANCEField;
            }
            set {
                if ((object.ReferenceEquals(this.SOCIAL_WORK_BALANCEField, value) != true)) {
                    this.SOCIAL_WORK_BALANCEField = value;
                    this.RaisePropertyChanged("SOCIAL_WORK_BALANCE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TRAINING {
            get {
                return this.TRAININGField;
            }
            set {
                if ((object.ReferenceEquals(this.TRAININGField, value) != true)) {
                    this.TRAININGField = value;
                    this.RaisePropertyChanged("TRAINING");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ExternalEvaluation", Namespace="http://schemas.datacontract.org/2004/07/DataServices")]
    public partial class ExternalEvaluation : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string AdiceToPresidentField;
        
        private string CommentField;
        
        private string ConsField;
        
        private int IdField;
        
        private string PosField;
        
        private string PredictionLabelResultField;
        
        private string RatingField;
        
        private string RecommendField;
        
        private string SourceField;
        
        private string UserProfileField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AdiceToPresident {
            get {
                return this.AdiceToPresidentField;
            }
            set {
                if ((object.ReferenceEquals(this.AdiceToPresidentField, value) != true)) {
                    this.AdiceToPresidentField = value;
                    this.RaisePropertyChanged("AdiceToPresident");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Comment {
            get {
                return this.CommentField;
            }
            set {
                if ((object.ReferenceEquals(this.CommentField, value) != true)) {
                    this.CommentField = value;
                    this.RaisePropertyChanged("Comment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cons {
            get {
                return this.ConsField;
            }
            set {
                if ((object.ReferenceEquals(this.ConsField, value) != true)) {
                    this.ConsField = value;
                    this.RaisePropertyChanged("Cons");
                }
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
        public string Pos {
            get {
                return this.PosField;
            }
            set {
                if ((object.ReferenceEquals(this.PosField, value) != true)) {
                    this.PosField = value;
                    this.RaisePropertyChanged("Pos");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PredictionLabelResult {
            get {
                return this.PredictionLabelResultField;
            }
            set {
                if ((object.ReferenceEquals(this.PredictionLabelResultField, value) != true)) {
                    this.PredictionLabelResultField = value;
                    this.RaisePropertyChanged("PredictionLabelResult");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Rating {
            get {
                return this.RatingField;
            }
            set {
                if ((object.ReferenceEquals(this.RatingField, value) != true)) {
                    this.RatingField = value;
                    this.RaisePropertyChanged("Rating");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Recommend {
            get {
                return this.RecommendField;
            }
            set {
                if ((object.ReferenceEquals(this.RecommendField, value) != true)) {
                    this.RecommendField = value;
                    this.RaisePropertyChanged("Recommend");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Source {
            get {
                return this.SourceField;
            }
            set {
                if ((object.ReferenceEquals(this.SourceField, value) != true)) {
                    this.SourceField = value;
                    this.RaisePropertyChanged("Source");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserProfile {
            get {
                return this.UserProfileField;
            }
            set {
                if ((object.ReferenceEquals(this.UserProfileField, value) != true)) {
                    this.UserProfileField = value;
                    this.RaisePropertyChanged("UserProfile");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TouchPoint", Namespace="http://schemas.datacontract.org/2004/07/DataServices")]
    public partial class TouchPoint : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string CardIdField;
        
        private string EventTypeField;
        
        private int IdField;
        
        private System.Nullable<System.DateTime> OccurrenceDateField;
        
        private string PersonIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardId {
            get {
                return this.CardIdField;
            }
            set {
                if ((object.ReferenceEquals(this.CardIdField, value) != true)) {
                    this.CardIdField = value;
                    this.RaisePropertyChanged("CardId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EventType {
            get {
                return this.EventTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.EventTypeField, value) != true)) {
                    this.EventTypeField = value;
                    this.RaisePropertyChanged("EventType");
                }
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
        public System.Nullable<System.DateTime> OccurrenceDate {
            get {
                return this.OccurrenceDateField;
            }
            set {
                if ((this.OccurrenceDateField.Equals(value) != true)) {
                    this.OccurrenceDateField = value;
                    this.RaisePropertyChanged("OccurrenceDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PersonId {
            get {
                return this.PersonIdField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonIdField, value) != true)) {
                    this.PersonIdField = value;
                    this.RaisePropertyChanged("PersonId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/DataServices")]
    public partial class Person : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int IdField;
        
        private string PersonIdField;
        
        private string PositionField;
        
        private string displayNameField;
        
        private string genderField;
        
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
        public string PersonId {
            get {
                return this.PersonIdField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonIdField, value) != true)) {
                    this.PersonIdField = value;
                    this.RaisePropertyChanged("PersonId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Position {
            get {
                return this.PositionField;
            }
            set {
                if ((object.ReferenceEquals(this.PositionField, value) != true)) {
                    this.PositionField = value;
                    this.RaisePropertyChanged("Position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string displayName {
            get {
                return this.displayNameField;
            }
            set {
                if ((object.ReferenceEquals(this.displayNameField, value) != true)) {
                    this.displayNameField = value;
                    this.RaisePropertyChanged("displayName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string gender {
            get {
                return this.genderField;
            }
            set {
                if ((object.ReferenceEquals(this.genderField, value) != true)) {
                    this.genderField = value;
                    this.RaisePropertyChanged("gender");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IPredictionDataService")]
    public interface IPredictionDataService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPredictionDataService/GetAllPosts", ReplyAction="http://tempuri.org/IPredictionDataService/GetAllPostsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<MachineLearningEngine.ServiceReference1.Post>> GetAllPostsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPredictionDataService/GetPostByStatus", ReplyAction="http://tempuri.org/IPredictionDataService/GetPostByStatusResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<MachineLearningEngine.ServiceReference1.Post>> GetPostByStatusAsync(string status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPredictionDataService/UpdatePost", ReplyAction="http://tempuri.org/IPredictionDataService/UpdatePostResponse")]
        System.Threading.Tasks.Task UpdatePostAsync(MachineLearningEngine.ServiceReference1.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPredictionDataService/AddPost", ReplyAction="http://tempuri.org/IPredictionDataService/AddPostResponse")]
        System.Threading.Tasks.Task AddPostAsync(MachineLearningEngine.ServiceReference1.Post post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPredictionDataService/AddExternalContent", ReplyAction="http://tempuri.org/IPredictionDataService/AddExternalContentResponse")]
        System.Threading.Tasks.Task AddExternalContentAsync(MachineLearningEngine.ServiceReference1.ExternalEvaluation post);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPredictionDataService/AddTouchPoint", ReplyAction="http://tempuri.org/IPredictionDataService/AddTouchPointResponse")]
        System.Threading.Tasks.Task AddTouchPointAsync(MachineLearningEngine.ServiceReference1.TouchPoint touchPoint);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPredictionDataService/AddPerson", ReplyAction="http://tempuri.org/IPredictionDataService/AddPersonResponse")]
        System.Threading.Tasks.Task AddPersonAsync(MachineLearningEngine.ServiceReference1.Person person);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPredictionDataService/GetCategoryByLabel", ReplyAction="http://tempuri.org/IPredictionDataService/GetCategoryByLabelResponse")]
        System.Threading.Tasks.Task<string> GetCategoryByLabelAsync(string label);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPredictionDataServiceChannel : MachineLearningEngine.ServiceReference1.IPredictionDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PredictionDataServiceClient : System.ServiceModel.ClientBase<MachineLearningEngine.ServiceReference1.IPredictionDataService>, MachineLearningEngine.ServiceReference1.IPredictionDataService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public PredictionDataServiceClient() : 
                base(PredictionDataServiceClient.GetDefaultBinding(), PredictionDataServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IPredictionDataService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PredictionDataServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(PredictionDataServiceClient.GetBindingForEndpoint(endpointConfiguration), PredictionDataServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PredictionDataServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(PredictionDataServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PredictionDataServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(PredictionDataServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public PredictionDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<MachineLearningEngine.ServiceReference1.Post>> GetAllPostsAsync() {
            return base.Channel.GetAllPostsAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<MachineLearningEngine.ServiceReference1.Post>> GetPostByStatusAsync(string status) {
            return base.Channel.GetPostByStatusAsync(status);
        }
        
        public System.Threading.Tasks.Task UpdatePostAsync(MachineLearningEngine.ServiceReference1.Post post) {
            return base.Channel.UpdatePostAsync(post);
        }
        
        public System.Threading.Tasks.Task AddPostAsync(MachineLearningEngine.ServiceReference1.Post post) {
            return base.Channel.AddPostAsync(post);
        }
        
        public System.Threading.Tasks.Task AddExternalContentAsync(MachineLearningEngine.ServiceReference1.ExternalEvaluation post) {
            return base.Channel.AddExternalContentAsync(post);
        }
        
        public System.Threading.Tasks.Task AddTouchPointAsync(MachineLearningEngine.ServiceReference1.TouchPoint touchPoint) {
            return base.Channel.AddTouchPointAsync(touchPoint);
        }
        
        public System.Threading.Tasks.Task AddPersonAsync(MachineLearningEngine.ServiceReference1.Person person) {
            return base.Channel.AddPersonAsync(person);
        }
        
        public System.Threading.Tasks.Task<string> GetCategoryByLabelAsync(string label) {
            return base.Channel.GetCategoryByLabelAsync(label);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IPredictionDataService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IPredictionDataService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/DataServices/Service1/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return PredictionDataServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IPredictionDataService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return PredictionDataServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IPredictionDataService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IPredictionDataService,
        }
    }
}
