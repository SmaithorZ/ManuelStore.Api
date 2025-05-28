namespace ManuelStore.Api.Models
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public List<BoxResponse> Boxes { get; set; }
    }
}
