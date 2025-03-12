import * as fs from 'fs';
import api from "chatwoot_client"
import models from "chatwoot_client"

const apiCaller = new api.HelpCenterApi();
apiCaller.setApiKey(api.HelpCenterApiApiKeys.userApiKey, "USER_API_KEY");

const articleCreateUpdatePayload = new models.ArticleCreateUpdatePayload();
articleCreateUpdatePayload.content = undefined;
articleCreateUpdatePayload.position = undefined;
articleCreateUpdatePayload.status = undefined;
articleCreateUpdatePayload.title = undefined;
articleCreateUpdatePayload.slug = undefined;
articleCreateUpdatePayload.views = undefined;
articleCreateUpdatePayload.portalId = undefined;
articleCreateUpdatePayload.accountId = undefined;
articleCreateUpdatePayload.authorId = undefined;
articleCreateUpdatePayload.categoryId = undefined;
articleCreateUpdatePayload.folderId = undefined;
articleCreateUpdatePayload.associatedArticleId = undefined;

apiCaller.addNewArticleToAccount(
  undefined, // accountId
  undefined, // portalId
  articleCreateUpdatePayload, // data
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling HelpCenterApi#addNewArticleToAccount:");
  console.log(error.body);
});
