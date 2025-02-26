import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.RelayProxyConfigurationsApi();
apiCaller.setApiKey(api.RelayProxyConfigurationsApiApiKeys.ApiKey, "YOUR_API_KEY");

const policy1 = new models.Statement();
policy1.effect = models.Statement.EffectEnum.Allow;
policy1.resources = [
  "proj/*:env/*",
];
policy1.actions = [
  "*",
];

const policy = [
  policy1,
];

const relayAutoConfigPost = new models.RelayAutoConfigPost();
relayAutoConfigPost.name = "Sample Relay Proxy config for all proj and env";
relayAutoConfigPost.policy = policy;

apiCaller.postRelayAutoConfig(
  relayAutoConfigPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling RelayProxyConfigurationsApi#postRelayAutoConfig:");
  console.log(error.body);
});
