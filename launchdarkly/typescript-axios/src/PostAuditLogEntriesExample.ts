import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const statementPost1: api.StatementPost = {
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

const statementPost = [
  statementPost1,
];

new api.AuditLogApi(configuration).postAuditLogEntries(
  undefined, // before
  undefined, // after
  undefined, // q
  undefined, // limit
  statementPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling AuditLogApi#postAuditLogEntries:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
