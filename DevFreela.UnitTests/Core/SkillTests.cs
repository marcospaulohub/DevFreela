using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Core
{
    public class SkillTests
    {
        [Fact]
        public void SkillIsCreatedAndDataAreOk_Success()
        {
            // Arrange
            var description = "Description";

            // Act
            var skill = new Skill(description);

            // Assert
            Assert.Equal(description, skill.Description);
            Assert.True(skill.UserSkills.Count == 0);
        }
    }
}
