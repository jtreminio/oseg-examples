import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.IntegrationsApi();
apiCaller.setApiKey(api.IntegrationsApiApiKeys.userApiKey, "USER_API_KEY");
// apiCaller.setApiKey(api.IntegrationsApiApiKeys.agentBotApiKey, "AGENT_BOT_API_KEY");
// apiCaller.setApiKey(api.IntegrationsApiApiKeys.platformAppApiKey, "PLATFORM_APP_API_KEY");

const integrationsHookUpdatePayload: models.IntegrationsHookUpdatePayload = {
};

apiCaller.updateAnIntegrationsHook(
  0, // accountId
  0, // hookId
  integrationsHookUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IntegrationsApi#updateAnIntegrationsHook:");
  console.log(error.body);
});
