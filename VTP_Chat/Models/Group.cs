namespace VTP_Chat.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public IList<Chat> Chats { get; set; }
        public IList<AppUser> Users { get; set; }
    }
}
