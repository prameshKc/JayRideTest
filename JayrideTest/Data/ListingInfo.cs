namespace JayrideTest.Data
{

    public class ListingInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public List<Listing> Listings { get; set; }
    }

    public class Listing
    {
        public string Name { get; set; }
        public float PricePerPassenger { get; set; }
        public Vehicletype VehicleType { get; set; }
        public float TotalPrice { get; set; }
    }

    public class Vehicletype
    {
        public string Name { get; set; }
        public int MaxPassengers { get; set; }
    }

}
