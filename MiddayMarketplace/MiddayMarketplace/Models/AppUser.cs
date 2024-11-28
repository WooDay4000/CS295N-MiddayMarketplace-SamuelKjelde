namespace MiddayMarketplace.Models
{
    // The class that will be handing App User
    public class AppUser
    {
        // The primary key for the AppUser
        // record in the table.
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public DateTime SignUpDate { get; set; }
    }
}
