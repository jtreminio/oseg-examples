import axios, { AxiosError } from "axios";
import * as api from "chatwoot_client"

const configuration = new api.Configuration({
  apiKey: "USER_API_KEY",
});

const articleCreateUpdatePayload: api.ArticleCreateUpdatePayload = {
  meta: {
    "description": "article description",
    "tags": [
      "article_name"
    ],
    "title": "article title"
  },
};

new api.HelpCenterApi(configuration).addNewArticleToAccount(
  0, // accountId
  0, // portalId
  articleCreateUpdatePayload, // data
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling HelpCenterApi#addNewArticleToAccount:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
