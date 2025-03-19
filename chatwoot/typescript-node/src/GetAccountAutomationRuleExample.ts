import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AutomationRuleApi();
apiCaller.setApiKey(api.AutomationRuleApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.getAccountAutomationRule(
  0, // accountId
  1, // page
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AutomationRuleApi#getAccountAutomationRule:");
  console.log(error.body);
});
