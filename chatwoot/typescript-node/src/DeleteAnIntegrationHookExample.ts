import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.IntegrationsApi();
apiCaller.setApiKey(api.IntegrationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.IntegrationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.IntegrationsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

apiCaller.deleteAnIntegrationHook(
  undefined, // accountId
  undefined, // hookId
).catch(error => {
  console.log("Exception when calling IntegrationsApi#deleteAnIntegrationHook:");
  console.log(error.body);
});
