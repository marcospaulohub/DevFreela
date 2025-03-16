using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Models
{
    public class ProjectViewModel(int id, string title, string description, int idClient, int idFreelancer, string clientName, string freelancerName, decimal totalCost, List<ProjectComment> comments)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public int IdClient { get; set; } = idClient;
        public int IdFreelancer { get; set; } = idFreelancer;
        public string ClientName { get; set; } = clientName;
        public string FreelancerName { get; set; } = freelancerName;
        public decimal TotalCost { get; set; } = totalCost;
        public List<string> Comments { get; set; } = comments.Select(c => c.Content).ToList();

        public static ProjectViewModel FromEntity(Project entity)
            => new(
                entity.Id,
                entity.Title,
                entity.Description,
                entity.IdClient,
                entity.IdFreelancer,
                entity.Client.FullName,
                entity.Freelancer.FullName,
                entity.TotalCost,
                entity.Comments);
    }
}
