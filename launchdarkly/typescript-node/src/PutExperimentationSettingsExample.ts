import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.ExperimentsApi();
apiCaller.setApiKey(api.ExperimentsApiApiKeys.ApiKey, "YOUR_API_KEY");

const randomizationUnits1 = new models.RandomizationUnitInput();
randomizationUnits1.randomizationUnit = "user";
randomizationUnits1.standardRandomizationUnit = models.RandomizationUnitInput.StandardRandomizationUnitEnum.Organization;

const randomizationUnits = [
  randomizationUnits1,
];

const randomizationSettingsPut = new models.RandomizationSettingsPut();
randomizationSettingsPut.randomizationUnits = randomizationUnits;

apiCaller.putExperimentationSettings(
  "the-project-key", // projectKey
  randomizationSettingsPut,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling Experiments#putExperimentationSettings:");
  console.log(error.body);
});
