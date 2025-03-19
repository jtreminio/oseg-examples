import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.JapaneseApi();
apiCaller.setApiKey(api.JapaneseApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.FirstLastNameIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
};

const personalNames2: models.FirstLastNameIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameIn: models.BatchFirstLastNameIn = {
  personalNames: personalNames,
};

apiCaller.genderJapaneseNamePinyinBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling JapaneseApi#genderJapaneseNamePinyinBatch:");
  console.log(error.body);
});
