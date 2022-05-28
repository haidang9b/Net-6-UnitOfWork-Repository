namespace BE.Models.Entities
{
    public class User : BaseEntity
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string numberPhone { get; set; }
    }
}
