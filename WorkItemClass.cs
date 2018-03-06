using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ManagedClientConsoleAppSample
{

    public class WorkItemClass
    {
        public int id { get; set; }
        public int? rev { get; set; }
        public Fields fields { get; set; }
        public _Links _links { get; set; }
        public string url { get; set; }

        public int? releaseId { get; set; }
    }

    [DataContract]
    public class Fields
    {
        [DataMember(Name = "System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [DataMember(Name = "System.TeamProject")]
        public string SystemTeamProject { get; set; }

        [DataMember(Name = "System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [DataMember(Name = "System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [DataMember(Name = "System.State")]
        public string SystemState { get; set; }

        [DataMember(Name = "System.Reason")]
        public string SystemReason { get; set; }

        [DataMember(Name = "System.AssignedTo")]
        public string SystemAssignedTo { get; set; }

        [DataMember(Name = "System.CreatedDate")]
        public DateTime SystemCreatedDate { get; set; }

        [DataMember(Name = "System.CreatedBy")]
        public string SystemCreatedBy { get; set; }

        [DataMember(Name = "System.ChangedDate")]
        public DateTime SystemChangedDate { get; set; }

        [DataMember(Name = "System.ChangedBy")]
        public string SystemChangedBy { get; set; }

        [DataMember(Name = "System.Title")]
        public string SystemTitle { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Scheduling.CompletedWork")]
        public float MicrosoftVSTSSchedulingCompletedWork { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime MicrosoftVSTSCommonStateChangeDate { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.Activity")]
        public string MicrosoftVSTSCommonActivity { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.ActivatedDate")]
        public DateTime MicrosoftVSTSCommonActivatedDate { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.ActivatedBy")]
        public string MicrosoftVSTSCommonActivatedBy { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.ClosedDate")]
        public DateTime MicrosoftVSTSCommonClosedDate { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.ClosedBy")]
        public string MicrosoftVSTSCommonClosedBy { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.Priority")]
        public int? MicrosoftVSTSCommonPriority { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.ResolvedDate")]
        public DateTime MicrosoftVSTSCommonResolvedDate { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.ResolvedBy")]
        public string MicrosoftVSTSCommonResolvedBy { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.ResolvedReason")]
        public string MicrosoftVSTSCommonResolvedReason { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.Severity")]
        public string MicrosoftVSTSCommonSeverity { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.StackRank")]
        public float? MicrosoftVSTSCommonStackRank { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Common.ValueArea")]
        public string MicrosoftVSTSCommonValueArea { get; set; }

        [DataMember(Name = "Microsoft.VSTS.Scheduling.StoryPoints")]
        public float? MicrosoftVSTSSchedulingStoryPoints { get; set; }
    }

    public class _LinksWorkItemClass
    {
        public Self self { get; set; }
        public Workitemupdates workItemUpdates { get; set; }
        public Workitemrevisions workItemRevisions { get; set; }
        public Workitemhistory workItemHistory { get; set; }
        public Html html { get; set; }
        public Workitemtype workItemType { get; set; }
        public Fields1 fields { get; set; }
    }

    public class SelfWorkItemClass
    {
        public string href { get; set; }
    }

    public class Workitemupdates
    {
        public string href { get; set; }
    }

    public class Workitemrevisions
    {
        public string href { get; set; }
    }

    public class Workitemhistory
    {
        public string href { get; set; }
    }

    public class Html
    {
        public string href { get; set; }
    }

    public class Workitemtype
    {
        public string href { get; set; }
    }

    public class Fields1
    {
        public string href { get; set; }
    }

}
