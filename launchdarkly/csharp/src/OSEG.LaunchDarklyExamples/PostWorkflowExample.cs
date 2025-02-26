using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class PostWorkflowExample
{
    public static void Run()
    {
        var config = new Configuration();
        config.ApiKey = new Dictionary<string, string> {["ApiKey"] = "YOUR_API_KEY"};

        var stages1Action = new ActionInput(
        );

        var stages1Conditions1 = new ConditionInput(
            scheduleKind: "relative",
            waitDuration: 2,
            waitDurationUnit: "calendarDay",
            kind: "schedule"
        );

        var stages1Conditions = new List<ConditionInput>
        {
            stages1Conditions1,
        };

        var stages1 = new StageInput(
            name: "10% rollout on day 1",
            action: stages1Action,
            conditions: stages1Conditions
        );

        var stages = new List<StageInput>
        {
            stages1,
        };

        var customWorkflowInput = new CustomWorkflowInput(
            name: "Progressive rollout starting in two days",
            description: "Turn flag on for 10% of customers each day",
            stages: stages
        );

        try
        {
            var response = new WorkflowsApi(config).PostWorkflow(
                projectKey: null,
                featureFlagKey: null,
                environmentKey: null,
                customWorkflowInput: customWorkflowInput,
                templateKey: null,
                dryRun: null
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling WorkflowsApi#PostWorkflow: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
