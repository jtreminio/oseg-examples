using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class DeleteWorkflowExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        try
        {
            new WorkflowsApi(config).DeleteWorkflow(
                projectKey: null,
                featureFlagKey: null,
                environmentKey: null,
                workflowId: null
            );
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling Workflows#DeleteWorkflow: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
