import * as fs from 'fs';
import api from "launchdarkly_client"
import models from "launchdarkly_client"

const apiCaller = new api.CodeReferencesApi();
apiCaller.setApiKey(api.CodeReferencesApiApiKeys.ApiKey, "YOUR_API_KEY");

const repositoryPost: models.RepositoryPost = {
  name: "LaunchDarkly-Docs",
  sourceLink: "https://github.com/launchdarkly/LaunchDarkly-Docs",
  commitUrlTemplate: "https://github.com/launchdarkly/LaunchDarkly-Docs/commit/${sha}",
  hunkUrlTemplate: "https://github.com/launchdarkly/LaunchDarkly-Docs/blob/${sha}/${filePath}#L${lineNumber}",
  type: models.RepositoryPost.TypeEnum.Github,
  defaultBranch: "main",
};

apiCaller.postRepository(
  repositoryPost,
).then(response => {
  console.log(response.body);
}).catch(error => {
  console.log("Exception when calling CodeReferencesApi#postRepository:");
  console.log(error.body);
});
