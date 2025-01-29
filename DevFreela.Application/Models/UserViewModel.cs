using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, List<UserSkill> userSkill)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = userSkill.Select(u => u.Skill.Description).ToList();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<string> Skills { get; private set; }


        public static UserViewModel FromEntity(User entity)
            => new(
                entity.FullName,
                entity.Email,
                entity.BirthDate,
                entity.Skills
                );
    }
}
