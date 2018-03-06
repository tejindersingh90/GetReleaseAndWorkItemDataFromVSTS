using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ManagedClientConsoleAppSample
{
    
    public class Rootobject
    {
        public int? count { get; set; }

       
        public Value[] value { get; set; }
    }

    
    public class Value
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime modifiedOn { get; set; }
        public Modifiedby modifiedBy { get; set; }
        public Createdby createdBy { get; set; }
        public Environment[] environments { get; set; }
        
        public Variables variables { get; set; }
        
        public object[] variableGroups { get; set; }
        public Releasedefinition releaseDefinition { get; set; }
        public string description { get; set; }
        public string reason { get; set; }
        public string releaseNameFormat { get; set; }
        public bool keepForever { get; set; }
        public int definitionSnapshotRevision { get; set; }
        
        public string logsContainerUrl { get; set; }
        
        public string url { get; set; }
        
        public _Links1 _links { get; set; }
        public object[] tags { get; set; }
        
        public Projectreference projectReference { get; set; }
        
        public Properties properties { get; set; }

    }

    public class Modifiedby
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
    }

    public class Createdby
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
    }

    public class Variables
    {
    }

    public class Releasedefinition
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public _Links _links { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
        public Web web { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
    }

    public class _Links1
    {
        public Self1 self { get; set; }
        public Web1 web { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
    }

    public class Web1
    {
        public string href { get; set; }
    }

    public class Projectreference
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Properties
    {
    }

    public class Environment
    {
        public int id { get; set; }
        public int releaseId { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        
        public Variables1 variables { get; set; }
        
        public object[] variableGroups { get; set; }
        
        public Deploystep[] deploySteps { get; set; }
        public int rank { get; set; }
        public int definitionEnvironmentId { get; set; }
        
        public Environmentoptions environmentOptions { get; set; }
        
        public object[] demands { get; set; }
        
        public Condition[] conditions { get; set; }
        
        public object[] workflowTasks { get; set; }
        
        public object[] deployPhasesSnapshot { get; set; }
        
        public Owner owner { get; set; }
        
        public object[] schedules { get; set; }
        public Release release { get; set; }
        public Releasedefinition1 releaseDefinition { get; set; }
        public Releasecreatedby releaseCreatedBy { get; set; }
        public string triggerReason { get; set; }
        
        public Processparameters processParameters { get; set; }
    }

    public class Variables1
    {
    }

    public class Environmentoptions
    {
        public string emailNotificationType { get; set; }
        public string emailRecipients { get; set; }
        public bool skipArtifactsDownload { get; set; }
        public int timeoutInMinutes { get; set; }
        public bool enableAccessToken { get; set; }
        public bool publishDeploymentStatus { get; set; }
    }

    public class Owner
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
    }

    public class Release
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public _Links2 _links { get; set; }
    }

    public class _Links2
    {
        public Web2 web { get; set; }
        public Self2 self { get; set; }
    }

    public class Web2
    {
        public string href { get; set; }
    }

    public class Self2
    {
        public string href { get; set; }
    }

    public class Releasedefinition1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public _Links3 _links { get; set; }
    }

    public class _Links3
    {
        public Web3 web { get; set; }
        public Self3 self { get; set; }
    }

    public class Web3
    {
        public string href { get; set; }
    }

    public class Self3
    {
        public string href { get; set; }
    }

    public class Releasecreatedby
    {
        public string id { get; set; }
        public string displayName { get; set; }
    }

    public class Processparameters
    {
    }

    public class Deploystep
    {
        public int id { get; set; }
        public int deploymentId { get; set; }
        public int attempt { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public string operationStatus { get; set; }
        public Releasedeployphas[] releaseDeployPhases { get; set; }
        public Requestedby requestedBy { get; set; }
        public Requestedfor requestedFor { get; set; }
        public DateTime queuedOn { get; set; }
        public Lastmodifiedby lastModifiedBy { get; set; }
        public DateTime lastModifiedOn { get; set; }
        public bool hasStarted { get; set; }
        public object[] tasks { get; set; }
        public string runPlanId { get; set; }
    }

    public class Requestedby
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
    }

    public class Requestedfor
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
    }

    public class Lastmodifiedby
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
    }

    public class Releasedeployphas
    {
        public int id { get; set; }
        public int rank { get; set; }
        public string phaseType { get; set; }
        public string status { get; set; }
        public object runPlanId { get; set; }
        public object[] deploymentJobs { get; set; }
        public string errorLog { get; set; }
        public object[] manualInterventions { get; set; }
    }

    public class Condition
    {
        
        public bool? result { get; set; }
        public string name { get; set; }
        public string conditionType { get; set; }
        public string value { get; set; }
    }

}
