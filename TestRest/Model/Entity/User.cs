using TestTask.Model.Abstract;

namespace TestTask.Model.Entity
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string? lastName { get; set; }

        public string? FatherName {  get; set; }

        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }

        public void Copy(User other)
        {
            FirstName = other.FirstName;
            lastName = other.lastName;
            FatherName = other.FatherName;
            Birthday = other.Birthday;
            PhoneNumber = other.PhoneNumber;
        }
    }
}
