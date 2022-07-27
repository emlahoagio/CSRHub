namespace Entities.Models
{
    public class Sponsor
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Avt { get; set; }
        public string Bio { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}

