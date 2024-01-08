using StockAndBuy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBuy.Data.Repositories
{
    public interface IBundleRepository
    {
        Task<Bundle> GetBundle(Guid bundleId);
    }
}
