using System.ComponentModel.DataAnnotations;

namespace WebApp.View_Model
{
    public class UserSignupVM
    {
        string username;
        string fristName;
        string lastName;
        string email;
        string password;
        string confirmPassword;

        public UserSignupVM()
        {

        }

        [Required]
        [MinLength(6, ErrorMessage = "The username should be at least 6 characters")]
        public string Username { get => username; set => username = value; }

        [Required]
        public string FirstName { get => fristName; set => fristName = value; }

        [Required]
        public string LastName { get => lastName; set => lastName = value; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get => email; set => email = value; }

        [Required]
        [DataType(DataType.Password), MinLength(4, ErrorMessage = "The password should be at least 6 characters")]
        public string Password { get => password; set => password = value; }

        [Required]
        [Compare("Password", ErrorMessage = "Both of the passwords should match")]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
    }
}
