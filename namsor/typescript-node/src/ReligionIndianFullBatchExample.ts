import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.IndianApi();
apiCaller.setApiKey(api.IndianApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1 = new models.PersonalNameSubdivisionIn();
personalNames1.id = "e630dda5-13b3-42c5-8f1d-648aa8a21c42";
personalNames1.name = "Akash Sharma";
personalNames1.subdivisionIso = "IN-PB";

const personalNames = [
  personalNames1,
];

const batchPersonalNameSubdivisionIn = new models.BatchPersonalNameSubdivisionIn();
batchPersonalNameSubdivisionIn.personalNames = personalNames;

apiCaller.religionIndianFullBatch(
  batchPersonalNameSubdivisionIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling IndianApi#religionIndianFullBatch:");
  console.log(error.body);
});
