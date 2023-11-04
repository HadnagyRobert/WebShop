using System.ComponentModel.DataAnnotations;

namespace WebApp.View_Model
{
    public class UserLoginVM
    {
        string username;
        string password;

        public UserLoginVM()
        {

        }

        [Required]
        [MinLength(3, ErrorMessage = "The username has to be at least 3 characters")]
        public string Username { get => username; set => username = value; }

        [Required]
        [DataType(DataType.Password), MinLength(3, ErrorMessage = "The password has to be at least 3 characters")]
        public string Password { get => password; set => password = value; }
    }
}
