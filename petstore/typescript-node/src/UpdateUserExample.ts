import * as fs from 'fs';
import api from "openapi_client"
import models from "openapi_client"

const apiCaller = new api.UserApi();
apiCaller.setApiKey(api.UserApiApiKeys.api_key, "YOUR_API_KEY");

const user: models.User = {
  id: 12345,
  username: "new-username",
  firstName: "Joe",
  lastName: "Broke",
  email: "some-email@example.com",
  password: "so secure omg",
  phone: "555-867-5309",
  userStatus: 1,
};

apiCaller.updateUser(
  "my-username", // username
  user,
).catch(error => {
  console.log("Exception when calling UserApi#updateUser:");
  console.log(error.body);
});
