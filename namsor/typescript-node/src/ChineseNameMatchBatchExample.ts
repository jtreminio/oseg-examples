import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.ChineseApi();
apiCaller.setApiKey(api.ChineseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1Name1 = new models.FirstLastNameIn();
personalNames1Name1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
personalNames1Name1.firstName = "Hong";
personalNames1Name1.lastName = "Yu";

const personalNames1Name2 = new models.PersonalNameIn();
personalNames1Name2.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c43";
personalNames1Name2.name = "喻红";

const personalNames1 = new models.MatchPersonalFirstLastNameIn();
personalNames1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c41";
personalNames1.name1 = personalNames1Name1;
personalNames1.name2 = personalNames1Name2;

const personalNames = [
  personalNames1,
];

const batchMatchPersonalFirstLastNameIn = new models.BatchMatchPersonalFirstLastNameIn();
batchMatchPersonalFirstLastNameIn.personalNames = personalNames;

apiCaller.chineseNameMatchBatch(
  batchMatchPersonalFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ChineseApi#chineseNameMatchBatch:");
  console.log(error.body);
});
