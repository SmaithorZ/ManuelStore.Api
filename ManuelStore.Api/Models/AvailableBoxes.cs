namespace ManuelStore.Api.Models
{
    public class AvailableBoxes
    {

        public static List<Box> Boxes = new List<Box>
        {
            new Box{ BoxId = "Box1", Height = 30, Width = 40, Length = 80 },
            new Box {BoxId = "Box2", Height = 80, Width = 50, Length = 40 },
            new Box {BoxId = "Box3", Height = 50, Width = 80, Length = 60 },

        };

    }
}
