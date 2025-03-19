import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1Name1: models.FirstLastNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Tessai",
  lastName: "Tomioka",
};

const personalNames1Name2: models.PersonalNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c43",
  name: "富岡 鉄斎",
};

const personalNames1: models.MatchPersonalFirstLastNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c41",
  name1: personalNames1Name1,
  name2: personalNames1Name2,
};

const personalNames = [
  personalNames1,
];

const batchMatchPersonalFirstLastNameIn: models.BatchMatchPersonalFirstLastNameIn = {
  personalNames: personalNames,
};

apiCaller.japaneseNameMatchBatch(
  batchMatchPersonalFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#japaneseNameMatchBatch:");
  console.log(error.body);
});
