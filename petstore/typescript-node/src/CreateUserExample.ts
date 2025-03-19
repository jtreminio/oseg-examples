import * as fs from 'fs';
import api from "openapi_client"
import models from "openapi_client"

const apiCaller = new api.UserApi();
apiCaller.setApiKey(api.UserApiApiKeys.api_key, "YOUR_API_KEY");

const user: models.User = {
  id: 12345,
  username: "my_user",
  firstName: "John",
  lastName: "Doe",
  email: "john@example.com",
  password: "secure_123",
  phone: "555-123-1234",
  userStatus: 1,
};

apiCaller.createUser(
  user,
).catch(error => {
  console.log("Exception when calling UserApi#createUser:");
  console.log(error.body);
});
