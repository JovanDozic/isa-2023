namespace MedEquipCentral.DA.Contracts.Shared
{
    public class PagedResult<TEntity>  where TEntity : class
    {
        public List<TEntity> Result { get; set; }
        public int Count { get; set; }
    }
}
