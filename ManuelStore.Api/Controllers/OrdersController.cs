using System.Linq.Expressions;
using ManuelStore.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManuelStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpPost("ProcessOrders")]
        public IActionResult ProcessOrders([FromBody] List<Order> orders)
        {
            var response = new List<OrderResponse>();

            foreach (var order in orders)
            {
                var boxResponses = new List<BoxResponse>();

                foreach (var product in order.Products)
                {
                    var fittingBox = AvailableBoxes.Boxes.FirstOrDefault(box => ProductFitsBox(product, box));

                    if (fittingBox == null)
                    {
                        //Product does not fi in  any box
                        boxResponses.Add(new BoxResponse
                        {
                            BoxId = null,
                            Products = new List<string> { product.ProductId },
                            Note = "Product does not fit in any available box."
                        });
                    }
                    else
                    {
                        //Verifies if this box already exists in the list
                        var existingBoxResponse = boxResponses.FirstOrDefault(br => br.BoxId == fittingBox.BoxId);

                        if (existingBoxResponse != null)
                        {
                            existingBoxResponse.Products.Add(product.ProductId);
                        }
                        else
                        {
                            boxResponses.Add(new BoxResponse
                            {
                                BoxId = fittingBox.BoxId,
                                Products = new List<string> { product.ProductId },
                                Note = null
                            });
                        }
                    }
                }

                response.Add(new OrderResponse
                {
                    OrderId = order.OrderId,
                    Boxes = boxResponses
                });
            }

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


        private bool ProductFitsBox(Product product, Box box)
        {
            return product.Dimensions.Height <= box.Height &&
                   product.Dimensions.Width <= box.Width &&
                   product.Dimensions.Length <= box.Length;
        }

    }
}
