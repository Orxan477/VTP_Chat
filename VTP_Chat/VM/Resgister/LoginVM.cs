using System.ComponentModel.DataAnnotations;

namespace VTP_Chat.VM.Resgister
{
    public class LoginVM
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
