import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const policy1: api.Statement = {
  effect: api.StatementEffectEnum.Allow,
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

const relayAutoConfigPost: api.RelayAutoConfigPost = {
  name: "Sample Relay Proxy config for all proj and env",
  policy: policy,
};

new api.RelayProxyConfigurationsApi(configuration).postRelayAutoConfig(
  relayAutoConfigPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling RelayProxyConfigurationsApi#postRelayAutoConfig:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
