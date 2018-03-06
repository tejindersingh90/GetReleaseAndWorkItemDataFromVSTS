using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.WebApi;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Microsoft.TeamFoundation.WorkItemTracking;

namespace ManagedClientConsoleAppSample
{
    class RestToData
    {
        //============= Config [Edit these with your settings] =====================
        internal const string vstsCollectionUrl = "https://fareportal.vsrm.visualstudio.com"; //change to the URL of your VSTS account; NOTE: This must use HTTPS
        //internal const string vstsCollectionUrl = "https:/"; //change to the URL of your VSTS account; NOTE: This must use HTTPS
        internal const string clientId = "872cd9fa-d31f-45e0-9eab-6e460a02d1f1";          //change to your app registration's Application ID, unless you are an MSA backed account
        internal const string replyUri = "urn:ietf:wg:oauth:2.0:oob";                     //change to your app registration's reply URI, unless you are an MSA backed account
        //==========================================================================

        internal const string VSTSResourceId = "499b84ac-1321-427f-aa17-267ca6975798"; //Constant value to target VSTS. Do not change

        internal const string VSTSKey = "76implkznhgunulcoqeyim2wvrciszzusse4fzbap5cxszk2uusq"; //Constant value to target VSTS Credential.


        public static void Main(string[] args)
        {
            Console.WriteLine("App package to gather Data from VSTS Rest API -> SQL DataBase By Tejinder Singh");
            AuthenticationContext ctx = GetAuthenticationContext(null);
            AuthenticationResult result = null;
            ClientCredential clientCred = new ClientCredential(clientId, VSTSKey);            
            try
            {
                //PromptBehavior.RefreshSession will enforce an authn prompt every time. NOTE: Auto will take your windows login state if possible
                //****Uncomment to enable Login GUI****
                //result = ctx.AcquireTokenAsync(VSTSResourceId, clientId, new Uri(replyUri), new PlatformParameters(PromptBehavior.Auto)).Result;                              
                //Console.WriteLine("Your authentication token will expire on: " + result.ExpiresOn);
                //****Uncomment to enable Login GUI****

                var base64Token = Convert.ToBase64String(Encoding.ASCII.GetBytes($":{VSTSKey}"));
                //****Uncomment to enable Login GUI****
                //var bearerAuthHeader = new AuthenticationHeaderValue("Bearer", result.AccessToken);
                //****Uncomment to enable Login GUI****
                //using (SqlConnection connection = new SqlConnection("Data Source = GGNB3FFTEC011W; Initial Catalog = ReleaseBIReports; integrated security = SSPI"))
                {
                    //connection.Open();
                    //****Uncomment to enable Login GUI****
                    //ListProjects(bearerAuthHeader);
                    //****Uncomment to enable Login GUI****
                    //connection.Close();

                    var authNew =  new AuthenticationHeaderValue("Basic", base64Token);
                    ListProjects(authNew);
                }
                Console.WriteLine("All done. Press any key to finish...");
            }
            catch (UnauthorizedAccessException)
            {
                // If the token has expired, prompt the user with a login prompt
                result = ctx.AcquireTokenAsync(VSTSResourceId, clientId, new Uri(replyUri), new PlatformParameters(PromptBehavior.Always)).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType(), ex.Message);
                Console.ReadLine();
            }
        }

        private static AuthenticationContext GetAuthenticationContext(string tenant)
        {
            AuthenticationContext ctx = null;
            if (tenant != null)
                ctx = new AuthenticationContext("https://login.microsoftonline.com/" + tenant);
            else
            {
                ctx = new AuthenticationContext("https://login.windows.net/common");
                if (ctx.TokenCache.Count > 0)
                {
                    string homeTenant = ctx.TokenCache.ReadItems().First().TenantId;
                    ctx = new AuthenticationContext("https://login.microsoftonline.com/" + homeTenant);
                }
            }

            return ctx;
        }

