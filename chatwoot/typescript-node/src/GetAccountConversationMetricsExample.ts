import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ReportsApi();
apiCaller.setApiKey(api.ReportsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ReportsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ReportsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.getAccountConversationMetrics(
  0, // accountId
  "account", // type
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReportsApi#getAccountConversationMetrics:");
  console.log(error.body);
});
