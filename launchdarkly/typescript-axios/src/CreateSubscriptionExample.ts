import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const statements1: api.StatementPost = {
  effect: api.StatementPostEffectEnum.Allow,
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

const subscriptionPost: api.SubscriptionPost = {
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

new api.IntegrationAuditLogSubscriptionsApi(configuration).createSubscription(
  "integrationKey_string", // integrationKey
  subscriptionPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling IntegrationAuditLogSubscriptionsApi#createSubscription:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
