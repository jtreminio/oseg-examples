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
    /// The current billing period.
    /// </summary>
    [DataContract(Name = "APIBillingPeriodUsageOut")]
    public partial class APIBillingPeriodUsageOut : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIBillingPeriodUsageOut" /> class.
        /// </summary>
        /// <param name="apiKey">User API Key..</param>
        /// <param name="subscriptionStarted">Datetime when the user subscribed to the plan..</param>
        /// <param name="periodStarted">Datetime when the the plan&#39;s current period started..</param>
        /// <param name="periodEnded">Datetime when the the plan&#39;s current period endend..</param>
        /// <param name="stripeCurrentPeriodEnd">Datetime when the the plan&#39;s current period endend (in Stripe). Internal and Stripe periodicity should ~coincide..</param>
        /// <param name="stripeCurrentPeriodStart">Datetime when the the plan&#39;s current period started (in Stripe). Internal and Stripe periodicity should ~coincide..</param>
        /// <param name="billingStatus">Current period billing status ex OPEN..</param>
        /// <param name="usage">Current period usage in units (NB some API endpoints use more than one unit)..</param>
        /// <param name="softLimit">Current period soft limit (reaching the limit sends an email notification)..</param>
        /// <param name="hardLimit">Current period hard limit (reaching the limit sends an email notification and blocks the API Key)..</param>
        public APIBillingPeriodUsageOut(string apiKey = default(string), long subscriptionStarted = default(long), long periodStarted = default(long), long periodEnded = default(long), long stripeCurrentPeriodEnd = default(long), long stripeCurrentPeriodStart = default(long), string billingStatus = default(string), long usage = default(long), long softLimit = default(long), long hardLimit = default(long))
        {
            this.ApiKey = apiKey;
            this.SubscriptionStarted = subscriptionStarted;
            this.PeriodStarted = periodStarted;
            this.PeriodEnded = periodEnded;
            this.StripeCurrentPeriodEnd = stripeCurrentPeriodEnd;
            this.StripeCurrentPeriodStart = stripeCurrentPeriodStart;
            this.BillingStatus = billingStatus;
            this.Usage = usage;
            this.SoftLimit = softLimit;
            this.HardLimit = hardLimit;
        }

        /// <summary>
        /// User API Key.
        /// </summary>
        /// <value>User API Key.</value>
        [DataMember(Name = "apiKey", EmitDefaultValue = false)]
        public string ApiKey { get; set; }

        /// <summary>
        /// Datetime when the user subscribed to the plan.
        /// </summary>
        /// <value>Datetime when the user subscribed to the plan.</value>
        [DataMember(Name = "subscriptionStarted", EmitDefaultValue = false)]
        public long SubscriptionStarted { get; set; }

        /// <summary>
        /// Datetime when the the plan&#39;s current period started.
        /// </summary>
        /// <value>Datetime when the the plan&#39;s current period started.</value>
        [DataMember(Name = "periodStarted", EmitDefaultValue = false)]
        public long PeriodStarted { get; set; }

        /// <summary>
        /// Datetime when the the plan&#39;s current period endend.
        /// </summary>
        /// <value>Datetime when the the plan&#39;s current period endend.</value>
        [DataMember(Name = "periodEnded", EmitDefaultValue = false)]
        public long PeriodEnded { get; set; }

        /// <summary>
        /// Datetime when the the plan&#39;s current period endend (in Stripe). Internal and Stripe periodicity should ~coincide.
        /// </summary>
        /// <value>Datetime when the the plan&#39;s current period endend (in Stripe). Internal and Stripe periodicity should ~coincide.</value>
        [DataMember(Name = "stripeCurrentPeriodEnd", EmitDefaultValue = false)]
        public long StripeCurrentPeriodEnd { get; set; }

        /// <summary>
        /// Datetime when the the plan&#39;s current period started (in Stripe). Internal and Stripe periodicity should ~coincide.
        /// </summary>
        /// <value>Datetime when the the plan&#39;s current period started (in Stripe). Internal and Stripe periodicity should ~coincide.</value>
        [DataMember(Name = "stripeCurrentPeriodStart", EmitDefaultValue = false)]
        public long StripeCurrentPeriodStart { get; set; }

        /// <summary>
        /// Current period billing status ex OPEN.
        /// </summary>
        /// <value>Current period billing status ex OPEN.</value>
        [DataMember(Name = "billingStatus", EmitDefaultValue = false)]
        public string BillingStatus { get; set; }

        /// <summary>
        /// Current period usage in units (NB some API endpoints use more than one unit).
        /// </summary>
        /// <value>Current period usage in units (NB some API endpoints use more than one unit).</value>
        [DataMember(Name = "usage", EmitDefaultValue = false)]
        public long Usage { get; set; }

        /// <summary>
        /// Current period soft limit (reaching the limit sends an email notification).
        /// </summary>
        /// <value>Current period soft limit (reaching the limit sends an email notification).</value>
        [DataMember(Name = "softLimit", EmitDefaultValue = false)]
        public long SoftLimit { get; set; }

        /// <summary>
        /// Current period hard limit (reaching the limit sends an email notification and blocks the API Key).
        /// </summary>
        /// <value>Current period hard limit (reaching the limit sends an email notification and blocks the API Key).</value>
        [DataMember(Name = "hardLimit", EmitDefaultValue = false)]
        public long HardLimit { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class APIBillingPeriodUsageOut {\n");
            sb.Append("  ApiKey: ").Append(ApiKey).Append("\n");
            sb.Append("  SubscriptionStarted: ").Append(SubscriptionStarted).Append("\n");
            sb.Append("  PeriodStarted: ").Append(PeriodStarted).Append("\n");
            sb.Append("  PeriodEnded: ").Append(PeriodEnded).Append("\n");
            sb.Append("  StripeCurrentPeriodEnd: ").Append(StripeCurrentPeriodEnd).Append("\n");
            sb.Append("  StripeCurrentPeriodStart: ").Append(StripeCurrentPeriodStart).Append("\n");
            sb.Append("  BillingStatus: ").Append(BillingStatus).Append("\n");
            sb.Append("  Usage: ").Append(Usage).Append("\n");
            sb.Append("  SoftLimit: ").Append(SoftLimit).Append("\n");
            sb.Append("  HardLimit: ").Append(HardLimit).Append("\n");
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
