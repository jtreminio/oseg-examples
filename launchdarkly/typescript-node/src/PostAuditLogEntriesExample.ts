import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AuditLogApi();
apiCaller.setApiKey(api.AuditLogApiApiKeys.ApiKey, "YOUR_API_KEY");

const statementPost1: models.StatementPost = {
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

const statementPost = [
  statementPost1,
];

apiCaller.postAuditLogEntries(
  undefined, // before
  undefined, // after
  undefined, // q
  undefined, // limit
  statementPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AuditLogApi#postAuditLogEntries:");
  console.log(error.body);
});
