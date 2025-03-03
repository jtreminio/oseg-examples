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
 * APIUsageAggregatedOut
 */
@javax.annotation.Generated(value = "org.openapitools.codegen.languages.JavaClientCodegen", comments = "Generator version: 7.11.0")
public class APIUsageAggregatedOut {
  public static final String SERIALIZED_NAME_TIME_UNIT = "timeUnit";
  @SerializedName(SERIALIZED_NAME_TIME_UNIT)
  @javax.annotation.Nullable
  private String timeUnit;

  public static final String SERIALIZED_NAME_PERIOD_START = "periodStart";
  @SerializedName(SERIALIZED_NAME_PERIOD_START)
  @javax.annotation.Nullable
  private Long periodStart;

  public static final String SERIALIZED_NAME_PERIOD_END = "periodEnd";
  @SerializedName(SERIALIZED_NAME_PERIOD_END)
  @javax.annotation.Nullable
  private Long periodEnd;

  public static final String SERIALIZED_NAME_TOTAL_USAGE = "totalUsage";
  @SerializedName(SERIALIZED_NAME_TOTAL_USAGE)
  @javax.annotation.Nullable
  private Long totalUsage;

  public static final String SERIALIZED_NAME_HISTORY_TRUNCATED = "historyTruncated";
  @SerializedName(SERIALIZED_NAME_HISTORY_TRUNCATED)
  @javax.annotation.Nullable
  private Boolean historyTruncated;

  public static final String SERIALIZED_NAME_DATA = "data";
  @SerializedName(SERIALIZED_NAME_DATA)
  @javax.annotation.Nullable
  private List<List<Integer>> data = new ArrayList<>();

  public static final String SERIALIZED_NAME_COL_HEADERS = "colHeaders";
  @SerializedName(SERIALIZED_NAME_COL_HEADERS)
  @javax.annotation.Nullable
  private List<String> colHeaders = new ArrayList<>();

  public static final String SERIALIZED_NAME_ROW_HEADERS = "rowHeaders";
  @SerializedName(SERIALIZED_NAME_ROW_HEADERS)
  @javax.annotation.Nullable
  private List<String> rowHeaders = new ArrayList<>();

  public APIUsageAggregatedOut() {
  }

  public APIUsageAggregatedOut timeUnit(@javax.annotation.Nullable String timeUnit) {
    this.timeUnit = timeUnit;
    return this;
  }

  /**
   * Time unit is DAY, WEEK or MONTH depending on prior usage
   * @return timeUnit
   */
  @javax.annotation.Nullable
  public String getTimeUnit() {
    return timeUnit;
  }

  public void setTimeUnit(@javax.annotation.Nullable String timeUnit) {
    this.timeUnit = timeUnit;
  }


  public APIUsageAggregatedOut periodStart(@javax.annotation.Nullable Long periodStart) {
    this.periodStart = periodStart;
    return this;
  }

  /**
   * Start datetime of the reporting period
   * @return periodStart
   */
  @javax.annotation.Nullable
  public Long getPeriodStart() {
    return periodStart;
  }

  public void setPeriodStart(@javax.annotation.Nullable Long periodStart) {
    this.periodStart = periodStart;
  }


  public APIUsageAggregatedOut periodEnd(@javax.annotation.Nullable Long periodEnd) {
    this.periodEnd = periodEnd;
    return this;
  }

  /**
   * End datetime of the reporting period
   * @return periodEnd
   */
  @javax.annotation.Nullable
  public Long getPeriodEnd() {
    return periodEnd;
  }

  public void setPeriodEnd(@javax.annotation.Nullable Long periodEnd) {
    this.periodEnd = periodEnd;
  }


  public APIUsageAggregatedOut totalUsage(@javax.annotation.Nullable Long totalUsage) {
    this.totalUsage = totalUsage;
    return this;
  }

  /**
   * Total usage in the current period
   * @return totalUsage
   */
  @javax.annotation.Nullable
  public Long getTotalUsage() {
    return totalUsage;
  }

  public void setTotalUsage(@javax.annotation.Nullable Long totalUsage) {
    this.totalUsage = totalUsage;
  }


  public APIUsageAggregatedOut historyTruncated(@javax.annotation.Nullable Boolean historyTruncated) {
    this.historyTruncated = historyTruncated;
    return this;
  }

  /**
   * If the history was truncaded due to data limit
   * @return historyTruncated
   */
  @javax.annotation.Nullable
  public Boolean getHistoryTruncated() {
    return historyTruncated;
  }

