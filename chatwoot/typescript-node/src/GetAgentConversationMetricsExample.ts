import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.ReportsApi();
apiCaller.setApiKey(api.ReportsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.ReportsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.ReportsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.getAgentConversationMetrics(
  0, // accountId
  "agent", // type
  undefined, // userId
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ReportsApi#getAgentConversationMetrics:");
  console.log(error.body);
});
