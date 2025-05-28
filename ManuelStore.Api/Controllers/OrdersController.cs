using ManuelStore.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManuelStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpPost]
        public IActionResult ProcessOrders([FromBody] List<Order> orders)
        {
            var response = orders.Select(o => new OrderResponse
            {
               OrderId = o.OrderId,
               Boxes = PackProductsInBoxes(o.Products)

            }).ToList();

            return Ok(new { orders = response });
        }
        

        private List<BoxResponse> PackProductsInBoxes(List<Product> products)
        {
            var packedBoxes = new List<BoxResponse>();

            foreach(var product in products)
            {
                //Tries finding a box that the product can fit in
                var box = AvailableBoxes.Boxes.FirstOrDefault(b => b.FitsProduct(product));
                
                if (box == null)
                {
                    //Product does not fit in any of the boxes - creates a box with a note
                    packedBoxes.Add(new BoxResponse
                    {
                        BoxId = null,
                        Products = new List<string> {product.ProductId },
                        Note = "This product does not fit in any of the available boxes."
                    });
                }
                else
                {
                    packedBoxes.Add(new BoxResponse
                    {
                        BoxId = box.BoxId,
                        Products = new List<string> { product.ProductId },
                        Note = null
                    });
                }
            }

            return packedBoxes; 
        } 

    }
}
