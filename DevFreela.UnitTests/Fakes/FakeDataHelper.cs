using Bogus;
using DevFreela.Application.Commands.Projects.InsertComment;
using DevFreela.Application.Commands.Projects.InsertProject;
using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Fakes
{
    public class FakeDataHelper
    {
        public static InsertProjectCommand CreateFakeInsertProjectCommand() => _insertProjectCommandFaker.Generate();
        #region _insertProjectCommandFaker
        private static readonly Faker<InsertProjectCommand> _insertProjectCommandFaker = new Faker<InsertProjectCommand>()
            .RuleFor(c => c.Title, f => f.Commerce.ProductName())
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.IdClient, f => f.Random.Int(1, 100))
            .RuleFor(c => c.IdFreelancer, f => f.Random.Int(1, 100))
            .RuleFor(c => c.TotalCost, f => f.Random.Decimal(1000, 10000));
        #endregion

        public static InsertCommentCommand CreateFakeInsertCommentCommand() => _InsertCommentCommandFaker.Generate();
        #region _InsertCommentCommandFaker
        private static readonly Faker<InsertCommentCommand> _InsertCommentCommandFaker = new Faker<InsertCommentCommand>()
            .RuleFor(c => c.Content, f => f.Commerce.ProductName())
            .RuleFor(c => c.IdProject, f => f.Random.Int(2, 100))
            .RuleFor(c => c.IdUser, f => f.Random.Int(3, 100));
        #endregion

        public static User CreateFakeUserClient() => _userFakerClient.Generate();
        #region _userFakerClient
        private static readonly Faker<User> _userFakerClient = new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Int(1, 1000))
            .RuleFor(u => u.FullName, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.BirthDate, DateTime.Now.AddYears(-20))
            .RuleFor(u => u.Password, f => f.Internet.Password(10))
            .RuleFor(u => u.Role, "client");
        #endregion

        public static User CreateFakeUserFreelancer() => _userFakerFreelancer.Generate();
        #region _userFakerFreelancer
        private static readonly Faker<User> _userFakerFreelancer = new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Int(1, 1000))
            .RuleFor(u => u.FullName, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.BirthDate, DateTime.Now.AddYears(-20))
            .RuleFor(u => u.Password, f => f.Internet.Password(10))
            .RuleFor(u => u.Role, "freelancer");
        #endregion

        public static Skill CreateFakeSkill() => _skillFaker.Generate();
        #region _skillFaker
        private static readonly Faker<Skill> _skillFaker = new Faker<Skill>()
            .RuleFor(s => s.Id, f => f.Random.Int(1, 1000))
            .RuleFor(s => s.Description, f => f.Commerce.ProductName());
        #endregion

        public static Project CreateFakeProject() => _projectFaker.Generate();
        public static List<Project> CreateFakeProjectList() => _projectFaker.Generate(5);
        #region _projectFaker
        private static readonly Faker<Project> _projectFaker = new Faker<Project>()
            .RuleFor(p => p.Id, f => f.Random.Int(1, 1000))
            .RuleFor(p => p.Title, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.IdClient, f => f.Random.Int(1, 100))
            .RuleFor(p => p.IdFreelancer, f => f.Random.Int(1, 100))
            .RuleFor(p => p.TotalCost, f => f.Random.Decimal(1000, 10000));
        #endregion

    }
}
