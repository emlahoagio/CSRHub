namespace Entities.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}