import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.PersonalNameGeoSubdivisionIn = {
  id: "id",
  name: "name",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames2: models.PersonalNameGeoSubdivisionIn = {
  id: "id",
  name: "name",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchPersonalNameGeoSubdivisionIn: models.BatchPersonalNameGeoSubdivisionIn = {
  personalNames: personalNames,
};

apiCaller.religionFullBatch(
  batchPersonalNameGeoSubdivisionIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#religionFullBatch:");
  console.log(error.body);
});
