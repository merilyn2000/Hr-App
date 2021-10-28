namespace HrApp_WebAPI.Data.Entities.Companies.Employees
{
    public class EmployeeContacts
    {
        public int Id { get; set; }
        public int PersonalPhoneNumber { get; set; }
        public int WorkPhoneNumber { get; set; }
        public int Email { get; set; }
        public string MicrosoftTeams { get; set; }
    }
}