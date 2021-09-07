using Example.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Services.Order.Domain.OrderAggregate
{
    public class OrderItem:Entity
    {
        public string ProductId { get;private set; }
        public string ProductName { get;private set; }
        public string PicturueUrl { get; private set; }
        public Decimal Price { get;private set; }

        public OrderItem()
        {

        }
        public OrderItem(string productId, string productName, string picturueUrl, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            PicturueUrl = picturueUrl;
            Price = price;
        }

        public void UpdateOrderItem(string productName,string pictureUrl,decimal price)
        {
            ProductName = productName;
            PicturueUrl = pictureUrl;
            Price = price;
        }
    }
}
