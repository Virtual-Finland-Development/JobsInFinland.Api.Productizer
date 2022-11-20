/*
 * Jobs in Finland
 *
 * API specification for Jobs in Finland API
 *
 * The version of the OpenAPI document: 1.0
 * Contact: lassi.patanen@gofore.com
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
using OpenAPIDateConverter = JobsInFinland.Api.Infrastructure.CodeGen.Client.OpenAPIDateConverter;

namespace JobsInFinland.Api.Infrastructure.CodeGen.Model
{
    /// <summary>
    /// HiddenBecause
    /// </summary>
    [DataContract(Name = "HiddenBecause")]
    public partial class HiddenBecause : IEquatable<HiddenBecause>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HiddenBecause" /> class.
        /// </summary>
        /// <param name="lowSkilledWork">lowSkilledWork.</param>
        /// <param name="finnishRequired">finnishRequired.</param>
        /// <param name="notInFinland">notInFinland.</param>
        /// <param name="jobPostingExpired">jobPostingExpired.</param>
        /// <param name="duplicateJobPosting">duplicateJobPosting.</param>
        /// <param name="missingInformation">missingInformation.</param>
        /// <param name="wrongCategory">wrongCategory.</param>
        /// <param name="inaccurateTranslation">inaccurateTranslation.</param>
        /// <param name="userSubmitted">userSubmitted.</param>
        /// <param name="deleted">deleted.</param>
        public HiddenBecause(bool lowSkilledWork = default(bool), bool finnishRequired = default(bool), bool notInFinland = default(bool), bool jobPostingExpired = default(bool), bool duplicateJobPosting = default(bool), bool missingInformation = default(bool), bool wrongCategory = default(bool), bool inaccurateTranslation = default(bool), bool userSubmitted = default(bool), bool deleted = default(bool))
        {
            this.LowSkilledWork = lowSkilledWork;
            this.FinnishRequired = finnishRequired;
            this.NotInFinland = notInFinland;
            this.JobPostingExpired = jobPostingExpired;
            this.DuplicateJobPosting = duplicateJobPosting;
            this.MissingInformation = missingInformation;
            this.WrongCategory = wrongCategory;
            this.InaccurateTranslation = inaccurateTranslation;
            this.UserSubmitted = userSubmitted;
            this.Deleted = deleted;
        }

        /// <summary>
        /// Gets or Sets LowSkilledWork
        /// </summary>
        [DataMember(Name = "lowSkilledWork", EmitDefaultValue = true)]
        public bool LowSkilledWork { get; set; }

        /// <summary>
        /// Gets or Sets FinnishRequired
        /// </summary>
        [DataMember(Name = "finnishRequired", EmitDefaultValue = true)]
        public bool FinnishRequired { get; set; }

        /// <summary>
        /// Gets or Sets NotInFinland
        /// </summary>
        [DataMember(Name = "notInFinland", EmitDefaultValue = true)]
        public bool NotInFinland { get; set; }

        /// <summary>
        /// Gets or Sets JobPostingExpired
        /// </summary>
        [DataMember(Name = "jobPostingExpired", EmitDefaultValue = true)]
        public bool JobPostingExpired { get; set; }

        /// <summary>
        /// Gets or Sets DuplicateJobPosting
        /// </summary>
        [DataMember(Name = "duplicateJobPosting", EmitDefaultValue = true)]
        public bool DuplicateJobPosting { get; set; }

        /// <summary>
        /// Gets or Sets MissingInformation
        /// </summary>
        [DataMember(Name = "missingInformation", EmitDefaultValue = true)]
        public bool MissingInformation { get; set; }

        /// <summary>
        /// Gets or Sets WrongCategory
        /// </summary>
        [DataMember(Name = "wrongCategory", EmitDefaultValue = true)]
        public bool WrongCategory { get; set; }

        /// <summary>
        /// Gets or Sets InaccurateTranslation
        /// </summary>
        [DataMember(Name = "inaccurateTranslation", EmitDefaultValue = true)]
        public bool InaccurateTranslation { get; set; }

        /// <summary>
        /// Gets or Sets UserSubmitted
        /// </summary>
        [DataMember(Name = "userSubmitted", EmitDefaultValue = true)]
        public bool UserSubmitted { get; set; }

        /// <summary>
        /// Gets or Sets Deleted
        /// </summary>
        [DataMember(Name = "deleted", EmitDefaultValue = true)]
        public bool Deleted { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class HiddenBecause {\n");
            sb.Append("  LowSkilledWork: ").Append(LowSkilledWork).Append("\n");
            sb.Append("  FinnishRequired: ").Append(FinnishRequired).Append("\n");
            sb.Append("  NotInFinland: ").Append(NotInFinland).Append("\n");
            sb.Append("  JobPostingExpired: ").Append(JobPostingExpired).Append("\n");
            sb.Append("  DuplicateJobPosting: ").Append(DuplicateJobPosting).Append("\n");
            sb.Append("  MissingInformation: ").Append(MissingInformation).Append("\n");
            sb.Append("  WrongCategory: ").Append(WrongCategory).Append("\n");
            sb.Append("  InaccurateTranslation: ").Append(InaccurateTranslation).Append("\n");
            sb.Append("  UserSubmitted: ").Append(UserSubmitted).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
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
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as HiddenBecause);
        }

        /// <summary>
        /// Returns true if HiddenBecause instances are equal
        /// </summary>
        /// <param name="input">Instance of HiddenBecause to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HiddenBecause input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.LowSkilledWork == input.LowSkilledWork ||
                    this.LowSkilledWork.Equals(input.LowSkilledWork)
                ) && 
                (
                    this.FinnishRequired == input.FinnishRequired ||
                    this.FinnishRequired.Equals(input.FinnishRequired)
                ) && 
                (
                    this.NotInFinland == input.NotInFinland ||
                    this.NotInFinland.Equals(input.NotInFinland)
                ) && 
                (
                    this.JobPostingExpired == input.JobPostingExpired ||
                    this.JobPostingExpired.Equals(input.JobPostingExpired)
                ) && 
                (
                    this.DuplicateJobPosting == input.DuplicateJobPosting ||
                    this.DuplicateJobPosting.Equals(input.DuplicateJobPosting)
                ) && 
                (
                    this.MissingInformation == input.MissingInformation ||
                    this.MissingInformation.Equals(input.MissingInformation)
                ) && 
                (
                    this.WrongCategory == input.WrongCategory ||
                    this.WrongCategory.Equals(input.WrongCategory)
                ) && 
                (
                    this.InaccurateTranslation == input.InaccurateTranslation ||
                    this.InaccurateTranslation.Equals(input.InaccurateTranslation)
                ) && 
                (
                    this.UserSubmitted == input.UserSubmitted ||
                    this.UserSubmitted.Equals(input.UserSubmitted)
                ) && 
                (
                    this.Deleted == input.Deleted ||
                    this.Deleted.Equals(input.Deleted)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = (hashCode * 59) + this.LowSkilledWork.GetHashCode();
                hashCode = (hashCode * 59) + this.FinnishRequired.GetHashCode();
                hashCode = (hashCode * 59) + this.NotInFinland.GetHashCode();
                hashCode = (hashCode * 59) + this.JobPostingExpired.GetHashCode();
                hashCode = (hashCode * 59) + this.DuplicateJobPosting.GetHashCode();
                hashCode = (hashCode * 59) + this.MissingInformation.GetHashCode();
                hashCode = (hashCode * 59) + this.WrongCategory.GetHashCode();
                hashCode = (hashCode * 59) + this.InaccurateTranslation.GetHashCode();
                hashCode = (hashCode * 59) + this.UserSubmitted.GetHashCode();
                hashCode = (hashCode * 59) + this.Deleted.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
