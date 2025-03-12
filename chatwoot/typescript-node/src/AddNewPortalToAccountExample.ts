import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.HelpCenterApi();
apiCaller.setApiKey(api.HelpCenterApiApiKeys.userApiKey, "USER_API_KEY");

const portalCreateUpdatePayload = new models.PortalCreateUpdatePayload();
portalCreateUpdatePayload.archived = undefined;
portalCreateUpdatePayload.color = "add color HEX string, \"#fffff\"";
portalCreateUpdatePayload.customDomain = "https://chatwoot.help/.";
portalCreateUpdatePayload.headerText = "Handbook";
portalCreateUpdatePayload.homepageLink = "https://www.chatwoot.com/";
portalCreateUpdatePayload.name = undefined;
portalCreateUpdatePayload.slug = undefined;
portalCreateUpdatePayload.pageTitle = undefined;
portalCreateUpdatePayload.accountId = undefined;

apiCaller.addNewPortalToAccount(
  undefined, // accountId
  portalCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HelpCenterApi#addNewPortalToAccount:");
  console.log(error.body);
});
