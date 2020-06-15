namespace Kira.Genealogy.Model.Base.Contracts
{
    public interface IBaseCatalog<T> : IBaseEntity<T>, IBaseAuditable 
    {
        string Name { get; }
        string ShortName { get; }
    }
}
