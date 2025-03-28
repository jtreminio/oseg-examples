import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
  // apiKey: "YOUR_API_KEY",
});

const order: api.Order = {
  id: 12345,
  petId: 98765,
  quantity: 5,
  shipDate: "2025-01-01T17:32:28Z",
  status: api.OrderStatusEnum.Approved,
  complete: false,
};

new api.StoreApi(configuration).placeOrder(
  order,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling StoreApi#placeOrder:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
