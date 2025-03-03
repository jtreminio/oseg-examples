/*
 * NamSor API v2
 *
 * NamSor API v2 : enpoints to process personal names (gender, cultural origin or ethnicity) in all alphabets or languages. By default, enpoints use 1 unit per name (ex. Gender), but Ethnicity classification uses 10 to 20 units per name depending on taxonomy. Use GET methods for small tests, but prefer POST methods for higher throughput (batch processing of up to 100 names at a time). Need something you can't find here? We have many more features coming soon. Let us know, we'll do our best to add it! 
 *
 * The version of the OpenAPI document: 2.0.29
 * Contact: contact@namsor.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = App.Namsor.Client.OpenAPIDateConverter;

namespace App.Namsor.Model
{
    /// <summary>
    /// List of API Services
    /// </summary>
    [DataContract(Name = "APIServiceOut")]
    public partial class APIServiceOut : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIServiceOut" /> class.
        /// </summary>
        /// <param name="serviceName">A service name corresponds to classifier name in apiStatus (ex. personalname_gender or personalfullname_gender).</param>
        /// <param name="serviceGroup">Groups together classifiers providing a similar service (ex. gender groups personalname_gender and personalfullname_gender).</param>
        /// <param name="costInUnits">Indicates how many units per call this service costs (ex. the number of units per name).</param>
        public APIServiceOut(string serviceName = default(string), string serviceGroup = default(string), int costInUnits = default(int))
        {
            this.ServiceName = serviceName;
            this.ServiceGroup = serviceGroup;
            this.CostInUnits = costInUnits;
        }

        /// <summary>
        /// A service name corresponds to classifier name in apiStatus (ex. personalname_gender or personalfullname_gender)
        /// </summary>
        /// <value>A service name corresponds to classifier name in apiStatus (ex. personalname_gender or personalfullname_gender)</value>
        [DataMember(Name = "serviceName", EmitDefaultValue = false)]
        public string ServiceName { get; set; }

        /// <summary>
        /// Groups together classifiers providing a similar service (ex. gender groups personalname_gender and personalfullname_gender)
        /// </summary>
        /// <value>Groups together classifiers providing a similar service (ex. gender groups personalname_gender and personalfullname_gender)</value>
        [DataMember(Name = "serviceGroup", EmitDefaultValue = false)]
        public string ServiceGroup { get; set; }

        /// <summary>
        /// Indicates how many units per call this service costs (ex. the number of units per name)
        /// </summary>
        /// <value>Indicates how many units per call this service costs (ex. the number of units per name)</value>
        [DataMember(Name = "costInUnits", EmitDefaultValue = false)]
        public int CostInUnits { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class APIServiceOut {\n");
            sb.Append("  ServiceName: ").Append(ServiceName).Append("\n");
            sb.Append("  ServiceGroup: ").Append(ServiceGroup).Append("\n");
            sb.Append("  CostInUnits: ").Append(CostInUnits).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
