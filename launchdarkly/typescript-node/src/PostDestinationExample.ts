import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.DataExportDestinationsApi();
apiCaller.setApiKey(api.DataExportDestinationsApiApiKeys.ApiKey, "YOUR_API_KEY");

const destinationPost: models.DestinationPost = {
  kind: models.DestinationPost.KindEnum.GooglePubsub,
};

apiCaller.postDestination(
  "projectKey_string", // projectKey
  "environmentKey_string", // environmentKey
  destinationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling DataExportDestinationsApi#postDestination:");
  console.log(error.body);
});
