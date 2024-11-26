using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Car
    { 
        public int CarId { get; set; } 
        public int BrandId { get; set; }     
        public Brand Brand { get; set; } 
        public string Model { get; set; }    
        public string CoverImage { get; set; }  
        public int Km {  get; set; }    
        public int Transmission {  get; set; }    
        public byte Seat { get; set; } 
        public byte Luggage { get; set; }   
        public string Fuel { get; set; } 
        public List<CarFeature> CarFeatures { get; set; } 
        public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }

    }
}
