namespace ManuelStore.Api.Models
{
    public class Box
    {
        public string BoxId { get; set; }
        public int Height { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }

        public bool FitsProduct(Product product)
        {
            return product.Dimensions.Height <= Height &&
                   product.Dimensions.Width <= Width &&
                   product.Dimensions.Length <= Length;
        }


    }
}
