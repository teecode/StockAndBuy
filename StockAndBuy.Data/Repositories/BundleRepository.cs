using Microsoft.EntityFrameworkCore;
using StockAndBuy.Core.Models;

namespace StockAndBuy.Data.Repositories
{
    public class BundleRepository: IBundleRepository
    {
        private readonly StockAndBuyDbContext _dbContext;

        public BundleRepository(StockAndBuyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Bundle> GetBundle(Guid bundleId) => await _dbContext.Bundles
                .Include(x => x.BundleParts)
                .Include(x => x.SpareParts)
                .SingleOrDefaultAsync(x => x.Id == bundleId);
    }
}
