
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MinimalJwt.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
