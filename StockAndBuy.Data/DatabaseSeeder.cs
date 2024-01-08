using Microsoft.EntityFrameworkCore;
using StockAndBuy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockAndBuy.Data
{
    public static class DatabaseSeeder
    {
        public static void SeedBundle(this ModelBuilder builder)
        {

            builder.Entity<Bundle>().HasData(
                new Bundle
                {
                    Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6E"),
                    Name = "Bicycle",
                    IsMainBundle = true,
                },
                new Bundle
                {
                    Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6D"),
                    Name = "Wheel",
                    IsMainBundle = false,
                }
                );

            builder.Entity<SparePart>().HasData(
                new SparePart
                {
                    Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6A"),
                    Name = "Frame",
                    InventoryCount = 60
                },
                new SparePart
                {
                    Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6B"),
                    Name = "Tube",
                    InventoryCount = 35
                },
                new SparePart
                {
                    Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6C"),
                    Name = "Seat",
                    InventoryCount = 50
                },
                new SparePart
                {
                    Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6D"),
                    Name = "Pedals",
                    InventoryCount = 60
                }
                );

            builder.Entity<BundleSpareParts>().HasData(
                 new BundleSpareParts
                 {
                     Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E61"),
                     SparePartId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6A"),
                     BundleId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6D"),
                     RequiredUnits = 1
                 },
                  new BundleSpareParts
                  {
                      Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E62"),
                      SparePartId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6B"),
                      BundleId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6D"),
                     RequiredUnits = 1
                  },
                   new BundleSpareParts
                   {
                       Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E63"),
                       SparePartId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6C"),
                       BundleId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6E"),
                       RequiredUnits = 1
                   },
                  new BundleSpareParts
                  {
                      Id = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E64"),
                      SparePartId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6D"),
                      BundleId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6E"),
                      RequiredUnits = 2
                  }
                );

            builder.Entity<BundleParts>().HasData(
                new BundleParts
                { 
                    Id= Guid.Parse("6128354F-2E07-4063-901A-B60C02930E61"),
                    BundleId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6E"),
                    BundlePartId = Guid.Parse("6128354F-2E07-4063-901A-B60C02930E6D"),
                    RequiredUnits = 2
                });

        }
    }

}

