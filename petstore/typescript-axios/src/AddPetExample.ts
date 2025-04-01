import axios, { AxiosError } from "axios";
import * as api from "openapi_client"

const configuration = new api.Configuration({
  accessToken: "YOUR_ACCESS_TOKEN",
});

const category: api.Category = {
  id: 12345,
  name: "Category_Name",
};

const tags1: api.Tag = {
  id: 12345,
  name: "tag_1",
};

const tags2: api.Tag = {
  id: 98765,
  name: "tag_2",
};

const tags = [
  tags1,
  tags2,
];

const pet: api.Pet = {
  name: "My pet name",
  photoUrls: [
    "https://example.com/picture_1.jpg",
    "https://example.com/picture_2.jpg",
  ],
  id: 12345,
  status: api.PetStatusEnum.Available,
  category: category,
  tags: tags,
};

new api.PetApi(configuration).addPet(
  pet,
).then(response => {
  console.log(response.data);
}).catch((error: Error | AxiosError) => {
  console.log("Exception when calling PetApi#addPet:");
  axios.isAxiosError(error) ? console.log(error.message) : console.log(error);
});
