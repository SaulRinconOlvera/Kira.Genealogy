using Kira.Genealogy.Model.Base.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Kira.Genealogy.Model.Base.Implementations
{
    public abstract class BaseAuditable<T> : BaseEntity<T>, IBaseAuditable
    {
        public BaseAuditable() { Enabled = true; }

        [JsonIgnore]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [JsonIgnore]
        [Column(TypeName = "smalldatetime")]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        [StringLength(50)]
        public string LastModifiedBy { get; set; }

        [JsonIgnore]
        [Column(TypeName = "smalldatetime")]
        public DateTime LastModificationDate { get; set; }

        [JsonIgnore]
        [StringLength(50)]
        public string DeletedBy { get; set; }

        [JsonIgnore]
        [Column(TypeName = "smalldatetime")]
        public DateTime? DeletionDate { get; set; }

        [JsonIgnore]
        public bool Enabled { get; set; }
    }
}
