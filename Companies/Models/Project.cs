namespace Companies.Models
{
    public class Project
    {
        public string IdCode { get; set; }
        public Division MotherDivision { get; set; }
        public string Name { get; set; }
        public int DirectorOfProjectID { get; set; }
    }
}
