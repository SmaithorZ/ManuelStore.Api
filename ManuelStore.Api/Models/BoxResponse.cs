namespace ManuelStore.Api.Models
{

    public class OrderResponse
    {
        public int OrderId { get; set; }
        public List<BoxResponse> Boxes { get; set; }
    }
    public class BoxResponse
    {
        public string? BoxId { get; set; }
        public List<string>Products { get; set; }
        public string? Note { get; set; }


    }
}
