import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const portalCreateUpdatePayload: api.PortalCreateUpdatePayload = {
  color: "add color HEX string, \"#fffff\"",
  custom_domain: "https://chatwoot.help/.",
  header_text: "Handbook",
  homepage_link: "https://www.chatwoot.com/",
  config: {
    "allowed_locales": [
      "en",
      "es"
    ],
    "default_locale": "en"
  },
};

new api.HelpCenterApi(configuration).addNewPortalToAccount(
  0, // accountId
  portalCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling HelpCenterApi#addNewPortalToAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
