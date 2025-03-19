import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.IndianApi();
apiCaller.setApiKey(api.IndianApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.PersonalNameGeoIn = {
  id: "e630dda5-13b3-42c5-8f1d-648aa8a21c42",
  name: "Jannat Rahmani",
};

const personalNames = [
  personalNames1,
];

const batchPersonalNameGeoIn: models.BatchPersonalNameGeoIn = {
  personalNames: personalNames,
};

apiCaller.subclassificationIndianFullBatch(
  batchPersonalNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IndianApi#subclassificationIndianFullBatch:");
  console.log(error.body);
});
