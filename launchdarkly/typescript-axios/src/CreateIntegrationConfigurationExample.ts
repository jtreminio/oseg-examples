import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const capabilityConfigAuditLogEventsHookStatements1: api.StatementPost = {
  effect: api.StatementPostEffectEnum.Allow,
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

const capabilityConfigApprovals: api.ApprovalsCapabilityConfig = {
  additionalFormVariables: capabilityConfigApprovalsAdditionalFormVariables,
};

const capabilityConfigAuditLogEventsHook: api.AuditLogEventsHookCapabilityConfigPost = {
  statements: capabilityConfigAuditLogEventsHookStatements,
};

const capabilityConfig: api.CapabilityConfigPost = {
  approvals: capabilityConfigApprovals,
  auditLogEventsHook: capabilityConfigAuditLogEventsHook,
};

const integrationConfigurationPost: api.IntegrationConfigurationPost = {
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

new api.IntegrationsBetaApi(configuration).createIntegrationConfiguration(
  "integrationKey_string", // integrationKey
  integrationConfigurationPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IntegrationsBetaApi#createIntegrationConfiguration:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
