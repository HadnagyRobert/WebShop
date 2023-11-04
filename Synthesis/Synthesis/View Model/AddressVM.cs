using System.ComponentModel.DataAnnotations;

namespace WebApp.View_Model
{
    public class AddressVM
    {
        private string country;
        private string city;
        private string postalCode;
        private string street;
        private int number;

        public AddressVM()
        {

        }

        [Required]
        public string Country { get => country; set => country = value; }
        [Required]
        public string City { get => city; set => city = value; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get => postalCode; set => postalCode = value; }
        [Required]
        public string Street { get => street; set => street = value; }
        [Required]
        public int Number { get => number; set => number = value; }
    }
}
