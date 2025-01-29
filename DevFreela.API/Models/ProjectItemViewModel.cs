﻿using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string title, string clientName, string freelancerName, decimal totalCost)
        {
            Id = id;
            Title = title;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ClientName { get; set; }
        public string FreelancerName { get; set; }
        public decimal TotalCost { get; set; }


        public static ProjectItemViewModel FromEntity(Project entity)
            => new(
                entity.Id,
                entity.Title,
                entity.Client.FullName,
                entity.Freelancer.FullName,
                entity.TotalCost);
    }
}
