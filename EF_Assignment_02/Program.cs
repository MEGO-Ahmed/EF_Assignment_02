namespace EF_Assignment_02
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var context = new EventHubDbContext();

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var organizer = new Organizer
            {
                Name = "Ahmed Tarek",
                CompanyName = "Cairo Tech Hub",
                IsVerified = true,
                Profile = new OrganizerProfile
                {
                    Biography = "Tech community organizer focusing on .NET and Cloud events.",
                    WebsiteUrl = "https://cairotechhub.example.com",
                    LogoUrl = "https://cairotechhub.example.com/logo.png"
                },
                Events = new List<Event>
            {
                new Event
                {
                    Title = "EF Core Deep Dive Workshop",
                    Description = "Comprehensive hands-on training on Entity Framework Core.",
                    StartDate = new DateTime(2026, 12, 5, 10, 0, 0),
                    EndDate = new DateTime(2026, 12, 5, 16, 0, 0),
                    MaxAttendees = 150
                }
            }
            };

            var attendee = new Attendee
            {
                FullName = "Salma Khaled",
                Email = "salma.khaled@example.com",
                Street = "25 Tahrir St",
                City = "Cairo",
                Country = "Egypt",
                PostalCode = "11511",
                Badge = new Badge
                {
                    BadgeNumber = "BADGE-2026-001",
                    IssuedAt = DateTime.UtcNow,
                    Tier = BadgeTier.VIP
                }
            };

            context.Organizers.Add(organizer);
            context.Attendees.Add(attendee);
            await context.SaveChangesAsync();

            Console.WriteLine("Database created and data saved successfully!");
            Console.WriteLine($"Attendee Full Address: {attendee.FullAddress}");
        }
    }
}
