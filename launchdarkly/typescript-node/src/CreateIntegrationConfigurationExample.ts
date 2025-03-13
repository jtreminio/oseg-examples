import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationsBetaApi();
apiCaller.setApiKey(api.IntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const capabilityConfigAuditLogEventsHookStatements1 = new models.StatementPost();
capabilityConfigAuditLogEventsHookStatements1.effect = models.StatementPost.EffectEnum.Allow;
capabilityConfigAuditLogEventsHookStatements1.resources = [
  "proj/*:env/*:flag/*;testing-tag",
];
capabilityConfigAuditLogEventsHookStatements1.notResources = [
];
capabilityConfigAuditLogEventsHookStatements1.actions = [
  "*",
];
capabilityConfigAuditLogEventsHookStatements1.notActions = [
];

const capabilityConfigAuditLogEventsHookStatements = [
  capabilityConfigAuditLogEventsHookStatements1,
];

const capabilityConfigApprovalsAdditionalFormVariables = [
];

const capabilityConfigApprovals = new models.ApprovalsCapabilityConfig();
capabilityConfigApprovals.additionalFormVariables = capabilityConfigApprovalsAdditionalFormVariables;

const capabilityConfigAuditLogEventsHook = new models.AuditLogEventsHookCapabilityConfigPost();
capabilityConfigAuditLogEventsHook.statements = capabilityConfigAuditLogEventsHookStatements;

const capabilityConfig = new models.CapabilityConfigPost();
capabilityConfig.approvals = capabilityConfigApprovals;
capabilityConfig.auditLogEventsHook = capabilityConfigAuditLogEventsHook;

const integrationConfigurationPost = new models.IntegrationConfigurationPost();
integrationConfigurationPost.name = "Example integration configuration";
integrationConfigurationPost.configValues = {
  "optional": "an optional property",
  "required": "the required property",
  "url": "https://example.com"
};
integrationConfigurationPost.enabled = true;
integrationConfigurationPost.tags = [
  "ops",
];
integrationConfigurationPost.capabilityConfig = capabilityConfig;

apiCaller.createIntegrationConfiguration(
  "integrationKey_string", // integrationKey
  integrationConfigurationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationsBetaApi#createIntegrationConfiguration:");
  console.log(error.body);
});
