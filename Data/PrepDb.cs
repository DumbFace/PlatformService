using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("---> Seeding data");

                context.Platforms.AddRange(
                    new Platform { Id = 1, Name = "DotNet", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Id = 2, Name = "SQL", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Id = 3, Name = "Kubernetes", Publisher = "Cloud Computing Native Foundation", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("---> We already have data");
            }
        }

    }
}