  public void setHistoryTruncated(@javax.annotation.Nullable Boolean historyTruncated) {
    this.historyTruncated = historyTruncated;
  }


  public APIUsageAggregatedOut data(@javax.annotation.Nullable List<List<Integer>> data) {
    this.data = data;
    return this;
  }

  public APIUsageAggregatedOut addDataItem(List<Integer> dataItem) {
    if (this.data == null) {
      this.data = new ArrayList<>();
    }
    this.data.add(dataItem);
    return this;
  }

  /**
   * Data points : usage per DAY, WEEK or MONTH and per apiService
   * @return data
   */
  @javax.annotation.Nullable
  public List<List<Integer>> getData() {
    return data;
  }

  public void setData(@javax.annotation.Nullable List<List<Integer>> data) {
    this.data = data;
  }


  public APIUsageAggregatedOut colHeaders(@javax.annotation.Nullable List<String> colHeaders) {
    this.colHeaders = colHeaders;
    return this;
  }

  public APIUsageAggregatedOut addColHeadersItem(String colHeadersItem) {
    if (this.colHeaders == null) {
      this.colHeaders = new ArrayList<>();
    }
    this.colHeaders.add(colHeadersItem);
    return this;
  }

  /**
   * apiServices as column headers 
   * @return colHeaders
   */
  @javax.annotation.Nullable
  public List<String> getColHeaders() {
    return colHeaders;
  }

  public void setColHeaders(@javax.annotation.Nullable List<String> colHeaders) {
    this.colHeaders = colHeaders;
  }


  public APIUsageAggregatedOut rowHeaders(@javax.annotation.Nullable List<String> rowHeaders) {
    this.rowHeaders = rowHeaders;
    return this;
  }

  public APIUsageAggregatedOut addRowHeadersItem(String rowHeadersItem) {
    if (this.rowHeaders == null) {
      this.rowHeaders = new ArrayList<>();
    }
    this.rowHeaders.add(rowHeadersItem);
    return this;
  }

  /**
   * dates as row headers 
   * @return rowHeaders
   */
  @javax.annotation.Nullable
  public List<String> getRowHeaders() {
    return rowHeaders;
  }

