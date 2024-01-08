using StockAndBuy.Core.Models;

namespace StockAndBuy.Data.Repositories
{
    public interface ISparePartRepository
    {
        Task<List<SparePart>> GetSpareParts(Guid[] sparePartsIds);
    }
}
