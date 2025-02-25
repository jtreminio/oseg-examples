import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.SegmentsApi();
apiCaller.setApiKey(api.SegmentsApiApiKeys.ApiKey, "YOUR_API_KEY");

apiCaller.getBigSegmentExport(
  undefined, // projectKey
  undefined, // environmentKey
  undefined, // segmentKey
  undefined, // exportID
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Segments#getBigSegmentExport:");
  console.log(error.body);
});
