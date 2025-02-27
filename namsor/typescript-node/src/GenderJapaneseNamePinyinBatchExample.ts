import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.FirstLastNameIn();
personalNames1.id = "id";
personalNames1.firstName = "firstName";
personalNames1.lastName = "lastName";

const personalNames2 = new models.FirstLastNameIn();
personalNames2.id = "id";
personalNames2.firstName = "firstName";
personalNames2.lastName = "lastName";

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameIn = new models.BatchFirstLastNameIn();
batchFirstLastNameIn.personalNames = personalNames;

apiCaller.genderJapaneseNamePinyinBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#genderJapaneseNamePinyinBatch:");
  console.log(error.body);
});
