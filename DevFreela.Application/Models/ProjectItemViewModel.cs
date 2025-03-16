using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class ProjectItemViewModel(int id, string title, string clientName, string freelancerName, decimal totalCost)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string ClientName { get; set; } = clientName;
        public string FreelancerName { get; set; } = freelancerName;
        public decimal TotalCost { get; set; } = totalCost;


        public static ProjectItemViewModel FromEntity(Project entity)
            => new(
                entity.Id,
                entity.Title,
                entity.Client.FullName,
                entity.Freelancer.FullName,
                entity.TotalCost);
    }
}