        private static void ListProjects(AuthenticationHeaderValue authHeader)
        {
            try
            {
                DataBaseConn db = new DataBaseConn();
                int DBTopId = db.getDBTopId();
                // use the httpclient
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(vstsCollectionUrl);
                    //client.BaseAddress = new Uri("");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", "ManagedClientConsoleAppSample");
                    client.DefaultRequestHeaders.Add("X-TFS-FedAuthRedirect", "Suppress");
                    client.DefaultRequestHeaders.Authorization = authHeader;

                    // connect to the REST endpoint 
                    HttpResponseMessage responseTillRun = client.GetAsync("/engineering/_apis/release/releases?$top=100&$expand=environments").Result;

                    if (DBTopId != 0)
                    {
                        appendNewRows(responseTillRun, DBTopId, client, authHeader);
                        //Console.WriteLine("if condition called");
                    }

                    else
                    {
                        HttpResponseMessage response = client.GetAsync("/engineering/_apis/release/releases?$top=100&$expand=environments&queryOrder=ascending").Result;
                        //HttpResponseMessage response = client.GetAsync("/engineering/_apis/release/releases?$top=2&$expand=environments").Result;
                        //int continuousToken = (Convert.ToBoolean(response.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault())) ? Convert.ToInt32(response.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault()) : 1;

                        int continuousToken = Convert.ToInt32(response.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault());
                        int continuousTokenFinalRun = Convert.ToInt32(responseTillRun.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault());
                        // check to see if we have a succesfull respond
                        if (response.IsSuccessStatusCode)
                        {
                            //DoTheMainWork(response);
                            //**** DB Connection*****    
                            Consolidated obj = new Consolidated();
                            Rootobject result = JsonConvert.DeserializeObject<Rootobject>(response.Content.ReadAsStringAsync().Result);
                            obj.classRootObject = result;
                            obj.classWorkItemClass = getWorkItemId(result, client, authHeader);
                            
                            db.getDBConn(obj);

                            if (continuousToken != 0)
                            {
                                Consolidated obj2 = new Consolidated();
                                try
                                {
                                    for (int i = 0; i <= continuousTokenFinalRun;)
                                    {
                                        HttpResponseMessage responseNew = client.GetAsync("/engineering/_apis/release/releases?$top=100&$expand=environments&queryOrder=ascending&continuationToken=" + continuousToken).Result;
                                        int continuousTokenNew = Convert.ToInt32(responseNew.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault());
                                        Rootobject result2 = JsonConvert.DeserializeObject<Rootobject>(responseNew.Content.ReadAsStringAsync().Result);
                                        obj2.classRootObject = result2;
                                        obj2.classWorkItemClass = getWorkItemId(result2, client, authHeader);
                                        db.getDBConn(obj2);
                                        continuousToken = continuousTokenNew;
                                        i = continuousToken;
                                    }
                                    //DoTheMainWork2(null, true);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error inside ListProjects 1 :  " + ex.Message);
                                }

                            }



                        }
                        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        {
                            throw new UnauthorizedAccessException();
                        }
                        else
                        {
                            Console.WriteLine("{0}:{1}", response.StatusCode, response.ReasonPhrase);
                            Console.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inside ListProjects 2 :  " + ex.Message);
            }
            Console.WriteLine("Data gathered, press any key to exit!");
            //Console.ReadLine();

        }

        private static void appendNewRows(HttpResponseMessage responseTillRun, int DBTopId, HttpClient client, AuthenticationHeaderValue authHeader)
        {
            int continuousTokenFinalRun = Convert.ToInt32(responseTillRun.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault());
            int continuousToken = DBTopId + 1;
            DataBaseConn db = new DataBaseConn();
            Consolidated obj3 = new Consolidated();
            try
            {
                for (int i = 0; i <= continuousTokenFinalRun;)
                {
                    HttpResponseMessage responseNew = client.GetAsync("/engineering/_apis/release/releases?$top=10&$expand=environments&queryOrder=ascending&continuationToken=" + continuousToken).Result;
                    int continuousTokenNew = Convert.ToInt32(responseNew.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault());
                    Rootobject result2 = JsonConvert.DeserializeObject<Rootobject>(responseNew.Content.ReadAsStringAsync().Result);
                    obj3.classRootObject = result2;
                    obj3.classWorkItemClass = getWorkItemId(result2, client, authHeader);
                    db.getDBConn(obj3);
                    continuousToken = continuousTokenNew;
                    i = continuousToken;
                }
                //DoTheMainWork2(null, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inside amendNewRows :  " + ex.Message);
            }
        }

        //******Get work item ID*******
        private static List<WorkItemClass> getWorkItemId(Rootobject result, HttpClient client, AuthenticationHeaderValue authHeader)
        {
            List<WorkItemClass> workItem = new List<WorkItemClass>();
            foreach (var id in result.value)
            {
                if (!string.IsNullOrEmpty(id.ToString()))
                {

                    HttpResponseMessage response = client.GetAsync("/Engineering/_apis/release/releases/" + id.id + "/workitems").Result;
                    WorkItemIdClass itemId = JsonConvert.DeserializeObject<WorkItemIdClass>(response.Content.ReadAsStringAsync().Result);
                    if (itemId!=null && itemId.value != null && itemId.count>0)
                    {
                        workItem.AddRange(getWorkItem(itemId, authHeader, id.id));
                    }

                }
            }
            return workItem;
        }

        //******Get work item *******
        private static List<WorkItemClass> getWorkItem(WorkItemIdClass itemId, AuthenticationHeaderValue authHeader, int resultId)
        {
            List<WorkItemClass> workItem = new List<WorkItemClass>();
            try
            {                
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://tfsprodcus2.visualstudio.com");
                //client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "ManagedClientConsoleAppSample");
                client.DefaultRequestHeaders.Add("X-TFS-FedAuthRedirect", "Suppress");
                client.DefaultRequestHeaders.Authorization = authHeader;
                //const string newUrl = "https://tfsprodcus2.visualstudio.com/Aade702de-d9d9-418b-8e06-5fedd74e5d58/";
                //client.BaseAddress = new Uri(newUrl);
                if (itemId != null)
                {
                    foreach (var id in itemId.value)
                    {
                        if (!string.IsNullOrEmpty(id.ToString()))
                        {
                            try
                            {
                                HttpResponseMessage response = client.GetAsync("/Aade702de-d9d9-418b-8e06-5fedd74e5d58/_apis/wit/workItems/" + id.id).Result;
                                WorkItemClass item = (JsonConvert.DeserializeObject<WorkItemClass>(response.Content.ReadAsStringAsync().Result));
                                item.releaseId = resultId;
                                workItem.Add(item);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error in getWorkItem 0 : " + ex.Message + " and ID : " + id.id);
                                break;
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getWorkItem " + ex.Message);
            }

            return workItem;
        }

    }


}
