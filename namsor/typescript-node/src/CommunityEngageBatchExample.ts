import * as fs from 'fs';
import api from "namsor_client"
import models from "namsor_client"

const apiCaller = new api.PersonalApi();
apiCaller.setApiKey(api.PersonalApiApiKeys.api_key, "YOUR_API_KEY");

const personalNames1: models.FirstLastNameGeoIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
};

const personalNames2: models.FirstLastNameGeoIn = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  countryIso2: "countryIso2",
};

const personalNames = [
  personalNames1,
  personalNames2,
];

const batchFirstLastNameGeoIn: models.BatchFirstLastNameGeoIn = {
  personalNames: personalNames,
};

apiCaller.communityEngageBatch(
  batchFirstLastNameGeoIn,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling PersonalApi#communityEngageBatch:");
  console.log(error.body);
});
