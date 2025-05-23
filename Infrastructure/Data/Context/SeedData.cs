using Bogus;
using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Context
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Resturants.Any())
                return;

            var rnd = new Random();

            var test = new Resturant
            {
                Name          = "Aalborg",
                Description   = "Authentic Nordic flavors in the heart of Aalborg.",
                Type          = "Fine Dining",
                Email           = "aalborg@flexybox.com",     
                PostCode   = "9000",
                Open          = true,
                Address       = "Østergade 27",
                City          = "Aalborg",
                Country       = "Denmark",
                TelefonNumber = "+45 11 22 33 44",
                Images = new List<Images>
                {
                    new Images { Uid = Guid.NewGuid(), AltText = "Front view",      FileName = "aalborg1.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Dining area",     FileName = "aalborg2.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Signature dish",  FileName = "aalborg3.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Interior shot",   FileName = "aalborg4.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Bar area",        FileName = "aalborg5.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Chef plating",    FileName = "aalborg6.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Outdoor seating", FileName = "aalborg7.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Evening ambiance",FileName = "aalborg8.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Dessert",         FileName = "aalborg9.jpg", FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Wine selection",  FileName = "aalborg10.jpg",FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Chef portrait",   FileName = "aalborg11.jpg",FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Kitchen view",    FileName = "aalborg12.jpg",FileType = "image/jpeg" },
                    new Images { Uid = Guid.NewGuid(), AltText = "Special event",   FileName = "aalborg13.jpg",FileType = "image/jpeg" },
                },
                Openings = new List<Openings>
                {
                    new Openings
                    {
                        Name       = "Restaurant",
                        Toggled    = false,
                        ResturantId = 0,   
                        Days = Enum.GetValues<Days>().Select(d =>
                            new DaysOpen
                            {
                                Days          = d,
                                StartTimeSlot = (d >= Days.Monday && d <= Days.Sunday)
                                                 ? new TimeOnly(7,0)
                                                 : new TimeOnly(0,0),
                                EndTimeSlot   = (d >= Days.Monday && d <= Days.Sunday)
                                                 ? new TimeOnly(22,0)
                                                 : new TimeOnly(0,0)
                            }).ToList()
                    },
                    // Takeaway hours (Mon-Thu:11-20, Fri-Sun & Holidays closed)
                    new Openings
                    {
                        Name       = "Takeaway",
                        Toggled    = false,
                        ResturantId = 0,
                        Days = Enum.GetValues<Days>().Select(d =>
                            new DaysOpen
                            {
                                Days          = d,
                                StartTimeSlot = (d >= Days.Tuesday && d <= Days.Saturday)
                                                 ? new TimeOnly(11,0)
                                                 : new TimeOnly(0,0),
                                EndTimeSlot   = (d >= Days.Monday && d <= Days.Thursday)
                                                 ? new TimeOnly(20,0)
                                                 : new TimeOnly(0,0)
                            }).ToList()
                    },
                    new Openings
                    {
                        Name       = "Buffet",
                        Toggled    = false,
                        ResturantId = 0,
                        Days = Enum.GetValues<Days>().Select(d =>
                            new DaysOpen
                            {
                                Days          = d,
                                StartTimeSlot = (d >= Days.Tuesday && d <= Days.Saturday)
                                                 ? new TimeOnly(12,0)
                                                 : new TimeOnly(0,0),
                                EndTimeSlot   = (d >= Days.Wednesday && d <= Days.Saturday)
                                                 ? new TimeOnly(23,0)
                                                 : new TimeOnly(0,0)
                            }).ToList()
                    },
                    new Openings
                    {
                        Name       = "Special Events",
                        Toggled    = false,
                        ResturantId = 0,
                        Days = Enum.GetValues<Days>().Select(d =>
                            new DaysOpen
                            {
                                Days          = d,
                                StartTimeSlot = (d >= Days.Monday && d <= Days.Sunday)
                                                 ? new TimeOnly(14,0)
                                                 : new TimeOnly(0,0),
                                EndTimeSlot   = (d >= Days.Friday && d <= Days.Sunday)
                                                 ? new TimeOnly(18,0)
                                                 : new TimeOnly(0,0)
                            }).ToList()
                    }
                }
            };

            context.Resturants.Add(test);
            context.SaveChanges(); 

            var faker = new Faker<Resturant>()
                .RuleFor(r => r.Name,          f => f.Company.CompanyName())
                .RuleFor(r => r.Description,   f => f.Lorem.Sentence(6))
                .RuleFor(r => r.Type,          f => f.PickRandom("Cafe","Bistro","Diner","Fine Dining","Pub","Buffet"))
                .RuleFor(r => r.Email,           f => f.Internet.Email())           
                .RuleFor(r => r.PostCode,   f => f.Address.ZipCode())            
                .RuleFor(r => r.Open,          f => f.Random.Bool(0.75f))
                .RuleFor(r => r.Address,       f => f.Address.StreetAddress())
                .RuleFor(r => r.City,          f => f.Address.City())
                .RuleFor(r => r.Country,       f => "Denmark")
                .RuleFor(r => r.TelefonNumber, f => f.Phone.PhoneNumber("+45 ## ## ## ##"))
                .RuleFor(r => r.Images,        f => null)
                .RuleFor(r => r.Openings,      f => null);

            var randomList = faker.Generate(30);
            context.Resturants.AddRange(randomList);
            context.SaveChanges();

            var openings = new List<Openings>();
            foreach (var r in randomList)
            {
                openings.Add(new Openings
                {
                    Name        = $"{r.Name} Opening",
                    Toggled     = rnd.NextDouble() < 0.8,
                    ResturantId = r.Id
                });
            }
            context.Openings.AddRange(openings);
            context.SaveChanges();

            var days = new List<DaysOpen>();
            foreach (var oh in openings)
            {
                foreach (Days d in Enum.GetValues(typeof(Days)))
                {
                    days.Add(new DaysOpen
                    {
                        OpeningsId    = oh.Id,
                        Days          = d,
                        StartTimeSlot = new TimeOnly(rnd.Next(6, 12), 0),
                        EndTimeSlot   = new TimeOnly(rnd.Next(15, 23), 0)
                    });
                }
            }
            context.Days.AddRange(days);
            context.SaveChanges();

            var images = new List<Images>();
            foreach (var r in randomList)
            {
                int imgCount = rnd.Next(1, 6);
                for (int i = 1; i <= imgCount; i++)
                {
                    images.Add(new Images
                    {
                        Uid = Guid.NewGuid(),
                        AltText = $"{r.Name} photo #{i}",
                        FileName = $"{r.Name.Replace(" ", "")}_{i}.jpg",
                        FileType = "image/jpeg",
                        ResturantId = r.Id
                    });
                }
            }
            context.Images.AddRange(images);
            context.SaveChanges();
        }
    }
}
