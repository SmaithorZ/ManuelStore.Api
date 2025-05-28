# ManuelStore.Api

This is a RESTful API built with ASP.NET Core that simulates a packing system. The system receives orders with products and returns the allocation of these products into predefined boxes based on their dimensions.

# Features
- Accepts multiple orders containing a list of products and their dimensions.

- Allocates products into one of the available box sizes if possible.

- Returns a response showing which products go into which boxes.

- If a product does not fit in any available box, it is returned with a note.
---
# Sample Input
```json
[
  {
    "orderId": 1,
    "products": [
      {
        "productId": "ps5",
        "dimensions": { "height": 40, "width": 10, "length": 25 }
      },
      {
        "productId": "cadeira gamer",
        "dimensions": { "height": 100, "width": 70, "length": 70 }
      },
      {
        "productId": "volante",
        "dimensions": { "height": 20, "width": 20, "length": 20 }
      }
    ]
  }
]
```
# Sample Output
```json
{
  "orders": [
    {
      "orderId": 1,
      "boxes": [
        {
          "boxId": "Box 2",
          "products": ["ps5"],
          "note": null
        },
        {
          "boxId": null,
          "products": ["cadeira gamer"],
          "note": "Product does not fit in any available box."
        },
        {
          "boxId": "Box 1",
          "products": ["volante"],
          "note": null
        }
      ]
    }
  ]
}

```
---
# Tech used
- ASP.NET Core Web API
- C#
- Swagger (for testing the API)
---
# The project was developed for learning purposes.
