import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AutomationRuleApi();
apiCaller.setApiKey(api.AutomationRuleApiApiKeys.userApiKey, "USER_API_KEY");

apiCaller.deleteAutomationRuleFromAccount(
  0, // accountId
  0, // id
).catch(error => {
  console.log("Exception when calling AutomationRuleApi#deleteAutomationRuleFromAccount:");
  console.log(error.body);
});
