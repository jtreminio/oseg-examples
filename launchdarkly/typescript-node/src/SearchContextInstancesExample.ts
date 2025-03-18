import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ContextsApi();
apiCaller.setApiKey(api.ContextsApiApiKeys.ApiKey, "YOUR_API_KEY");

const contextInstanceSearch = new models.ContextInstanceSearch();
contextInstanceSearch.filter = "{\"filter\": \"kindKeys:{\"contains\": [\"user:Henry\"]},\"sort\": \"-ts\",\"limit\": 50}";
contextInstanceSearch.sort = "-ts";
contextInstanceSearch.limit = 10;
contextInstanceSearch.continuationToken = "QAGFKH1313KUGI2351";

apiCaller.searchContextInstances(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  contextInstanceSearch,
  undefined, // limit
  undefined, // continuationToken
  undefined, // sort
  undefined, // filter
  undefined, // includeTotalCount
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ContextsApi#searchContextInstances:");
  console.log(error.body);
});
