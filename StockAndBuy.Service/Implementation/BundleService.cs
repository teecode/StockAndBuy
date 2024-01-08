using StockAndBuy.Data.Repositories;
using StockAndBuy.Service.Interfaces;

namespace StockAndBuy.Service.Implementation
{
    public class BundleService : IBundleService
    {
        private readonly IBundleRepository _bundleRepository;
        private readonly ISparePartRepository _sparePartRepository;

        public BundleService(IBundleRepository bundleRepository, ISparePartRepository sparePartRepository)
        {
            _bundleRepository = bundleRepository;
            _sparePartRepository = sparePartRepository;
        }

        async Task<Dictionary<Guid, int>> GetRequiredSparePartsToBuildTheMainBundle(Guid bundleId, Dictionary<Guid, int> spareparts, int requiredUnits = 1)
        {
            spareparts = spareparts.Any() ? spareparts : new Dictionary<Guid, int>();
            var bundle = await _bundleRepository.GetBundle(bundleId);

            foreach (var parts in bundle.SpareParts)
            {
                if (spareparts.ContainsKey(parts.SparePartId))
                    spareparts[parts.SparePartId] += (parts.RequiredUnits * requiredUnits);
                spareparts.Add(parts.SparePartId, (parts.RequiredUnits * requiredUnits));
            }

            if (!bundle.HasChildren) return spareparts;

            foreach (var bundleParts in bundle.BundleParts)
            {
                await GetRequiredSparePartsToBuildTheMainBundle(bundleParts.BundlePartId, spareparts, bundleParts.RequiredUnits);
            }

            return spareparts;
        }

        public async Task<int> MaximumNumberOfFinishedBundle(Guid bundleId)
        {
            var partsRequiredToBuild = await GetRequiredSparePartsToBuildTheMainBundle(bundleId, new Dictionary<Guid, int>());

            var spareparts = await _sparePartRepository.GetSpareParts(partsRequiredToBuild.Keys.ToArray());

            int leastAvailableSparePart = spareparts.Max(x=>x.InventoryCount);

            foreach (var part in spareparts)
            {
                var buildableUnits = Math.Floor(decimal.Divide(part.InventoryCount, partsRequiredToBuild[part.Id]));
                if (buildableUnits < leastAvailableSparePart)
                    leastAvailableSparePart = Convert.ToInt32(Math.Floor(decimal.Divide(part.InventoryCount, partsRequiredToBuild[part.Id])));
            }

            return leastAvailableSparePart;
        }
    }
}
