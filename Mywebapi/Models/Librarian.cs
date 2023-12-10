using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mywebapi.Models
{
    public class Librarian
    {
        [Key]
        public int Lid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Role { get;set; }
    }
}
