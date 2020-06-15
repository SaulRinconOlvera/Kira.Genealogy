using Kira.Genealogy.Model.Base.Implementations;
using System;
using System.Collections.Generic;

namespace Kira.Genealogy.Model.Domain.Tree
{
    public class TreeFamily : BaseAuditable<Guid>
    {
        public string FirstFamilyName { get; set; }
        public string SecondFamilyName { get; set; }
        public Guid UserOwnerId { get; set; }
        public virtual IList<Branch> Branches { get; set; }
        public virtual IList<Person> TreePeople { get; set; }
    }
}
