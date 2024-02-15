    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Entities
    {
        public class Car : Base
        {
            public string Color { get; set; }
            public decimal Price { get; set; }
            public double Kilometers { get; set; }
            public string FuelType { get; set; }
            public string TransmissionType { get; set; }
            public int EnginePower { get; set; }
            public int EngineVolume { get; set; }
            public int Year { get; set; }
            public int CategoryId { get; set; }
            public Category Category { get; set; } 
            public int BrandId { get; set; }
            public Brand Brand { get; set; }
            public int ModelId { get; set; }
            public Model Model { get; set; }
        }
    }
