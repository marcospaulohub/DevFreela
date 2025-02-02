using DevFreela.Core.Entities;
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

            // Act
            var user = new User(fullname, email, birthDate);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(fullname, user.FullName);
            Assert.Equal(email, user.Email);
            Assert.Equal(birthDate, user.BirthDate);
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
            var fullname = "Fullname";
            var email = "email@email.com";
            var birthDate = DateTime.Now.AddYears(-18);

            var user = new User(fullname, email, birthDate);

            // Act
            user.SetAsDeleted();

            // Assert
            Assert.NotNull(user);
            Assert.True(user.IsDeleted);
        }
        
    }
}
