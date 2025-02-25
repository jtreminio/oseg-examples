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

public class CreateIntegrationConfigurationExample
{
    public static void main(String[] args)
    {
        var config = Configuration.getDefaultApiClient();
        config.setApiKey("YOUR_API_KEY");

        var capabilityConfigAuditLogEventsHookStatements1 = new StatementPost();
        capabilityConfigAuditLogEventsHookStatements1.effect(StatementPost.EffectEnum.ALLOW);
        capabilityConfigAuditLogEventsHookStatements1.resources(List.of (
            "proj/*:env/*:flag/*;testing-tag"
        ));
        capabilityConfigAuditLogEventsHookStatements1.notResources(List.of ());
        capabilityConfigAuditLogEventsHookStatements1.actions(List.of (
            "*"
        ));
        capabilityConfigAuditLogEventsHookStatements1.notActions(List.of ());

        var capabilityConfigAuditLogEventsHookStatements = new ArrayList<StatementPost>(List.of (
            capabilityConfigAuditLogEventsHookStatements1
        ));

        var capabilityConfigApprovalsAdditionalFormVariables = new ArrayList<FormVariable>(List.of ());

        var capabilityConfigApprovals = new ApprovalsCapabilityConfig();
        capabilityConfigApprovals.additionalFormVariables(capabilityConfigApprovalsAdditionalFormVariables);

        var capabilityConfigAuditLogEventsHook = new AuditLogEventsHookCapabilityConfigPost();
        capabilityConfigAuditLogEventsHook.statements(capabilityConfigAuditLogEventsHookStatements);

        var capabilityConfig = new CapabilityConfigPost();
        capabilityConfig.approvals(capabilityConfigApprovals);
        capabilityConfig.auditLogEventsHook(capabilityConfigAuditLogEventsHook);

        var integrationConfigurationPost = new IntegrationConfigurationPost();
        integrationConfigurationPost.name("Example integration configuration");
        integrationConfigurationPost.configValues(JSON.deserialize("""
            {
                "optional": "an optional property",
                "required": "the required property",
                "url": "https://example.com"
            }
        """, Map.class));
        integrationConfigurationPost.enabled(true);
        integrationConfigurationPost.tags(List.of (
            "ops"
        ));
        integrationConfigurationPost.capabilityConfig(capabilityConfig);

        try
        {
            var response = new IntegrationsBetaApi(config).createIntegrationConfiguration(
                null, // integrationKey
                integrationConfigurationPost
            );

            System.out.println(response);
        } catch (ApiException e) {
            System.err.println("Exception when calling IntegrationsBeta#createIntegrationConfiguration");
            System.err.println("Status code: " + e.getCode());
            System.err.println("Reason: " + e.getResponseBody());
            System.err.println("Response headers: " + e.getResponseHeaders());
            e.printStackTrace();
        }
    }
}
