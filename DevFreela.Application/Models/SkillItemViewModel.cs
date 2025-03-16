using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class SkillItemViewModel(string description)
    {
        public string Description { get; set; } = description;

        public static SkillItemViewModel FromEntity(Skill entity)
            => new(entity.Description);
    }
}
