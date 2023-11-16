#nullable disable

namespace MedEquipCentral.DA.Contracts.Shared
{
    public class Location : Entity
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

    }
}
