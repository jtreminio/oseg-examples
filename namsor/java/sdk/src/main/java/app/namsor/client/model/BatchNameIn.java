/*
 * NamSor API v2
 * NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can't find here? We have many more features coming soon. Let us know, we'll do our best to add it! 
 *
 * The version of the OpenAPI document: 2.0.29
 * Contact: contact@namsor.com
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


package app.namsor.client.model;

import java.util.Objects;
import app.namsor.client.model.NameIn;
import com.google.gson.TypeAdapter;
import com.google.gson.annotations.JsonAdapter;
import com.google.gson.annotations.SerializedName;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;
import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParseException;
import com.google.gson.TypeAdapterFactory;
import com.google.gson.reflect.TypeToken;
import com.google.gson.TypeAdapter;
import com.google.gson.stream.JsonReader;
import com.google.gson.stream.JsonWriter;
import java.io.IOException;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import app.namsor.client.JSON;

/**
 * BatchNameIn
 */
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", comments = "Generator version: 7.11.0")
public class BatchNameIn {
  public static final String SERIALIZED_NAME_PROPER_NOUNS = "properNouns";
  @SerializedName(SERIALIZED_NAME_PROPER_NOUNS)
  @javax.annotation.Nullable
  private List<NameIn> properNouns = new ArrayList<>();

  public BatchNameIn() {
  }

  public BatchNameIn properNouns(@javax.annotation.Nullable List<NameIn> properNouns) {
    this.properNouns = properNouns;
    return this;
  }

  public BatchNameIn addProperNounsItem(NameIn properNounsItem) {
    if (this.properNouns == null) {
      this.properNouns = new ArrayList<>();
    }
    this.properNouns.add(properNounsItem);
    return this;
  }

  /**
   * Get properNouns
   * @return properNouns
   */
  @javax.annotation.Nullable
  public List<NameIn> getProperNouns() {
    return properNouns;
  }

  public void setProperNouns(@javax.annotation.Nullable List<NameIn> properNouns) {
    this.properNouns = properNouns;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    BatchNameIn batchNameIn = (BatchNameIn) o;
    return Objects.equals(this.properNouns, batchNameIn.properNouns);
  }

  @Override
  public int hashCode() {
    return Objects.hash(properNouns);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class BatchNameIn {\n");
    sb.append("    properNouns: ").append(toIndentedString(properNouns)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }


  public static HashSet<String> openapiFields;
  public static HashSet<String> openapiRequiredFields;

  static {
    // a set of all properties/fields (JSON key names)
    openapiFields = new HashSet<String>();
    openapiFields.add("properNouns");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
  }

  /**
   * Validates the JSON Element and throws an exception if issues found
   *
   * @param jsonElement JSON Element
   * @throws IOException if the JSON Element is invalid with respect to BatchNameIn
   */
  public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      if (jsonElement == null) {
        if (!BatchNameIn.openapiRequiredFields.isEmpty()) { // has required fields but JSON element is null
          throw new IllegalArgumentException(String.format("The required field(s) %s in BatchNameIn is not found in the empty JSON string", BatchNameIn.openapiRequiredFields.toString()));
        }
      }

      Set<Map.Entry<String, JsonElement>> entries = jsonElement.getAsJsonObject().entrySet();
      // check to see if the JSON string contains additional fields
      for (Map.Entry<String, JsonElement> entry : entries) {
        if (!BatchNameIn.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `BatchNameIn` properties. JSON: %s", entry.getKey(), jsonElement.toString()));
        }
      }
        JsonObject jsonObj = jsonElement.getAsJsonObject();
      if (jsonObj.get("properNouns") != null && !jsonObj.get("properNouns").isJsonNull()) {
        JsonArray jsonArrayproperNouns = jsonObj.getAsJsonArray("properNouns");
        if (jsonArrayproperNouns != null) {
          // ensure the json data is an array
          if (!jsonObj.get("properNouns").isJsonArray()) {
            throw new IllegalArgumentException(String.format("Expected the field `properNouns` to be an array in the JSON string but got `%s`", jsonObj.get("properNouns").toString()));
          }

          // validate the optional field `properNouns` (array)
          for (int i = 0; i < jsonArrayproperNouns.size(); i++) {
            NameIn.validateJsonElement(jsonArrayproperNouns.get(i));
          };
        }
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!BatchNameIn.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'BatchNameIn' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<BatchNameIn> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(BatchNameIn.class));

       return (TypeAdapter<T>) new TypeAdapter<BatchNameIn>() {
           @Override
           public void write(JsonWriter out, BatchNameIn value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public BatchNameIn read(JsonReader in) throws IOException {
             JsonElement jsonElement = elementAdapter.read(in);
             validateJsonElement(jsonElement);
             return thisAdapter.fromJsonTree(jsonElement);
           }

       }.nullSafe();
    }
  }

  /**
   * Create an instance of BatchNameIn given an JSON string
   *
   * @param jsonString JSON string
   * @return An instance of BatchNameIn
   * @throws IOException if the JSON string is invalid with respect to BatchNameIn
   */
  public static BatchNameIn fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, BatchNameIn.class);
  }

  /**
   * Convert an instance of BatchNameIn to an JSON string
   *
   * @return JSON string
   */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

