using DevFreela.Core.Entities;
using DevFreela.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Core
{
    public class UserTests
    {
        [Fact]
        public void UserIsCreatedAndDataAreOk_Success()
        {
            // Arrange 
            var fullname = "Fullname";
            var email = "email@email.com";
            var birthDate = DateTime.Now.AddYears(-18);
            var password = "password";
            var role = "client";

            // Act
            var user = new User(fullname, email, birthDate,password, role);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(fullname, user.FullName);
            Assert.Equal(email, user.Email);
            Assert.Equal(birthDate, user.BirthDate);
            Assert.Equal(password, user.Password);
            Assert.Equal(role, user.Role);
            Assert.True(user.Active);
            Assert.False(user.IsDeleted);

            Assert.True(user.Skills.Count == 0);
            Assert.True(user.OwnedProjects.Count == 0);
            Assert.True(user.FrelanceProjects.Count == 0);
            Assert.True(user.Comments.Count == 0);
        }

        [Fact]
        public void UserIsCreatedAndDeletedOk_Success()
        {
            // Arrange 
            var user = FakeDataHelper.CreateFakeUserClient();

            // Act
            user.SetAsDeleted();

            // Assert
            Assert.NotNull(user);
            Assert.True(user.IsDeleted);
        }

        [Fact]
        public void UserIsCreatedAndAddSkillsDataAreOk_Success()
        {
            // Arrange 
            var user = FakeDataHelper.CreateFakeUserClient();
            var skill = FakeDataHelper.CreateFakeSkill();
            var userSkill = new UserSkill(user.Id, skill.Id);

            // Act
            user.Skills.Add(userSkill);

            // Assert
            Assert.True(user.Skills.Count == 1);
            Assert.True(user.Id == userSkill.IdUser);
            Assert.True(skill.Id == userSkill.IdSkill);
        }

        [Fact]
        public void UserUpdatePasswordOk_Success()
        {
            // Arrange
            var user = FakeDataHelper.CreateFakeUserClient();
            var newPassword = new Random().Next(100000, 999999).ToString();

            // Act
            user.UpdatePassword(newPassword);

            // Assert
            Assert.True(user.Password == newPassword);
        }

    }
}
