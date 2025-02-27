package oseg.launchdarkly_examples;

import com.launchdarkly.client.ApiException;
import com.launchdarkly.client.Configuration;
import com.launchdarkly.client.api.*;
import com.launchdarkly.client.auth.*;
import com.launchdarkly.client.JSON;
import com.launchdarkly.client.model.*;

import java.io.File;
import java.time.LocalDate;
import java.time.OffsetDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class PostWorkflowExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var stages1Action = new ActionInput();

        var stages1Conditions1 = new ConditionInput();
        stages1Conditions1.scheduleKind("relative");
        stages1Conditions1.waitDuration(2);
        stages1Conditions1.waitDurationUnit("calendarDay");
        stages1Conditions1.kind("schedule");

        var stages1Conditions = new ArrayList<ConditionInput>(List.of (
            stages1Conditions1
        ));

        var stages1 = new StageInput();
        stages1.name("10% rollout on day 1");
        stages1.action(stages1Action);
        stages1.conditions(stages1Conditions);

        var stages = new ArrayList<StageInput>(List.of (
            stages1
        ));

        var customWorkflowInput = new CustomWorkflowInput();
        customWorkflowInput.name("Progressive rollout starting in two days");
        customWorkflowInput.description("Turn flag on for 10% of customers each day");
        customWorkflowInput.stages(stages);

        try
        {
            var response = new WorkflowsApi(config).postWorkflow(
                null, // projectKey
                null, // featureFlagKey
                null, // environmentKey
                customWorkflowInput,
                null, // templateKey
                null // dryRun
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling WorkflowsApi#postWorkflow");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
