import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const categoryCreateUpdatePayload: api.CategoryCreateUpdatePayload = {
  locale: "en/es",
};

new api.HelpCenterApi(configuration).addNewCategoryToAccount(
  0, // accountId
  0, // portalId
  categoryCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling HelpCenterApi#addNewCategoryToAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
