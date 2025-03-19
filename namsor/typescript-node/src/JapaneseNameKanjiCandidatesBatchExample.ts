import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.FirstLastNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Sanae",
  lastName: "Yamamoto",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn: models.BatchFirstLastNameIn = {
  personalNames: personalNames,
};

apiCaller.japaneseNameKanjiCandidatesBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#japaneseNameKanjiCandidatesBatch:");
  console.log(error.body);
});
