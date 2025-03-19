import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

const contextSearch: models.ContextSearch = {
  filter: "*.name startsWith Jo,kind anyOf [\"user\",\"organization\"]",
  sort: "-ts",
  limit: 10,
  continuationToken: "QAGFKH1313KUGI2351",
};

apiCaller.searchContexts(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  contextSearch,
  undefined, // limit
  undefined, // continuationToken
  undefined, // sort
  undefined, // filter
  undefined, // includeTotalCount
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContextsApi#searchContexts:");
  console.log(error.body);
});
