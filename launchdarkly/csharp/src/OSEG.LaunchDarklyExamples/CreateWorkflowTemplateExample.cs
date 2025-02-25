using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using Org.LaunchDarklyTools.Api;
using Org.LaunchDarklyTools.Client;
using Org.LaunchDarklyTools.Model;

namespace OSEG.LaunchDarklyExamples;

public class CreateWorkflowTemplateExample
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
            executeConditionsInSequence: true,
            action: stages1Action,
            conditions: stages1Conditions
        );

        var stages = new List<StageInput>
        {
            stages1,
        };

        var createWorkflowTemplateInput = new CreateWorkflowTemplateInput(
            key: null,
            name: null,
            description: null,
            workflowId: null,
            projectKey: null,
            environmentKey: null,
            flagKey: null,
            stages: stages
        );

        try
        {
            var response = new WorkflowTemplatesApi(config).CreateWorkflowTemplate(
                createWorkflowTemplateInput: createWorkflowTemplateInput
            );

            Console.WriteLine(response);
        }
        catch (ApiException e)
        {
            Console.WriteLine("Exception when calling WorkflowTemplates#CreateWorkflowTemplate: " + e.Message);
            Console.WriteLine("Status Code: " + e.ErrorCode);
            Console.WriteLine(e.StackTrace);
        }
    }
}
