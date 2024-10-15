using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Products.Queries.Results
{
    public class GetProductPaginatedListResponse
    {
        public int ProductID { get; set; }
        public int CategoryId { get; set; }
        public string Item_Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int? Solditems { get; set; }
        public int? Quantity { get; set; }
        public List<string> ImageUrls { get; set; }  // Added this property
        public GetProductPaginatedListResponse(int productId, int categoryId, string itemName,
       int price, string? description, int? solditems, int? quantity, List<string> imageUrls)
        {
            ProductID = productId;
            CategoryId = categoryId;
            Item_Name = itemName;  // Ensure that Item_Name is being set correctly
            Price = price;
            Description = description;
            Solditems = solditems;
            Quantity = quantity;
            ImageUrls = imageUrls;
        }

    }
}
