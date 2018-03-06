using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.WebApi;
using System.IO;


namespace ManagedClientConsoleAppSample
{
    //After running the console will close so please add a breakpoint or sleep to see output.
    class Program
    {
        //============= Config [Edit these with your settings] =====================
        internal const string vstsCollectionUrl = "https://fareportal.vsrm.visualstudio.com"; //change to the URL of your VSTS account; NOTE: This must use HTTPS
        internal const string clientId = "872cd9fa-d31f-45e0-9eab-6e460a02d1f1";          //change to your app registration's Application ID, unless you are an MSA backed account
        internal const string replyUri = "urn:ietf:wg:oauth:2.0:oob";                     //change to your app registration's reply URI, unless you are an MSA backed account
        //==========================================================================

        internal const string VSTSResourceId = "499b84ac-1321-427f-aa17-267ca6975798"; //Constant value to target VSTS. Do not change  

        
        public static void Main(string[] args)
        {
            AuthenticationContext ctx = GetAuthenticationContext(null);
            AuthenticationResult result = null;
            try
            {
                //PromptBehavior.RefreshSession will enforce an authn prompt every time. NOTE: Auto will take your windows login state if possible
                result = ctx.AcquireTokenAsync(VSTSResourceId, clientId, new Uri(replyUri), new PlatformParameters(PromptBehavior.Always)).Result;
                Console.WriteLine("Token expires on: " + result.ExpiresOn);

                var bearerAuthHeader = new AuthenticationHeaderValue("Bearer", result.AccessToken);
                ListProjects(bearerAuthHeader);
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
            // use the httpclient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(vstsCollectionUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "ManagedClientConsoleAppSample");
                client.DefaultRequestHeaders.Add("X-TFS-FedAuthRedirect", "Suppress");                
                client.DefaultRequestHeaders.Authorization = authHeader;
                 
                // connect to the REST endpoint            
                //HttpResponseMessage response = client.GetAsync("_apis/projects?stateFilter=All&top=500&api-version=2.2").Result;
                HttpResponseMessage response = client.GetAsync("/engineering/_apis/release/releases?$top=100&$expand=environments&minCreatedTime=11-20-2017&maxCreatedTime=11-25-2017").Result;
                //int continuousToken = (Convert.ToBoolean(response.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault())) ? Convert.ToInt32(response.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault()) : 0;
                int continuousToken = Convert.ToInt32(response.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault());

                // check to see if we have a succesfull respond
                if (response.IsSuccessStatusCode)
                {
                    DoTheMainWork(response);

                    if (continuousToken != 0)
                    {
                        for (int i = continuousToken; i >= 0; i = i - 100)
                        {
                            HttpResponseMessage responseNew = client.GetAsync("/engineering/_apis/release/releases?$top=100&$expand=environments&minCreatedTime=11-20-2017&maxCreatedTime=11-25-2017&continuationToken=" + continuousToken).Result;
                            //HttpResponseMessage responseNew = client.GetAsync("/engineering/_apis/release/releases?$top=100&continuationToken=" + continuousToken).Result;
                            //int continuousTokenNew = Convert.ToInt32(responseNew.Headers.FirstOrDefault(x => x.Key == "x-ms-continuationtoken").Value.FirstOrDefault());
                            int continuousTokenNew = Convert.ToInt32(continuousToken - 100);
                            DoTheMainWork2(responseNew);
                            continuousToken = continuousTokenNew;
                        }
                        DoTheMainWork2(null, true);
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
            Console.WriteLine("Data gathered, press any key to exit!");
            Console.ReadLine();
        }

        private static void DoTheMainWork(HttpResponseMessage response)
        {
            Console.WriteLine("\tSuccesful REST call");
            //Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            Console.WriteLine("\nWriting REST result into data.json .....");

            // *****code to write text start****
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                if(File.Exists("C:\\Users\\t.s.z4ni\\Desktop\\dataOct.json"))
                {
                    System.IO.File.WriteAllText(@"C:\\Users\\t.s.z4ni\\Desktop\\dataOct.json", string.Empty);
                }
                ostrm = new FileStream("C:\\Users\\t.s.z4ni\\Desktop\\dataOct.json", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result.Substring(0, response.Content.ReadAsStringAsync().Result.ToString().LastIndexOf(']')));
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            
            // code to write text end
            
        }

        private static void DoTheMainWork2(HttpResponseMessage response=null, bool iscompleted=false)
        {
            //Console.WriteLine("\tSuccesful REST call");
            //Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            Console.WriteLine("\nWriting data.json .....");

            // *****code to write text start****
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            //Sub string
            string sb = string.Empty;
            if (iscompleted)
                sb = "]}";
            else
                sb = ","+response.Content.ReadAsStringAsync().Result.ToString().Substring(response.Content.ReadAsStringAsync().Result.ToString().IndexOf('[')+1, response.Content.ReadAsStringAsync().Result.ToString().LastIndexOf(']') - response.Content.ReadAsStringAsync().Result.ToString().IndexOf('[')-1);
            try
            {
                ostrm = new FileStream("C:\\Users\\t.s.z4ni\\Desktop\\dataOct.json", FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            Console.WriteLine(sb);
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            
            // code to write text end
            
        }
    }
}
