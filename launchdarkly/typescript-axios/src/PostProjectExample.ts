import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const projectPost: api.ProjectPost = {
  name: "My Project",
  key: "project-key-123abc",
};

new api.ProjectsApi(configuration).postProject(
  projectPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling ProjectsApi#postProject:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
