import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationsBetaApi();
apiCaller.setApiKey(api.IntegrationsBetaApiApiKeys.ApiKey, "YOUR_API_KEY");

const capabilityConfigAuditLogEventsHookStatements1: models.StatementPost = {
  effect: models.StatementPost.EffectEnum.Allow,
  resources: [
    "proj/*:env/*:flag/*;testing-tag",
  ],
  notResources: [
  ],
  actions: [
    "*",
  ],
  notActions: [
  ],
};

const capabilityConfigAuditLogEventsHookStatements = [
  capabilityConfigAuditLogEventsHookStatements1,
];

const capabilityConfigApprovalsAdditionalFormVariables = [
];

const capabilityConfigApprovals: models.ApprovalsCapabilityConfig = {
  additionalFormVariables: capabilityConfigApprovalsAdditionalFormVariables,
};

const capabilityConfigAuditLogEventsHook: models.AuditLogEventsHookCapabilityConfigPost = {
  statements: capabilityConfigAuditLogEventsHookStatements,
};

const capabilityConfig: models.CapabilityConfigPost = {
  approvals: capabilityConfigApprovals,
  auditLogEventsHook: capabilityConfigAuditLogEventsHook,
};

const integrationConfigurationPost: models.IntegrationConfigurationPost = {
  name: "Example integration configuration",
  configValues: {
    "optional": "an optional property",
    "required": "the required property",
    "url": "https://example.com"
  },
  enabled: true,
  tags: [
    "ops",
  ],
  capabilityConfig: capabilityConfig,
};

apiCaller.createIntegrationConfiguration(
  "integrationKey_string", // integrationKey
  integrationConfigurationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationsBetaApi#createIntegrationConfiguration:");
  console.log(error.body);
});
