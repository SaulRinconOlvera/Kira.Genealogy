using Kira.Genealogy.Model.Base.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Kira.Genealogy.Model.Base.Implementations
{
    public class BaseCatalog<T> : BaseAuditable<T>, IBaseCatalog<T>
    {
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }

        [StringLength(20)]
        public virtual string ShortName { get; set; }
    }
}
