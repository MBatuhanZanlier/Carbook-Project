﻿using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    { 
        private readonly CarbookContext _context;

        public CarRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarListWithBrands()
        {
            var values= _context.Cars.Include(x=>x.Brand).ToList();
            return values;
        }
    }
}
