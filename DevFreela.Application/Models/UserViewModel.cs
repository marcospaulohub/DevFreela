using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Models
{
    public class UserViewModel(string fullName, string email, DateTime birthDate, List<UserSkill> userSkill)
    {
        public string FullName { get; private set; } = fullName;
        public string Email { get; private set; } = email;
        public DateTime BirthDate { get; private set; } = birthDate;
        public List<string> Skills { get; private set; } = userSkill.Select(u => u.Skill.Description).ToList();


        public static UserViewModel FromEntity(User entity)
            => new(
                entity.FullName,
                entity.Email,
                entity.BirthDate,
                entity.Skills
                );
    }
}