  public void setRowHeaders(@javax.annotation.Nullable List<String> rowHeaders) {
    this.rowHeaders = rowHeaders;
  }



  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    APIUsageAggregatedOut apIUsageAggregatedOut = (APIUsageAggregatedOut) o;
    return Objects.equals(this.timeUnit, apIUsageAggregatedOut.timeUnit) &&
        Objects.equals(this.periodStart, apIUsageAggregatedOut.periodStart) &&
        Objects.equals(this.periodEnd, apIUsageAggregatedOut.periodEnd) &&
        Objects.equals(this.totalUsage, apIUsageAggregatedOut.totalUsage) &&
        Objects.equals(this.historyTruncated, apIUsageAggregatedOut.historyTruncated) &&
        Objects.equals(this.data, apIUsageAggregatedOut.data) &&
        Objects.equals(this.colHeaders, apIUsageAggregatedOut.colHeaders) &&
        Objects.equals(this.rowHeaders, apIUsageAggregatedOut.rowHeaders);
  }

  @Override
  public int hashCode() {
    return Objects.hash(timeUnit, periodStart, periodEnd, totalUsage, historyTruncated, data, colHeaders, rowHeaders);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class APIUsageAggregatedOut {\n");
    sb.append("    timeUnit: ").append(toIndentedString(timeUnit)).append("\n");
    sb.append("    periodStart: ").append(toIndentedString(periodStart)).append("\n");
    sb.append("    periodEnd: ").append(toIndentedString(periodEnd)).append("\n");
    sb.append("    totalUsage: ").append(toIndentedString(totalUsage)).append("\n");
    sb.append("    historyTruncated: ").append(toIndentedString(historyTruncated)).append("\n");
    sb.append("    data: ").append(toIndentedString(data)).append("\n");
    sb.append("    colHeaders: ").append(toIndentedString(colHeaders)).append("\n");
    sb.append("    rowHeaders: ").append(toIndentedString(rowHeaders)).append("\n");
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
    openapiFields.add("timeUnit");
    openapiFields.add("periodStart");
    openapiFields.add("periodEnd");
    openapiFields.add("totalUsage");
    openapiFields.add("historyTruncated");
    openapiFields.add("data");
    openapiFields.add("colHeaders");
    openapiFields.add("rowHeaders");

    // a set of required properties/fields (JSON key names)
    openapiRequiredFields = new HashSet<String>();
  }

  /**
   * Validates the JSON Element and throws an exception if issues found
   *
   * @param jsonElement JSON Element
   * @throws IOException if the JSON Element is invalid with respect to APIUsageAggregatedOut
   */
  public static void validateJsonElement(JsonElement jsonElement) throws IOException {
      if (jsonElement == null) {
        if (!APIUsageAggregatedOut.openapiRequiredFields.isEmpty()) { // has required fields but JSON element is null
          throw new IllegalArgumentException(String.format("The required field(s) %s in APIUsageAggregatedOut is not found in the empty JSON string", APIUsageAggregatedOut.openapiRequiredFields.toString()));
        }
      }

      Set<Map.Entry<String, JsonElement>> entries = jsonElement.getAsJsonObject().entrySet();
      // check to see if the JSON string contains additional fields
      for (Map.Entry<String, JsonElement> entry : entries) {
        if (!APIUsageAggregatedOut.openapiFields.contains(entry.getKey())) {
          throw new IllegalArgumentException(String.format("The field `%s` in the JSON string is not defined in the `APIUsageAggregatedOut` properties. JSON: %s", entry.getKey(), jsonElement.toString()));
        }
      }
        JsonObject jsonObj = jsonElement.getAsJsonObject();
      if ((jsonObj.get("timeUnit") != null && !jsonObj.get("timeUnit").isJsonNull()) && !jsonObj.get("timeUnit").isJsonPrimitive()) {
        throw new IllegalArgumentException(String.format("Expected the field `timeUnit` to be a primitive type in the JSON string but got `%s`", jsonObj.get("timeUnit").toString()));
      }
      // ensure the optional json data is an array if present
      if (jsonObj.get("data") != null && !jsonObj.get("data").isJsonNull() && !jsonObj.get("data").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `data` to be an array in the JSON string but got `%s`", jsonObj.get("data").toString()));
      }
      // ensure the optional json data is an array if present
      if (jsonObj.get("colHeaders") != null && !jsonObj.get("colHeaders").isJsonNull() && !jsonObj.get("colHeaders").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `colHeaders` to be an array in the JSON string but got `%s`", jsonObj.get("colHeaders").toString()));
      }
      // ensure the optional json data is an array if present
      if (jsonObj.get("rowHeaders") != null && !jsonObj.get("rowHeaders").isJsonNull() && !jsonObj.get("rowHeaders").isJsonArray()) {
        throw new IllegalArgumentException(String.format("Expected the field `rowHeaders` to be an array in the JSON string but got `%s`", jsonObj.get("rowHeaders").toString()));
      }
  }

  public static class CustomTypeAdapterFactory implements TypeAdapterFactory {
    @SuppressWarnings("unchecked")
    @Override
    public <T> TypeAdapter<T> create(Gson gson, TypeToken<T> type) {
       if (!APIUsageAggregatedOut.class.isAssignableFrom(type.getRawType())) {
         return null; // this class only serializes 'APIUsageAggregatedOut' and its subtypes
       }
       final TypeAdapter<JsonElement> elementAdapter = gson.getAdapter(JsonElement.class);
       final TypeAdapter<APIUsageAggregatedOut> thisAdapter
                        = gson.getDelegateAdapter(this, TypeToken.get(APIUsageAggregatedOut.class));

       return (TypeAdapter<T>) new TypeAdapter<APIUsageAggregatedOut>() {
           @Override
           public void write(JsonWriter out, APIUsageAggregatedOut value) throws IOException {
             JsonObject obj = thisAdapter.toJsonTree(value).getAsJsonObject();
             elementAdapter.write(out, obj);
           }

           @Override
           public APIUsageAggregatedOut read(JsonReader in) throws IOException {
             JsonElement jsonElement = elementAdapter.read(in);
             validateJsonElement(jsonElement);
             return thisAdapter.fromJsonTree(jsonElement);
           }

       }.nullSafe();
    }
  }

  /**
   * Create an instance of APIUsageAggregatedOut given an JSON string
   *
   * @param jsonString JSON string
   * @return An instance of APIUsageAggregatedOut
   * @throws IOException if the JSON string is invalid with respect to APIUsageAggregatedOut
   */
  public static APIUsageAggregatedOut fromJson(String jsonString) throws IOException {
    return JSON.getGson().fromJson(jsonString, APIUsageAggregatedOut.class);
  }

  /**
   * Convert an instance of APIUsageAggregatedOut to an JSON string
   *
   * @return JSON string
   */
  public String toJson() {
    return JSON.getGson().toJson(this);
  }
}

