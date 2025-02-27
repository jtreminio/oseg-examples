import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.AuditLogApi();
apiCaller.setApiKey(api.AuditLogApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getAuditLogEntry(
  undefined, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AuditLogApi#getAuditLogEntry:");
  console.log(error.body);
});
