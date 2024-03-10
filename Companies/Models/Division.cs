namespace Companies.Models
{
    public class Division
    {
        public string IdCode { get; set; }
        public Company MotherCompany { get; set; }
        public string Name { get; set; }
        public int DirectorOfDivisionID { get; set; }
    }
}
