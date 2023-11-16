namespace MedEquipCentral.DA.Contracts.Shared
{
    public class PagedResult<TEntity>  where TEntity : class
    {
        public List<TEntity> result { get; set; }
        public int count { get; set; }
    }
}
