import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.FirstLastNameIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  firstName: "Keith",
  lastName: "Haring",
};

const personalNames = [
  personalNames1,
];

const batchFirstLastNameIn: models.BatchFirstLastNameIn = {
  personalNames: personalNames,
};

apiCaller.originBatch(
  batchFirstLastNameIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#originBatch:");
  console.log(error.body);
});
