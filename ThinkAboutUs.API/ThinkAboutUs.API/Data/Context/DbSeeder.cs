using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkAboutUs.API.Data.Entities;
using ThinkAboutUs.API.Helpers;

namespace ThinkAboutUs.API.Data.Context
{
    public static class DbSeeder
    {
        public static void Seed(ThinkAboutUsContext db)
        {
            db.Database.EnsureCreated();

            if (!db.Sizes.Any())
            {
                //Ja seed-аме (пополнуваме) Sizes табелата.

                var mini = new SizeEntity() { Name = "Mini"};
                var small = new SizeEntity() { Name = "Small"};
                var medium = new SizeEntity() { Name = "Medium"};
                var large = new SizeEntity() { Name = "Large"};
                var extraLarge = new SizeEntity() { Name = "Extra Large"};

                db.Sizes.Add(mini);
                db.Sizes.Add(small);
                db.Sizes.Add(medium);
                db.Sizes.Add(large);
                db.Sizes.Add(extraLarge);

                db.SaveChanges();


                if (!db.Dogs.Any())
                {
                    var sizes = db.Sizes.ToList();

                    var dog0 = new DogEntity()
                    {
                        Status = Status.Lost,
                        Code = "000001",
                        Gender = Gender.Male,
                        Location = "Skopje, Karpos 4",
                        Breed = "Golden Retriever",
                        Description = "Very friendly and approachable, like to retrieve tennis balls.",
                        ImageUrl = "https://proxy.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.hdwallpaper.nu%2Fwp-content%2Fuploads%2F2015%2F03%2FGolden-Retriever-Playing-Among-Flowers.jpg&f=1",
                        Size = sizes[3]
                    };

                    var dog1 = new DogEntity()
                    {
                        Status = Status.Homeless,
                        Code = "500002",
                        Gender = Gender.Female,
                        Location = "Veles",
                        Breed = "Unknown mix",
                        Description = "Very cute pup, is scared at first but after a few minutes becomes very friendly, likes to chew on toys.",
                        ImageUrl = "https://qtxasset.com/styles/breakpoint_sm_default_480px_w/s3/Luxury%20Travel%20Advisor-1509741245/saddogMartazmataiStockGettyImagesPlusGettyImages.jpg?F7vWla0TyZwwHnSx8PIMZrCbwTNHuIXZ&itok=Y3B6kv3R",
                        Size = sizes[1],
                    };

                    var dog2 = new DogEntity()
                    {
                        Status = Status.PendingAdoption,
                        Code = "007603",
                        Gender = Gender.Male,
                        Location = "Bitola",
                        Breed = "Stray dog",
                        Description = "Brown mixed dog, likes to pet, cuddle and sleep. Is friendly with other dogs and animals",
                        ImageUrl = "https://proxy.duckduckgo.com/iu/?u=http%3A%2F%2Fst.depositphotos.com%2F2331871%2F4172%2Fi%2F950%2Fdepositphotos_41726543-stock-photo-stray-dog-is-breed-native.jpg&f=1",
                        Size = sizes[2],
                    };

                    var dog3 = new DogEntity()
                    {
                        Status = Status.Adopted,
                        Code = "000642",
                        Gender = Gender.Male,
                        Location = "Skopje, Aerodrom",
                        Breed = "Stray dog",
                        Description = "3 year old white mixed breed looking for a home where it can stay off the cold streets of Skopje.",
                        ImageUrl = "https://e3.365dm.com/17/08/768x432/230483ef152cde4b60c888bb0e87364022d70d15fa922ce3b8d6c7db405681e1_4080632.jpg?20170823085828",
                        Size = sizes[3]
                    };

                    var dog4 = new DogEntity()
                    {
                        Status = Status.Homeless,
                        Code = "1231666",
                        Gender = Gender.Male,
                        Location = "Veles",
                        Breed = "Shepherd mix",
                        Description = "Big shepherd dog with an even bigger heart, wondering the streets looking for friends and food. Loves to play.",
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1JZSLtyJlUV3yEdKxwfKRDhdhUTyMnUB4ZiyUpFVFOrrcNPHb",
                        Size = sizes[4],
                    };

                    var dog5 = new DogEntity()
                    {
                        Status = Status.Found,
                        Code = "1231666",
                        Gender = Gender.Male,
                        Location = "Veles",
                        Breed = "German Shepherd",
                        Description = "Very friendly and approachable, like to retrieve tennis balls.",
                        ImageUrl = "https://www.royalcanin.in/var/royalcanin/storage/images/subsidiaries/in/home/puppy-and-dog/the-dog/dogs-that-serve-man/rescue-dogs/389164-6-eng-GB/rescue-dogs_articleV3.png",
                        Size = sizes[4]
                    };

                    db.Dogs.Add(dog0);
                    db.Dogs.Add(dog1);
                    db.Dogs.Add(dog2);
                    db.Dogs.Add(dog3);
                    db.Dogs.Add(dog4);
                    db.Dogs.Add(dog5);

                    db.SaveChanges();
                }

                if (!db.Reports.Any())
                {
                    var dogs = db.Dogs.ToList();

                    var report0 = new ReportEntity
                    {
                        DateReported = DateTime.Now,
                        ContactNumber = "078-888-999",
                        ContactEmail = "nekoj@nesto.com",
                        DogId = dogs[0].Id,
                    };

                    var report1 = new ReportEntity
                    {
                        DateReported = DateTime.Now,
                        ContactNumber = "078-555-444",
                        ContactEmail = "ivana@thinkaboutus.com",
                        DogId = dogs[1].Id,
                    };

                    var report2 = new ReportEntity
                    {
                        DateReported = DateTime.Now,
                        ContactNumber = "078-222-333",
                        ContactEmail = "irina@thinkaboutus.com",
                        DogId = dogs[2].Id,
                    };

                    var report3 = new ReportEntity
                    {
                        DateReported = DateTime.Now,
                        ContactNumber = "078-222-333",
                        ContactEmail = "irina@thinkaboutus.com",
                        DogId = dogs[4].Id,
                    };

                    db.Reports.Add(report0);
                    db.Reports.Add(report1);
                    db.Reports.Add(report2);

                    db.SaveChanges();
                };
            }
            
        }
    }
}
