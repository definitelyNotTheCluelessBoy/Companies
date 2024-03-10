namespace Companies.Models
{
    public class Department
    {
        public string IdCode { get; set; }
        public Project MotherProject { get; set; }
        public string Name { get; set; }
        public int DirectorOfDepartmentID { get; set; }
    }
}
