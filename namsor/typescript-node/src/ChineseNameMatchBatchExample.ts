import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.ChineseApi();
apiCaller.setApiKey(api.ChineseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1Name1: models.FirstLastNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Hong",
  lastName: "Yu",
};

const personalNames1Name2: models.PersonalNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c43",
  name: "喻红",
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

apiCaller.chineseNameMatchBatch(
  batchMatchPersonalFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ChineseApi#chineseNameMatchBatch:");
  console.log(error.body);
});
