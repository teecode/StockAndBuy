using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAndBuy.Service.Interfaces
{
    public interface IBundleService
    {
        Task<int> MaximumNumberOfFinishedBundle(Guid bundleId);
    }
}
