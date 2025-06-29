using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            // TODO: Hier moet ik nog wat namen verzinnen die betrekking hebben op de matrix.
            // - Denk aan de m3 boutjes, moertjes en ringetjes.
            // - Denk aan namen van schepen
            // - Denk aan namen van vliegtuigen            
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", Address = "123 Elm St" , Active=true},
                new Customer { Name = "Morpheus", Address = "456 Oak St", Active = true },
                new Customer { Name = "Trinity", Address = "789 Pine St", Active = true }
            };
            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[1], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[2], OrderDate = DateTime.Parse("2021-03-01")}
            };  
            context.Orders.AddRange(orders);

            var products = new Product[]
            {
                new Product { Name = "Nebuchadnezzar", Description = "Het schip waarop Neo voor het eerst de echte wereld leert kennen", Price = 10000.00m, ImageUrl = "https://cdn.bsky.app/img/feed_thumbnail/plain/did:plc:so362smrcoypah6gusrtkqvz/bafkreico4i7tipgw7ccv6brnfdug45tql45wdeaq3liopupfdjefc6k6um@jpeg" },
                new Product { Name = "Jack-in Chair", Description = "Stoel met een rugsteun en metalen armen waarin mensen zitten om ingeplugd te worden in de Matrix via een kabel in de nekpoort", Price = 500.50m, ImageUrl = "https://d2t1xqejof9utc.cloudfront.net/screenshots/pics/2d5b01cc30cc15b24e134c1a519924e4/large.png" },
                new Product { Name = "EMP (Electro-Magnetic Pulse) Device", Description = "Wapentuig op de schepen van Zion", Price = 129.99m, ImageUrl = "https://m.media-amazon.com/images/I/6154WVOBExL.jpg" }
            };
            context.Products.AddRange(products);

            var parts = new Part[]
            {
                new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen", Price = 3.00m, ImageUrl = "https://cdn.webshopapp.com/shops/319232/files/419622060/500x500x1/dts-products-recht-gefreesd-tandwiel-moduul-6-z-18.jpg" },
                new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules", Price = 0.25m, ImageUrl = "https://ijzershop.nl/556-medium_default/verzinkte-zeskantbout-m5-x-40.jpg" },
                new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen", Price = 420.69m, ImageUrl = "https://hytres.com/wp-content/uploads/Cilinders-dubbelwerkend-hytres.jpg" },
                new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen.", Price = 69.00m, ImageUrl = "https://www.torros.nl/images/photolib/400x300/80486/80486.jpg" }
            };
            context.Parts.AddRange(parts);

            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}
