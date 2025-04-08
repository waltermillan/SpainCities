namespace API.DTOs
{
    public class RegionDTO
    {
        public int IdCity { get; set; }
        public string CityName { get; set; }

        public int IdProvince { get; set; }
        public string ProvinceName { get; set; }

        public int IdRegion { get; set; }
        public string RegionName { get; set; }
    }
}
