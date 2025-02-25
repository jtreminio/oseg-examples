import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.DataExportDestinationsApi();
apiCaller.setApiKey(api.DataExportDestinationsApiApiKeys.ApiKey, "YOUR_API_KEY");

const destinationPost = new models.DestinationPost();
destinationPost.kind = models.DestinationPost.KindEnum.GooglePubsub;

apiCaller.postDestination(
  undefined, // projectKey
  undefined, // environmentKey
  destinationPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling DataExportDestinations#postDestination:");
  console.log(error.body);
});
