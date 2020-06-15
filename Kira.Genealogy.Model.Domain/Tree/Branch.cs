using Kira.Genealogy.Model.Base.Implementations;
using System;
using System.Collections.Generic;

namespace Kira.Genealogy.Model.Domain.Tree
{
    public class Branch : BaseAuditable<Guid>
    {
        public string FirstFamilyName { get; set; }
        public string SecondFamilyName { get; set; }
        public Guid TreeId { get; set; }
        public Guid? ParentBranchId { get; set; }
        public virtual TreeFamily TreeFamily { get; set; }
    }
}
