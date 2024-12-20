﻿using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    { 
        private readonly CarbookContext _context;

        public CarFeatureRepository(CarbookContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values=_context.CarFeatures.Where(x=>x.CarFeatureId==id).FirstOrDefault();
            values.Available = false; 
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
           _context.CarFeatures.Add(carFeature);
            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeaturesByCarId(int id)
        { 
            var values= _context.CarFeatures.Include(y=>y.Feature).Where(x=>x.CarId == id).ToList(); 
            return values;
        }
    }
}