﻿using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, int idClient, int idFreelancer, string clientName, string freelancerName, decimal totalCost, List<ProjectComment> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;

            Comments = comments.Select(c => c.Content).ToList();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public string ClientName { get; set; }
        public string FreelancerName { get; set; }
        public decimal TotalCost { get; set; }
        public List<string> Comments { get; set; }

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
