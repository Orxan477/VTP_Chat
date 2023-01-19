namespace VTP_Chat.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public DateTime Date { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
    }
}
