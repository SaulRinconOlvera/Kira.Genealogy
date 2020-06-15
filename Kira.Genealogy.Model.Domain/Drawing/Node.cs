using Kira.Genealogy.Model.Base.Implementations;
using Kira.Genealogy.Model.Domain.Drawing.Enumerations;
using Kira.Genealogy.Model.Domain.Tree;
using System;
using System.Text.Json.Serialization;

namespace Kira.Genealogy.Model.Domain.Drawing
{
    public class Node : BaseAuditable<int>
    {
        public NodeType NodeType { get; set; }
        public int? NodeParentId { get; set; }
        public Guid? PersonId { get; set; }
        public Guid? MatePersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Person MatePerson { get; set; }

        [JsonIgnore]
        public virtual Node NodeParent { get; set; }
    }
}
