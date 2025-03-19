import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.HelpCenterApi();
apiCaller.setApiKey(api.HelpCenterApiApiKeys.userApiKey, "USER_API_KEY");

const portalCreateUpdatePayload: models.PortalCreateUpdatePayload = {
  color: "add color HEX string, \"#fffff\"",
  customDomain: "https://chatwoot.help/.",
  headerText: "Handbook",
  homepageLink: "https://www.chatwoot.com/",
  config: {
    "allowed_locales": [
      "en",
      "es"
    ],
    "default_locale": "en"
  },
};

apiCaller.updateNewPortalToAccount(
  0, // accountId
  portalCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HelpCenterApi#updateNewPortalToAccount:");
  console.log(error.body);
});
