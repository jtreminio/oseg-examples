import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.FirstLastNameGeoSubdivisionIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames2: models.FirstLastNameGeoSubdivisionIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
  subdivisionIso: "subdivisionIso",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameGeoSubdivisionIn: models.BatchFirstLastNameGeoSubdivisionIn = {
  personalNames: personalNames,
};

apiCaller.religionBatch(
  batchFirstLastNameGeoSubdivisionIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#religionBatch:");
  console.log(error.body);
});
