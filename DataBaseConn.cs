using System;
using System.Text;
using System.Data.SqlClient;

namespace ManagedClientConsoleAppSample
{
    class DataBaseConn
    {
        public void getDBConn(Consolidated result)
        {
            try
            {
                
                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                //Local system db
                using (SqlConnection connection = new SqlConnection("Data Source = FP-TECHSRV8; Initial Catalog = ReleaseBIReports; integrated security = SSPI"))
                //using (SqlConnection connection = new SqlConnection("Data Source = FP-TECHSRV8; Initial Catalog = ReleaseBIReports; integrated security = SSPI"))
                {
                    connection.Open();
                    Console.WriteLine("Done.");


                    // INSERT demo
                    Console.Write("Inserting a new row into table...");
                    //Console.ReadKey(true);

                    foreach (var res in result.classRootObject.value)
                    {
                        //foreach (var env in res.environments)
                        //{

                            //if (env.status == "succeeded" || env.status == "inProgress" || env.status == "failed")
                            //{
                                StringBuilder sb = new StringBuilder();
                                sb.Clear();
                                //sb.Append("INSERT INTO [dbo].[ReleaseBIReportsData] ([value_id],[value_name],[value_status],[value_createdOn],[value_createdOn_Sprint],[value_modifiedOn],[value_modifiedBy_id],[value_modifiedBy_displayName],[value_modifiedBy_uniqueName],[value_createdBy_id],[value_createdBy_displayName],[value_createdBy_uniqueName],[value_environments_id],[value_environments_releaseId],[value_environments_name],[value_environments_name_LockOrLive],[value_environments_status],[value_environments_rank],[value_environments_definitionEnvironmentId],[value_environments_release_id],[value_environments_release_name],[value_environments_releaseDefinition_id],[value_environments_releaseDefinition_name],[value_environments_releaseDefinition_name_teamName],[value_environments_releaseDefinition_name_projectName],[value_environments_releaseDefinition_name_repoName],[value_environments_releaseCreatedBy_id],[value_environments_releaseCreatedBy_displayName],[value_environments_triggerReason],[value_releaseDefinition_id],[value_releaseDefinition_name],[value_releaseDefinition_url],[value_description],[value_reason],[value_releaseNameFormat],[value_keepForever],[value_definitionSnapshotRevision]) ");
                                //sb.Append("VALUES (@value_id,@value_name,@value_status,@value_createdOn,@value_createdOn_Sprint,@value_modifiedOn,@value_modifiedBy_id,@value_modifiedBy_displayName,@value_modifiedBy_uniqueName,@value_createdBy_id,@value_createdBy_displayName,@value_createdBy_uniqueName,@value_environments_id,@value_environments_releaseId,@value_environments_name,@value_environments_name_LockOrLive,@value_environments_status,@value_environments_rank,@value_environments_definitionEnvironmentId,@value_environments_release_id,@value_environments_release_name,@value_environments_releaseDefinition_id,@value_environments_releaseDefinition_name,@value_environments_releaseDefinition_name_teamName,@value_environments_releaseDefinition_name_projectName,@value_environments_releaseDefinition_name_repoName,@value_environments_releaseCreatedBy_id,@value_environments_releaseCreatedBy_displayName,@value_environments_triggerReason,@value_releaseDefinition_id,@value_releaseDefinition_name,@value_releaseDefinition_url,@value_description,@value_reason,@value_releaseNameFormat,@value_keepForever,@value_definitionSnapshotRevision);");
                                sb.Append("INSERT INTO [dbo].[ReleaseBIReportsData] ([value_id],[value_name],[value_status],[value_createdOn],[value_createdOn_Sprint],[value_modifiedOn],[value_modifiedBy_id],[value_modifiedBy_displayName],[value_modifiedBy_uniqueName],[value_createdBy_id],[value_createdBy_displayName],[value_createdBy_uniqueName],[value_releaseDefinition_id],[value_releaseDefinition_name],[value_releaseDefinition_url],[value_description],[value_reason],[value_releaseNameFormat],[value_keepForever],[value_definitionSnapshotRevision]) ");
                                sb.Append("VALUES (@value_id,@value_name,@value_status,@value_createdOn,@value_createdOn_Sprint,@value_modifiedOn,@value_modifiedBy_id,@value_modifiedBy_displayName,@value_modifiedBy_uniqueName,@value_createdBy_id,@value_createdBy_displayName,@value_createdBy_uniqueName,@value_releaseDefinition_id,@value_releaseDefinition_name,@value_releaseDefinition_url,@value_description,@value_reason,@value_releaseNameFormat,@value_keepForever,@value_definitionSnapshotRevision);");
                                string sql = sb.ToString();
                                using (SqlCommand command = new SqlCommand(sql, connection))
                                {
                                    command.Parameters.AddWithValue("@value_id", res.id);
                                    command.Parameters.AddWithValue("@value_name", res.name);
                                    command.Parameters.AddWithValue("@value_status", res.status);
                                    command.Parameters.AddWithValue("@value_createdOn", Convert.ToDateTime(res.createdOn).Date);

                                    //******SPRINT CODE START******
                                    if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("9-11-2017") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("9-24-2017"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-19");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("9-25-2017") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("10-8-2017"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-20");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("10-9-2017") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("10-22-2017"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-21");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("10-23-2017") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("11-5-2017"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-22");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("11-6-2017") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("11-19-2017"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-23");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("11-20-2017") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("12-3-2017"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-24");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("12-4-2017") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("12-17-2017"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-25");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("12-18-2017") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("12-31-2017"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-26");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("1-1-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("1-14-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-1 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("1-15-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("1-28-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-2 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("1-29-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("2-11-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-3 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("2-12-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("2-25-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-4 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("2-26-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("3-11-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-5 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("3-12-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("3-25-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-6 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("3-26-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("4-8-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-7 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("4-9-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("4-22-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-8 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("4-23-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("5-6-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-9 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("5-7-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("5-20-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-10 2018");
                                    }
                                    else if (Convert.ToDateTime(res.createdOn).Date >= Convert.ToDateTime("5-21-2018") && Convert.ToDateTime(res.createdOn).Date <= Convert.ToDateTime("6-3-2018"))
                                    {
                                        command.Parameters.AddWithValue("@value_createdOn_Sprint", "Sprint-11 2018");
                                    }

                                    //******SPRINT CODE START******

                                    command.Parameters.AddWithValue("@value_modifiedOn", res.modifiedOn);
                                    command.Parameters.AddWithValue("@value_modifiedBy_id", res.modifiedBy.id);
                                    command.Parameters.AddWithValue("@value_modifiedBy_displayName", res.modifiedBy.displayName);
                                    command.Parameters.AddWithValue("@value_modifiedBy_uniqueName", res.modifiedBy.uniqueName);
                                    command.Parameters.AddWithValue("@value_createdBy_id", res.createdBy.id);
                                    command.Parameters.AddWithValue("@value_createdBy_displayName", res.createdBy.displayName);
                                    command.Parameters.AddWithValue("@value_createdBy_uniqueName", res.createdBy.uniqueName);

                                    //*****Environment table entry start*****

                                    //StringBuilder sbEnv = new StringBuilder();
                                    //sbEnv.Clear();
                                    //sbEnv.Append("INSERT INTO [dbo].[ReleaseBIReportsDataEnv] ([value_environments_id],[value_environments_releaseId],[value_environments_name],[value_environments_name_LockOrLive],[value_environments_status],[value_environments_rank],[value_environments_definitionEnvironmentId],[value_environments_release_id],[value_environments_release_name],[value_environments_releaseDefinition_id],[value_environments_releaseDefinition_name],[value_environments_releaseDefinition_name_teamName],[value_environments_releaseDefinition_name_projectName],[value_environments_releaseDefinition_name_repoName],[value_environments_releaseCreatedBy_id],[value_environments_releaseCreatedBy_displayName],[value_environments_triggerReason]) ");
                                    //sbEnv.Append("VALUES (@value_environments_id,@value_environments_releaseId,@value_environments_name,@value_environments_name_LockOrLive,@value_environments_status,@value_environments_rank,@value_environments_definitionEnvironmentId,@value_environments_release_id,@value_environments_release_name,@value_environments_releaseDefinition_id,@value_environments_releaseDefinition_name,@value_environments_releaseDefinition_name_teamName,@value_environments_releaseDefinition_name_projectName,@value_environments_releaseDefinition_name_repoName,@value_environments_releaseCreatedBy_id,@value_environments_releaseCreatedBy_displayName,@value_environments_triggerReason);");
                                    //string sqlEnv = sbEnv.ToString();
                                    //using (SqlCommand commandEnv = new SqlCommand(sqlEnv, connection))
                                    //{

                                    //    commandEnv.Parameters.AddWithValue("@value_environments_id", env.id);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_releaseId", env.releaseId);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_name", env.name);

                                    //    if (env.name.ToLower().Contains("lock") || env.name.ToLower().Contains("fpnext") || env.name.ToLower().Contains("prelive") || env.name.ToLower().Contains("prod") || env.name.ToLower().Contains("stag") || env.name.ToLower().Contains("ptr") || env.name.ToLower().Contains("automationresourcemanager") || env.name.ToLower().Contains("coa-ss") || env.name.ToLower().Contains("environment 1") || env.name.ToLower().Contains("fdatool") || env.name.ToLower().Contains("fpautomationresourcesservice") || env.name.ToLower().Contains("hotfix") || env.name.ToLower().Contains("ot-ss") || env.name.ToLower().Contains("testmode") || env.name.ToLower().Contains("copy"))
                                    //    {
                                    //        commandEnv.Parameters.AddWithValue("@value_environments_name_LockOrLive", "Lock");
                                    //    }
                                    //    else
                                    //    {
                                    //        commandEnv.Parameters.AddWithValue("@value_environments_name_LockOrLive", "Live");
                                    //    }

                                    //    commandEnv.Parameters.AddWithValue("@value_environments_status", env.status);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_rank", env.rank);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_definitionEnvironmentId", env.definitionEnvironmentId);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_release_id", env.release.id);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_release_name", env.release.name);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_id", env.releaseDefinition.id);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_name", env.releaseDefinition.name);
                                    //    // code to fetch the team name start
                                    //    string[] teamName = env.releaseDefinition.name.Split('.');
                                    //    {
                                    //        commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_name_teamName", ((teamName.Length > 0 && !string.IsNullOrEmpty(teamName[0])) ? teamName[0] : ""));
                                    //        commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_name_projectName", ((teamName.Length > 1 && !string.IsNullOrEmpty(teamName[1])) ? teamName[1] : ""));
                                    //        commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_name_repoName", ((teamName.Length > 2 && !string.IsNullOrEmpty(teamName[2])) ? teamName[2] : ""));
                                    //    }
                                    //    // code to fetch the team name end
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_releaseCreatedBy_id", env.releaseCreatedBy.id);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_releaseCreatedBy_displayName", env.releaseCreatedBy.displayName);
                                    //    commandEnv.Parameters.AddWithValue("@value_environments_triggerReason", env.triggerReason);
                                    //    int rowsAffectedEnv = commandEnv.ExecuteNonQuery();
                                    //    Console.WriteLine(rowsAffectedEnv + " row(s) inserted for environments");

                                        //*****Environment table entry end*****
                                    //}
                                    command.Parameters.AddWithValue("@value_releaseDefinition_id", res.releaseDefinition.id);
                                    command.Parameters.AddWithValue("@value_releaseDefinition_name", res.releaseDefinition.name);
                                    command.Parameters.AddWithValue("@value_releaseDefinition_url", res.releaseDefinition.url);
                                    command.Parameters.AddWithValue("@value_description", res.description);
                                    command.Parameters.AddWithValue("@value_reason", res.reason);
                                    command.Parameters.AddWithValue("@value_releaseNameFormat", res.releaseNameFormat);
                                    command.Parameters.AddWithValue("@value_keepForever", res.keepForever);
                                    command.Parameters.AddWithValue("@value_definitionSnapshotRevision", res.definitionSnapshotRevision);
                                    int rowsAffected = command.ExecuteNonQuery();
                                    Console.WriteLine(rowsAffected + " row(s) inserted for main table");
                                }


                            //}

                        //}


                        foreach (var env in res.environments)
                        {

                            if (env.status == "succeeded" || env.status == "inProgress" || env.status == "failed")
                            {
                                StringBuilder sbEnv = new StringBuilder();
                                sbEnv.Clear();
                                sbEnv.Append("INSERT INTO [dbo].[ReleaseBIReportsDataEnv] ([value_environments_id],[value_environments_releaseId],[value_environments_name],[value_environments_name_LockOrLive],[value_environments_status],[value_environments_rank],[value_environments_definitionEnvironmentId],[value_environments_release_id],[value_environments_release_name],[value_environments_releaseDefinition_id],[value_environments_releaseDefinition_name],[value_environments_releaseDefinition_name_teamName],[value_environments_releaseDefinition_name_projectName],[value_environments_releaseDefinition_name_repoName],[value_environments_releaseCreatedBy_id],[value_environments_releaseCreatedBy_displayName],[value_environments_triggerReason]) ");
                                sbEnv.Append("VALUES (@value_environments_id,@value_environments_releaseId,@value_environments_name,@value_environments_name_LockOrLive,@value_environments_status,@value_environments_rank,@value_environments_definitionEnvironmentId,@value_environments_release_id,@value_environments_release_name,@value_environments_releaseDefinition_id,@value_environments_releaseDefinition_name,@value_environments_releaseDefinition_name_teamName,@value_environments_releaseDefinition_name_projectName,@value_environments_releaseDefinition_name_repoName,@value_environments_releaseCreatedBy_id,@value_environments_releaseCreatedBy_displayName,@value_environments_triggerReason);");
                                string sqlEnv = sbEnv.ToString();
                                using (SqlCommand commandEnv = new SqlCommand(sqlEnv, connection))
                                {

                                    commandEnv.Parameters.AddWithValue("@value_environments_id", env.id);
                                    commandEnv.Parameters.AddWithValue("@value_environments_releaseId", env.releaseId);
                                    commandEnv.Parameters.AddWithValue("@value_environments_name", env.name);

                                    if (env.name.ToLower().Contains("lock") || env.name.ToLower().Contains("fpnext") || env.name.ToLower().Contains("prelive") || env.name.ToLower().Contains("prod") || env.name.ToLower().Contains("stag") || env.name.ToLower().Contains("ptr") || env.name.ToLower().Contains("automationresourcemanager") || env.name.ToLower().Contains("coa-ss") || env.name.ToLower().Contains("environment 1") || env.name.ToLower().Contains("fdatool") || env.name.ToLower().Contains("fpautomationresourcesservice") || env.name.ToLower().Contains("hotfix") || env.name.ToLower().Contains("ot-ss") || env.name.ToLower().Contains("testmode") || env.name.ToLower().Contains("copy"))
                                    {
                                        commandEnv.Parameters.AddWithValue("@value_environments_name_LockOrLive", "Lock");
                                    }
                                    else
                                    {
                                        commandEnv.Parameters.AddWithValue("@value_environments_name_LockOrLive", "Live");
                                    }

                                    commandEnv.Parameters.AddWithValue("@value_environments_status", env.status);
                                    commandEnv.Parameters.AddWithValue("@value_environments_rank", env.rank);
                                    commandEnv.Parameters.AddWithValue("@value_environments_definitionEnvironmentId", env.definitionEnvironmentId);
                                    commandEnv.Parameters.AddWithValue("@value_environments_release_id", env.release.id);
                                    commandEnv.Parameters.AddWithValue("@value_environments_release_name", env.release.name);
                                    commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_id", env.releaseDefinition.id);
                                    commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_name", env.releaseDefinition.name);
                                    // code to fetch the team name start
                                    string[] teamName = env.releaseDefinition.name.Split('.');
                                    {
                                        commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_name_teamName", ((teamName.Length > 0 && !string.IsNullOrEmpty(teamName[0])) ? teamName[0] : ""));
                                        commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_name_projectName", ((teamName.Length > 1 && !string.IsNullOrEmpty(teamName[1])) ? teamName[1] : ""));
                                        commandEnv.Parameters.AddWithValue("@value_environments_releaseDefinition_name_repoName", ((teamName.Length > 2 && !string.IsNullOrEmpty(teamName[2])) ? teamName[2] : ""));
                                    }
                                    // code to fetch the team name end
                                    commandEnv.Parameters.AddWithValue("@value_environments_releaseCreatedBy_id", env.releaseCreatedBy.id);
                                    commandEnv.Parameters.AddWithValue("@value_environments_releaseCreatedBy_displayName", env.releaseCreatedBy.displayName);
                                    commandEnv.Parameters.AddWithValue("@value_environments_triggerReason", env.triggerReason);
                                    int rowsAffectedEnv = commandEnv.ExecuteNonQuery();
                                    Console.WriteLine(rowsAffectedEnv + " row(s) inserted for environments");
                                }
                            }
                        }

                        
                    }


                    //enable work item table insertion start

                    Console.Write("Insertion into table ReleaseBIReportsWorkItemData.....");

                    foreach (var wk in result.classWorkItemClass)
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Clear();
                            sb.Append("INSERT INTO [dbo].[ReleaseBIReportsWorkItemData] ([workitem_id],[workitem_releaseId],[workitem_rev],[workitem_fields_System_AreaPath],[workitem_fields_System_TeamProject],[workitem_fields_System_IterationPath],[workitem_fields_System_WorkItemType],[workitem_fields_System_State],[workitem_fields_System_Reason],[workitem_fields_System_AssignedTo],[workitem_fields_System_CreatedDate],[workitem_fields_System_CreatedBy],[workitem_fields_System_ChangedDate],[workitem_fields_System_ChangedBy],[workitem_fields_System_Title],[workitem_fields_Microsoft_VSTS_Common_Activity],[workitem_fields_Microsoft_VSTS_Common_StateChangeDate],[workitem_fields_Microsoft_VSTS_Common_ActivatedDate],[workitem_fields_Microsoft_VSTS_Common_ActivatedBy],[workitem_fields_Microsoft_VSTS_Common_ResolvedDate],[workitem_fields_Microsoft_VSTS_Common_ResolvedBy],[workitem_fields_Microsoft_VSTS_Common_ResolvedReason],[workitem_fields_Microsoft_VSTS_Common_Priority],[workitem_fields_Microsoft_VSTS_Common_Severity],[workitem_fields_Microsoft_VSTS_Common_StackRank],[workitem_fields_Microsoft_VSTS_Common_ValueArea],[workitem_fields_Microsoft_VSTS_Scheduling_StoryPoints]) ");
                            sb.Append("VALUES (@workitem_id,@workitem_releaseId,@workitem_rev,@workitem_fields_System_AreaPath,@workitem_fields_System_TeamProject,@workitem_fields_System_IterationPath,@workitem_fields_System_WorkItemType,@workitem_fields_System_State,@workitem_fields_System_Reason,@workitem_fields_System_AssignedTo,@workitem_fields_System_CreatedDate,@workitem_fields_System_CreatedBy,@workitem_fields_System_ChangedDate,@workitem_fields_System_ChangedBy,@workitem_fields_System_Title,@workitem_fields_Microsoft_VSTS_Common_Activity,@workitem_fields_Microsoft_VSTS_Common_StateChangeDate,@workitem_fields_Microsoft_VSTS_Common_ActivatedDate,@workitem_fields_Microsoft_VSTS_Common_ActivatedBy,@workitem_fields_Microsoft_VSTS_Common_ResolvedDate,@workitem_fields_Microsoft_VSTS_Common_ResolvedBy,@workitem_fields_Microsoft_VSTS_Common_ResolvedReason,@workitem_fields_Microsoft_VSTS_Common_Priority,@workitem_fields_Microsoft_VSTS_Common_Severity,@workitem_fields_Microsoft_VSTS_Common_StackRank,@workitem_fields_Microsoft_VSTS_Common_ValueArea,@workitem_fields_Microsoft_VSTS_Scheduling_StoryPoints);");
                            string sql = sb.ToString();
                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                command.Parameters.AddWithValue("@workitem_id", wk.id);
                                command.Parameters.AddWithValue("@workitem_releaseId", wk.releaseId);
                                command.Parameters.AddWithValue("@workitem_rev", wk.rev ?? 0);
                                command.Parameters.AddWithValue("@workitem_fields_System_AreaPath",  String.IsNullOrEmpty(wk.fields.SystemAreaPath) ? "" : wk.fields.SystemAreaPath);
                                command.Parameters.AddWithValue("@workitem_fields_System_TeamProject", String.IsNullOrEmpty(wk.fields.SystemTeamProject) ? "" : wk.fields.SystemTeamProject);
                                command.Parameters.AddWithValue("@workitem_fields_System_IterationPath", String.IsNullOrEmpty(wk.fields.SystemIterationPath) ? "" : wk.fields.SystemIterationPath);
                                command.Parameters.AddWithValue("@workitem_fields_System_WorkItemType", String.IsNullOrEmpty(wk.fields.SystemWorkItemType) ? "" : wk.fields.SystemWorkItemType);
                                command.Parameters.AddWithValue("@workitem_fields_System_State", String.IsNullOrEmpty(wk.fields.SystemState) ? "" : wk.fields.SystemState);
                                command.Parameters.AddWithValue("@workitem_fields_System_Reason", String.IsNullOrEmpty(wk.fields.SystemReason) ? "" : wk.fields.SystemReason);
                                command.Parameters.AddWithValue("@workitem_fields_System_AssignedTo", String.IsNullOrEmpty(wk.fields.SystemAssignedTo) ? "" : wk.fields.SystemAssignedTo);
                                command.Parameters.AddWithValue("@workitem_fields_System_CreatedDate", ((wk.fields.SystemCreatedDate == DateTime.MinValue) ? Convert.ToDateTime("1/1/1800").Date : (Convert.ToDateTime(wk.fields.SystemCreatedDate).Date)));
                                command.Parameters.AddWithValue("@workitem_fields_System_CreatedBy", String.IsNullOrEmpty(wk.fields.SystemCreatedBy) ? "" : wk.fields.SystemCreatedBy);
                                command.Parameters.AddWithValue("@workitem_fields_System_ChangedDate", ((wk.fields.SystemChangedDate == DateTime.MinValue) ? Convert.ToDateTime("1/1/1800").Date : (Convert.ToDateTime(wk.fields.SystemChangedDate).Date)));
                                command.Parameters.AddWithValue("@workitem_fields_System_ChangedBy", String.IsNullOrEmpty(wk.fields.SystemChangedBy) ? "" : wk.fields.SystemChangedBy);
                                command.Parameters.AddWithValue("@workitem_fields_System_Title", String.IsNullOrEmpty(wk.fields.SystemTitle) ? "" : wk.id + " - " + wk.fields.SystemTitle);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_Activity", String.IsNullOrEmpty(wk.fields.MicrosoftVSTSCommonActivity) ? "" : wk.fields.MicrosoftVSTSCommonActivity);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_StateChangeDate", ((wk.fields.MicrosoftVSTSCommonStateChangeDate == DateTime.MinValue) ? Convert.ToDateTime("1/1/1800").Date : (Convert.ToDateTime(wk.fields.MicrosoftVSTSCommonStateChangeDate).Date)));
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_ActivatedDate", ((wk.fields.MicrosoftVSTSCommonActivatedDate == DateTime.MinValue) ? Convert.ToDateTime("1/1/1800").Date : (Convert.ToDateTime(wk.fields.MicrosoftVSTSCommonActivatedDate).Date)));
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_ActivatedBy", String.IsNullOrEmpty(wk.fields.MicrosoftVSTSCommonActivatedBy) ? "" : wk.fields.MicrosoftVSTSCommonActivatedBy);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_ResolvedDate", ((wk.fields.MicrosoftVSTSCommonResolvedDate == DateTime.MinValue) ? Convert.ToDateTime("1/1/1800").Date : (Convert.ToDateTime(wk.fields.MicrosoftVSTSCommonResolvedDate).Date)));
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_ResolvedBy", String.IsNullOrEmpty(wk.fields.MicrosoftVSTSCommonResolvedBy) ? "" : wk.fields.MicrosoftVSTSCommonResolvedBy);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_ResolvedReason", String.IsNullOrEmpty(wk.fields.MicrosoftVSTSCommonResolvedReason) ? "" : wk.fields.MicrosoftVSTSCommonResolvedReason);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_Priority", wk.fields.MicrosoftVSTSCommonPriority ?? 0);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_Severity", String.IsNullOrEmpty(wk.fields.MicrosoftVSTSCommonSeverity) ? "" : wk.fields.MicrosoftVSTSCommonSeverity);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_StackRank", wk.fields.MicrosoftVSTSCommonStackRank ?? 0);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Common_ValueArea", String.IsNullOrEmpty(wk.fields.MicrosoftVSTSCommonValueArea) ? "" : wk.fields.MicrosoftVSTSCommonValueArea);
                                command.Parameters.AddWithValue("@workitem_fields_Microsoft_VSTS_Scheduling_StoryPoints", wk.fields.MicrosoftVSTSSchedulingStoryPoints ?? 0);
                                int rowsAffected = command.ExecuteNonQuery();
                                Console.WriteLine(rowsAffected + " row(s) inserted in table ReleaseBIReportsWorkItemData");
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error in workItem data write : " + ex.Message + " and occured at : " + wk.fields);
                        }
                    }

                    //enable work item table insertion end

                    connection.Close();
                }

                }
            
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            //Console.WriteLine("All done. Press any key to finish...");
            //Console.ReadKey(true);
        }


        public int getDBTopId()
        {
            try
            {
                // Connect to SQL
                
                using (SqlConnection connection = new SqlConnection("Data Source = FP-TECHSRV8; Initial Catalog = ReleaseBIReports; integrated security = SSPI"))
                {
                    connection.Open(); 
                    String sql = "Select top 1 value_id from [ReleaseBIReports].[dbo].[ReleaseBIReportsData] order by value_id desc;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Console.WriteLine("{0}", reader.GetInt32(0));
                                return (reader.GetInt32(0));
                            }
                        }
                    }
                    connection.Close();
                }

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return (0);

            //Console.WriteLine("All done. Press any key to finish...");
            //Console.ReadKey(true);
        }
    }
}