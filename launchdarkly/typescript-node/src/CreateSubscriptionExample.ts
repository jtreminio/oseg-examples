import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationAuditLogSubscriptionsApi();
apiCaller.setApiKey(api.IntegrationAuditLogSubscriptionsApiApiKeys.ApiKey, "YOUR_API_KEY");

const statements1: models.StatementPost = {
  effect: models.StatementPost.EffectEnum.Allow,
  resources: [
    "proj/*:env/*:flag/*;testing-tag",
  ],
  actions: [
    "*",
  ],
};

const statements = [
  statements1,
];

const subscriptionPost: models.SubscriptionPost = {
  name: "Example audit log subscription.",
  config: {
    "optional": "an optional property",
    "required": "the required property",
    "url": "https://example.com"
  },
  on: false,
  tags: [
    "testing-tag",
  ],
  statements: statements,
};

apiCaller.createSubscription(
  "integrationKey_string", // integrationKey
  subscriptionPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationAuditLogSubscriptionsApi#createSubscription:");
  console.log(error.body);
});
