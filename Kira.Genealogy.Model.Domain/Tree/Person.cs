using Kira.Genealogy.Model.Base.Implementations;
using Kira.Genealogy.Model.Domain.Tree.Enumerations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kira.Genealogy.Model.Domain.Tree
{
    public class Person : BaseAuditable<Guid>
    {
        public string Name { get; set; }
        public string FirstFamilyName { get; set; }
        public string SecondFamilyName { get; set; }
        public DateTime? BornDate { get; set; }

        [NotMapped]
        public long? BornDateTimeSpan { 
            get {
                if (BornDate.HasValue)
                    return BornDate.Value.Ticks;
                else return null; 
            } 
        }

        public bool? IsBornDateExactly { get; set; }
        public bool IsAlive { get; set; }
        public DateTime? DeathDate { get; set; }

        [NotMapped]
        public long? DeathDateTimeSpan
        {
            get
            {
                if (DeathDate.HasValue)
                    return DeathDate.Value.Ticks;
                else return null;
            }
        }

        public bool? IsDeathDateExactly { get; set; }
        public GenderEnum Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool SharePhone { get; set; }
        public string MailAddress { get; set; }
        public bool ShareMailAddress { get; set; }
        public string BornCity { get; set; }
        public bool IsBornCityExactly { get; set; }
        public Guid TreeId { get; set; }
        public string PersonalImage { get; set; }

        [NotMapped]
        public bool HasPhoto { 
            get 
            {
                return !string.IsNullOrWhiteSpace(PersonalImage);
            } 
        }


        public virtual TreeFamily TreeFamily { get; set; }
        //public virtual IList<PersonBranch> Branches { get; set; }
    }
}
