import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.HelpCenterApi();
apiCaller.setApiKey(api.HelpCenterApiApiKeys.userApiKey, "USER_API_KEY");

const articleCreateUpdatePayload: models.ArticleCreateUpdatePayload = {
  meta: {
    "description": "article description",
    "tags": [
      "article_name"
    ],
    "title": "article title"
  },
};

apiCaller.addNewArticleToAccount(
  0, // accountId
  0, // portalId
  articleCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HelpCenterApi#addNewArticleToAccount:");
  console.log(error.body);
});
