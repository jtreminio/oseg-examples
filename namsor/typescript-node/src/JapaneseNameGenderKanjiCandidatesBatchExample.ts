import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.FirstLastNameGenderIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Takashi",
  lastName: "Murakami",
  gender: "male",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameGenderIn: models.BatchFirstLastNameGenderIn = {
  personalNames: personalNames,
};

apiCaller.japaneseNameGenderKanjiCandidatesBatch(
  batchFirstLastNameGenderIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#japaneseNameGenderKanjiCandidatesBatch:");
  console.log(error.body);
});
