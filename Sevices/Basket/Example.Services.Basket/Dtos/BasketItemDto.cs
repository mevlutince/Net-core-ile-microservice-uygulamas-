using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quntity { get; set; } //default olarak 1 gelecek 
        public string CourseId { get; set; } // MongoDbde string olarak oluşturuldu
        public string CourseName { get; set; }
        public decimal Price { get; set; }
    }
}
