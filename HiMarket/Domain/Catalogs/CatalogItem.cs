using Domain.Attributes;

namespace Domain.Catalogs
{
    [Auditable]
    public class CatalogItem
    {
        public int Id { get; set; }
    }
}
