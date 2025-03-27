import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.AutomationRuleApi();
apiCaller.setApiKey(api.AutomationRuleApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.AutomationRuleApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.AutomationRuleApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.getDetailsOfASingleAutomationRule(
  0, // accountId
  0, // id
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling AutomationRuleApi#getDetailsOfASingleAutomationRule:");
  console.log(error.body);
});
