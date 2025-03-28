import axios, { AxiosError } from "axios";
import * as api from "launchdarkly_client"

const configuration = new api.Configuration({
  apiKey: "YOUR_API_KEY",
});

const repositoryPost: api.RepositoryPost = {
  name: "LaunchDarkly-Docs",
  sourceLink: "https://github.com/launchdarkly/LaunchDarkly-Docs",
  commitUrlTemplate: "https://github.com/launchdarkly/LaunchDarkly-Docs/commit/${sha}",
  hunkUrlTemplate: "https://github.com/launchdarkly/LaunchDarkly-Docs/blob/${sha}/${filePath}#L${lineNumber}",
  type: api.RepositoryPostTypeEnum.Github,
  defaultBranch: "main",
};

new api.CodeReferencesApi(configuration).postRepository(
  repositoryPost,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling CodeReferencesApi#postRepository:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
