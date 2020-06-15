using Kira.Genealogy.Model.Base.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Kira.Genealogy.Model.Base.Implementations
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
