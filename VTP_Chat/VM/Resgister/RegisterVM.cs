using System.ComponentModel.DataAnnotations;

namespace VTP_Chat.VM.Resgister
{
    public class RegisterVM
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
