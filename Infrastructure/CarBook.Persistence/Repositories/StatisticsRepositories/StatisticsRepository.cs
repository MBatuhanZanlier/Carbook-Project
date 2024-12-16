﻿using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarbookContext _context;

        public StatisticsRepository(CarbookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count(); 
            return values;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount); 
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var values = _context.Comments.GroupBy(x => x.BlogId).
                  Select(y => new
                  {
                      BlogID = y.Key,
                      Count = y.Count()
                  }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogId == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }

        public int GetBrandCount()
        {
            var values=_context.Brands.Count(); 
            return values;
        }

        public string GetBrandNameByMaxCar()
        {
            var values = _context.Cars.GroupBy(x => x.BrandId).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandId == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingID).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
           var values=_context.Contacts.Count();
            return values;
        }

        public int GetCarCountByFuelElectric()
        {
            var values = _context.Cars.Where(x => x.Fuel == "Elektirik" ).Count();
            return values;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var values=_context.Cars.Where(x=>x.Fuel=="Benzin"|| x.Fuel== "Disel").Count(); 
            return values;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
           var value=_context.Cars.Where(x=>x.Km <= 1000).Count(); 
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()
        { 
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;

        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}