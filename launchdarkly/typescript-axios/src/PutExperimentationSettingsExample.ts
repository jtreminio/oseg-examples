import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const randomizationUnits1: api.RandomizationUnitInput = {
  randomizationUnit: "user",
  standardRandomizationUnit: api.RandomizationUnitInputStandardRandomizationUnitEnum.Organization,
};

const randomizationUnits = [
  randomizationUnits1,
];

const randomizationSettingsPut: api.RandomizationSettingsPut = {
  randomizationUnits: randomizationUnits,
};

new api.ExperimentsApi(configuration).putExperimentationSettings(
  "the-project-key", // projectKey
  randomizationSettingsPut,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ExperimentsApi#putExperimentationSettings:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
