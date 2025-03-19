import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.PersonalNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  name: "中松 義郎",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameIn: models.BatchPersonalNameIn = {
  personalNames: personalNames,
};

apiCaller.genderJapaneseNameFullBatch(
  batchPersonalNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#genderJapaneseNameFullBatch:");
  console.log(error.body);
});
