import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.PersonalNameGeoIn = {
  id: "0d7d6417-0bbb-4205-951d-b3473f605b56",
  name: "Keith Haring",
  countryIso2: "US",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameGeoIn: models.BatchPersonalNameGeoIn = {
  personalNames: personalNames,
};

apiCaller.diasporaFullBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#diasporaFullBatch:");
  console.log(error.body);
});
