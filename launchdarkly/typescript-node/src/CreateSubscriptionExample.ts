import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.IntegrationAuditLogSubscriptionsApi();
apiCaller.setApiKey(api.IntegrationAuditLogSubscriptionsApiApiKeys.ApiKey, "YOUR_API_KEY");

const statements1 = new models.StatementPost();
statements1.effect = models.StatementPost.EffectEnum.Allow;
statements1.resources = [
  "proj/*:env/*:flag/*;testing-tag",
];
statements1.actions = [
  "*",
];

const statements = [
  statements1,
];

const subscriptionPost = new models.SubscriptionPost();
subscriptionPost.name = "Example audit log subscription.";
subscriptionPost.config =   {
  "optional": "an optional property",
  "required": "the required property",
  "url": "https://example.com"
};
subscriptionPost.on = false;
subscriptionPost.tags = [
  "testing-tag",
];
subscriptionPost.statements = statements;

apiCaller.createSubscription(
  undefined, // integrationKey
  subscriptionPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationAuditLogSubscriptions#createSubscription:");
  console.log(error.body);
});
