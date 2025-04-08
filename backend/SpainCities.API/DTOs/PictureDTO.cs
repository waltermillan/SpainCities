namespace API.DTOs
{
    public class PictureDTO
    {
        public int Id { get; set; }                 // Table: Picture | Field: Id
        public int IdRegion { get; set; }           // Table: Region | Field: Id

        public string ImageBase64 { get; set; }     // Table: Picture | Field: ImageBase64
        public string RegionName { get; set; }      // Table: Region | Field: Name

        public double Population { get; set; } 
        public string Capital { get; set; }
        public string Surface { get; set; }
    }
}
