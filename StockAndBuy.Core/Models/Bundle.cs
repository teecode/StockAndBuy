namespace StockAndBuy.Core.Models
{
    public class Bundle : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BundleParts> BundleParts { get; set; } = new List<BundleParts>();
        public ICollection<BundleSpareParts> SpareParts { get; set; } = new List<BundleSpareParts>();

        public bool HasChildren
        {
            get
            {
                return BundleParts.Any();
            }
        }

        public bool IsMainBundle { get; set; }
    }

   
}