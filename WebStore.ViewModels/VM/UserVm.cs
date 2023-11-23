namespace WebStore.ViewModels.VM
{
    public class UserVm
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }

}
