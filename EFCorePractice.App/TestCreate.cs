using EFCorePractice.App;
using EFCorePractice.Data;
using EFCorePractice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCorePractice
{
    public class TestCreate
    {
        public static void Run()
        {
            AppDbContextFactory factory = new AppDbContextFactory();
            using (var db = factory.CreateDbContext(null))
            {
                // Create
                var newhero = new Hero()
                {
                    Name = "GuanYu",
                    DateAchieved = DateTime.Now
                };

                newhero.Mount = new Mount() { Description = "ChiTu" };
                
                db.Heros.Add(newhero);
                db.SaveChanges();

                // Query
                var lastHero = db.Heros
                    .OrderByDescending(b => b.DateAchieved)
                    .First();

                // Update
                lastHero.Equipment.Add(
                    new Equipment
                    {
                        Name = "QingLong",
                    });
                db.SaveChanges();

                // Delete
                //db.Remove(hero);
                db.SaveChanges();
            }
        }
    }
}
