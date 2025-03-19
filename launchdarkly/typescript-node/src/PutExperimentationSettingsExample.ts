import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ExperimentsApi();
apiCaller.setApiKey(api.ExperimentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const randomizationUnits1: models.RandomizationUnitInput = {
  randomizationUnit: "user",
  standardRandomizationUnit: models.RandomizationUnitInput.StandardRandomizationUnitEnum.Organization,
};

const randomizationUnits = [
  randomizationUnits1,
];

const randomizationSettingsPut: models.RandomizationSettingsPut = {
  randomizationUnits: randomizationUnits,
};

apiCaller.putExperimentationSettings(
  "the-project-key", // projectKey
  randomizationSettingsPut,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling ExperimentsApi#putExperimentationSettings:");
  console.log(error.body);
});
