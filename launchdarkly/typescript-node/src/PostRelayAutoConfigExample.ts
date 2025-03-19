import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.RelayProxyConfigurationsApi();
apiCaller.setApiKey(api.RelayProxyConfigurationsApiApiKeys.ApiKey, "YOUR_API_KEY");

const policy1: models.Statement = {
  effect: models.Statement.EffectEnum.Allow,
  resources: [
    "proj/*:env/*",
  ],
  actions: [
    "*",
  ],
};

const policy = [
  policy1,
];

const relayAutoConfigPost: models.RelayAutoConfigPost = {
  name: "Sample Relay Proxy config for all proj and env",
  policy: policy,
};

apiCaller.postRelayAutoConfig(
  relayAutoConfigPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling RelayProxyConfigurationsApi#postRelayAutoConfig:");
  console.log(error.body);
});
