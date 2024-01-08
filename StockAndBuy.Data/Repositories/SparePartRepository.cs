using Microsoft.EntityFrameworkCore;
using StockAndBuy.Core.Models;

namespace StockAndBuy.Data.Repositories
{
    public class SparePartRepository : ISparePartRepository
    {
        private readonly StockAndBuyDbContext _dbContext;

        public SparePartRepository(StockAndBuyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<SparePart>> GetSpareParts(Guid[] sparePartsIds)
        {
            return await _dbContext.SpareParts.AsNoTracking().Where(x=> sparePartsIds.Contains(x.Id)).ToListAsync();  
        }

    }
}
