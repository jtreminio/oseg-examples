import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.FirstLastNameIn();
personalNames1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
personalNames1.firstName = "塩田";
personalNames1.lastName = "千春";

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn = new models.BatchFirstLastNameIn();
batchFirstLastNameIn.personalNames = personalNames;

apiCaller.japaneseNameLatinCandidatesBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#japaneseNameLatinCandidatesBatch:");
  console.log(error.body);
});
