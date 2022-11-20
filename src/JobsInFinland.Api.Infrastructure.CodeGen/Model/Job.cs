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
    /// Job
    /// </summary>
    [DataContract(Name = "Job")]
    public partial class Job : IEquatable<Job>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Job" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="title">title.</param>
        /// <param name="description">description.</param>
        /// <param name="imageUrl">imageUrl.</param>
        /// <param name="externalUrl">externalUrl.</param>
        /// <param name="employer">employer.</param>
        /// <param name="location">location.</param>
        /// <param name="source">source.</param>
        /// <param name="schedule">schedule.</param>
        /// <param name="clustering">clustering.</param>
        /// <param name="status">status.</param>
        public Job(string id = default(string), string title = default(string), string description = default(string), string imageUrl = default(string), string externalUrl = default(string), Employer employer = default(Employer), Location location = default(Location), Source source = default(Source), Schedule schedule = default(Schedule), Clustering clustering = default(Clustering), Status status = default(Status))
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.ImageUrl = imageUrl;
            this.ExternalUrl = externalUrl;
            this.Employer = employer;
            this.Location = location;
            this.Source = source;
            this.Schedule = schedule;
            this.Clustering = clustering;
            this.Status = status;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ImageUrl
        /// </summary>
        [DataMember(Name = "imageUrl", EmitDefaultValue = false)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or Sets ExternalUrl
        /// </summary>
        [DataMember(Name = "externalUrl", EmitDefaultValue = false)]
        public string ExternalUrl { get; set; }

        /// <summary>
        /// Gets or Sets Employer
        /// </summary>
        [DataMember(Name = "employer", EmitDefaultValue = false)]
        public Employer Employer { get; set; }

        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        [DataMember(Name = "location", EmitDefaultValue = false)]
        public Location Location { get; set; }

        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [DataMember(Name = "source", EmitDefaultValue = false)]
        public Source Source { get; set; }

        /// <summary>
        /// Gets or Sets Schedule
        /// </summary>
        [DataMember(Name = "schedule", EmitDefaultValue = false)]
        public Schedule Schedule { get; set; }

        /// <summary>
        /// Gets or Sets Clustering
        /// </summary>
        [DataMember(Name = "clustering", EmitDefaultValue = false)]
        public Clustering Clustering { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public Status Status { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Job {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
            sb.Append("  ExternalUrl: ").Append(ExternalUrl).Append("\n");
            sb.Append("  Employer: ").Append(Employer).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Schedule: ").Append(Schedule).Append("\n");
            sb.Append("  Clustering: ").Append(Clustering).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
            return this.Equals(input as Job);
        }

        /// <summary>
        /// Returns true if Job instances are equal
        /// </summary>
        /// <param name="input">Instance of Job to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Job input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.ImageUrl == input.ImageUrl ||
                    (this.ImageUrl != null &&
                    this.ImageUrl.Equals(input.ImageUrl))
                ) && 
                (
                    this.ExternalUrl == input.ExternalUrl ||
                    (this.ExternalUrl != null &&
                    this.ExternalUrl.Equals(input.ExternalUrl))
                ) && 
                (
                    this.Employer == input.Employer ||
                    (this.Employer != null &&
                    this.Employer.Equals(input.Employer))
                ) && 
                (
                    this.Location == input.Location ||
                    (this.Location != null &&
                    this.Location.Equals(input.Location))
                ) && 
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) && 
                (
                    this.Schedule == input.Schedule ||
                    (this.Schedule != null &&
                    this.Schedule.Equals(input.Schedule))
                ) && 
                (
                    this.Clustering == input.Clustering ||
                    (this.Clustering != null &&
                    this.Clustering.Equals(input.Clustering))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
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
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Title != null)
                {
                    hashCode = (hashCode * 59) + this.Title.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.ImageUrl != null)
                {
                    hashCode = (hashCode * 59) + this.ImageUrl.GetHashCode();
                }
                if (this.ExternalUrl != null)
                {
                    hashCode = (hashCode * 59) + this.ExternalUrl.GetHashCode();
                }
                if (this.Employer != null)
                {
                    hashCode = (hashCode * 59) + this.Employer.GetHashCode();
                }
                if (this.Location != null)
                {
                    hashCode = (hashCode * 59) + this.Location.GetHashCode();
                }
                if (this.Source != null)
                {
                    hashCode = (hashCode * 59) + this.Source.GetHashCode();
                }
                if (this.Schedule != null)
                {
                    hashCode = (hashCode * 59) + this.Schedule.GetHashCode();
                }
                if (this.Clustering != null)
                {
                    hashCode = (hashCode * 59) + this.Clustering.GetHashCode();
                }
                if (this.Status != null)
                {
                    hashCode = (hashCode * 59) + this.Status.GetHashCode();
                }
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