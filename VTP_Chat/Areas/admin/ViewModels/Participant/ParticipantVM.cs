namespace VTP_Chat.Areas.admin.ViewModels.Participant
{
    public class ParticipantVM
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsActivated { get; set; }
    }
}
